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
    public partial class ThongTinNV : Form
    {
        public ThongTinNV()
        {
            InitializeComponent();
        }

        private void ThongTinNV_Load(object sender, EventArgs e)
        {
            txtTenNV.Focus();
            lvTTNV.Columns[0].Width = (int)(lvTTNV.Width * 0.25);
            lvTTNV.Columns[1].Width = (int)(lvTTNV.Width * 0.2);
            lvTTNV.Columns[2].Width = (int)(lvTTNV.Width * 0.15);
            lvTTNV.Columns[3].Width = (int)(lvTTNV.Width * 0.2);
            lvTTNV.Columns[4].Width = (int)(lvTTNV.Width * 0.2);
            lvTTNV.View = View.Details;
            lvTTNV.GridLines = true;
            lvTTNV.FullRowSelect = true;

            ListViewItem item = lvTTNV.Items.Add("Nguyễn Minh Trung");
            item.SubItems.Add("172100168");
            item.SubItems.Add("Nam");
            item.SubItems.Add("8/1/2003");
            item.SubItems.Add("0817115434");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenNV.Text == "" || txtMaNV.Text == "" || txtSDT.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else
            {
                for (int i = 0; i < lvTTNV.Items.Count; i++)
                {
                    if (txtMaNV.Text == lvTTNV.Items[i].Text)
                    {
                        MessageBox.Show("Không được trùng mã nhân viên!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        txtMaNV.Clear();
                        return;
                    }
                }
                ListViewItem item = lvTTNV.Items.Add(txtTenNV.Text);
                item.SubItems.Add(txtMaNV.Text);
                item.SubItems.Add(cbGioiTinh.Text);
                item.SubItems.Add(datetimeNV.Value.ToShortDateString());
                item.SubItems.Add(txtSDT.Text);
            }

            txtTenNV.Text = "";
            txtMaNV.Text = "";
            txtSDT.Text = "";
            datetimeNV.Value = DateTime.Now;
        }

        private void lvTTNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvTTNV.SelectedItems.Count > 0)
            {
                txtTenNV.Text = lvTTNV.SelectedItems[0].SubItems[0].Text;
                txtMaNV.Text = lvTTNV.SelectedItems[0].SubItems[1].Text;
                cbGioiTinh.Text = lvTTNV.SelectedItems[0].SubItems[2].Text;
                datetimeNV.Text = lvTTNV.SelectedItems[0].SubItems[3].Text;
                txtSDT.Text = lvTTNV.SelectedItems[0].SubItems[4].Text;
                txtMaNV.Enabled = false;
            }
            else if (lvTTNV.SelectedItems.Count == 0)
            {
                txtTenNV.Text = "";
                txtMaNV.Text = "";
                txtSDT.Text = "";
                datetimeNV.Value = DateTime.Now;
                txtMaNV.Enabled = true;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvTTNV.SelectedItems.Count > 0)
            {
                lvTTNV.Items.Remove(lvTTNV.SelectedItems[0]);
            }
            else
            {
                MessageBox.Show("Bạn phải chọn ít nhất 1 dòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lvTTNV.SelectedItems.Count > 0)
            {
                lvTTNV.SelectedItems[0].SubItems[0].Text = txtTenNV.Text;
                lvTTNV.SelectedItems[0].SubItems[1].Text = txtMaNV.Text;
                lvTTNV.SelectedItems[0].SubItems[2].Text = cbGioiTinh.Text;
                lvTTNV.SelectedItems[0].SubItems[3].Text = datetimeNV.Value.ToShortDateString();
                lvTTNV.SelectedItems[0].SubItems[4].Text = txtSDT.Text;
                txtMaNV.Enabled = false;
                MessageBox.Show("Thông tin đã được thay đổi", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Bạn phải chọn ít nhất 1 dòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            txtTenNV.Text = "";
            txtMaNV.Text = "";
            txtSDT.Text = "";
            datetimeNV.Value = DateTime.Now;
            txtMaNV.Enabled = true;

        }

        private void btnXoaAll_Click(object sender, EventArgs e)
        {
            if(lvTTNV.Items.Count == 0)
            {
                MessageBox.Show("Dữ liệu đang trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else
            {
                lvTTNV.Items.Clear();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();
            FormAdmin formadmin = new FormAdmin();
            formadmin.ShowDialog();
        }

        private void ThongTinNV_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dl;
            dl = MessageBox.Show("Bạn có chắc muốn thoát không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
            if (dl == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
