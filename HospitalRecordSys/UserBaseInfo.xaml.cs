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
    /// UserBaseInfo.xaml 的交互逻辑
    /// </summary>
    public partial class UserBaseInfo : Window
    {
        Num num = new Num();
        DataTable dtCity = new DataTable();
        DataTable dtDistrict = new DataTable();
        DataTable dtNum = new DataTable();

        DataTable dtYear = new DataTable();

        DataTable dtMonth = new DataTable();
        DataTable dtDay = new DataTable();

        Time time = new Time();
         
        
        public UserBaseInfo()
        {
            InitializeComponent();

            dtYear = time.getyear();
            CB_1.ItemsSource = dtYear.DefaultView;
            CB_1.DisplayMemberPath = "Year";
            CB_1.SelectedValuePath = "Year";
            dtYear = time.getyear();
            CB_1_Copy.ItemsSource = dtYear.DefaultView;
            CB_1_Copy.DisplayMemberPath = "Year";
            CB_1_Copy.SelectedValuePath = "Year";

            dtNum = num.getnum();
            CB_Age.ItemsSource = dtNum.DefaultView;
            CB_Age.DisplayMemberPath = "Num";
            CB_Age.SelectedValuePath = "Num";
           
           
            
        }

        private void But_JobAdmin_Update_Click(object sender, RoutedEventArgs e)
        {
            
            Database db = new Database();
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            string sqlString = string.Empty;
            UserBaseClass ubc = new UserBaseClass();
            ubc.JobNum = Lab_ShowJobNum.Content.ToString();
            ubc.Name = Text_Name.Text.Trim();
            ubc.BIHNum = this.Lab_ShowBINNum.Content.ToString();
          
            JobAdmin ja = new JobAdmin();
            
            if(RB_Sex_Man.IsChecked==true)
            {
                ubc.Sex = "男";
            }
            else if(RB_Sex_Woman.IsChecked == true)
            {
                ubc.Sex = "女";

            }

            if (CB_Age.SelectedValue == null)
            {
                MessageBox.Show("年龄未填写");
            }
            else
            { 
            ubc.Age = Convert.ToInt32(CB_Age.SelectedValue.ToString());
            }
            ubc.MarryState = CB_MarryShow.Text.Trim();
            ubc.Nation = CB_Nation.Text.Trim();
            if (RB_Teacher.IsChecked == true)
            {
                ubc.Vocation = "教师";
            }
          
            else if (RB_Docter.IsChecked == true)
            {
                ubc.Vocation = "医生";
            }
            else if (RB_Office.IsChecked == true)
            {
                ubc.Vocation = "普通上班";
            }
            else if (RB_VocationOther.IsChecked == true)
            {
                ubc.Vocation = Text_VocationAdd.Text.Trim();
            }

            ubc.BirthLocal = Text_BirthLocal.Text.Trim();
            ubc.LiveLocal = Text_LiveLocal.Text.Trim();
            ubc.WorkOrg = Text_WorkOrg.Text.Trim();
            
            if(RB_Self.IsChecked == true)
            {
                ubc.DeclarePer = "本人";
            }
            if(RB_Parents.IsChecked == true)
            {

                ubc.DeclarePer = "父母";
            }
            if(RB_Child.IsChecked == true)
            {
                ubc.DeclarePer = "子女";

            }
            if (RB_SickSpeakOther.IsChecked == true)
            {
                ubc.DeclarePer = Text_SickSpeakOther.Text.Trim();
            }
            ubc.DeclarePer = "陈述人:"+ubc.DeclarePer+",陈述人姓名:" + Text_SickSpeak_Name.Text.Trim();
            if (RB_BIHTimeNow.IsChecked == true)
            {
                ubc.BINTime = "GETDATE()";
            }
            else if(RB_BIHTimeWrite.IsChecked == true)
            {

                ubc.BINTime ="'"+CB_1.SelectedValue.ToString()+"/"+CB_2.SelectedValue.ToString()+"/"+CB_3.SelectedValue.ToString()+"'";
            }

            if(RB_RecordTimeNow.IsChecked == true)
            {
                ubc.RecordTime = "GETDATE()";
            }
            else if(RB_RecordTimeWrite.IsChecked == true)
            {
                ubc.RecordTime = "'"+CB_1_Copy.SelectedValue.ToString()+"/"+CB_2_Copy.SelectedValue.ToString()+"/"+CB_3_Copy.SelectedValue.ToString()+"'";
            }

            ubc.update_TB_UserBaseInfo();



            

            MessageBox.Show(ubc.DeclarePer);
            PHI phi = new PHI();
            phi.Lab_ShowBINNum.Content = this.Lab_ShowBINNum.Content;
            phi.Lab_ShowJobNum.Content = this.Lab_ShowJobNum.Content;
            phi.Lab_ShowBINName.Content = this.Text_Name.Text.Trim();


            phi.Show();
            this.Hide();
            
        }

        private void CB_1_DropDownClosed(object sender, EventArgs e)
        {

            dtMonth = time.getmonth();
            CB_2.ItemsSource = dtMonth.DefaultView;
            CB_2.DisplayMemberPath = "Month";
            CB_2.SelectedValuePath = "Month";
        }

        private void CB_2_DropDownClosed(object sender, EventArgs e)
        {

            dtDay = time.getday();
            CB_3.ItemsSource = dtDay.DefaultView;
            CB_3.DisplayMemberPath = "Day";
            CB_3.SelectedValuePath = "Day";



        }

        private void CB_1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            time.SelectYear = CB_1.SelectedValue.ToString();
            CB_2.SelectedValue = "";
            CB_3.SelectedValue = "";

        }

        private void CB_2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          //  time.SelectMonth = CB_2.SelectedValue.ToString();
            CB_3.SelectedValue = "";
            //MessageBox.Show(time.SelectMonth);
        }


        private void CB_1_Copy_DropDownClosed(object sender, EventArgs e)
        {

            dtMonth = time.getmonth();
            CB_2_Copy.ItemsSource = dtMonth.DefaultView;
            CB_2_Copy.DisplayMemberPath = "Month";
            CB_2_Copy.SelectedValuePath = "Month";
        }

        private void CB_2_Copy_DropDownClosed(object sender, EventArgs e)
        {

            dtDay = time.getday();
            CB_3_Copy.ItemsSource = dtDay.DefaultView;
            CB_3_Copy.DisplayMemberPath = "Day";
            CB_3_Copy.SelectedValuePath = "Day";



        }

        private void CB_1_Copy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            time.SelectYear = CB_1_Copy.SelectedValue.ToString();
            CB_2_Copy.SelectedValue = "";
            CB_3_Copy.SelectedValue = "";

        }

        private void CB_2_Copy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            time.SelectMonth = CB_2_Copy.SelectedValue.ToString();
            CB_3_Copy.SelectedValue = "";
            //MessageBox.Show(time.SelectMonth);
        }

       

       
        
    }
}
