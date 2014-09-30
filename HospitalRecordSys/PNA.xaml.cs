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
    /// PNA.xaml 的交互逻辑
    /// </summary>
    public partial class PNA : Window
    {
        PHI_State ps = new PHI_State();

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

        PHI_PNA_Fever ppf = new PHI_PNA_Fever();
        PHI_PNA_Fever_Drup ppfd = new PHI_PNA_Fever_Drup();
        PHI_PNA_Cough pp_Cough = new PHI_PNA_Cough();
        PHI_PNA_Cough_Luggies ppcl = new PHI_PNA_Cough_Luggies();
        PHI_PNA_BreathHard ppb = new PHI_PNA_BreathHard();


        PHI phi = new PHI();
        Num num = new Num();
        Time time = new Time();


        public PNA()
        {
            InitializeComponent();

            dtNum = num.getnum();
            CB_PNA_LastTimeDayFever.ItemsSource = dtNum.DefaultView;
            CB_PNA_LastTimeDayFever.DisplayMemberPath = "Num";
            CB_PNA_LastTimeDayFever.SelectedValuePath = "Num";

            CB_HighestHeatDuFever.ItemsSource = dtNum.DefaultView;
            CB_HighestHeatDuFever.DisplayMemberPath = "Num";
            CB_HighestHeatDuFever.SelectedValuePath = "Num";

            CB_ChestPain_LastTimeChestPainHour.ItemsSource = dtNum.DefaultView;
            CB_ChestPain_LastTimeChestPainHour.DisplayMemberPath = "Num";
            CB_ChestPain_LastTimeChestPainHour.SelectedValuePath = "Num";

            CB_PNA_Follow_AbdomenPain_Day.ItemsSource = dtNum.DefaultView;
            CB_PNA_Follow_AbdomenPain_Day.DisplayMemberPath = "Num";
            CB_PNA_Follow_AbdomenPain_Day.SelectedValuePath = "Num";

            CB_PNA_Follow_Nausea_Day.ItemsSource = dtNum.DefaultView;
            CB_PNA_Follow_Nausea_Day.DisplayMemberPath = "Num";
            CB_PNA_Follow_Nausea_Day.SelectedValuePath = "Num";

            CB_PNA_Follow_Diarrhea_Times.ItemsSource = dtNum.DefaultView;
            CB_PNA_Follow_Diarrhea_Times.DisplayMemberPath = "Num";
            CB_PNA_Follow_Diarrhea_Times.SelectedValuePath = "Num";

            CB_PNA_LastTimeDayCough.ItemsSource = dtNum.DefaultView;
            CB_PNA_LastTimeDayCough.DisplayMemberPath = "Num";
            CB_PNA_LastTimeDayCough.SelectedValuePath = "Num";

            CB_PNA_Follow_HeadPain_Day.ItemsSource = dtNum.DefaultView;
            CB_PNA_Follow_HeadPain_Day.DisplayMemberPath = "Num";
            CB_PNA_Follow_HeadPain_Day.SelectedValuePath = "Num";



            dtYear = time.getyear();
            CB_PNA_BreathHardStartTimeYear.ItemsSource = dtYear.DefaultView;
            CB_PNA_BreathHardStartTimeYear.DisplayMemberPath = "Year";
            CB_PNA_BreathHardStartTimeYear.SelectedValuePath = "Year";


            CB_PNA_BreathHardStartDeepTime_Year.ItemsSource = dtYear.DefaultView;
            CB_PNA_BreathHardStartDeepTime_Year.DisplayMemberPath = "Year";
            CB_PNA_BreathHardStartDeepTime_Year.SelectedValuePath = "Year";

        }








        private void CB_PNA_BreathHardStartTimeYear_DropDownClosed(object sender, EventArgs e)
        {
            dtMonth = time.getmonth();
            CB_PNA_BreathHardStartTimeMonth.ItemsSource = dtMonth.DefaultView;
            CB_PNA_BreathHardStartTimeMonth.DisplayMemberPath = "Month";
            CB_PNA_BreathHardStartTimeMonth.SelectedValuePath = "Month";
        }


        private void CB_PNA_BreathHardStartTimeMonth_DropDownClosed(object sender, EventArgs e)
        {

            dtDay = time.getday();
            CB_PNA_BreathHardStartTimeDay.ItemsSource = dtDay.DefaultView;
            CB_PNA_BreathHardStartTimeDay.DisplayMemberPath = "Day";
            CB_PNA_BreathHardStartTimeDay.SelectedValuePath = "Day";
        }

        private void CB_PNA_BreathHardStartTimeYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            time.SelectYear = CB_PNA_BreathHardStartTimeYear.SelectedValue.ToString();
            CB_PNA_BreathHardStartTimeMonth.SelectedValue = "";
            CB_PNA_BreathHardStartTimeDay.SelectedValue = "";
        }

        private void CB_PNA_BreathHardStartTimeMonth_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            time.SelectMonth = CB_PNA_BreathHardStartTimeMonth.SelectedValue.ToString();
            CB_PNA_BreathHardStartTimeDay.SelectedValue = "";
        }




        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~`




        private void CB_PNA_BreathHardStartDeepTime_Year_DropDownClosed(object sender, EventArgs e)
        {
            dtMonth = time.getmonth();
            CB_PNA_BreathHardStartDeepTime_Month.ItemsSource = dtMonth.DefaultView;
            CB_PNA_BreathHardStartDeepTime_Month.DisplayMemberPath = "Month";
            CB_PNA_BreathHardStartDeepTime_Month.SelectedValuePath = "Month";
        }

        private void CB_PNA_BreathHardStartDeepTime_Month_DropDownClosed(object sender, EventArgs e)
        {
            dtDay = time.getday();
            CB_PNA_BreathHardStartDeepTime_Day.ItemsSource = dtDay.DefaultView;
            CB_PNA_BreathHardStartDeepTime_Day.DisplayMemberPath = "Day";
            CB_PNA_BreathHardStartDeepTime_Day.SelectedValuePath = "Day";
        }

        private void CB_PNA_BreathHardStartDeepTime_Year_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            time.SelectYear = CB_PNA_BreathHardStartDeepTime_Year.SelectedValue.ToString();
            CB_PNA_BreathHardStartDeepTime_Month.SelectedValue = "";
            CB_PNA_BreathHardStartDeepTime_Day.SelectedValue = "";
        }

        private void CB_PNA_BreathHardStartDeepTime_Month_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            time.SelectMonth = CB_PNA_BreathHardStartDeepTime_Month.SelectedValue.ToString();
            CB_PNA_BreathHardStartDeepTime_Day.SelectedValue = "";
        }



        private void CBox_Fever_Click(object sender, RoutedEventArgs e)
        {
            if (CBox_Fever.IsChecked == true)
            {
                Grid_PNAFever.IsEnabled = true;
            }
            else
            {
                Grid_PNAFever.IsEnabled = false;
            }
        }

        private void CBox_Cough_Click(object sender, RoutedEventArgs e)
        {
            if (CBox_Cough.IsChecked == true)
            {
                Grid_PNACough.IsEnabled = true;
            }
            else
            {
                Grid_PNACough.IsEnabled = false;
            }
        }


        private void CBox_BreathHard_Click(object sender, RoutedEventArgs e)
        {
            if (CBox_BreathHard.IsChecked == true)
            {
                Grid_PNABreathHard.IsEnabled = true;
            }
            else
            {
                Grid_PNABreathHard.IsEnabled = false;
            }
        }

        private void CBox_ChestPain_Click(object sender, RoutedEventArgs e)
        {
            if (CBox_ChestPain.IsChecked == true)
            {
                Grid_PNAChestPain.IsEnabled = true;
            }
            else
            {
                Grid_PNAChestPain.IsEnabled = false;
            }
        }

        private void CBox_Fllow_Click(object sender, RoutedEventArgs e)
        {
            if (CBox_Fllow.IsChecked == true)
            {
                Grid_PNAFollow.IsEnabled = true;
            }
            else
            {
                Grid_PNAFollow.IsEnabled = false;
            }
        }

        private void But_PNA_Update_Click(object sender, RoutedEventArgs e)
        {


            PHI_PNA pp = new PHI_PNA();

            PHI_PNA_Fever ppf = new PHI_PNA_Fever();
            pp.BIHNum = Lab_ShowBINNum.Content.ToString();
            pp.BIHNum = Lab_ShowBINNum.Content.ToString();
            ppf.BIHNum = Lab_ShowBINNum.Content.ToString();
         
            #region 发烧
            if (CBox_Fever.IsChecked == true)
            {
                pp.Fever_State = 1;



                //      MessageBox.Show("发烧持续时间，或者开始时间未选择，请注意填写");


                ppf.LastTime = Convert.ToInt32(CB_PNA_LastTimeDayFever.SelectedValue.ToString());
                MessageBox.Show(CB_PNA_LastTimeDayFever.SelectedValue.ToString());
                ppf.HighestHeat = Convert.ToSingle(CB_HighestHeatDuFever.SelectedValue.ToString());


                if (CBox_PNA_MoningFever.IsChecked == true)
                {
                    moning = "早晨、";
                }
                if (CBox_PNA_AfternoonFever.IsChecked == true)
                {
                    afternoon = "下午、";
                }
                if (CBox_PNA_NightFever.IsChecked == true)
                {
                    night = "晚上、";
                }
                if (Lab_PNA_TimeRange_OtherFever.IsChecked == true)
                {
                    other = Text_PNA_TimeRange_OtherFever.Text.Trim();
                }

                ppf.TimeRange = moning + afternoon + night + other;
                ppf.Shakes = (CB_PNA_ShakesFever.SelectedItem as ComboBoxItem).Content.ToString();

                if ((CB_PNA_Shakes_Fever.SelectedItem as ComboBoxItem).Content.ToString() == "是")
                {
                    PHI_PNA_Fever_Drup ppfd = new PHI_PNA_Fever_Drup();
                    ppfd.BIHNum = Lab_ShowBINNum.Content.ToString();
           
                    ppfd.DrupName = Text_PNA_DrugNameFever.Text.Trim();
                    ppfd.DrupEffect = (CB_PNA_DrugEffectFever.SelectedItem as ComboBoxItem).Content.ToString();
                    ppfd.Update_PHI_PNA_Fever_Drup();


                    ppf.UserDrug = 1;
                }
                else if ((CB_PNA_Shakes_Fever.SelectedItem as ComboBoxItem).Content.ToString() == "否")
                {
                    ppf.UserDrug = 0;

                }
                //     MessageBox.Show(ppf.UserDrup.ToString());


                //   MessageBox.Show((CB_PNA_Shakes_Fever.SelectedItem as ComboBoxItem).Content.ToString());
                ppf.Update_PHI_PNA_Fever();

            }
            else
            {
                pp.Fever_State = 0;
            }
            #endregion
            #region 咳嗽
            if (CBox_Cough.IsChecked == true)
            {
                PHI_PNA_Cough ppc = new PHI_PNA_Cough();
                ppc.BIHNum = Lab_ShowBINNum.Content.ToString();
           
                ppc.LastTime = CB_PNA_LastTimeDayCough.SelectedValue.ToString() + "天";
                if (CBox_PNA_MoningCough.IsChecked == true)
                {
                    moning = "早晨、";
                }
                if (CBox_PNA_AfternoonCough.IsChecked == true)
                {
                    afternoon = "下午、";
                }
                if (CBox_PNA_NightCough.IsChecked == true)
                {
                    night = "晚上、";
                }
                if (Lab_PNA_ClearTime_OtherCough.IsChecked == true)
                {
                    other = TB_PNA_ClearTime_OtherCough.Text.Trim();
                }
                ppc.ClearTime = moning + afternoon + night + other;
                if ((CB_PNA_Luggies.SelectedItem as ComboBoxItem).Content.ToString() == "是")
                {
                    PHI_PNA_Cough_Luggies ppcl = new PHI_PNA_Cough_Luggies();
                    ppcl.BIHNum = Lab_ShowBINNum.Content.ToString();
                    ppcl.Color = (CB_PNA_ColorLuggiesCough.SelectedItem as ComboBoxItem).Content.ToString();
                    ppcl.ClearTime = (CB_PNA_Luggies_Cough.SelectedItem as ComboBoxItem).Content.ToString();
                    ppcl.Blood = (CB_PNA_BloodLuggiesCough.SelectedItem as ComboBoxItem).Content.ToString();
                    ppcl.update_PHI_PNA_Cough_Luggies();
                    ppc.Luggies = 1;
                }
                else if ((CB_PNA_Luggies.SelectedItem as ComboBoxItem).Content.ToString() == "否")
                {
                    ppc.Luggies = 0;
                }
                pp.Cough_State = 1;
                ppc.update_PHI_PNA_Cough();
            }
            else
            {
                pp.Cough_State = 0;
            }
            #endregion
            #region 呼吸困难
            if (CBox_BreathHard.IsChecked == true)
            {
                PHI_PNA_BreathHard ppb = new PHI_PNA_BreathHard();
                ppb.BIHNum = Lab_ShowBINNum.Content.ToString();
          
                ppb.Level = (CB_PNA_BreathHardLevel.SelectedItem as ComboBoxItem).Content.ToString();
                ppb.StartTime = CB_PNA_BreathHardStartTimeYear.SelectedValue + "/" + CB_PNA_BreathHardStartTimeMonth.SelectedValue + "/" + CB_PNA_BreathHardStartTimeDay.SelectedValue;
                ppb.StartDeepTime = CB_PNA_BreathHardStartDeepTime_Year.SelectedValue + "/" + CB_PNA_BreathHardStartDeepTime_Month.SelectedValue + "/" + CB_PNA_BreathHardStartDeepTime_Day.SelectedValue;
                ppb.HaveDrug = (CB_PNA_BreathHardHaveDrug.SelectedItem as ComboBoxItem).Content.ToString();
                if ((CB_PNA_BreathHardHaveDrug.SelectedItem as ComboBoxItem).Content.ToString() == "有")
                {
                    ppb.HaveDrugName = Text_PNA_BreathHardHaveDrugName.Text.Trim();
                }
                else
                {
                    ppb.HaveDrugName = null;
                }
                ppb.update_PHI_PNA_BreathHard();

                pp.BreathHard_State = 1;
            }
            else
            {
                pp.BreathHard_State = 0;
            }
            #endregion
            #region 胸痛
            if (CBox_ChestPain.IsChecked == true)
            {
                PHI_PNA_ChestPain ppcp = new PHI_PNA_ChestPain();
                ppcp.BIHNum = Lab_ShowBINNum.Content.ToString();
            
                ppcp.LastTime = Convert.ToInt32(CB_ChestPain_LastTimeChestPainHour.SelectedValue.ToString());
                ppcp.PainNature = (CB_PNA_ChestPain_PainNature.SelectedItem as ComboBoxItem).Content.ToString();
                ppcp.Position = (CB_PNA_ChestPain_Position.SelectedItem as ComboBoxItem).Content.ToString();
                ppcp.update_PHI_PNA_ChestPain();
                pp.ChestPain_State = 1;
            }
            else
            {
                pp.ChestPain_State = 0;
            }
            #endregion
            #region fllow
            if (CBox_Fllow.IsChecked == true)
            {
                PHI_PNA_Follow ppfll = new PHI_PNA_Follow();
                ppfll.BIHNum = Lab_ShowBINNum.Content.ToString();
               
                if ((CB_PNA_Follow_HeadPain.SelectedItem as ComboBoxItem).Content.ToString() == "有")
                {
                    ppfll.HeadPain = Convert.ToInt32(CB_PNA_Follow_HeadPain_Day.SelectedValue.ToString());

                }
                else
                {
                    ppfll.HeadPain = 0;
                }
                if ((CB_PNA_Follow_Nausea.SelectedItem as ComboBoxItem).Content.ToString() == "有")
                {
                    ppfll.Nausea = Convert.ToInt32(CB_PNA_Follow_Nausea_Day.SelectedValue.ToString());
                }
                else
                {
                    ppfll.Nausea = 0;
                }

                if ((CB_PNA_Follow_AbdomenPain_Copy.SelectedItem as ComboBoxItem).Content.ToString() == "有")
                {
                    ppfll.AbdomenPain = Convert.ToInt32(CB_PNA_Follow_AbdomenPain_Day.SelectedValue.ToString());
                }
                else
                {
                    ppfll.AbdomenPain = 0;
                }
                if ((CB_PNA_Follow_Diarrhea.SelectedItem as ComboBoxItem).Content.ToString() == "有")
                {
                    ppfll.Diarrhea = (CB_PNA_Follow_Diarrhea_Times.SelectedValue.ToString());
                }
                else
                {
                    ppfll.Diarrhea = "false";
                }
                ppfll.update_PHI_PNA_Follow();
                pp.Follow = 1;
            }
            else
            {
                pp.Follow = 0;
            }
            
            pp.update_TB_PNA();
            this.Hide();
            PHI phi = new PHI();
            COPD copd = new COPD();
            BEA bea = new BEA();
            PHI_CA ca = new PHI_CA();
            PHI_State ps = new PHI_State();
            
            PHI_Pleuraleffusion peff = new PHI_Pleuraleffusion();
            ps.BIHNum = Lab_ShowBINNum.Content.ToString();
            ps.get_TB_PHI();
           
            if (ps.BEA == 1)
            {
                bea.Lab_ShowBINNum.Content = this.Lab_ShowBINNum.Content;
                bea.Lab_ShowJobNum.Content = this.Lab_ShowJobNum.Content;
                bea.Lab_ShowBINName.Content = this.Lab_ShowBINName.Content;
                bea.Show();
                MessageBox.Show("BEA>ISchecked");
                this.Hide();
            }

            else if (ps.COPD == 1)
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
           
             #endregion
            pp.update_TB_PNA();
        }
           
        private void CB_PNA_Shakes_Fever_DropDownClosed(object sender, EventArgs e)
        {
            if ((CB_PNA_Shakes_Fever.SelectedItem as ComboBoxItem).Content.ToString() == "是")
            {
                Grid_FeverDrug.IsEnabled = true;
            }
            else
            {
                Grid_FeverDrug.IsEnabled = false;
            }
        }

        private void CB_PNA_Luggies_DropDownClosed(object sender, EventArgs e)
        {
            if ((CB_PNA_Luggies.SelectedItem as ComboBoxItem).Content.ToString() == "是")
            {
                Grid_Luggies.IsEnabled = true;
            }
            else
            {
                Grid_Luggies.IsEnabled = false;
            }

        }

        private void CB_PNA_BreathHardHaveDrug_DropDownClosed(object sender, EventArgs e)
        {
            if ((CB_PNA_BreathHardHaveDrug.SelectedItem as ComboBoxItem).Content.ToString() == "有")
            {
                Grid_BreathHardHaveDrug1.IsEnabled = true;
            }
            else
            {
                Grid_BreathHardHaveDrug1.IsEnabled = false;
            }




        }










    }
}
