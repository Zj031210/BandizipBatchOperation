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
            // Ĭ��ѡ�е�һ��������ѡ������
            radioButton_Type_zip.Checked = true;

            radioButton_Type_rar.Checked = false;
            radioButton_Type_7z.Checked = false;
            radioButton_Type_other.Checked = false;

            textBox_Type.Enabled = false;

            // ��������汾��ʾ
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

            // �ж�Bandizip�Ƿ��Ѱ�װ
            var validateText = Execute("bz.exe", 0);
            if (string.IsNullOrEmpty(validateText))
            {
                MessageBox.Show("��û�а�װBandizip�����Ȱ�װ", "ȱ��Bandizip", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // �ж�textBox_AddressWaitUnzip�Ƿ�Ϊ��
            if (textBox_AddressWaitUnzip.Text.Length == 0)
            {
                MessageBox.Show("����ѡ��һ����Ŵ���ѹ�ļ����ļ��У�", "ȱ��·��", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            // �ж�textBox_UnzipToAddress�Ƿ�Ϊ��
            if (textBox_UnzipToAddress.Text.Length == 0)
            {
                MessageBox.Show("����ѡ��һ����ѹ���ļ��У�", "ȱ��·��", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            // �ж�groupBox_radioButton�еİ�ť������һ��ѡ�У�������һ����ʽ
            if (!CheckZipTypeIsChecked())
            {
                MessageBox.Show("��ѡ��zip/rar/7z��ѹ����ʽ\n��ѡ��������ʽ������һ����Ч��ʽ��");
                return;
            }
            else
            {
                type = returntype();
            }
            // ����cmd����
            string command = $"Bandizip.exe x {(checkBox_DeleteSrc.Checked ? "-delsrc" : String.Empty)} -o:{(checkBox_UnzipToSameDir.Checked ? textBox_AddressWaitUnzip.Text + "\\" : textBox_UnzipToAddress.Text + "\\")} {(checkBox_UnzipToSameNameDir.Checked ? "-target:name" : String.Empty)} {(CheckPasswordIsNull() ? "-p" + textBox_Unzip_Password.Text : String.Empty)} {textBox_AddressWaitUnzip.Text + "\\*." + type}";
            // ����ִ��
            Execute(command, 0);
        }

        /// <summary>
        /// �ж�ѹ���ļ������Ƿ�������һ��ѡ��
        /// </summary>
        /// <returns>���ز�ѯ���</returns>
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
        /// ����ѹ���ļ�����
        /// </summary>
        /// <returns>��������</returns>
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
                return_type = "zip"; // �쳣���Ĭ��zip
            }
            return return_type;
        }

        /// <summary>
        /// �ж��Ƿ�����д����
        /// </summary>
        /// <returns>���ز�ѯ���</returns>
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
        /// ִ��DOS�������DOS��������  
        /// </summary>  
        /// <param name="command">dos����</param>
        /// <param name="seconds">�ȴ�����ִ�е�ʱ�� ����趨Ϊ0�������޵ȴ�</param>
        /// <returns>����DOS��������</returns>  
        private static string Execute(string command, int seconds)
        {
            var output = string.Empty; //����ַ���  
            if (command == null || command.Equals("")) return output;
            var cmd_process = new Process();//�������̶���  
            var startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe", // �趨cmd.exe
                Arguments = "/C " + command, //��/C����ʾִ��������������˳�  
                UseShellExecute = false, // ��ʹ��ϵͳ��ǳ������� 
                RedirectStandardInput = false, // ���ض�������  
                RedirectStandardOutput = true, // �ض������  
                CreateNoWindow = true // ����������  
            };
            cmd_process.StartInfo = startInfo;
            try
            {
                if (cmd_process.Start())
                {
                    if (seconds == 0)
                    {
                        cmd_process.WaitForExit(); // ���޵ȴ����̽���  
                    }
                    else
                    {
                        cmd_process.WaitForExit(seconds); // �ȴ����̽������ȴ�ʱ��Ϊָ���ĺ���  
                    }
                    output = cmd_process.StandardOutput.ReadToEnd(); // ��ȡ���̵����  
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // �����쳣������쳣��Ϣ
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