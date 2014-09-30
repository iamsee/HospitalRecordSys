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
    /// PersonalHis.xaml 的交互逻辑
    /// </summary>
    public partial class PersonalHis : Window
    {
        Database db = new Database();
        DataTable dt = new DataTable();
        DataTable dtNum = new DataTable();
        DataTable dtYear = new DataTable();

        DataTable dtMonth = new DataTable();
        DataTable dtDay = new DataTable();
        DataTable dtPro = new DataTable();
        DataTable dtCity = new DataTable();
        DataTable dtDistrict = new DataTable();
        string moning;
        string afternoon;
        string night;
        string other;

        DataSet ds = new DataSet();
        string sqlString = string.Empty;

        CityandContury cc = new CityandContury();

        Time time =new Time();
        Num num = new Num();            
        public PersonalHis()
        {
            InitializeComponent();
            dtPro = cc.getprovincename();
            CB_1.ItemsSource = dtPro.DefaultView;

            CB_1.DisplayMemberPath = "ProvinceName";
            CB_1.SelectedValuePath = "ProvinceName";

            CB_1_Copy.ItemsSource = dtPro.DefaultView;
            CB_1_Copy.DisplayMemberPath = "ProvinceName";
            CB_1_Copy.SelectedValuePath = "ProvinceName";

            CB_PersonalHis_No1_GOLocalName__.ItemsSource = dtPro.DefaultView;
            CB_PersonalHis_No1_GOLocalName__.DisplayMemberPath = "ProvinceName";
            CB_PersonalHis_No1_GOLocalName__.SelectedValuePath = "ProvinceName";

            dtYear = time.getyear();
            
            CB_PersonalHis_No1_GOLocalTime_Year.ItemsSource = dtYear.DefaultView;
            CB_PersonalHis_No1_GOLocalTime_Year.DisplayMemberPath = "Year";
            CB_PersonalHis_No1_GOLocalTime_Year.SelectedValuePath = "Year";

            dtNum = num.getnum();
            CB_PersonalHis_No3_MarryAge.ItemsSource = dtNum.DefaultView;
            CB_PersonalHis_No3_MarryAge.DisplayMemberPath = "Num";
            CB_PersonalHis_No3_MarryAge.SelectedValuePath = "Num";

            CB_PersonalHis_No2_SmokeNum.ItemsSource = dtNum.DefaultView;
            CB_PersonalHis_No2_SmokeNum.DisplayMemberPath = "Num";
            CB_PersonalHis_No2_SmokeNum.SelectedValuePath = "Num";

            CB_PersonalHis_No2_SmokeLast.ItemsSource = dtNum.DefaultView;
            CB_PersonalHis_No2_SmokeLast.DisplayMemberPath = "Num";
            CB_PersonalHis_No2_SmokeLast.SelectedValuePath = "Num";

            CB_PersonalHis_No3_GraviditasTimes.ItemsSource = dtNum.DefaultView;
            CB_PersonalHis_No3_GraviditasTimes.DisplayMemberPath = "Num";
            CB_PersonalHis_No3_GraviditasTimes.SelectedValuePath = "Num";

            CB_PersonalHis_No3_GiveBirthToTimes.ItemsSource = dtNum.DefaultView;
            CB_PersonalHis_No3_GiveBirthToTimes.DisplayMemberPath = "Num";
            CB_PersonalHis_No3_GiveBirthToTimes.SelectedValuePath = "Num";

            CB_PersonalHis_No3_woman_1.ItemsSource = dtNum.DefaultView;
            CB_PersonalHis_No3_woman_1.DisplayMemberPath = "Num";
            CB_PersonalHis_No3_woman_1.SelectedValuePath = "Num";

            CB_PersonalHis_No3_woman_2.ItemsSource = dtNum.DefaultView;
            CB_PersonalHis_No3_woman_2.DisplayMemberPath = "Num";
            CB_PersonalHis_No3_woman_2.SelectedValuePath = "Num";
        }

        private void CB_1_DropDownClosed(object sender, EventArgs e)
        {
            dtCity = cc.getcityname();
            CB_2.ItemsSource = dtCity.DefaultView;
            CB_2.DisplayMemberPath = "CityName";
            CB_2.SelectedValuePath = "CityName";
        }

        private void CB_2_Copy_DropDownClosed(object sender, EventArgs e)
        {
            dtDistrict = cc.getdistrictname();
            CB_3_Copy.ItemsSource = dtDistrict.DefaultView;
            CB_3_Copy.DisplayMemberPath = "DistrictName";
            CB_3_Copy.SelectedValuePath = "DistrictName";
        }

        private void CB_PersonalHis_No1_GOLocalName_2_DropDownClosed(object sender, EventArgs e)
        {
            dtDistrict = cc.getdistrictname();
            CB_PersonalHis_No1_GOLocalName_3.ItemsSource = dtDistrict.DefaultView;
            CB_PersonalHis_No1_GOLocalName_3.DisplayMemberPath = "DistrictName";
            CB_PersonalHis_No1_GOLocalName_3.SelectedValuePath = "DistrictName";

        }

        private void CB_2_DropDownClosed(object sender, EventArgs e)
        {
            dtDistrict = cc.getdistrictname();
            CB_3.ItemsSource = dtDistrict.DefaultView;
            CB_3.DisplayMemberPath = "DistrictName";
            CB_3.SelectedValuePath = "DistrictName";
        }

        private void CB_1_Copy_DropDownClosed(object sender, EventArgs e)
        {
            dtCity = cc.getcityname();
            CB_2_Copy.ItemsSource = dtCity.DefaultView;
            CB_2_Copy.DisplayMemberPath = "CityName";
            CB_2_Copy.SelectedValuePath = "CityName";
        }

        private void CB_PersonalHis_No1_GOLocalName___DropDownClosed(object sender, EventArgs e)
        {
            dtCity = cc.getcityname();
            CB_PersonalHis_No1_GOLocalName_2.ItemsSource = dtCity.DefaultView;
            CB_PersonalHis_No1_GOLocalName_2.DisplayMemberPath = "CityName";
            CB_PersonalHis_No1_GOLocalName_2.SelectedValuePath = "CityName";
        }

        private void CB_PersonalHis_No1_GOLocalTime_Year_DropDownClosed(object sender, EventArgs e)
        {
            dtMonth = time.getmonth();
            CB_PersonalHis_No1_GOLocalTime_Month.ItemsSource = dtMonth.DefaultView;
            CB_PersonalHis_No1_GOLocalTime_Month.DisplayMemberPath = "Month";
            CB_PersonalHis_No1_GOLocalTime_Month.SelectedValuePath = "Month";
        }

        private void CB_PersonalHis_No1_GOLocalTime_Month_DropDownClosed(object sender, EventArgs e)
        {
            dtDay = time.getday();
            CB_PersonalHis_No1_GOLocalTime_Day.ItemsSource = dtDay.DefaultView;
            CB_PersonalHis_No1_GOLocalTime_Day.DisplayMemberPath = "Day";
            CB_PersonalHis_No1_GOLocalTime_Day.SelectedValuePath = "Day";
        }

        private void CB_1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cc.SelectProvinceName = CB_1.SelectedValue.ToString();
            CB_2.SelectedValue = "";
            CB_3.SelectedValue = "";
        }

        private void CB_2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cc.SelectCityName = CB_2.SelectedValue.ToString();
            CB_3.SelectedValue = "";
        }

        private void CB_PersonalHis_No1_GOLocalName___SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cc.SelectProvinceName = CB_PersonalHis_No1_GOLocalName__.SelectedValue.ToString();
            CB_PersonalHis_No1_GOLocalName_2.SelectedValue = "";
            CB_PersonalHis_No1_GOLocalName_3.SelectedValue = "";
        }

        private void CB_PersonalHis_No1_GOLocalName_2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cc.SelectCityName = CB_PersonalHis_No1_GOLocalName_2.SelectedValue.ToString();
            CB_PersonalHis_No1_GOLocalName_3.SelectedValue = "";
        }

        private void CB_1_Copy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cc.SelectProvinceName = CB_1_Copy.SelectedValue.ToString();
            CB_2_Copy.SelectedValue = "";
            CB_3_Copy.SelectedValue = "";
        }

       

         private void CB_2_Copy_SelectionChanged(object sender, SelectionChangedEventArgs e)
         {
             cc.SelectCityName = CB_2_Copy.SelectedValue.ToString();
             CB_3_Copy.SelectedValue = "";

         }

         private void CB_PersonalHis_No1_GOLocalTime_Year_SelectionChanged(object sender, SelectionChangedEventArgs e)
         {
             time.SelectYear = CB_PersonalHis_No1_GOLocalTime_Year.SelectedValue.ToString();
             CB_PersonalHis_No1_GOLocalTime_Month.SelectedValue = "";
             CB_PersonalHis_No1_GOLocalTime_Day.SelectedValue = "";
         }

         private void CB_PersonalHis_No1_GOLocalTime_Month_SelectionChanged(object sender, SelectionChangedEventArgs e)
         {
             time.SelectMonth = CB_PersonalHis_No1_GOLocalTime_Month.SelectedValue.ToString();
             CB_PersonalHis_No1_GOLocalTime_Day.SelectedValue = "";
         }

         private void CB_PersonalHis_No1_GOLocal_DropDownClosed(object sender, EventArgs e)
         {
             if((CB_PersonalHis_No1_GOLocal.SelectedItem as ComboBoxItem).Content.ToString() == "是")
             {
                 Grid_PersonalHis_No1_GOLocal.IsEnabled = true;
             }
             else
             {
                 Grid_PersonalHis_No1_GOLocal.IsEnabled = false;
             }
         }

         private void CB_PersonalHis_No2_Drink_DropDownClosed(object sender, EventArgs e)
         {
             if((CB_PersonalHis_No2_Drink.SelectedItem as ComboBoxItem).Content.ToString() == "是")
             {
                 Grid_IsDrink.IsEnabled = true;

             }
             else
             {
                 Grid_IsDrink.IsEnabled = false;
             }
         }

         private void CB_PersonalHis_No2_Smoke_DropDownClosed(object sender, EventArgs e)
         {
             if((CB_PersonalHis_No2_Smoke.SelectedItem as ComboBoxItem).Content.ToString() == "是")
             {

                 Grid_IsSmoke.IsEnabled = true;

             }
             else
             {
                 Grid_IsSmoke.IsEnabled = false;
             }
         }

         private void CB_Sex_DropDownClosed(object sender, EventArgs e)
         {
             if((CB_Sex.SelectedItem as ComboBoxItem).Content.ToString()=="女")
             {
                 Grid_woman.IsEnabled = true;
             }
             else
             {
                 Grid_woman.IsEnabled = false;
             }
         }

         private void But_Update_PersonalHis_Click(object sender, RoutedEventArgs e)
         {
             TB_PersonalHis tph = new TB_PersonalHis();
             tph.BIHNum = Lab_ShowBINNum.Content.ToString();
             tph.BirthLocal = CB_1.SelectedValue.ToString() + "-" + CB_2.SelectedValue.ToString() + "-" + CB_3.SelectedValue.ToString();
             tph.LiveLocal = CB_1_Copy.SelectedValue.ToString() + "-" + CB_2_Copy.SelectedValue.ToString() + "-" + CB_3_Copy.SelectedValue.ToString();
             if((CB_PersonalHis_No1_GOLocal.SelectedItem as ComboBoxItem).Content.ToString()=="是")
             {
                 tph.GoLocal_State = 1;
                 TB_PersonalHis_GOLocal tphg = new TB_PersonalHis_GOLocal();
                 tphg.BIHNum = Lab_ShowBINNum.Content.ToString();
   

                 tphg.LocalName = CB_PersonalHis_No1_GOLocalName__.SelectedValue.ToString() + "-" + CB_PersonalHis_No1_GOLocalName_2.SelectedValue.ToString() + "-" + CB_PersonalHis_No1_GOLocalName_3.SelectedValue.ToString();
                 tphg.LastTime = CB_PersonalHis_No1_GOLocalTime_Year.SelectedValue.ToString() + "/" + CB_PersonalHis_No1_GOLocalTime_Month.SelectedValue.ToString() + "/" + CB_PersonalHis_No1_GOLocalTime_Day.SelectedValue.ToString();                 tphg.update_TB_PersonalHis_GOLocal();

             }
             tph.JobHow = (CB_PersonalHis_No2_JobShow.SelectedItem as ComboBoxItem).Content.ToString();
            if((CB_PersonalHis_No2_JobShow.SelectedItem as ComboBoxItem).Content.ToString()=="有")
            {
                tph.JobEnviron_State = 1;
                TB_PersonalHis_JobEnviron tphje = new TB_PersonalHis_JobEnviron();
                tphje.BIHNum = Lab_ShowBINNum.Content.ToString();
           
                tphje.CompanyName = Text_PersonalHis_No2_JobName.Text.ToString();
                tphje.TypeOfWork = Text_PersonalHis_No2_JobTo.Text.ToString();
                tphje.update_TB_PersonalHis_JobEnviron();
            }
             if((CB_PersonalHis_No2_Drink.SelectedItem as ComboBoxItem).Content.ToString()=="是")
             {
                 tph.Drink_State = 1;
                 TB_PersonalHis_Drink tphd = new TB_PersonalHis_Drink();
                 tphd.BIHNum = Lab_ShowBINNum.Content.ToString();
              

                 tphd.DrinkMode = (CB_PersonalHis_No2_DrinkMode.SelectedItem as ComboBoxItem).Content.ToString();
                 tphd.DrinkNum = (CB_PersonalHis_No2_DrinkNum.SelectedItem as ComboBoxItem).Content.ToString();

                 tphd.update_TB_PersonalHis_Drink();

             }
             if((CB_PersonalHis_No2_Smoke.SelectedItem as ComboBoxItem).Content.ToString() == "是")
             {
                 tph.Smoke_State = 1;
                 TB_PersonalHis_Smoke tphs = new TB_PersonalHis_Smoke();
                 tphs.BIHNum = Lab_ShowBINNum.Content.ToString();

           //      tphs.SmokeLast = Convert.ToInt32((CB_PersonalHis_No2_SmokeLast.SelectedItem as ComboBoxItem).Content.ToString());
           //      tphs.SmokeNum = Convert.ToInt32((CB_PersonalHis_No2_SmokeNum.SelectionBoxItem as ComboBoxItem).Content.ToString());

                 tphs.update_TB_PersonalHis_Smoke();

                     


             }
             if ((CB_PersonalHis_No3_Marriage.SelectedItem as ComboBoxItem).Content.ToString() == "已婚")
             { 
              
                 tph.Marriage_State = 1;
                 TB_PersonalHis_Marriage tphm = new TB_PersonalHis_Marriage();
                 tphm.BIHNum = Lab_ShowBINNum.Content.ToString();
          
                 tphm.MarryAge = Convert.ToInt32((CB_PersonalHis_No3_BetterHalfNow.SelectedItem as ComboBoxItem).Content.ToString());
                     tphm.BetterHalfNow=(CB_PersonalHis_No3_BetterHalfNow.SelectedItem as ComboBoxItem).Content.ToString();
                     tphm.GraviditasTimes =Convert.ToInt32(CB_PersonalHis_No3_GraviditasTimes.SelectedValue.ToString());
                     tphm.GiveBirthToTimes = Convert.ToInt32(CB_PersonalHis_No3_GiveBirthToTimes.SelectedValue.ToString());

                     tphm.MensesStart = CB_PersonalHis_No3_woman_1.SelectedValue.ToString();
                     tphm.MensesOver = CB_PersonalHis_No3_woman_2.SelectedValue.ToString();
                     //tphm.MensesCycle = null;
                     //tphm.MensesDays = null;
                     //tphm.MensesNum = null;
                     //tphm.MensesPain = null;
                     //tphm.Leukorrhea =
                     tphm.update_TB_PersonalHis_Marriage();

             }
             if ((CB_PersonalHis_No2_OtherHabby.SelectedItem as ComboBoxItem).Content.ToString()=="有")
             {
                 tph.OtherHobby_State = 1;
             }
             tph.update_TB_PersonalHis();
             FamillyHis fh = new FamillyHis();
             fh.Lab_ShowBINNum.Content = this.Lab_ShowBINNum.Content;
             fh.Lab_ShowJobNum.Content = this.Lab_ShowJobNum.Content;
             fh.Lab_ShowBINName.Content = this.Lab_BINName.Content;
             fh.Show();
             this.Hide();
         }


    }
}

