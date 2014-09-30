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
    /// BEA.xaml 的交互逻辑
    /// </summary>
    public partial class BEA : Window
    {
        Database db = new Database();
        DataTable dt = new DataTable();
        DataTable dtNum = new DataTable();
        DataTable dtYear = new DataTable();

        DataTable dtMonth = new DataTable();
        DataTable dtDay = new DataTable();
        string moning;
        string afternoon;
        string night;
        string other;

        DataSet ds = new DataSet();
        string sqlString = string.Empty;

        Num num = new Num();
        Time time = new Time();
        public BEA()
        {
            InitializeComponent();

            dtNum = num.getnum();
            CB_RadidBreath_EveryLastTime.ItemsSource = dtNum.DefaultView;
            CB_RadidBreath_EveryLastTime.DisplayMemberPath = "Num";
            CB_RadidBreath_EveryLastTime.SelectedValuePath = "Num";

            CB_RadidBreath_EveryDay_Times.ItemsSource = dtNum.DefaultView;
            CB_RadidBreath_EveryDay_Times.DisplayMemberPath = "Num";
            CB_RadidBreath_EveryDay_Times.SelectedValuePath = "Num";

            dtYear = time.getyear();
            CB_RadidBreath_StartTime_Year.ItemsSource = dtYear.DefaultView;
            CB_RadidBreath_StartTime_Year.DisplayMemberPath = "Year";
            CB_RadidBreath_StartTime_Year.SelectedValuePath = "Year";

            CB_BEA_Cough_StartTime_Year.ItemsSource = dtYear.DefaultView;
            CB_BEA_Cough_StartTime_Year.DisplayMemberPath = "Year";
            CB_BEA_Cough_StartTime_Year.SelectedValuePath = "Year";


        }

        private void CBox_RapidBreath_Click(object sender, RoutedEventArgs e)
        {
            if (CBox_RapidBreath.IsChecked == true)
            {
                Grid_RapidBreath.IsEnabled = true;
            }
            else
            {
                Grid_RapidBreath.IsEnabled = false;
            }
        }

        private void CBox_Cough_Click(object sender, RoutedEventArgs e)
        {
            if (CBox_Cough.IsChecked == true)
            {
                Grid_BEACough.IsEnabled = true;
            }
            else
            {
                Grid_BEACough.IsEnabled = false;
            }
        }

        private void CBox_EarlierCheck_Click(object sender, RoutedEventArgs e)
        {
            if (CBox_EarlierCheck.IsChecked == true)
            {

                Grid_EarlierCheck.IsEnabled = true;
            }
            else
            {
                Grid_EarlierCheck.IsEnabled = false;
            }
        }

        private void CB_RadidBreath_StartTime_Year_DropDownClosed(object sender, EventArgs e)
        {
            dtMonth = time.getmonth();
            CB_RadidBreath_StartTime_Month.ItemsSource = dtMonth.DefaultView;
            CB_RadidBreath_StartTime_Month.DisplayMemberPath = "Month";
            CB_RadidBreath_StartTime_Month.SelectedValuePath = "Month";
        }

        private void CB_RadidBreath_StartTime_Month_DropDownClosed(object sender, EventArgs e)
        {
            dtDay = time.getday();

            CB_RadidBreath_StartTime_Day.ItemsSource = dtDay.DefaultView;
            CB_RadidBreath_StartTime_Day.DisplayMemberPath = "Day";
            CB_RadidBreath_StartTime_Day.SelectedValuePath = "Day";
        }

        private void CB_BEA_Cough_StartTime_Year_DropDownClosed(object sender, EventArgs e)
        {
            dtMonth = time.getmonth();

            CB_BEA_Cough_StartTime_Month.ItemsSource = dtMonth.DefaultView;
            CB_BEA_Cough_StartTime_Month.DisplayMemberPath = "Month";
            CB_BEA_Cough_StartTime_Month.SelectedValuePath = "Month";
        }

        private void CB_BEA_Cough_StartTime_Month_DropDownClosed(object sender, EventArgs e)
        {
            dtDay = time.getday();

            CB_BEA_Cough_StartTime_Day.ItemsSource = dtDay.DefaultView;
            CB_BEA_Cough_StartTime_Day.DisplayMemberPath = "Day";
            CB_BEA_Cough_StartTime_Day.SelectedValuePath = "Day";
        }

        private void CB_RadidBreath_StartTime_Year_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            time.SelectYear = CB_RadidBreath_StartTime_Year.SelectedValue.ToString();
            CB_RadidBreath_StartTime_Month.SelectedValue = "";
            CB_RadidBreath_StartTime_Day.SelectedValue = "";
        }

        private void CB_RadidBreath_StartTime_Month_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            time.SelectMonth = CB_RadidBreath_StartTime_Month.SelectedValue.ToString();
            CB_RadidBreath_StartTime_Day.SelectedValue = "";
        }

        private void CB_BEA_Cough_StartTime_Year_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            time.SelectYear = CB_BEA_Cough_StartTime_Year.SelectedValue.ToString();
            CB_BEA_Cough_StartTime_Month.SelectedValue = "";
            CB_BEA_Cough_StartTime_Day.SelectedValue = "";
        }

        private void CB_BEA_Cough_StartTime_Month_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            time.SelectMonth = CB_BEA_Cough_StartTime_Month.SelectedValue.ToString();
            CB_BEA_Cough_StartTime_Day.SelectedValue = "";
        }



        private void CB_RadidBreath_StartDeepTime_DropDownClosed(object sender, EventArgs e)
        {
            if ((CB_RadidBreath_StartDeepTime.SelectedItem as ComboBoxItem).Content.ToString() == "有")
            {
                Grid_RadidBreath_StartDeepTime.IsEnabled = true;
            }
            else
            {
                Grid_RadidBreath_StartDeepTime.IsEnabled = false;
            }
        }

        private void CB_RadidBreath_Better_DropDownClosed(object sender, EventArgs e)
        {
            if ((CB_RadidBreath_Better.SelectedItem as ComboBoxItem).Content.ToString() == "是")
            {
                Grid_RadidBreath_Better_Drug.IsEnabled = true;
            }
            else
            {
                Grid_RadidBreath_Better_Drug.IsEnabled = false;

            }
        }

        private void CB_BEA_Luggies_DropDownClosed(object sender, EventArgs e)
        {
            if ((CB_BEA_Luggies.SelectedItem as ComboBoxItem).Content.ToString() == "有")
            {
                Grid_Luggies.IsEnabled = true;
            }
            else
            {
                Grid_Luggies.IsEnabled = false;
            }
        }

        private void CBox_EarlierCheck_1_Click(object sender, RoutedEventArgs e)
        {
            if (CBox_EarlierCheck_1.IsChecked == true)
            {
                CB_EarlierCheck_1.IsEnabled = true;
            }
            else
            {
                CB_EarlierCheck_1.IsEnabled = false;
            }
        }

        private void CBox_EarlierCheck_2_Click(object sender, RoutedEventArgs e)
        {
            if (CBox_EarlierCheck_2.IsChecked == true)
            {
                CB_EarlierCheck_2.IsEnabled = true;
            }
            else
            {
                CB_EarlierCheck_2.IsEnabled = false;
            }
        }

        private void CBox_EarlierCheck_3_Click(object sender, RoutedEventArgs e)
        {
            if (CBox_EarlierCheck_3.IsChecked == true)
            {

                CB_EarlierCheck_3.IsEnabled = true;
            }
            else
            {
                CB_EarlierCheck_3.IsEnabled = false;
            }
        }

        private void CBox_EarlierCheck_4_Click(object sender, RoutedEventArgs e)
        {
            if (CBox_EarlierCheck_4.IsEnabled == true)
            {
                Text_EarlierCheck_4.IsEnabled = true;
            }
            else
            {
                Text_EarlierCheck_4.IsEnabled = false;
            }
        }

        private void CBox_EarlierCheck_5_Click(object sender, RoutedEventArgs e)
        {
            if (CBox_EarlierCheck_5.IsChecked == true)
            {
                Grid_EarlierCheck_5.IsEnabled = true;
            }
            else
            {
                Grid_EarlierCheck_5.IsEnabled = false;
            }

        }

        private void CB_RadidBreath_Better_DropDownClosed_1(object sender, EventArgs e)
        {
            if ((CB_RadidBreath_Better.SelectedItem as ComboBoxItem).Content.ToString() == "能")
            {
                CB_RadidBreath_Better_Show.IsEnabled = true;
            }
            else
            {
                CB_RadidBreath_Better_Show.IsEnabled = false;
            }
        }

        private void CB_RadidBreath_Better_Show_DropDownClosed(object sender, EventArgs e)
        {
            if (((CB_RadidBreath_Better_Show.SelectedItem as ComboBoxItem).Content.ToString() == "用药缓解") || ((CB_RadidBreath_Better_Show.SelectedItem as ComboBoxItem).Content.ToString() == "用药无缓解"))
            {
                Grid_RadidBreath_Better_Drug.IsEnabled = true;

            }
            else
            {
                Grid_RadidBreath_Better_Drug.IsEnabled = false;
            }
        }
        private void CB_RadidBreath_DropDownClosed(object sender, EventArgs e)
        {
            if ((CB_RadidBreath.SelectedItem as ComboBoxItem).Content.ToString() == "与外界有关")
            {
                Grid_Show_RadidBreath.IsEnabled = true;
            }
            else
            {
                Grid_Show_RadidBreath.IsEnabled = false;
            }
        }

        private void CB_RadidBreath_8_Click(object sender, RoutedEventArgs e)
        {
            if (CB_RadidBreath_7.IsChecked == true)
            {
                Text_Show_RadidBreath_Other.IsEnabled = true;
            }
            else
            {
                Text_Show_RadidBreath_Other.IsEnabled = false;
            }
        }

        private void CB_RadidBreath_StartDeepTime_4_Click(object sender, RoutedEventArgs e)
        {
            if (CB_RadidBreath_StartDeepTime_4.IsChecked == true)
            {
                Text_RadidBreath_StartDeepTime_4.IsEnabled = true;
            }
            else
            {

                Text_RadidBreath_StartDeepTime_4.IsEnabled = false;
            }
        }


        private void CB_BEA_BloodLuggiesCough_DropDownClosed(object sender, EventArgs e)
        {
            if (((CB_BEA_BloodLuggiesCough.SelectedItem as ComboBoxItem).Content.ToString() == "偶尔") || ((CB_BEA_BloodLuggiesCough.SelectedItem as ComboBoxItem).Content.ToString() == "多"))
            {
                Grid_BEA_BloodLuggiesCough_Show.IsEnabled = true;
            }
            else
            {
                Grid_BEA_BloodLuggiesCough_Show.IsEnabled = false;
            }
        }




        private void But_update_PHI_BEA_Click(object sender, RoutedEventArgs e)
        {
            PHI_BEA pb = new PHI_BEA();
            pb.BIHNum = Lab_ShowBINNum.Content.ToString();
  
            #region 喘息
            if (CBox_RapidBreath.IsChecked == true)
            {
                pb.RapidBreath_State = 1;


                PHI_BEA_RapidBreath pbr = new PHI_BEA_RapidBreath();
                if ((CB_RadidBreath.SelectedItem as ComboBoxItem).Content.ToString() == "与外界有关")
                {
                    pbr.BIHNum = Lab_ShowBINNum.Content.ToString();
                 
                    string cb_1, cb_2, cb_3, cb_4, cb_5, cb_6, cb_7;
                    if (CB_RadidBreath_1.IsChecked == true)
                    {
                        cb_1 = "基础变应原、";
                    }
                    else
                    {
                        cb_1 = "";
                    }
                    if (CB_RadidBreath_2.IsChecked == true)
                    {
                        cb_2 = "冷空气、";
                    }
                    else
                    {
                        cb_2 = "";
                    }
                    if (CB_RadidBreath_3.IsChecked == true)
                    {
                        cb_3 = "物理刺激、";
                    }
                    else
                    {
                        cb_3 = "";
                    }
                    if (CB_RadidBreath_4.IsChecked == true)
                    {
                        cb_4 = "化学刺激、";
                    }
                    else
                    {
                        cb_4 = "";
                    }
                    if (CB_RadidBreath_5.IsChecked == true)
                    {
                        cb_5 = "病毒性呼吸道感染、";
                    }
                    else
                    {
                        cb_5 = "";
                    }
                    if (CB_RadidBreath_6.IsChecked == true)
                    {
                        cb_6 = "运动";
                    }
                    else
                    {
                        cb_6 = "";
                    }
                    if (CB_RadidBreath_7.IsChecked == true)
                    {
                        cb_7 = Text_Show_RadidBreath_Other.Text.Trim();
                    }
                    else
                    {
                        cb_7 = "";
                    }

                    pbr.RadidBreath = "与 " + cb_1 + cb_2 + cb_3 + cb_4 + cb_5 + cb_6 + cb_7 + " 有关";
                }
                else
                {
                    pbr.RadidBreath = "与外界无关";
                }
                pbr.StartTime = CB_RadidBreath_StartTime_Year.SelectedValue.ToString() + "/" + CB_RadidBreath_StartTime_Month.SelectedValue.ToString() + "/" + CB_RadidBreath_StartTime_Day.SelectedValue.ToString();
                pbr.LastTime = CB_RadidBreath_StartTime_Year.SelectedValue.ToString() + "小时";
                pbr.CoutNum = Convert.ToInt32(CB_RadidBreath_EveryDay_Times.SelectedValue.ToString());
                if ((CB_RadidBreath_StartDeepTime.SelectedItem as ComboBoxItem).Content.ToString() == "有")
                {
                    string morning;
                    string afternoon;
                    string night;
                    string other;
                    if (CB_RadidBreath_StartDeepTime_1.IsChecked == true)
                    {
                        morning = "早晨、";
                    }
                    else
                    {
                        morning = "";
                    }
                    if (CB_RadidBreath_StartDeepTime_2.IsChecked == true)
                    {
                        afternoon = "下午、";
                    }
                    else
                    {
                        afternoon = "";
                    }
                    if (CB_RadidBreath_StartDeepTime_3.IsChecked == true)
                    {
                        night = "晚上、";
                    }
                    else
                    {
                        night = "";
                    }
                    if (CB_RadidBreath_StartDeepTime_4.IsChecked == true)
                    {
                        other = Text_RadidBreath_StartDeepTime_4.Text.Trim();
                    }
                    else
                    {
                        other = "";
                    }
                    pbr.DeepShow = morning + afternoon + night + other;
                }
                else
                {
                    pbr.DeepShow = "无";
                }

                if ((CB_RadidBreath_Better.SelectedItem as ComboBoxItem).Content.ToString() == "能")
                {
                    pbr.RelieveShow_State = 1;
                    PHI_BEA_RapidBreath_RelieveShow pbrr = new PHI_BEA_RapidBreath_RelieveShow();
                    pbrr.BIHNum = Lab_ShowBINNum.Content.ToString();
              
                    if ((CB_RadidBreath_Better_Show.SelectedItem as ComboBoxItem).Content.ToString() == "不用药缓解")
                    {
                        pbrr.NoDrugGood = "不用药缓解";
                    }
                    else if ((CB_RadidBreath_Better_Show.SelectedItem as ComboBoxItem).Content.ToString() == "用药缓解")
                    {
                        pbrr.DrugGood = "用药缓解" + " ,药名:" + Text_RadidBreath_Better_DrugName.Text.Trim();
                    }
                    else if ((CB_RadidBreath_Better_Show.SelectedItem as ComboBoxItem).Content.ToString() == "用药无缓解")
                    {
                        pbrr.DrugBad = "用药无缓解" + " ,药名:" + Text_RadidBreath_Better_DrugName.Text.Trim();
                    }
                    pbrr.update_PHI_BEA_RapidBreath_RelieveShow();
                }
                else
                {
                    pbr.RelieveShow_State = 0;
                }
                pbr.update_PHI_BEA_RapidBreath();




            }
            #endregion
            #region 咳嗽
            if (CBox_Cough.IsChecked == true)
            {
                pb.Cough_State = 1;
                PHI_BEA_Cough pbc = new PHI_BEA_Cough();
                pbc.BIHNum = Lab_ShowBINNum.Content.ToString();
         
                pbc.StartTime = CB_BEA_Cough_StartTime_Year.SelectedValue.ToString() + "/" + CB_BEA_Cough_StartTime_Month.SelectedValue.ToString() + "/" + CB_BEA_Cough_StartTime_Day.SelectedValue.ToString();
                if ((CB_BEA_Luggies.SelectedItem as ComboBoxItem).Content.ToString() == "有")
                {
                    pbc.Luggies = 1;
                    PHI_BEA_Cough_Luggies pbcl = new PHI_BEA_Cough_Luggies();

                    pbcl.BIHNum = Lab_ShowBINNum.Content.ToString();
                
                    pbcl.Color = (CB_BEA_ColorLuggiesCough.SelectedItem as ComboBoxItem).Content.ToString();
                    pbcl.LuggiesAmount = (CB_BEA_Luggies_Cough.SelectedItem as ComboBoxItem).Content.ToString();
                    if ((CB_BEA_BloodLuggiesCough.SelectedItem as ComboBoxItem).Content.ToString() == "偶尔")
                    {
                        pbcl.BloodLuggies_State = 1;
                        PHI_BEA_Cough_Luggies_BloodLuggies pbclb = new PHI_BEA_Cough_Luggies_BloodLuggies();
                        pbclb.BIHNum = Lab_ShowBINNum.Content.ToString();
                      
                        pbclb.BloodColor = (CB_BEA_BloodLuggiesCough_Color.SelectedItem as ComboBoxItem).Content.ToString();

                        pbclb.BloodNuture = (CB_BEA_BloodLuggiesCough_Num.SelectedItem as ComboBoxItem).Content.ToString();

                        pbclb.update_PHI_BEA_Cough_Luggies_BloodLuggies();

                    }
                    else if ((CB_BEA_BloodLuggiesCough.SelectedItem as ComboBoxItem).Content.ToString() == "多")
                    {
                        pbcl.BloodLuggies_State = 2;
                        PHI_BEA_Cough_Luggies_BloodLuggies pbclb = new PHI_BEA_Cough_Luggies_BloodLuggies();
                        pbclb.BIHNum = Lab_ShowBINNum.Content.ToString();
               
                        pbclb.BloodColor = (CB_BEA_BloodLuggiesCough_Color.SelectedItem as ComboBoxItem).Content.ToString();

                        pbclb.BloodNuture = (CB_BEA_BloodLuggiesCough_Num.SelectedItem as ComboBoxItem).Content.ToString();

                        pbclb.update_PHI_BEA_Cough_Luggies_BloodLuggies();

                    }
                    pbcl.update_PHI_BEA_Cough_Luggies();

                }
                pbc.update_PHI_BEA_Cough();
            }
            #endregion
            if (CBox_EarlierCheck.IsChecked == true)
            {
                pb.EarlierCheck = 1;
            }
            pb.update_PHI_BEA();

            this.Hide();

            PHI phi = new PHI();
            PHI_State ps = new PHI_State();
            
            COPD copd = new COPD();
            BEA bea = new BEA();
            PHI_CA ca = new PHI_CA();
            PHI_Pleuraleffusion peff = new PHI_Pleuraleffusion();
            
         

            ps.BIHNum = Lab_ShowBINNum.Content.ToString();
            ps.get_TB_PHI();
                if (ps.COPD == 1)
            {
                copd.Lab_ShowBINNum.Content = this.Lab_ShowBINNum.Content;
                copd.Lab_ShowJobNum.Content = this.Lab_ShowJobNum.Content;
                copd.Lab_ShowBINName.Content = this.Lab_ShowBINName.Content;
                copd.Show();
                this.Hide();

            }
            else if (ps.CA == 1)
            {
                ca.Lab_ShowBINNum.Content = this.Lab_ShowBINNum.Content;
                ca.Lab_ShowJobNum.Content = this.Lab_ShowJobNum.Content;
                ca.Lab_ShowBINName.Content = this.Lab_ShowBINName.Content;
                ca.Show();
                this.Hide();
            }
            else if (ps.peff == 1)
            {
                peff.Lab_ShowBINNum.Content = this.Lab_ShowBINNum.Content;
                peff.Lab_ShowJobNum.Content = this.Lab_ShowJobNum.Content;
                peff.Lab_ShowBINName.Content = this.Lab_ShowBINName.Content;
                peff.Show();
                this.Hide();
            }
            else
            {
                PMH pmh = new PMH();
                pmh.Lab_ShowBINNum.Content = this.Lab_ShowBINNum.Content;
                pmh.Lab_ShowJobNum.Content = this.Lab_ShowJobNum.Content;
                pmh.Lab_ShowBINName.Content = this.Lab_ShowBINName.Content;
                pmh.Show();
                this.Hide();
            }
           

        }













    }

}

