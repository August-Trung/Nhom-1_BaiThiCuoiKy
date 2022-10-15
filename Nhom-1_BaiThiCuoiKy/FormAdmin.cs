using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom_1_BaiThiCuoiKy
{
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }

        private void thôngTinNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ThongTinNV thongTinNV = new ThongTinNV();
            thongTinNV.ShowDialog();
        }

        private void thôngTinKháchHàngToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormTTKH thongtinKH = new FormTTKH();
            thongtinKH.ShowDialog();
        }

        private void orderToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMenu formMenu = new FormMenu();
            formMenu.ShowDialog();
        }
    }
}
