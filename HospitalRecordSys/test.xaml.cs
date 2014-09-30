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
    /// test.xaml 的交互逻辑
    /// </summary>
    public partial class test : Window
    {
        CityandContury cc = new CityandContury();
        Num num = new Num();
        DataTable dtCity = new DataTable();
        DataTable dtDistrict = new DataTable();
        DataTable dtNum = new DataTable();

        DataTable dtYear = new DataTable();

        DataTable dtMonth = new DataTable();
        DataTable dtDay = new DataTable();

        Time time = new Time();
        

        
        
        
        public test()
        {
            
            InitializeComponent();
           
            DataTable dtPro = new DataTable();
                        dtPro = cc.getprovincename();
         
            CB_1.ItemsSource = dtPro.DefaultView;

            CB_1.DisplayMemberPath = "ProvinceName";
            CB_1.SelectedValuePath = "ProvinceName";


            dtNum = num.getnum();
            CB_Num.ItemsSource = dtNum.DefaultView;
            CB_Num.DisplayMemberPath = "Num";
            CB_Num.SelectedValuePath = "Num";



            dtYear = time.getyear();
            CB_Year.ItemsSource = dtYear.DefaultView;
            CB_Year.DisplayMemberPath = "Year";
            CB_Year.SelectedValuePath = "Year";

            

        }

        private void CB_1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

           
          //  CB_2.Items.Clear();
            cc.SelectProvinceName = CB_1.SelectedValue.ToString();
            CB_2.SelectedValue = "";
           
            
            
        }
        private void CB_2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

           
            cc.SelectCityName = CB_2.SelectedValue.ToString();
            CB_3.SelectedValue = "";
           
           
            
          //  MessageBox.Show(cc.SelectCityName);
        }
      
       
     

      

        private void CB_1_DropDownClosed(object sender, EventArgs e)
        {
            dtCity = cc.getcityname();
            CB_2.ItemsSource = dtCity.DefaultView;
            CB_2.DisplayMemberPath = "CityName";
            CB_2.SelectedValuePath = "CityName";
        }

        private void CB_2_DropDownClosed(object sender, EventArgs e)
        {
            dtDistrict = cc.getdistrictname();

            CB_3.ItemsSource = dtDistrict.DefaultView;
            CB_3.DisplayMemberPath = "DistrictName";
            CB_3.SelectedValuePath = "DistrictName";

        }

        //private void CB_Year_DropDownOpened(object sender, EventArgs e)
        //{


        //}

        private void CB_Year_DropDownClosed(object sender, EventArgs e)
        {
            
            dtMonth = time.getmonth();
            CB_Month.ItemsSource = dtMonth.DefaultView;
            CB_Month.DisplayMemberPath = "Month";
            CB_Month.SelectedValuePath = "Month";
        }

        private void CB_Month_DropDownClosed(object sender, EventArgs e)
        {
            
            dtDay = time.getday();
            CB_Day.ItemsSource = dtDay.DefaultView;
            CB_Day.DisplayMemberPath = "Day";
            CB_Day.SelectedValuePath = "Day";
         
            
                
        }

        private void CB_Year_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            time.SelectYear =   CB_Year.SelectedValue.ToString();
            CB_Month.SelectedValue = "";
            CB_Day.SelectedValue = "";
            
        }

        private void CB_Month_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            time.SelectMonth = CB_Month.SelectedValue.ToString();
            CB_Day.SelectedValue = "";
            //MessageBox.Show(time.SelectMonth);
        }




       




    }
}
