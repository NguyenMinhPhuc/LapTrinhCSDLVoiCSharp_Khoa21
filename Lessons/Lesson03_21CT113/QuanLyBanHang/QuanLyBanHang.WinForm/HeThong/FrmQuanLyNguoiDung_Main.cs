using QuanLyBanHang.BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.WinForm.HeThong
{
    public partial class FrmQuanLyNguoiDung_Main : Form
    {
        public FrmQuanLyNguoiDung_Main()
        {
            InitializeComponent();
        }
        BLL_HeThong bll;
        string err = string.Empty;

        private void FrmQuanLyNguoiDung_Main_Load(object sender, EventArgs e)
        {
            bll = new BLL_HeThong(ClsMain.pathConnectFile);
            HienThiDanhSach();
        }

        private void HienThiDanhSach()
        {
            DataTable dataTable = new DataTable();

            dataTable = bll.GetUserByID(ref err, 4.ToString());
            dataGridView1.DataSource = dataTable;
        }
    }
}
