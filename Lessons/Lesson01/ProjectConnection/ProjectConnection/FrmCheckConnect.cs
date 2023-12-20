
using System.Windows.Forms;
//SQL provider
using System.Data;
using System.Data.SqlClient;

namespace ProjectConnection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private SqlConnection conn;
        private string connectionString = string.Empty;

        private string ChoiceConnectionString(bool winNT)
        {
            string connectionString = string.Empty;
            if (winNT)
            {
                connectionString = "server=MINHPHUC\\MSSQL2019;database=Data_ToDoList;integrated security=true;";
            }
            else
            {
                connectionString = "server=MINHPHUC\\MSSQL2019;database=Data_ToDoList;uid=sa;pwd=infor210385;";
            }
            return connectionString;
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            conn = new SqlConnection(ChoiceConnectionString(false));
        }

        private void btnCheckConnect_Click(object sender, System.EventArgs e)
        {
            if (CheckConnect())
            {
                MessageBox.Show("Connected successful");
            }
            else
            {
                MessageBox.Show("Connected not successful");
            }
        }
        private bool CheckConnect()
        {
            try
            {
                conn.Open();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
