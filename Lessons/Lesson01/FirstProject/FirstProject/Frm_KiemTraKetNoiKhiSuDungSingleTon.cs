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
    public partial class Frm_KiemTraKetNoiKhiSuDungSingleTon : Form
    {
        public Frm_KiemTraKetNoiKhiSuDungSingleTon()
        {
            InitializeComponent();
        }
        string err = string.Empty;
        bool winNT = false;
        private void Frm_KiemTraKetNoiKhiSuDungSingleTon_Load(object sender, EventArgs e)
        {
            this.Text = MyDatabase_SingleTon.Instance.ConnectString;
            MyDatabase_SingleTon.Instance.WinNT = ckbWinNT.Checked;
        }

        private void btnKiemTraKetNoi_Click(object sender, EventArgs e)
        {
            if (MyDatabase_SingleTon.Instance.CheckConnectToSql(ref err))
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
            MyDatabase_SingleTon.Instance.WinNT = ckbWinNT.Checked;
            this.Text = MyDatabase_SingleTon.Instance.ConnectString;

            MessageBox.Show("Vì Design pattern sẽ đảm bảo đối tượng mydatabase-SingleTon chỉ được tạo ra một lần duy nhất khi khởi tạo lần đầu.\n Nên khi ta có đổi chuỗi kết nối của đối tượng thì đối tượng kết nối cũng sẽ không thay đổi. do đó khi muốn thay đổi kết nối cần khởi động lại chương trình để thây đổi", "Giải thích", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
