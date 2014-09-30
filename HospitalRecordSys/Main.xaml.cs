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
    /// Main.xaml 的交互逻辑
    /// </summary>
    public partial class Main : Window
    {
        BIHNum bihnum = new BIHNum();
        public Main()
        {
            InitializeComponent();
            
        }

        private void But_UpdateBIHNum_Click(object sender, RoutedEventArgs e)
        {
            if(bihnum.checkBIHNum(Text_BIHnum.Text.Trim()) == true)
            {
                bihnum.insertBIHNum();

                UserBaseInfo ubi = new UserBaseInfo();
                ubi.Lab_ShowBINNum.Content = Text_BIHnum.Text.Trim();
                ubi.Lab_ShowJobNum.Content = this.Lab_ShowJobNum.Content;
                ubi.Show();
                this.Hide();


            }
            else
            {
                MessageBox.Show("此住院号已存在请检查录入");
            }
        }

        private void But_SearchBIHNum_Click(object sender, RoutedEventArgs e)
        {
            ReadyWord rw = new ReadyWord();


            rw.Lab_ShowBINNum.Content = this.Text_SearchBIHnum.Text.ToString();
            
            rw.Lab_ShowJobNum.Content = this.Lab_ShowJobNum.Content.ToString();
            string sqlstring = "select Name from TB_UserBaseInfo where BIHNum='" + Text_SearchBIHnum.Text.ToString()+"';";
           
            Database db = new Database();
            int state = db.ExecuteSQL(sqlstring);
           
            DataSet ds = new DataSet();
            ds = db.GetDataSet(sqlstring);
            rw.Lab_ShowBINName.Content = ds.Tables[0].Rows[0][0].ToString();

            rw.Show();
            this.Hide();
            
          
            
           
        }
    }
}
