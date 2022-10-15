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
    public partial class FormTTKH : Form
    {
        public FormTTKH()
        {
            InitializeComponent();
        }

        private void FormTTKH_Load(object sender, EventArgs e)
        {
            txtTenKH.Focus();
            lvTTKH.Columns[0].Width = (int)(lvTTKH.Width * 0.25);
            lvTTKH.Columns[1].Width = (int)(lvTTKH.Width * 0.15);
            lvTTKH.Columns[2].Width = (int)(lvTTKH.Width * 0.35);
            lvTTKH.Columns[3].Width = (int)(lvTTKH.Width * 0.25);
            lvTTKH.View = View.Details;
            lvTTKH.GridLines = true;
            lvTTKH.FullRowSelect = true;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenKH.Text == "" || txtDiaChi.Text == "" || txtSDTKH.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ListViewItem item = lvTTKH.Items.Add(txtTenKH.Text);
                item.SubItems.Add(cbGioiTinhKH.Text);
                item.SubItems.Add(txtDiaChi.Text);
                item.SubItems.Add(txtSDTKH.Text);
            }

            txtTenKH.Text = "";
            txtDiaChi.Text = "";
            txtSDTKH.Text = "";
        }

        private void lvTTKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvTTKH.SelectedItems.Count > 0)
            {
                txtTenKH.Text = lvTTKH.SelectedItems[0].SubItems[0].Text;
                cbGioiTinhKH.Text = lvTTKH.SelectedItems[0].SubItems[1].Text;
                txtDiaChi.Text = lvTTKH.SelectedItems[0].SubItems[2].Text;
                txtSDTKH.Text = lvTTKH.SelectedItems[0].SubItems[3].Text;
            }
            else if(lvTTKH.SelectedItems.Count == 0)
            {
                txtTenKH.Text = "";
                txtDiaChi.Text = "";
                txtSDTKH.Text = "";
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvTTKH.SelectedItems.Count > 0)
            {
                lvTTKH.Items.Remove(lvTTKH.SelectedItems[0]);
            }
            else
            {
                MessageBox.Show("Bạn phải chọn ít nhất 1 dòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnXoaAll_Click(object sender, EventArgs e)
        {
            if (lvTTKH.Items.Count == 0)
            {
                MessageBox.Show("Dữ liệu đang trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                lvTTKH.Items.Clear();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();
            FormAdmin formadmin = new FormAdmin();
            formadmin.ShowDialog();
        }

        private void FormTTKH_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dl;
            dl = MessageBox.Show("Bạn có chắc muốn thoát không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
            if (dl == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            if (lvTTKH.SelectedItems.Count > 0)
            {
                lvTTKH.SelectedItems[0].SubItems[0].Text = txtTenKH.Text;
                lvTTKH.SelectedItems[0].SubItems[1].Text = cbGioiTinhKH.Text;
                lvTTKH.SelectedItems[0].SubItems[2].Text = txtDiaChi.Text;
                lvTTKH.SelectedItems[0].SubItems[3].Text = txtSDTKH.Text;
            }
            else
            {
                MessageBox.Show("Bạn phải chọn ít nhất 1 dòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            txtTenKH.Text = "";
            txtDiaChi.Text = "";
            txtSDTKH.Text = "";
        }
    }
}
