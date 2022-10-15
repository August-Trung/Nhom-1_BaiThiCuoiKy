namespace Nhom_1_BaiThiCuoiKy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin fomlogin = new FormLogin();
            fomlogin.ShowDialog();
            this.Close();
        }
    }
}