using QuanLyBanHang.BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.WinForm.HeThong
{
    public partial class Frm_ConnectionManager : Form
    {
        public Frm_ConnectionManager()
        {
            InitializeComponent();
        }
        SqlConnectionStringBuilder sqlConnectionStringBuilder;
        BLL_ConnectionStringManager bd;

        string err = string.Empty;

        private void Frm_ConnectionManager_Load(object sender, EventArgs e)
        {
            sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            bd = new BLL_ConnectionStringManager();
            ReadConnetionString(ref err, ClsMain.path);
        }

        private void ReadConnetionString(ref string err, string path)
        {
            sqlConnectionStringBuilder = bd.ReadConnectionString(ref err, path);
            txtServer.Text = sqlConnectionStringBuilder.DataSource;
            txtDatabase.Text = sqlConnectionStringBuilder.InitialCatalog;
            txtUserID.Text = sqlConnectionStringBuilder.UserID;
            txtPassword.Text = sqlConnectionStringBuilder.Password;
            if (sqlConnectionStringBuilder.IntegratedSecurity)
            {
                cboAuthentication.SelectedIndex = 0;

            }
            else
            {

                cboAuthentication.SelectedIndex = 1;
            }
        }

        private void CreateConnectionString(ref string err, string path)
        {
            if (cboAuthentication.SelectedIndex == 1)
            {
                if (!string.IsNullOrEmpty(txtUserID.Text))
                {
                    if (!string.IsNullOrEmpty(txtPassword.Text))
                    {
                        //tạo chuỗi kết nối sql
                        sqlConnectionStringBuilder.DataSource = txtServer.Text;
                        sqlConnectionStringBuilder.InitialCatalog = txtDatabase.Text;
                        sqlConnectionStringBuilder.UserID = txtUserID.Text;
                        sqlConnectionStringBuilder.Password = txtPassword.Text;
                        sqlConnectionStringBuilder.IntegratedSecurity = false;
                        bd.WriteConnectionString(ref err, path, sqlConnectionStringBuilder);
                    }
                    else
                    {
                        MessageBox.Show("Chưa có password", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Chưa có user name", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                //tạo =kêt nói quyen window 
                sqlConnectionStringBuilder.DataSource = txtServer.Text;
                sqlConnectionStringBuilder.InitialCatalog = txtDatabase.Text;
                sqlConnectionStringBuilder.UserID = string.Empty;
                sqlConnectionStringBuilder.Password = string.Empty;
                sqlConnectionStringBuilder.IntegratedSecurity = true;
                bd.WriteConnectionString(ref err, path, sqlConnectionStringBuilder);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtServer.Text))
            {
                if (!string.IsNullOrEmpty(txtDatabase.Text))
                {
                    CreateConnectionString(ref err, ClsMain.path);
                }
                else
                {
                    MessageBox.Show("Chưa có Server name", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Chưa có Server name", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cboAuthentication_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAuthentication.SelectedIndex == 0)
            {
                txtUserID.Enabled = false;
                txtPassword.Enabled = false;
            }
            else
            {
                txtUserID.Enabled = true;
                txtPassword.Enabled = true;
            }

        }
    }
}
