using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Nhom_1_BaiThiCuoiKy
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dl;
            dl = MessageBox.Show("Bạn có chắc muốn thoát không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
            if (dl == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            if(txtPass.Text == @"%!@#$%^&*()?/>.<,:;'\|}]{[_~`+=-" + "\"")
            {
                MessageBox.Show("Độ dài chưa đủ!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnDangnhap_Click_1(object sender, EventArgs e)
        {
            //sai mật khẩu cho admin và tài khoản admin
            try
            {
                if (txtAcc.Text == "admin")
                {
                    if (txtPass.Text == "admin")
                    {
                        this.Hide();
                        FormAdmin formadmin = new FormAdmin();
                        formadmin.ShowDialog();
                    }
                    else if (txtPass.Text != "admin" && txtPass.Text != "")
                    {
                        MessageBox.Show("Sai mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                //sai mật khẩu cho user và tài khoản user
                if (txtAcc.Text == "user")
                {
                    if (txtPass.Text == "user")
                    {
                        this.Hide();
                        FormUser formuser = new FormUser();
                        formuser.ShowDialog();
                    }
                    else if (txtPass.Text != "user" && txtPass.Text != "")
                    {
                        MessageBox.Show("Sai mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                //chưa nhập mật khẩu
                if (txtPass.Text == "Password" || txtPass.Text == "")
                {
                    txtInvalidPass.Visible = true;
                    txtPass.Focus();
                }
                //chưa nhập tài khoản
                if (txtAcc.Text == "Enter username" || txtAcc.Text == "")
                {
                    txtInvaldAcc.Visible = true;
                    txtAcc.Focus();
                }

                //tài khoản không tồn tại
                if (txtAcc.Text != "" && txtPass.Text != "" && txtAcc.Text != "Enter username" && txtPass.Text != "Password")
                {
                    if (txtAcc.Text != "admin")
                    {
                        if (txtPass.Text != "admin" && txtPass.Text != "user")
                        {
                            MessageBox.Show("Tài khoản không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void txtAcc_Click(object sender, EventArgs e)
        {
            txtAcc.SelectAll();
            txtInvaldAcc.Visible = false;
        }

        private void txtPass_Click(object sender, EventArgs e)
        {
            txtPass.SelectAll();
            txtInvalidPass.Visible = false;
        }

        private void txtAcc_TextChanged(object sender, EventArgs e)
        {
            txtAcc.ForeColor = Color.White;
            txtInvaldAcc.Visible = false;
        }

        private void txtPass_TextChanged_1(object sender, EventArgs e)
        {
            txtPass.ForeColor = Color.White;
            txtPass.UseSystemPasswordChar = true;
            txtInvalidPass.Visible = false;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            txtAcc.Focus();
            txtInvaldAcc.Visible = false;
            txtInvalidPass.Visible = false;
        }
        private void btnDangnhap_MouseEnter(object sender, EventArgs e)
        {
            btnDangnhap.ForeColor = Color.Black;
        }

        private void btnDangnhap_MouseLeave(object sender, EventArgs e)
        {
            btnDangnhap.ForeColor = Color.White;
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if(chkShowPass.Checked)
            {
                txtPass.UseSystemPasswordChar = false;
            } else
            {
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThoat_MouseLeave(object sender, EventArgs e)
        {
            btnThoat.ForeColor = Color.White;
        }

        private void btnThoat_MouseEnter(object sender, EventArgs e)
        {
            btnThoat.ForeColor = Color.Black;
        }
    }
}
