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
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
    {
        Database db = new Database();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string sqlString = string.Empty;
        public Login()
        {
            InitializeComponent();
        }

        private void But_Login_Click(object sender, RoutedEventArgs e)
        {
            


            sqlString = "select * from TB_JobAdmin where JobNum =" + Text_JobNum.Text.Trim() + "and Pwd=" + Text_JobPwd.Text.Trim() + ";";
            ds = db.GetDataSet(sqlString);
            if (ds.Tables[0].Rows.Count > 0)
            {
                JobAdmin ja = new JobAdmin();
                ja.JobNum = Text_JobNum.Text.Trim();
                ja.JobName = ds.Tables[0].Rows[0][2].ToString();
                Main main = new Main();
                PNA pna = new PNA();
                main.Lab_ShowJobNum.Content = ja.JobNum;
                
                
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("账号或密码错误，请重新输入");
                Text_JobNum.Text = "";
                Text_JobPwd.Text = "";
                Text_JobNum.Focus();
                return;
            }
        }

      
    }
}
