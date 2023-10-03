namespace BandizipBatchOperation
{
    partial class Main_Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
            label1 = new Label();
            textBox_AddressWaitUnzip = new TextBox();
            button_GetAddressWaitUnzip = new Button();
            label2 = new Label();
            textBox_UnzipToAddress = new TextBox();
            button_GetUnzipToAddress = new Button();
            radioButton_Type_zip = new RadioButton();
            radioButton_Type_7z = new RadioButton();
            radioButton_Type_rar = new RadioButton();
            radioButton_Type_other = new RadioButton();
            textBox_Type = new TextBox();
            label4 = new Label();
            textBox_Unzip_Password = new TextBox();
            checkBox_UnzipToSameDir = new CheckBox();
            checkBox_UnzipToSameNameDir = new CheckBox();
            checkBox_DeleteSrc = new CheckBox();
            button_StartUnzip = new Button();
            groupBox_radioButton = new GroupBox();
            groupBox_radioButton.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(174, 20);
            label1.TabIndex = 0;
            label1.Text = "存放待解压文件的文件夹";
            // 
            // textBox_AddressWaitUnzip
            // 
            textBox_AddressWaitUnzip.Location = new Point(12, 32);
            textBox_AddressWaitUnzip.Name = "textBox_AddressWaitUnzip";
            textBox_AddressWaitUnzip.Size = new Size(361, 27);
            textBox_AddressWaitUnzip.TabIndex = 1;
            // 
            // button_GetAddressWaitUnzip
            // 
            button_GetAddressWaitUnzip.Location = new Point(379, 32);
            button_GetAddressWaitUnzip.Name = "button_GetAddressWaitUnzip";
            button_GetAddressWaitUnzip.Size = new Size(91, 27);
            button_GetAddressWaitUnzip.TabIndex = 2;
            button_GetAddressWaitUnzip.Text = "选取...";
            button_GetAddressWaitUnzip.UseVisualStyleBackColor = true;
            button_GetAddressWaitUnzip.Click += button_GetAddressWaitUnzip_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 62);
            label2.Name = "label2";
            label2.Size = new Size(99, 20);
            label2.TabIndex = 3;
            label2.Text = "解压至文件夹";
            // 
            // textBox_UnzipToAddress
            // 
            textBox_UnzipToAddress.Location = new Point(12, 85);
            textBox_UnzipToAddress.Name = "textBox_UnzipToAddress";
            textBox_UnzipToAddress.Size = new Size(361, 27);
            textBox_UnzipToAddress.TabIndex = 4;
            // 
            // button_GetUnzipToAddress
            // 
            button_GetUnzipToAddress.Location = new Point(379, 85);
            button_GetUnzipToAddress.Name = "button_GetUnzipToAddress";
            button_GetUnzipToAddress.Size = new Size(91, 27);
            button_GetUnzipToAddress.TabIndex = 5;
            button_GetUnzipToAddress.Text = "选取...";
            button_GetUnzipToAddress.UseVisualStyleBackColor = true;
            // 
            // radioButton_Type_zip
            // 
            radioButton_Type_zip.AutoSize = true;
            radioButton_Type_zip.Location = new Point(6, 26);
            radioButton_Type_zip.Name = "radioButton_Type_zip";
            radioButton_Type_zip.Size = new Size(51, 24);
            radioButton_Type_zip.TabIndex = 7;
            radioButton_Type_zip.Text = "zip";
            radioButton_Type_zip.UseVisualStyleBackColor = true;
            // 
            // radioButton_Type_7z
            // 
            radioButton_Type_7z.AutoSize = true;
            radioButton_Type_7z.Location = new Point(119, 26);
            radioButton_Type_7z.Name = "radioButton_Type_7z";
            radioButton_Type_7z.Size = new Size(46, 24);
            radioButton_Type_7z.TabIndex = 8;
            radioButton_Type_7z.Text = "7z";
            radioButton_Type_7z.UseVisualStyleBackColor = true;
            // 
            // radioButton_Type_rar
            // 
            radioButton_Type_rar.AutoSize = true;
            radioButton_Type_rar.Location = new Point(63, 26);
            radioButton_Type_rar.Name = "radioButton_Type_rar";
            radioButton_Type_rar.Size = new Size(50, 24);
            radioButton_Type_rar.TabIndex = 9;
            radioButton_Type_rar.Text = "rar";
            radioButton_Type_rar.UseVisualStyleBackColor = true;
            // 
            // radioButton_Type_other
            // 
            radioButton_Type_other.AutoSize = true;
            radioButton_Type_other.Location = new Point(171, 26);
            radioButton_Type_other.Name = "radioButton_Type_other";
            radioButton_Type_other.Size = new Size(180, 24);
            radioButton_Type_other.TabIndex = 10;
            radioButton_Type_other.Text = "其他后缀（右侧填写）";
            radioButton_Type_other.UseVisualStyleBackColor = true;
            radioButton_Type_other.CheckedChanged += radioButton_Type_other_CheckedChanged;
            // 
            // textBox_Type
            // 
            textBox_Type.Location = new Point(357, 23);
            textBox_Type.Name = "textBox_Type";
            textBox_Type.Size = new Size(95, 27);
            textBox_Type.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 182);
            label4.Name = "label4";
            label4.Size = new Size(264, 20);
            label4.TabIndex = 12;
            label4.Text = "解压密码（若有则填写，若无则留空）";
            // 
            // textBox_Unzip_Password
            // 
            textBox_Unzip_Password.Location = new Point(12, 205);
            textBox_Unzip_Password.Name = "textBox_Unzip_Password";
            textBox_Unzip_Password.Size = new Size(458, 27);
            textBox_Unzip_Password.TabIndex = 13;
            // 
            // checkBox_UnzipToSameDir
            // 
            checkBox_UnzipToSameDir.AutoSize = true;
            checkBox_UnzipToSameDir.Location = new Point(12, 238);
            checkBox_UnzipToSameDir.Name = "checkBox_UnzipToSameDir";
            checkBox_UnzipToSameDir.Size = new Size(151, 24);
            checkBox_UnzipToSameDir.TabIndex = 14;
            checkBox_UnzipToSameDir.Text = "解压至同一目录中";
            checkBox_UnzipToSameDir.UseVisualStyleBackColor = true;
            // 
            // checkBox_UnzipToSameNameDir
            // 
            checkBox_UnzipToSameNameDir.AutoSize = true;
            checkBox_UnzipToSameNameDir.Location = new Point(12, 268);
            checkBox_UnzipToSameNameDir.Name = "checkBox_UnzipToSameNameDir";
            checkBox_UnzipToSameNameDir.Size = new Size(166, 24);
            checkBox_UnzipToSameNameDir.TabIndex = 15;
            checkBox_UnzipToSameNameDir.Text = "解压至同名文件夹中";
            checkBox_UnzipToSameNameDir.UseVisualStyleBackColor = true;
            // 
            // checkBox_DeleteSrc
            // 
            checkBox_DeleteSrc.AutoSize = true;
            checkBox_DeleteSrc.Location = new Point(12, 298);
            checkBox_DeleteSrc.Name = "checkBox_DeleteSrc";
            checkBox_DeleteSrc.Size = new Size(151, 24);
            checkBox_DeleteSrc.TabIndex = 16;
            checkBox_DeleteSrc.Text = "解压后删除源文件";
            checkBox_DeleteSrc.UseVisualStyleBackColor = true;
            // 
            // button_StartUnzip
            // 
            button_StartUnzip.Location = new Point(261, 238);
            button_StartUnzip.Name = "button_StartUnzip";
            button_StartUnzip.Size = new Size(209, 84);
            button_StartUnzip.TabIndex = 17;
            button_StartUnzip.Text = "开始";
            button_StartUnzip.UseVisualStyleBackColor = true;
            // 
            // groupBox_radioButton
            // 
            groupBox_radioButton.Controls.Add(radioButton_Type_zip);
            groupBox_radioButton.Controls.Add(radioButton_Type_rar);
            groupBox_radioButton.Controls.Add(radioButton_Type_7z);
            groupBox_radioButton.Controls.Add(radioButton_Type_other);
            groupBox_radioButton.Controls.Add(textBox_Type);
            groupBox_radioButton.Location = new Point(12, 118);
            groupBox_radioButton.Name = "groupBox_radioButton";
            groupBox_radioButton.Size = new Size(458, 61);
            groupBox_radioButton.TabIndex = 18;
            groupBox_radioButton.TabStop = false;
            groupBox_radioButton.Text = "文件格式类型（文件后缀）";
            // 
            // Main_Form
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(482, 333);
            Controls.Add(groupBox_radioButton);
            Controls.Add(button_StartUnzip);
            Controls.Add(checkBox_DeleteSrc);
            Controls.Add(checkBox_UnzipToSameNameDir);
            Controls.Add(checkBox_UnzipToSameDir);
            Controls.Add(textBox_Unzip_Password);
            Controls.Add(label4);
            Controls.Add(button_GetUnzipToAddress);
            Controls.Add(textBox_UnzipToAddress);
            Controls.Add(label2);
            Controls.Add(button_GetAddressWaitUnzip);
            Controls.Add(textBox_AddressWaitUnzip);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Main_Form";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bandizip文件批量操作";
            Load += Main_Form_Load;
            groupBox_radioButton.ResumeLayout(false);
            groupBox_radioButton.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox_AddressWaitUnzip;
        private Button button_GetAddressWaitUnzip;
        private Label label2;
        private TextBox textBox_UnzipToAddress;
        private Button button_GetUnzipToAddress;
        private RadioButton radioButton_Type_zip;
        private RadioButton radioButton_Type_7z;
        private RadioButton radioButton_Type_rar;
        private RadioButton radioButton_Type_other;
        private TextBox textBox_Type;
        private Label label4;
        private TextBox textBox_Unzip_Password;
        private CheckBox checkBox_UnzipToSameDir;
        private CheckBox checkBox_UnzipToSameNameDir;
        private CheckBox checkBox_DeleteSrc;
        private Button button_StartUnzip;
        private GroupBox groupBox_radioButton;
    }
}