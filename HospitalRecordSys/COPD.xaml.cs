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
    /// COPD.xaml 的交互逻辑
    /// </summary>
    public partial class COPD : Window
    {
        Database db = new Database();
        string sqlString = string.Empty;

        DataTable dtYear = new DataTable();

        DataTable dtMonth = new DataTable();
        DataTable dtDay = new DataTable();
        string moning;
        string afternoon;
        string night;
        string other;
        Num num = new Num();
        DataTable dtNum = new DataTable();

        Time time = new Time();
        public COPD()
        {
            InitializeComponent();
            


            dtNum = num.getnum();
            CB_Cough_LastTime.ItemsSource = dtNum.DefaultView;
            CB_Cough_LastTime.DisplayMemberPath = "Num";
            CB_Cough_LastTime.SelectedValuePath = "Num";


            dtYear = time.getyear();
            CB_BreathHardStartTimeYear.ItemsSource = dtYear.DefaultView;
            CB_BreathHardStartTimeYear.DisplayMemberPath = "Year";
            CB_BreathHardStartTimeYear.SelectedValuePath = "Year";


            CB_BreathHardStartDeepTime_Year.ItemsSource = dtYear.DefaultView;
            CB_BreathHardStartDeepTime_Year.DisplayMemberPath = "Year";
            CB_BreathHardStartDeepTime_Year.SelectedValuePath = "Year";
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

        private void But_Update_COPD_Click(object sender, RoutedEventArgs e)
        {
            TB_COPD tc = new TB_COPD();
            tc.BIHNum = Lab_ShowBINNum.Content.ToString();
      

            if ((CB_Cough.SelectedItem as ComboBoxItem).Content.ToString() == "是")
            {
                tc.Cough_State = 1;
                TB_COPD_Cough tcc = new TB_COPD_Cough();
                tcc.BIHNum = Lab_ShowBINNum.Content.ToString();
              
                tcc.LastTime = Convert.ToInt32(CB_Cough_LastTime.SelectedValue.ToString());
                tcc.ClearTime = CB_Cough_ClearTime.SelectedValue.ToString();
                if ((CB_Luggies.SelectedItem as ComboBoxItem).Content.ToString() == "是")
                {
                    tcc.Luggies = 1;
                    TB_COPD_Cough_Luggies tccl = new TB_COPD_Cough_Luggies();

                    tccl.BIHNum = Lab_ShowBINNum.Content.ToString();
                

                    tccl.Color = (CB_ColorLuggiesCough.SelectedItem as ComboBoxItem).Content.ToString();
                    tccl.ClearTime = (CB_Luggies_Cough.SelectedItem as ComboBoxItem).Content.ToString();
                    tccl.Blood = (CB_BloodLuggiesCough.SelectedItem as ComboBoxItem).Content.ToString();
                    tccl.update_TB_COPD_Cough_Luggies();

                }

                if ((CB_BreathHard.SelectedItem as ComboBoxItem).Content.ToString() == "是")
                {
                    tc.RapidBreath_State = 1;
                    TB_COPD_RapidBreath tcr = new TB_COPD_RapidBreath();
                    tcr.BIHNum = Lab_ShowBINNum.Content.ToString();

                    tcr.DeepLevel = (CB_BreathHardLevel.SelectedItem as ComboBoxItem).Content.ToString();
                    tcr.StartTime = CB_BreathHardStartTimeYear.SelectedValue + "/" + CB_BreathHardStartTimeMonth.SelectedValue + "/" + CB_BreathHardStartTimeDay.SelectedValue;
                    tcr.DeepTime = CB_BreathHardStartDeepTime_Year.SelectedValue + "/" + CB_BreathHardStartDeepTime_Month.SelectedValue + "/" + CB_BreathHardStartDeepTime_Day.SelectedValue;

                    if ((CB_BreathHardHaveDrug.SelectedItem as ComboBoxItem).Content.ToString() == "有")
                    {
                        tcr.Drup = Text_BreathHardHaveDrugName.Text.Trim();
                    }
                    else
                    {
                        tcr.Drup = null;
                    }

                    tcr.update_TB_COPD_RapidBreath();
                }
                tc.update_TB_COPD();
                this.Hide();
                PHI phi = new PHI();
                COPD copd = new COPD();
                BEA bea = new BEA();
                PHI_CA ca = new PHI_CA();
                PHI_Pleuraleffusion peff = new PHI_Pleuraleffusion();
                PHI_State ps = new PHI_State();
             

                ps.BIHNum = Lab_ShowBINNum.Content.ToString();
                ps.get_TB_PHI();
                if (ps.CA == 1)
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

        private void CB_BreathHard_DropDownClosed(object sender, EventArgs e)
        {
            if((CB_BreathHard.SelectedItem as ComboBoxItem).Content.ToString()=="是")
            {
                Grid_PNABreathHard.IsEnabled = true;
            }
            else
            {
                Grid_PNABreathHard.IsEnabled = false;
            }
        }

    }
}

