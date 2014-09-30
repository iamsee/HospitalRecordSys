using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HospitalRecordSys
{
    /// <summary>
    /// AdminLogin.xaml 的交互逻辑
    /// </summary>
    public partial class AdminLogin : Window
    {
        Database db = new Database();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string sqlString = string.Empty;
        public AdminLogin()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sqlString = "select * from TB_Admin where Name =" + Text_Name.Text.Trim() + "and Pwd=" + Text_Pwd.Text.Trim() + ";";
            ds = db.GetDataSet(sqlString);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Admin admin = new Admin();



                admin.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("账号或密码错误，请重新输入");
                Text_Name.Text = "";
                Text_Pwd.Text = "";
                Text_Name.Focus();
                return;
            }
        }
    }
}
