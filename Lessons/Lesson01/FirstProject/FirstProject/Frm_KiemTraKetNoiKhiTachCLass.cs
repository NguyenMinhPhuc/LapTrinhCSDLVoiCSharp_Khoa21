using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstProject
{
    public partial class Frm_KiemTraKetNoiKhiTachCLass : Form
    {
        public Frm_KiemTraKetNoiKhiTachCLass()
        {
            InitializeComponent();
        }
        bool winNT = false;
        string err = string.Empty;
        string connectionString = string.Empty;
        MyDatabase myDatabase;

        private string GetConnectionString(bool winNT)
        {
            string connectionString = string.Empty;
            if (winNT)
            {
                connectionString = "server=MINHPHUC\\MSSQL2019;database=Data_QuanLiHocVien;Integrated security=true;";
            }
            else
            {
                connectionString = "server=MINHPHUC\\MSSQL2019;database=Data_QuanLiHocVien;uid=sa;pwd=infor210385;";
            }
            return connectionString;
        }
        private void Frm_KiemTraKetNoiKhiTachCLass_Load(object sender, EventArgs e)
        {
            myDatabase = new MyDatabase(GetConnectionString(winNT));
            this.Text = myDatabase.ConnectString;
        }

        private void btnKiemTraKetNoi_Click(object sender, EventArgs e)
        {
            if (myDatabase.CheckConnectToSql(ref err))
            {
                MessageBox.Show("Kết nối thành công đến SQL", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kết nối không thành công đến SQL do: \n " + err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void ckbWinNT_CheckedChanged(object sender, EventArgs e)
        {

            winNT = ckbWinNT.Checked;
            myDatabase = new MyDatabase(GetConnectionString(winNT));
            this.Text = myDatabase.ConnectString;
        }
    }
}
