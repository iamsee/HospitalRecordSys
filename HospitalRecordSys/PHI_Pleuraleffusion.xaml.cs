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
    /// PHI_Pleuraleffusion.xaml 的交互逻辑
    /// </summary>
    public partial class PHI_Pleuraleffusion : Window
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




        PHI phi = new PHI();
        Num num = new Num();
        Time time = new Time();
        public PHI_Pleuraleffusion()
        {

            InitializeComponent();

            dtYear = time.getyear();
            CB_RadidBreath_StartTime_Year.ItemsSource = dtYear.DefaultView;
            CB_RadidBreath_StartTime_Year.DisplayMemberPath = "Year";
            CB_RadidBreath_StartTime_Year.SelectedValuePath = "Year";


            dtNum = num.getnum();
            CB_LastTimeDayFever.ItemsSource = dtNum.DefaultView;
            CB_LastTimeDayFever.DisplayMemberPath = "Num";
            CB_LastTimeDayFever.SelectedValuePath = "Num";

            CB_HighestHeatDuFever.ItemsSource = dtNum.DefaultView;
            CB_HighestHeatDuFever.DisplayMemberPath = "Num";
            CB_HighestHeatDuFever.SelectedValuePath = "Num";

            CB_ChestPain_LastTimeChestPainHour.ItemsSource = dtNum.DefaultView;
            CB_ChestPain_LastTimeChestPainHour.DisplayMemberPath = "Num";
            CB_ChestPain_LastTimeChestPainHour.SelectedValuePath = "Num";

            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            CB_ChestPain_LastTimeChestPainHour.ItemsSource = dtNum.DefaultView;
            CB_ChestPain_LastTimeChestPainHour.DisplayMemberPath = "Num";
            CB_ChestPain_LastTimeChestPainHour.SelectedValuePath = "Num";

            CB_RadidBreath_EveryLastTime.ItemsSource = dtNum.DefaultView;
            CB_RadidBreath_EveryLastTime.DisplayMemberPath = "Num";
            CB_RadidBreath_EveryLastTime.SelectedValuePath = "Num";

            CB_RadidBreath_EveryDay_Times.ItemsSource = dtNum.DefaultView;
            CB_RadidBreath_EveryDay_Times.DisplayMemberPath = "Num";
            CB_RadidBreath_EveryDay_Times.SelectedValuePath = "Num";

            CB_Wasting_LastTime.ItemsSource = dtNum.DefaultView;
            CB_Wasting_LastTime.DisplayMemberPath = "Num";
            CB_Wasting_LastTime.SelectedValuePath = "Num";

            CB_Cough_LastTime.ItemsSource = dtNum.DefaultView;
            CB_Cough_LastTime.DisplayMemberPath = "Num";
            CB_Cough_LastTime.SelectedValuePath = "Num";

            CB_Wasting_KG.ItemsSource = dtNum.DefaultView;
            CB_Wasting_KG.DisplayMemberPath = "Num";
            CB_Wasting_KG.SelectedValuePath = "Num";




            dtYear = time.getyear();
            CB_BreathHardStartTimeYear.ItemsSource = dtYear.DefaultView;
            CB_BreathHardStartTimeYear.DisplayMemberPath = "Year";
            CB_BreathHardStartTimeYear.SelectedValuePath = "Year";


            CB_BreathHardStartDeepTime_Year.ItemsSource = dtYear.DefaultView;
            CB_BreathHardStartDeepTime_Year.DisplayMemberPath = "Year";
            CB_BreathHardStartDeepTime_Year.SelectedValuePath = "Year";
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




        private void CB_BreathHardStartTimeYear_DropDownClosed(object sender, EventArgs e)
        {
            dtMonth = time.getmonth();
            CB_BreathHardStartTimeMonth.ItemsSource = dtMonth.DefaultView;
            CB_BreathHardStartTimeMonth.DisplayMemberPath = "Month";
            CB_BreathHardStartTimeMonth.SelectedValuePath = "Month";
        }


        private void CB_BreathHardStartTimeMonth_DropDownClosed(object sender, EventArgs e)
        {

            dtDay = time.getday();
            CB_BreathHardStartTimeDay.ItemsSource = dtDay.DefaultView;
            CB_BreathHardStartTimeDay.DisplayMemberPath = "Day";
            CB_BreathHardStartTimeDay.SelectedValuePath = "Day";
        }

        private void CB_BreathHardStartTimeYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            time.SelectYear = CB_BreathHardStartTimeYear.SelectedValue.ToString();
            CB_BreathHardStartTimeMonth.SelectedValue = "";
            CB_BreathHardStartTimeDay.SelectedValue = "";
        }

        private void CB_BreathHardStartTimeMonth_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            time.SelectMonth = CB_BreathHardStartTimeMonth.SelectedValue.ToString();
            CB_BreathHardStartTimeDay.SelectedValue = "";
        }




        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~`




        private void CB_BreathHardStartDeepTime_Year_DropDownClosed(object sender, EventArgs e)
        {
            dtMonth = time.getmonth();
            CB_BreathHardStartDeepTime_Month.ItemsSource = dtMonth.DefaultView;
            CB_BreathHardStartDeepTime_Month.DisplayMemberPath = "Month";
            CB_BreathHardStartDeepTime_Month.SelectedValuePath = "Month";
        }

        private void CB_BreathHardStartDeepTime_Month_DropDownClosed(object sender, EventArgs e)
        {
            dtDay = time.getday();
            CB_BreathHardStartDeepTime_Day.ItemsSource = dtDay.DefaultView;
            CB_BreathHardStartDeepTime_Day.DisplayMemberPath = "Day";
            CB_BreathHardStartDeepTime_Day.SelectedValuePath = "Day";
        }

        private void CB_BreathHardStartDeepTime_Year_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            time.SelectYear = CB_BreathHardStartDeepTime_Year.SelectedValue.ToString();
            CB_BreathHardStartDeepTime_Month.SelectedValue = "";
            CB_BreathHardStartDeepTime_Day.SelectedValue = "";
        }

        private void CB_BreathHardStartDeepTime_Month_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            time.SelectMonth = CB_BreathHardStartDeepTime_Month.SelectedValue.ToString();
            CB_BreathHardStartDeepTime_Day.SelectedValue = "";
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

        private void But_Update_Pleuraleffusion_xaml_Click(object sender, RoutedEventArgs e)
        {
            TB_Pleuraleffusion tp = new TB_Pleuraleffusion();

            if ((CB_BreathHard.SelectedItem as ComboBoxItem).Content.ToString() == "是")
            {
                tp.RapidBreath_State = 1;

                TB_Pleuraleffusion_BreathHard tpbh = new TB_Pleuraleffusion_BreathHard();
                tpbh.BIHNum = Lab_ShowBINNum.Content.ToString();


                tpbh.DeepLevel = (CB_BreathHardLevel.SelectedItem as ComboBoxItem).Content.ToString();
                tpbh.StartTime = CB_BreathHardStartTimeYear.SelectedValue + "/" + CB_BreathHardStartTimeMonth.SelectedValue + "/" + CB_BreathHardStartTimeDay.SelectedValue;
                tpbh.DeepTime = CB_BreathHardStartDeepTime_Year.SelectedValue + "/" + CB_BreathHardStartDeepTime_Month.SelectedValue + "/" + CB_BreathHardStartDeepTime_Day.SelectedValue;

                if ((CB_BreathHardHaveDrug.SelectedItem as ComboBoxItem).Content.ToString() == "有")
                {
                    tpbh.Drup = Text_BreathHardHaveDrugName.Text.Trim();
                }
                else
                {
                    tpbh.Drup = null;
                }
                tpbh.update_TB_Pleuraleffusion_BreathHard();
            }

            if ((CB_Fever.SelectedItem as ComboBoxItem).Content.ToString() == "是")
            {
                tp.Fever_State = 1;
                TB_Pleuraleffusion_Fever tpf = new TB_Pleuraleffusion_Fever();
                tpf.BIHNum = Lab_ShowBINNum.Content.ToString();
                tpf.LastTime = Convert.ToInt32(CB_LastTimeDayFever.SelectedValue.ToString());
                tpf.HighestHeat = Convert.ToSingle(CB_HighestHeatDuFever.SelectedValue.ToString());


                if (CBox_MoningFever.IsChecked == true)
                {
                    moning = "早晨、";
                }
                if (CBox_AfternoonFever.IsChecked == true)
                {
                    afternoon = "下午、";
                }
                if (CBox_NightFever.IsChecked == true)
                {
                    night = "晚上、";
                }
                if (Lab_TimeRange_OtherFever.IsChecked == true)
                {
                    other = Text_TimeRange_OtherFever.Text.Trim();
                }

                tpf.TimeRange = moning + afternoon + night + other;
                tpf.Shakes = (CB_ShakesFever.SelectedItem as ComboBoxItem).Content.ToString();

                if ((CB_Shakes_Fever.SelectedItem as ComboBoxItem).Content.ToString() == "是")
                {
                    TB_Pleuraleffusion_Fever_Drup tpfd = new TB_Pleuraleffusion_Fever_Drup();
                    tpfd.BIHNum = Lab_ShowBINNum.Content.ToString();
                    tpfd.DrupName = Text_DrugNameFever.Text.Trim();
                    tpfd.DrupEffect = (CB_DrugEffectFever.SelectedItem as ComboBoxItem).Content.ToString();
                    tpfd.Update_TB_Pleuraleffusion_Fever_Drup();


                    tpf.UserDrug = 1;
                }
                else if ((CB_Shakes_Fever.SelectedItem as ComboBoxItem).Content.ToString() == "否")
                {
                    tpf.UserDrug = 0;

                }
                //     MessageBox.Show(tpf.UserDrup.ToString());


                //   MessageBox.Show((CB_Shakes_Fever.SelectedItem as ComboBoxItem).Content.ToString());
                tpf.Update_TB_Pleuraleffusion_Fever();

            }
            else
            {
                tp.Fever_State = 0;
            }

            if ((CB_Cough.SelectedItem as ComboBoxItem).Content.ToString() == "是")
            {
                tp.Cough_State = 1;
                TB_Pleuraleffusion_Cough tpc = new TB_Pleuraleffusion_Cough();
                tpc.BIHNum = Lab_ShowBINNum.Content.ToString();
             

                tpc.LastTime = CB_Cough_LastTime.SelectedValue.ToString();
                tpc.ClearTime = (CB_Cough_ClearTime.SelectedItem as ComboBoxItem).Content.ToString();
                if ((CB_Luggies.SelectedItem as ComboBoxItem).Content.ToString() == "是")
                {
                    tpc.Luggies = 1;
                    TB_Pleuraleffusion_Cough_Luggies tpcl = new TB_Pleuraleffusion_Cough_Luggies();

                    tpcl.BIHNum = Lab_ShowBINNum.Content.ToString();
                 

                    tpcl.Color = (CB_ColorLuggiesCough.SelectedItem as ComboBoxItem).Content.ToString();
                    tpcl.ClearTime = (CB_Luggies_Cough.SelectedItem as ComboBoxItem).Content.ToString();
                    tpcl.Blood = (CB_BloodLuggiesCough.SelectedItem as ComboBoxItem).Content.ToString();
                    tpcl.update_TB_Pleuraleffusion_Cough_Luggies();

                }
            }
            if ((CB_ChestPain.SelectedItem as ComboBoxItem).Content.ToString() == "是")
            {
                tp.ChestPain_State = 1;
                TB_Pleuraleffusion_ChestPain tpcp = new TB_Pleuraleffusion_ChestPain();
                tpcp.BIHNum = Lab_ShowBINNum.Content.ToString();
   //             tpcp.LastTime = Convert.ToInt32(CB_ChestPain_LastTimeChestPainHour.SelectedValue.ToString());
                tpcp.PainNature = (CB_ChestPain_PainNature.SelectedItem as ComboBoxItem).Content.ToString();
                tpcp.Position = (CB_ChestPain_Position.SelectedItem as ComboBoxItem).Content.ToString();

                tpcp.update_TB_Pleuraleffusion_ChestPain();
            }

            if ((CB_RapidBreath.SelectedItem as ComboBoxItem).Content.ToString() == "是")
            {
                tp.RapidBreath_State = 1;
                TB_Pleuraleffusion_RapidBreath tprb = new TB_Pleuraleffusion_RapidBreath();
                tprb.BIHNum = Lab_ShowBINNum.Content.ToString();

                if ((CB_RadidBreath.SelectedItem as ComboBoxItem).Content.ToString() == "与外界有关")
                {
                    tprb.BIHNum = Lab_ShowBINNum.Content.ToString();
                   
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

                    tprb.RadidBreath = "与 " + cb_1 + cb_2 + cb_3 + cb_4 + cb_5 + cb_6 + cb_7 + " 有关";
                }
                else
                {
                    tprb.RadidBreath = "与外界无关";
                }
                tprb.StartTime = CB_RadidBreath_StartTime_Year.SelectedValue.ToString() + "/" + CB_RadidBreath_StartTime_Month.SelectedValue.ToString() + "/" + CB_RadidBreath_StartTime_Day.SelectedValue.ToString();
                tprb.LastTime = CB_RadidBreath_StartTime_Year.SelectedValue.ToString() + "小时";
                tprb.CoutNum = Convert.ToInt32(CB_RadidBreath_EveryDay_Times.SelectedValue.ToString());
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
                    tprb.DeepShow = morning + afternoon + night + other;
                }
                else
                {
                    tprb.DeepShow = "无";
                }

                if ((CB_RadidBreath_Better.SelectedItem as ComboBoxItem).Content.ToString() == "能")
                {
                    tprb.RelieveShow_State = 1;
                    TB_Pleuraleffusion_RapidBreath_RelieveShow tprbr = new TB_Pleuraleffusion_RapidBreath_RelieveShow();

                    tprbr.BIHNum = Lab_ShowBINNum.Content.ToString();
               
                    if ((CB_RadidBreath_Better_Show.SelectedItem as ComboBoxItem).Content.ToString() == "不用药缓解")
                    {
                        tprbr.NoDrugGood = "不用药缓解";
                    }
                    else if ((CB_RadidBreath_Better_Show.SelectedItem as ComboBoxItem).Content.ToString() == "用药缓解")
                    {
                        tprbr.DrugGood = "用药缓解" + " ,药名:" + Text_RadidBreath_Better_DrugName.Text.Trim();
                    }
                    else if ((CB_RadidBreath_Better_Show.SelectedItem as ComboBoxItem).Content.ToString() == "用药无缓解")
                    {
                        tprbr.DrugBad = "用药无缓解" + " ,药名:" + Text_RadidBreath_Better_DrugName.Text.Trim();
                    }
                    tprbr.update_TB_Pleuraleffusion_RapidBreath_RelieveShow();
                }
                else
                {
                    tprb.RelieveShow_State = 0;
                }
                tprb.update_TB_Pleuraleffusion_RapidBreath();


            }
            if ((CB_Wasting.SelectedItem as ComboBoxItem).Content.ToString() == "是")
            {
                tp.Wasting_State = 1;
                TB_Pleuraleffusion_Wasting tpw = new TB_Pleuraleffusion_Wasting();
                tpw.BIHNum = Lab_ShowBINNum.Content.ToString();
                tpw.LastTime = Convert.ToInt32(CB_Wasting_LastTime.SelectedValue.ToString());
                tpw.WeightFall = Convert.ToInt32(CB_Wasting_KG.SelectedValue.ToString());
                tpw.update_TB_Pleuraleffusion_Wasting();

            }
            tp.update_TB_Pleuraleffusion();
            this.Hide();
            PHI phi = new PHI();
            COPD copd = new COPD();
            BEA bea = new BEA();
            PHI_CA ca = new PHI_CA();
            PHI_Pleuraleffusion peff = new PHI_Pleuraleffusion();


            PMH pmh = new PMH();
           

           
                pmh.Lab_ShowBINNum.Content = this.Lab_ShowBINNum.Content;
                pmh.Lab_ShowJobNum.Content = this.Lab_ShowJobNum.Content;
                pmh.Lab_ShowBINName.Content = this.Lab_BINName.Content;
                pmh.Show();
                this.Hide();

           
        }
    }
}



