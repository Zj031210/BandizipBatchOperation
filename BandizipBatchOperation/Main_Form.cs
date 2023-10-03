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
            if(radioButton_Type_other.Checked == true)
            {
                textBox_Type.Enabled = true;
            }
            else
            {
                textBox_Type.Enabled =false;
            }
        }
    }
}