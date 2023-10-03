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
    }
}