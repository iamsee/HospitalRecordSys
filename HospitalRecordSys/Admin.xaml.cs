using System;
using System.Collections.Generic;
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
    /// Admin.xaml 的交互逻辑
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TB_Admin ta = new TB_Admin();
            try { 
            ta.JobNum = Convert.ToInt32(Text_JobNum.Text.ToString());
                }
            catch
            {
                MessageBox.Show("您输入的工作号不正确");
            
            }
            ta.JobName = Text_JobName.Text.ToString();
            ta.Pwd = Text_JobPwd.Text.ToString();
            ta.Update_TB_JobAdmin();
            if(ta.state > 0)
            {
                MessageBox.Show("增加医生成功");
               
            }
            else
            {
                MessageBox.Show("增加医生失败");
            }
        }
    }
}
