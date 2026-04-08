namespace GetAnnotationFromPDF
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.execButton = new System.Windows.Forms.Button();
			this.getFileButton = new System.Windows.Forms.Button();
			this.targetTextBox = new System.Windows.Forms.TextBox();
			this.getDeptButton = new System.Windows.Forms.GroupBox();
			this.chineseCheckBox = new System.Windows.Forms.CheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.deptTextBox = new System.Windows.Forms.TextBox();
			this.loadFileButton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.getDeptButton.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// execButton
			// 
			this.execButton.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.execButton.Location = new System.Drawing.Point(169, 170);
			this.execButton.Name = "execButton";
			this.execButton.Size = new System.Drawing.Size(134, 46);
			this.execButton.TabIndex = 0;
			this.execButton.Text = "button1";
			this.execButton.UseVisualStyleBackColor = true;
			this.execButton.Click += new System.EventHandler(this.execButton_Click);
			// 
			// getFileButton
			// 
			this.getFileButton.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.getFileButton.Location = new System.Drawing.Point(406, 42);
			this.getFileButton.Name = "getFileButton";
			this.getFileButton.Size = new System.Drawing.Size(51, 29);
			this.getFileButton.TabIndex = 1;
			this.getFileButton.Text = "button1";
			this.getFileButton.UseVisualStyleBackColor = true;
			this.getFileButton.Click += new System.EventHandler(this.getFileButton_Click);
			// 
			// targetTextBox
			// 
			this.targetTextBox.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.targetTextBox.Location = new System.Drawing.Point(12, 44);
			this.targetTextBox.Name = "targetTextBox";
			this.targetTextBox.Size = new System.Drawing.Size(378, 25);
			this.targetTextBox.TabIndex = 2;
			// 
			// getDeptButton
			// 
			this.getDeptButton.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.getDeptButton.Controls.Add(this.groupBox1);
			this.getDeptButton.Controls.Add(this.chineseCheckBox);
			this.getDeptButton.Controls.Add(this.label3);
			this.getDeptButton.Controls.Add(this.deptTextBox);
			this.getDeptButton.Controls.Add(this.loadFileButton);
			this.getDeptButton.Controls.Add(this.label2);
			this.getDeptButton.Controls.Add(this.label1);
			this.getDeptButton.Controls.Add(this.targetTextBox);
			this.getDeptButton.Controls.Add(this.getFileButton);
			this.getDeptButton.Controls.Add(this.execButton);
			this.getDeptButton.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.getDeptButton.Location = new System.Drawing.Point(0, 0);
			this.getDeptButton.Name = "getDeptButton";
			this.getDeptButton.Size = new System.Drawing.Size(477, 248);
			this.getDeptButton.TabIndex = 3;
			this.getDeptButton.TabStop = false;
			// 
			// chineseCheckBox
			// 
			this.chineseCheckBox.AutoSize = true;
			this.chineseCheckBox.Location = new System.Drawing.Point(362, 161);
			this.chineseCheckBox.Name = "chineseCheckBox";
			this.chineseCheckBox.Size = new System.Drawing.Size(89, 22);
			this.chineseCheckBox.TabIndex = 10;
			this.chineseCheckBox.Text = "checkBox1";
			this.chineseCheckBox.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label3.Location = new System.Drawing.Point(14, 87);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(42, 18);
			this.label3.TabIndex = 8;
			this.label3.Text = "label3";
			// 
			// deptTextBox
			// 
			this.deptTextBox.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.deptTextBox.Location = new System.Drawing.Point(12, 108);
			this.deptTextBox.Name = "deptTextBox";
			this.deptTextBox.Size = new System.Drawing.Size(378, 25);
			this.deptTextBox.TabIndex = 7;
			// 
			// loadFileButton
			// 
			this.loadFileButton.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.loadFileButton.Location = new System.Drawing.Point(406, 106);
			this.loadFileButton.Name = "loadFileButton";
			this.loadFileButton.Size = new System.Drawing.Size(51, 29);
			this.loadFileButton.TabIndex = 6;
			this.loadFileButton.Text = "button1";
			this.loadFileButton.UseVisualStyleBackColor = true;
			this.loadFileButton.Click += new System.EventHandler(this.loadFileButton_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label2.Location = new System.Drawing.Point(427, 203);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(44, 20);
			this.label2.TabIndex = 4;
			this.label2.Text = "label2";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label1.Location = new System.Drawing.Point(14, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(42, 18);
			this.label1.TabIndex = 3;
			this.label1.Text = "label1";
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Location = new System.Drawing.Point(15, 18);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(101, 22);
			this.radioButton1.TabIndex = 11;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "radioButton1";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point(15, 46);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(101, 22);
			this.radioButton2.TabIndex = 12;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "radioButton2";
			this.radioButton2.UseVisualStyleBackColor = true;			
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioButton2);
			this.groupBox1.Controls.Add(this.radioButton1);
			this.groupBox1.Location = new System.Drawing.Point(12, 143);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(140, 73);
			this.groupBox1.TabIndex = 13;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "groupBox1";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(476, 230);
			this.Controls.Add(this.getDeptButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "Form1";
			this.getDeptButton.ResumeLayout(false);
			this.getDeptButton.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button execButton;
        private System.Windows.Forms.Button getFileButton;
        private System.Windows.Forms.TextBox targetTextBox;
        private System.Windows.Forms.GroupBox getDeptButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button loadFileButton;
        private System.Windows.Forms.TextBox deptTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chineseCheckBox;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton1;
	}
}

