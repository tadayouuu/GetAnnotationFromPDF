using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using PdfSharp.Pdf.Annotations;
using PdfSharp.Pdf.IO;
using ClosedXML.Excel;
using System.Runtime.CompilerServices;
using DocumentFormat.OpenXml.Spreadsheet;
using Csv;

namespace GetAnnotationFromPDF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "PDFから注釈を取得（福岡原作チーム専用）";
            this.getFileButton.Text = "...";
            this.loadFileButton.Text = "...";
            this.execButton.Text = "実行";
            this.label1.Text = "PDFファイルパス:";
            this.label2.Text = "V0.01";
            this.label3.Text = "宛先ファイルパス:";
            this.chineseCheckBox.Text = "中国語対応（-1）";
            this.groupBox1.Text = "使用用途:";
            this.radioButton1.Checked = true;
            this.radioButton1.Text = "設計チェック用";
            this.radioButton2.Text = "戻りまとめ用";
			//V0.01 通常版（V0.10）から引き継ぎ、宛先をまとめないバージョンも作成
		}

        private static string GetFilePath(string filter)
        {
            using (var ofd = new OpenFileDialog())
            {                
                ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                ofd.Filter = filter;
                ofd.FilterIndex = 2;
                ofd.Title = "開くファイルを選択してください";
                ofd.RestoreDirectory = true;
                ofd.CheckFileExists = true;
                ofd.CheckPathExists = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    return ofd.FileName;
                }
                return null;
            }
        }

		private async void execButton_Click(object sender, EventArgs e)
		{
			if (this.targetTextBox.Text == "")
			{
				MessageBox.Show("PDFファイルのあるフォルダを選択してください");
				return;
			}

			bool checkback = this.radioButton2.Checked;
			await Task.Run(() => LoadCommentList(this.targetTextBox.Text, this.deptTextBox.Text, this.chineseCheckBox.Checked, checkback));

			MessageBox.Show("処理終了");
			System.Diagnostics.Process.Start(Path.GetDirectoryName(this.targetTextBox.Text));
		}

		private static void LoadCommentList(string dir, string fPath, bool chinese, bool checkback) //using pdfsharp
        {
            var lines = File.ReadAllLines(fPath).Distinct().ToList();			

			PdfSharp.Pdf.PdfDocument inputDoc = PdfSharp.Pdf.IO.PdfReader.Open(dir, PdfDocumentOpenMode.Import);
            PdfSharp.Pdf.PdfDocument document = new PdfSharp.Pdf.PdfDocument();
            PdfSharp.Pdf.PdfPage page = new PdfSharp.Pdf.PdfPage();
            var CommentList = new List<Annos>();
            var dirPath = Path.GetDirectoryName(dir);
            var xlsxFileName = checkback ? Path.Combine(dirPath, Path.GetFileNameWithoutExtension(dir) + "_戻りまとめ用.xlsx") : Path.Combine(dirPath, Path.GetFileNameWithoutExtension(dir) + ".xlsx");

            var kouki = GetKouki(Properties.Resources.kouki); //康煕部首対応

			if (File.Exists(xlsxFileName))
            {
                File.Delete(xlsxFileName);
            }

            int page_count = 0;
            string annotation = "";

            try
            {
                for (int i = 0; i < inputDoc.PageCount; i++)
                {
                    page = inputDoc.Pages[i];
                    page = document.AddPage(page);

                    for (int p = 0; p < document.Pages[i].Annotations.Elements.Count; p++)
                    {
                        PdfAnnotation textAnnot = document.Pages[i].Annotations[p];

                        string content = textAnnot.Contents;

                        page_count = i + 1;
                        annotation = content;

                        if (content != null && content != "")
                        {
                            if (content.Contains("殿"))
                            {
                                content = content.Replace("殿\r", "\u0110"); //20201125 ','を'\u0110'に変更
                                var dest = content.Split('\u0110');
                                dest[1] = dest[1].Trim().Replace("\r", "\n"); //20201110 Trim追記
                                if (dest[0].Contains('、'))
                                {
                                    var cls = dest[0].Split('、');
                                    for (var n = 0; n < cls.Length; n++)
                                    {
                                        if(!chinese)
                                            CommentList.Add(new Annos(cls[n].Trim(), (i + 1).ToString(), dest[1])); //20201110 Trim追記
                                        else
                                            CommentList.Add(new Annos(cls[n].Trim(), i.ToString(), dest[1])); //20201110 Trim追記
                                    }
                                }
                                else
                                {
                                    if(!chinese)
                                        CommentList.Add(new Annos(dest[0].Trim(), (i + 1).ToString(), dest[1])); //20201110 Trim追記
                                    else
                                        CommentList.Add(new Annos(dest[0].Trim(), i.ToString(), dest[1])); //20201110 Trim追記
                                }
                            }
						}
                    }
                }
            }catch(Exception ex)
            {
                CreateErrorLog(ex, page_count, annotation, dirPath);
                MessageBox.Show("エラー");
                return;
            }

            using (var wb = new XLWorkbook())
            {
                var ws = wb.AddWorksheet();
                int i = 1;

                ws.Cell(i, 1).Value = "No.";
                ws.Cell(i, 2).Value = "配布先部署名";
                ws.Cell(i, 3).Value = "設計CK該当頁";
                ws.Cell(i, 4).Value = "SISからの連絡事項";
                i++;

                var OrderedList = CommentList.OrderBy(list => list.Content).OrderBy(list => list.ClsName);
                foreach (var list in OrderedList)
                {
                    ws.Cell(i, 2).Value = list.ClsName;
                    ws.Cell(i, 3).Value = list.Page;
                    ws.Cell(i, 4).Value = KoukiCheck(list, kouki, dirPath) + "\n";  //康煕部首対応
                    ws.Cell(i, 4).Style.Alignment.WrapText = true;
                    i++;
                }
                ws.Columns("B:D").Style.Alignment.Vertical = XLAlignmentVerticalValues.Top;
                ws.Columns("B:D").AdjustToContents();
                ws.Column("D").Style.Alignment.WrapText = true;
                ws.Column("D").Width = 50;
                wb.SaveAs(xlsxFileName);
            }
            DistinctSupport(xlsxFileName, lines, checkback);
        }

		//重複確認
		private static void DistinctSupport(string xlsxFileName, List<string> lines, bool checkback)
		{
			using (var wb = new XLWorkbook(xlsxFileName))
			{
				var ws = wb.Worksheet(1);
				int lastRow = ws.LastRowUsed().RowNumber();
				var new_lines = new List<string>(lines);
				for (int i = lastRow; i > 1; i--)
				{
					//同じページ内に全く同じコメントがあったら1つ削除
					if (ws.Cell(i, 2).Value == ws.Cell(i - 1, 2).Value && ws.Cell(i, 3).Value.ToString() == ws.Cell(i - 1, 3).Value.ToString() && ws.Cell(i, 4).Value == ws.Cell(i - 1, 4).Value)
					{
						ws.Row(i).Delete();
					}
					foreach (var line in lines.ToList())
					{
						try
						{
							if (ws.Cell(i, 2).Value.ToString() == line.Split('\t')[1])
							{
								//lines.Remove(ws.Cell(i, 1).Value.ToString());
								ws.Cell(i, 1).Value = line.Split('\t')[0];
								new_lines.Remove(line);
								break;
							}
						}
						catch
						{
							continue;
						}

					}
				}

                if (!checkback)
                {
					lastRow = ws.LastRowUsed().RowNumber();
					for (int i = lastRow; i > 1; i--)
					{
						if (ws.Cell(i, 2).Value == ws.Cell(i - 1, 2).Value && ws.Cell(i, 4).Value == ws.Cell(i - 1, 4).Value)
						{
							ws.Cell(i - 1, 3).Value = ws.Cell(i - 1, 3).Value + "、" + ws.Cell(i, 3).Value;
							ws.Row(i).Delete();
						}
						else
						{
							ws.Cell(i, 3).Value = ws.Cell(i, 3).Value + "\n"; //20221028
							ws.Cell(i, 3).Style.NumberFormat.Format = "@";
						}
					}
				}				

				lastRow = ws.LastRowUsed().RowNumber();
				int cnt = 1;
				foreach (var line in new_lines)
				{
					try
					{
						ws.Cell(lastRow + cnt, 1).Value = line.Split('\t')[0];
						ws.Cell(lastRow + cnt, 2).Value = line.Split('\t')[1];
						ws.Cell(lastRow + cnt, 3).Value = "-";
						ws.Cell(lastRow + cnt, 4).Value = "特に質問はありません。\n修正がある場合はご指示ください。\n";
						cnt++;
					}
					catch
					{
						continue;
					}

				}
				ws.Range(ws.Cell(2, 1), ws.Cell(lastRow + cnt, 4)).SortColumns.Add(1, XLSortOrder.Ascending, true, true);
				ws.Range(ws.Cell(2, 1), ws.Cell(lastRow + cnt, 4)).SortColumns.Add(3, XLSortOrder.Ascending);
				ws.Range(ws.Cell(2, 1), ws.Cell(lastRow + cnt, 4)).Sort();
				wb.Save();
			}
		}

		//康煕部首対応----------------------------------------------------------------------------------
		private static Dictionary<int, int> GetKouki(string koukiStr)
        {
			//var csvText = File.ReadAllText(koukiPath);
			var kouki = new Dictionary<int, int>();

			// CSVファイルの各行ごとに処理をする
			foreach (var line in CsvReader.ReadFromText(koukiStr))
			{
				kouki.Add(int.Parse(line["target"]), int.Parse(line["replace"]));
			}
            return kouki;
		}
        private static string KoukiCheck(Annos list, Dictionary<int, int> kouki, string dirpath)
        {
            using(var sw = new StreamWriter(Path.Combine(dirpath,"kouki_report_" + DateTime.Now.ToString("yyMMddhhmm") + ".tsv"), true, Encoding.UTF8))
            {
				string checkedStr = "";
				foreach (var m in list.Content)
				{
					int code = ((int)m);

					if (kouki.ContainsKey(code))
					{
						char new_m = (char)kouki[code];
						checkedStr += new_m;
                        sw.WriteLine($"{list.ClsName} {list.Page}ページ:康煕部首「{(char)code}（{code}）」を「{new_m}（{kouki[code]}）」に変更しました。");
					}
					else
					{
						checkedStr += m;
					}
				}
				return checkedStr;
			}            
		}
		//康煕部首対応----------------------------------------------------------------------------------

		private static void CreateErrorLog(Exception ex, int page, string annotation, string dirpath)
        {
            var date = DateTime.Now.ToString("yyMMdd");
            var time = DateTime.Now.ToString("HH:mm:ss");
            using (var sw = new StreamWriter(Path.Combine(dirpath, "error_log" + date + ".tsv"), true, Encoding.UTF8))
            {
                sw.WriteLine($"{time}\n「{ex.Message}」\n{page}ページ\n{annotation}\n");
            }
        }    
        
        private void getFileButton_Click(object sender, EventArgs e)
        {
            string filter = "pdfファイル(*.pdf)|*.pdf";
            this.targetTextBox.Text = GetFilePath(filter);
        }

        private void loadFileButton_Click(object sender, EventArgs e)
        {
            string filter = "txtファイル(*.txt)|*.txt";
            this.deptTextBox.Text = GetFilePath(filter);
        }

	}
	public class Annos
    {
        public string ClsName { get; set; }
        public string Page { get; set; }
        public string Content { get; set; }
        
        public Annos(string name, string page, string content)
        {
            this.ClsName = name;
            this.Page = page;
            this.Content = content;
        }
        
    }
}
