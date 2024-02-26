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
    public partial class Frm_QuanLyNguoiDung_Main : Form
    {
        public Frm_QuanLyNguoiDung_Main()
        {
            InitializeComponent();
        }
        BLL_NhanVien bd;
        string err = string.Empty;
        private void Frm_QuanLyNguoiDung_Main_Load(object sender, EventArgs e)
        {
            bd = new BLL_NhanVien(ClsMain.path);
            HienThiNhanVien();
        }

        private void HienThiNhanVien()
        {
            DataTable dataTable = new DataTable();
            dataTable = bd.GetNhanViens(ref err);
            dataGridView1.DataSource = dataTable;
        }
    }
}
