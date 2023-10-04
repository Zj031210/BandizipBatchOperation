using System.Diagnostics;
using System.Text.RegularExpressions;

namespace BandizipBatchOperation
{
    public partial class Main_Form : Form
    {
        public Main_Form()
        {
            InitializeComponent();
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            // 默认选中第一个，但不选中其余
            radioButton_Type_zip.Checked = true;

            radioButton_Type_rar.Checked = false;
            radioButton_Type_7z.Checked = false;
            radioButton_Type_other.Checked = false;

            textBox_Type.Enabled = false;

            // 设置软件版本显示
            label_Version.Text = "V1.1.0";
        }

        private void radioButton_Type_other_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Type_other.Checked == true)
            {
                textBox_Type.Enabled = true;
            }
            else
            {
                textBox_Type.Enabled = false;
            }
        }

        private void button_GetAddressWaitUnzip_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog UnzipAddress_dialog = new FolderBrowserDialog())
            {
                UnzipAddress_dialog.RootFolder = Environment.SpecialFolder.Desktop;

                if (UnzipAddress_dialog.ShowDialog() == DialogResult.OK)
                {
                    String Address_WaitUnzip = UnzipAddress_dialog.SelectedPath;
                    textBox_AddressWaitUnzip.Text = Address_WaitUnzip;
                }
            }
        }

        private void button_GetUnzipToAddress_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog UnzipToAddress_dialog = new FolderBrowserDialog())
            {
                UnzipToAddress_dialog.RootFolder = Environment.SpecialFolder.Desktop;

                if (UnzipToAddress_dialog.ShowDialog() == DialogResult.OK)
                {
                    String Address_UnzipTo = UnzipToAddress_dialog.SelectedPath;
                    textBox_UnzipToAddress.Text = Address_UnzipTo;
                }
            }
        }

        private void button_StartUnzip_Click(object sender, EventArgs e)
        {
            string type;

            // 判断Bandizip是否已安装
            var validateText = Execute("bz.exe", 0);
            if (string.IsNullOrEmpty(validateText))
            {
                MessageBox.Show("您没有安装Bandizip，请先安装", "缺少Bandizip", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // 判断textBox_AddressWaitUnzip是否为空
            if (textBox_AddressWaitUnzip.Text.Length == 0)
            {
                MessageBox.Show("请先选择一个存放待解压文件的文件夹！", "缺少路径", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            // 判断textBox_UnzipToAddress是否为空
            if (textBox_UnzipToAddress.Text.Length == 0)
            {
                MessageBox.Show("请先选择一个解压至文件夹！", "缺少路径", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            // 判断groupBox_radioButton中的按钮至少有一个选中，并储存一个格式
            if (!CheckZipTypeIsChecked())
            {
                MessageBox.Show("请选择zip/rar/7z的压缩格式\n或选择其他格式并输入一个有效格式！");
                return;
            }
            else
            {
                type = returntype();
            }
            // 构造cmd代码
            string command = $"Bandizip.exe x {(checkBox_DeleteSrc.Checked ? "-delsrc" : String.Empty)} -o:{(checkBox_UnzipToSameDir.Checked ? textBox_AddressWaitUnzip.Text + "\\" : textBox_UnzipToAddress.Text + "\\")} {(checkBox_UnzipToSameNameDir.Checked ? "-target:name" : String.Empty)} {(CheckPasswordIsNull() ? "-p" + textBox_Unzip_Password.Text : String.Empty)} {textBox_AddressWaitUnzip.Text + "\\*." + type}";
            // 推送执行
            Execute(command, 0);
        }

        /// <summary>
        /// 判断压缩文件类型是否有至少一个选中
        /// </summary>
        /// <returns>返回查询结果</returns>
        private bool CheckZipTypeIsChecked()
        {
            bool return_type = false;
            if (radioButton_Type_zip.Checked == true || radioButton_Type_rar.Checked == true || radioButton_Type_7z.Checked == true)
            {
                return_type = true;
            }
            else if (radioButton_Type_other.Checked == true && textBox_Type.Text.Length > 0)
            {
                bool isFormatName = Regex.IsMatch(textBox_Type.Text, @"^[a-zA-Z0-9]+$");
                if (isFormatName)
                {
                    return_type = true;
                }
            }
            return return_type;
        }

        /// <summary>
        /// 返回压缩文件类型
        /// </summary>
        /// <returns>返回类型</returns>
        private string returntype()
        {
            string return_type = "zip";
            if (radioButton_Type_zip.Checked == true)
            {
                return_type = "zip";
            }
            else if (radioButton_Type_rar.Checked == true)
            {
                return_type = "rar";
            }
            else if (radioButton_Type_7z.Checked == true)
            {
                return_type = "7z";
            }
            else if (radioButton_Type_other.Checked == true)
            {
                return_type = textBox_Type.Text;
            }
            else
            {
                return_type = "zip"; // 异常情况默认zip
            }
            return return_type;
        }

        /// <summary>
        /// 判断是否有填写密码
        /// </summary>
        /// <returns>返回查询结果</returns>
        private bool CheckPasswordIsNull()
        {
            bool return_type = false;
            if (textBox_Unzip_Password.Text.Length > 0)
            {
                return_type = true;
            }
            return return_type;
        }

        /// <summary>  
        /// 执行DOS命令，返回DOS命令的输出  
        /// </summary>  
        /// <param name="command">dos命令</param>
        /// <param name="seconds">等待命令执行的时间 如果设定为0，则无限等待</param>
        /// <returns>返回DOS命令的输出</returns>  
        private static string Execute(string command, int seconds)
        {
            var output = string.Empty; //输出字符串  
            if (command == null || command.Equals("")) return output;
            var cmd_process = new Process();//创建进程对象  
            var startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe", // 设定cmd.exe
                Arguments = "/C " + command, //“/C”表示执行完命令后马上退出  
                UseShellExecute = false, // 不使用系统外壳程序启动 
                RedirectStandardInput = false, // 不重定向输入  
                RedirectStandardOutput = true, // 重定向输出  
                CreateNoWindow = true // 不创建窗口  
            };
            cmd_process.StartInfo = startInfo;
            try
            {
                if (cmd_process.Start())
                {
                    if (seconds == 0)
                    {
                        cmd_process.WaitForExit(); // 无限等待进程结束  
                    }
                    else
                    {
                        cmd_process.WaitForExit(seconds); // 等待进程结束，等待时间为指定的毫秒  
                    }
                    output = cmd_process.StandardOutput.ReadToEnd(); // 读取进程的输出  
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // 捕获异常，输出异常信息
            }
            finally
            {
                cmd_process.Close();
            }
            return output;
        }

        private void checkBox_UnzipToSameDir_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_UnzipToSameDir.Checked == true)
            {
                textBox_UnzipToAddress.Enabled = false;
            }
            else
            {
                textBox_UnzipToAddress.Enabled = true;
            }
        }

        private void Download_Bandizip_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("explorer.exe", "https://cn.bandisoft.com/bandizip/");
        }

        private void linkLabel_GitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("explorer.exe", "https://github.com/Zj031210/BandizipBatchOperation");
        }
    }
}