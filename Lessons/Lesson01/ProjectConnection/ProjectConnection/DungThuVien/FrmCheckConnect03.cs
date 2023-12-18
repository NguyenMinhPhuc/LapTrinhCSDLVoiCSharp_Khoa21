using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer;

namespace ProjectConnection.DungThuVien
{
    public partial class FrmCheckConnect03 : Form
    {
        public FrmCheckConnect03()
        {
            InitializeComponent();
        }
        MyDatabase myDatabase;
        string err = string.Empty;
        private void btnCheckConnect_Click(object sender, EventArgs e)
        {
            myDatabase = new MyDatabase("");
        }

        private void FrmCheckConnect03_Load(object sender, EventArgs e)
        {
            if (myDatabase.CheckConnect(ref err))
            {
                MessageBox.Show("thanh cong");
            }
            else
            {
                MessageBox.Show("Khong thanh cong");
            }
        }
    }
}
