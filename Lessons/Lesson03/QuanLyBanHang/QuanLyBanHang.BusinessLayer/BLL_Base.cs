using QuanLyBanHang.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.BusinessLayer
{
    public class BLL_Base
    {
        public MyDatabase myDatabase;
        public BLL_Base(string path)
        {
            myDatabase = new MyDatabase(path);
        }
    }
}
