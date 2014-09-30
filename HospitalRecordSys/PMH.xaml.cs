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
    /// PMH.xaml 的交互逻辑
    /// </summary>
    public partial class PMH : Window
    {
        Database db = new Database();
        DataTable dt = new DataTable();
        DataTable dtNum = new DataTable();
        DataTable dtYear = new DataTable();

        DataTable dtMonth = new DataTable();
        DataTable dtDay = new DataTable();

        DataSet ds = new DataSet();
        string sqlString = string.Empty;
        Num num = new Num();
        Time time = new Time();
        CityandContury cc = new CityandContury();
        public PMH()
        {
            InitializeComponent();

            dtNum = num.getnum();
            CB_4.ItemsSource = dtNum.DefaultView;
            CB_4.DisplayMemberPath = "Num";
            CB_4.SelectedValuePath = "Num";

            CB_4_Copy.ItemsSource = dtNum.DefaultView;
            CB_4_Copy.DisplayMemberPath = "Num";
            CB_4_Copy.SelectedValuePath = "Num";

            CB_4_Copy1.ItemsSource = dtNum.DefaultView;
            CB_4_Copy1.DisplayMemberPath = "Num";
            CB_4_Copy1.SelectedValuePath = "Num";

            CB_4_Copy2.ItemsSource = dtNum.DefaultView;
            CB_4_Copy2.DisplayMemberPath = "Num";
            CB_4_Copy2.SelectedValuePath = "Num";

            CB_9.ItemsSource = dtNum.DefaultView;
            CB_9.DisplayMemberPath = "Num";
            CB_9.SelectedValuePath = "Num";

        

            CB_9_Copy.ItemsSource = dtNum.DefaultView;
            CB_9_Copy.DisplayMemberPath = "Num";
            CB_9_Copy.SelectedValuePath = "Num";

            CB_4_Copy3.ItemsSource = dtNum.DefaultView;
            CB_4_Copy3.DisplayMemberPath = "Num";
            CB_4_Copy3.SelectedValuePath = "Num";

            dtYear = time.getyear();
            CB_1.ItemsSource = dtYear.DefaultView;
            CB_1.DisplayMemberPath = "Year";
            CB_1.SelectedValuePath = "Year";

            CB_1_Copy.ItemsSource = dtYear.DefaultView;
            CB_1_Copy.DisplayMemberPath = "Year";
            CB_1_Copy.SelectedValuePath = "Year";

            CB_1_Copy1.ItemsSource = dtYear.DefaultView;
            CB_1_Copy1.DisplayMemberPath = "Year";
            CB_1_Copy1.SelectedValuePath = "Year";

            CB_1_Copy2.ItemsSource = dtYear.DefaultView;
            CB_1_Copy2.DisplayMemberPath = "Year";
            CB_1_Copy2.SelectedValuePath = "Year";

            CB_1_Copy3.ItemsSource = dtYear.DefaultView;
            CB_1_Copy3.DisplayMemberPath = "Year";
            CB_1_Copy3.SelectedValuePath = "Year";

            CB_6.ItemsSource = dtYear.DefaultView;
            CB_6.DisplayMemberPath = "Year";
            CB_6.SelectedValuePath = "Year";

            CB_6_Copy.ItemsSource = dtYear.DefaultView;
            CB_6_Copy.DisplayMemberPath = "Year";
            CB_6_Copy.SelectedValuePath = "Year";

         ;

            CB_11.ItemsSource = dtYear.DefaultView;
            CB_11.DisplayMemberPath = "Year";
            CB_11.SelectedValuePath = "Year";

            CB_11_Copy.ItemsSource = dtYear.DefaultView;
            CB_11_Copy.DisplayMemberPath = "Year";
            CB_11_Copy.SelectedValuePath = "Year";
        }

        private void CB_1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            //  CB_2.Items.Clear();
            time.SelectYear = CB_1.SelectedValue.ToString();
            CB_2.SelectedValue = "";
            CB_3.SelectedValue = "";



        }
        private void CB_2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if(CB_2.SelectedValue == null)
            {
                time.SelectMonth = "0";
            }
            else
            {
      //       time.SelectMonth= CB_2.SelectedValue.ToString();
            }
            CB_3.SelectedValue = "";



            //  MessageBox.Show(time.SelectMonth);
        }

        private void CB_1_Copy_SelectionChanged(object sender, EventArgs e)
        {
            time.SelectYear = CB_1_Copy.SelectedValue.ToString();
            CB_2_Copy.SelectedValue = "";

        }

        private void CB_2_Copy_SelectionChanged(object sender, EventArgs e)
        {
            time.SelectMonth = CB_2_Copy.SelectedValue.ToString();
            CB_3_Copy.SelectedValue = "";
        }

        private void CB_1_Copy1_SelectionChanged(object sender, EventArgs e)
        {
            time.SelectYear = CB_1_Copy1.SelectedValue.ToString();
            CB_2_Copy1.SelectedValue = "";
        }

        private void CB_2_Copy1_SelectionChanged(object sender, EventArgs e)
        {
            time.SelectMonth = CB_2_Copy1.SelectedValue.ToString();
            CB_3_Copy1.SelectedValue = "";
        }

        private void CB_1_Copy2_SelectionChanged(object sender, EventArgs e)
        {
            time.SelectYear = CB_1_Copy2.SelectedValue.ToString();
            CB_2_Copy2.SelectedValue = "";
        }

        private void CB_2_Copy2_SelectionChanged(object sender, EventArgs e)
        {
            time.SelectMonth = CB_2_Copy2.SelectedValue.ToString();
            CB_3_Copy2.SelectedValue = "";
        }

        private void CB_1_Copy3_SelectionChanged(object sender, EventArgs e)
        {
            time.SelectYear = CB_1_Copy3.SelectedValue.ToString();
            CB_2_Copy3.SelectedValue = "";
        }

        private void CB_2_Copy3_SelectionChanged(object sender, EventArgs e)
        {
            time.SelectMonth = CB_2_Copy3.SelectedValue.ToString();
            CB_3_Copy3.SelectedValue = "";
        }

        private void CB_6_SelectionChanged(object sender, EventArgs e)
        {
            time.SelectYear = CB_6.SelectedValue.ToString();
            CB_7.SelectedValue = "";
        }

        private void CB_7_SelectionChanged(object sender, EventArgs e)
        {
            time.SelectMonth = CB_7.SelectedValue.ToString();
            CB_8.SelectedValue = "";
        }

        private void CB_6_Copy_SelectionChanged(object sender, EventArgs e)
        {
            time.SelectYear = CB_6_Copy.SelectedValue.ToString();
            CB_7_Copy.SelectedValue = "";
        }

        private void CB_7_Copy_SelectionChanged(object sender, EventArgs e)
        {

            time.SelectMonth = CB_7_Copy.SelectedValue.ToString();
            CB_8_Copy.SelectedValue = "";

        }

      

     

        private void CB_11_SelectionChanged(object sender, EventArgs e)
        {
            time.SelectYear = CB_11.SelectedValue.ToString();
            CB_12.SelectedValue = "";
        }

        private void CB_12_SelectionChanged(object sender, EventArgs e)
        {
            time.SelectMonth = CB_12.SelectedValue.ToString();
            CB_13.SelectedValue = "";
        }

        private void CB_11_Copy_SelectionChanged(object sender, EventArgs e)
        {
            time.SelectYear = CB_11_Copy.SelectedValue.ToString();
            CB_12_Copy.SelectedValue = "";
        }

        private void CB_12_Copy_SelectionChanged(object sender, EventArgs e)
        {
            time.SelectMonth = CB_12_Copy.SelectedValue.ToString();
            CB_13_Copy.SelectedValue = "";

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

        private void CB_1_Copy1_DropDownClosed(object sender, EventArgs e)
        {
            dtMonth = time.getmonth();
            CB_2_Copy1.ItemsSource = dtMonth.DefaultView;
            CB_2_Copy1.DisplayMemberPath = "Month";
            CB_2_Copy1.SelectedValuePath = "Month";

        }

        private void CB_2_Copy1_DropDownClosed(object sender, EventArgs e)
        {
            dtDay = time.getday();
            CB_3_Copy1.ItemsSource = dtDay.DefaultView;
            CB_3_Copy1.DisplayMemberPath = "Day";
            CB_3_Copy1.SelectedValuePath = "Day";

        }

        private void CB_1_Copy2_DropDownClosed(object sender, EventArgs e)
        {
            dtMonth = time.getmonth();
            CB_2_Copy2.ItemsSource = dtMonth.DefaultView;
            CB_2_Copy2.DisplayMemberPath = "Month";
            CB_2_Copy2.SelectedValuePath = "Month";
        }


        private void CB_2_Copy2_DropDownClosed(object sender, EventArgs e)
        {
            dtDay = time.getday();
            CB_3_Copy2.ItemsSource = dtDay.DefaultView;
            CB_3_Copy2.DisplayMemberPath = "Day";
            CB_3_Copy2.SelectedValuePath = "Day";
        }

        private void CB_1_Copy3_DropDownClosed(object sender, EventArgs e)
        {
            dtMonth = time.getmonth();
            CB_2_Copy3.ItemsSource = dtMonth.DefaultView;
            CB_2_Copy3.DisplayMemberPath = "Month";
            CB_2_Copy3.SelectedValuePath = "Month";
        }

        private void CB_2_Copy3_DropDownClosed(object sender, EventArgs e)
        {
            dtDay = time.getday();
            CB_3_Copy3.ItemsSource = dtDay.DefaultView;
            CB_3_Copy3.DisplayMemberPath = "Day";
            CB_3_Copy3.SelectedValuePath = "Day";
        }

        private void CB_6_DropDownClosed(object sender, EventArgs e)
        {
            dtMonth = time.getmonth();
            CB_7.ItemsSource = dtMonth.DefaultView;
            CB_7.DisplayMemberPath = "Month";
            CB_7.SelectedValuePath = "Month";
        }

        private void CB_7_DropDownClosed(object sender, EventArgs e)
        {
            dtDay = time.getday();
            CB_8.ItemsSource = dtDay.DefaultView;
            CB_8.DisplayMemberPath = "Day";
            CB_8.SelectedValuePath = "Day";

        }

        private void CB_6_Copy_DropDownClosed(object sender, EventArgs e)
        {
            dtMonth = time.getmonth();
            CB_7_Copy.ItemsSource = dtMonth.DefaultView;
            CB_7_Copy.DisplayMemberPath = "Month";
            CB_7_Copy.SelectedValuePath = "Month";
        }

        private void CB_7_Copy_DropDownClosed(object sender, EventArgs e)
        {
            dtDay = time.getday();
            CB_8_Copy.ItemsSource = dtDay.DefaultView;
            CB_8_Copy.DisplayMemberPath = "Day";
            CB_8_Copy.SelectedValuePath = "Day";

        }

     

     

        private void CB_11_DropDownClosed(object sender, EventArgs e)
        {
            dtMonth = time.getmonth();
            CB_12.ItemsSource = dtMonth.DefaultView;
            CB_12.DisplayMemberPath = "Month";
            CB_12.SelectedValuePath = "Month";
        }

        private void CB_12_DropDownClosed(object sender, EventArgs e)
        {
            dtDay = time.getday();
            CB_13.ItemsSource = dtDay.DefaultView;
            CB_13.DisplayMemberPath = "Day";
            CB_13.SelectedValuePath = "Day";
        }

        private void CB_11_Copy_DropDownClosed(object sender, EventArgs e)
        {
            dtMonth = time.getmonth();
            CB_12_Copy.ItemsSource = dtMonth.DefaultView;
            CB_12_Copy.DisplayMemberPath = "Month";
            CB_12_Copy.SelectedValuePath = "Month";
        }

        private void CB_12_Copy_DropDownClosed(object sender, EventArgs e)
        {
            dtDay = time.getday();
            CB_13_Copy.ItemsSource = dtDay.DefaultView;
            CB_13_Copy.DisplayMemberPath = "Day";
            CB_13_Copy.SelectedValuePath = "Day";
        }

        private void But_update_PMH_Click(object sender, RoutedEventArgs e)
        {
            TB_PMH pm = new TB_PMH();
            pm.BIHNum = Lab_ShowBINNum.Content.ToString();
     

            if((CB_PHM_HaveSick.SelectedItem as ComboBoxItem).Content.ToString()=="有病")
            {
                pm.Health_State = 1;
                if((CB_PMH_ComplexSice.SelectedItem as ComboBoxItem).Content.ToString()=="有")
                {
                    pm.ComplexSice_State = 1;

                   
                    TB_PMH_ComplexSick tpc = new TB_PMH_ComplexSick();
                    tpc.BIHNum = Lab_ShowBINNum.Content.ToString();
             

                    if(PHM_No1_gxy.IsChecked == true)
                    {
                        tpc.SickName = "高血压";
                        tpc.StartTime = CB_1.SelectedValue.ToString() + "/" + CB_2.SelectedValue.ToString() + "/" + CB_3.SelectedValue.ToString();
                        tpc.LastTime = CB_4.SelectedValue.ToString();
                        tpc.DrugName = Text1.Text.Trim();
                        tpc.CurativeEffect = (CB_5.SelectedItem as ComboBoxItem).Content.ToString();
                        tpc.update_TB_PMH_ComplexSick();
                    }
                    if(PHM_No1_gxz.IsChecked == true)
                    {
                        tpc.SickName = "高血脂";
                        tpc.StartTime = CB_1_Copy.SelectedValue.ToString() + "/" + CB_2_Copy.SelectedValue.ToString() + "/" + CB_3_Copy.SelectedValue.ToString();
                        tpc.LastTime = CB_4_Copy.SelectedValue.ToString();
                        tpc.DrugName = Text2.Text.Trim();
                        tpc.CurativeEffect = (CB_5_Copy.SelectedItem as ComboBoxItem).Content.ToString();
                        tpc.update_TB_PMH_ComplexSick();

                    }

                    if (PHM_No1_tnb.IsChecked == true)
                    {
                        tpc.SickName = "糖尿病";
                        tpc.StartTime = CB_1_Copy1.SelectedValue.ToString() + "/" + CB_2_Copy1.SelectedValue.ToString() + "/" + CB_3_Copy1.SelectedValue.ToString();
                        tpc.LastTime = CB_4_Copy1.SelectedValue.ToString();
                        tpc.DrugName = Text3.Text.Trim();
                        tpc.CurativeEffect = (CB_5_Copy1.SelectedItem as ComboBoxItem).Content.ToString();
                        tpc.update_TB_PMH_ComplexSick();

                    }
                    if (PHM_No1_gxb.IsChecked == true)
                    {
                        tpc.SickName = "冠心病";
                        tpc.StartTime = CB_1_Copy2.SelectedValue.ToString() + "/" + CB_2_Copy2.SelectedValue.ToString() + "/" + CB_3_Copy2.SelectedValue.ToString();
                        tpc.LastTime = CB_4_Copy2.SelectedValue.ToString();
                        tpc.DrugName = Text4.Text.Trim();
                        tpc.CurativeEffect = (CB_5_Copy2.SelectedItem as ComboBoxItem).Content.ToString();
                        tpc.update_TB_PMH_ComplexSick();

                    }
                    if (PHM_No1_ng.IsChecked == true)
                    {
                        tpc.SickName = "脑梗";
                        tpc.StartTime = CB_1_Copy3.SelectedValue.ToString() + "/" + CB_2_Copy2.SelectedValue.ToString() + "/" + CB_3_Copy2.SelectedValue.ToString();
                        tpc.LastTime = CB_4_Copy3.SelectedValue.ToString();
                        tpc.DrugName = Text5.Text.Trim();
                        tpc.CurativeEffect = (CB_5_Copy3.SelectedItem as ComboBoxItem).Content.ToString();
                        tpc.update_TB_PMH_ComplexSick();

                    }
                  
                   
                    

                }
                if((CB_PMH_NDC.SelectedItem as ComboBoxItem).Content.ToString()=="有")
                {
                    pm.NDC_State = 1;
                    TB_PMH_NDC tpn = new TB_PMH_NDC();
                    tpn.BIHNum = Lab_ShowBINNum.Content.ToString();
        

                    if(PHM_No2_gy.IsChecked==true)
                    {
                        tpn.SickName = "肝炎";
                        tpn.StartTime =CB_6.SelectedValue.ToString()+"/"+CB_7.SelectedValue.ToString()+"/"+CB_8.SelectedValue.ToString();
            //            tpn.Cure = (CB_9.SelectedItem as ComboBoxItem).Content.ToString();
                        tpn.CurativeEffect = (CB_10.SelectedItem as ComboBoxItem).Content.ToString();
                        tpn.update_TB_PMH_NDC();
                    }
                    if(PHM_fjh.IsChecked == true)
                    {
                        tpn.SickName = "肺结核";
             //           tpn.StartTime =CB_6_Copy.SelectedValue.ToString()+"/"+CB_7_Copy.SelectedValue.ToString()+"/"+CB_8_Copy.SelectedValue.ToString();
              //          tpn.Cure = (CB_9_Copy.SelectedItem as ComboBoxItem).Content.ToString();
                        tpn.CurativeEffect = (CB_10_Copy.SelectedItem as ComboBoxItem).Content.ToString();
                        tpn.update_TB_PMH_NDC();
                    }
                }
                if((CB_No3_Surgery.SelectedItem as ComboBoxItem).Content.ToString()=="有")
                {
                    pm.Surgery_State = 1;
                    TB_PMH_Surgery tps = new TB_PMH_Surgery();
                    tps.BIHNum = Lab_ShowBINNum.Content.ToString();
                  
                    tps.OperationName = Text_No3_SurgeryName.Text.ToString();
                    tps.OPerationTime = CB_11.SelectedValue.ToString()+"/"+CB_12.SelectedValue.ToString()+"/"+CB_13.SelectedValue.ToString();
                }
                if((CB_No3_Trauma.SelectedItem as ComboBoxItem).Content.ToString()=="有")
                {
                    pm.Trauma_State = 1;
                     TB_PMH_Trauma tpt = new TB_PMH_Trauma();
                    tpt.BIHNum = Lab_ShowBINNum.Content.ToString();


                    tpt.TraumaPart = Text_No3_TraumaName.Text.ToString();
                    tpt.TraumaTime = CB_11_Copy.SelectedValue.ToString()+"/"+CB_12_Copy.SelectedValue.ToString()+"/"+CB_13_Copy.SelectedValue.ToString();

                    tpt.update_TB_PMH_Trauma();

                }
                pm.Vaccinate_State = (CB_No3_Vaccinate.SelectedItem as ComboBoxItem).Content.ToString();

                if((CB_No3_DrugAllergy.SelectedItem as ComboBoxItem).Content.ToString()=="有")
                {
                    pm.DrugAllergy = 1;
                   TB_PMH_DrugAllergy tpda = new TB_PMH_DrugAllergy();
                    tpda.BIHNum = Lab_ShowBINNum.Content.ToString();
                    tpda.DrupName = Text_No3_DrugAllergyName.Text.ToString();
                    tpda.update_TB_PMH_DrugAllergy();

                }
                pm.update_TB_PMH();
                PersonalHis ph = new PersonalHis();

                ph.Lab_ShowBINNum.Content = this.Lab_ShowBINNum.Content;
                ph.Lab_ShowJobNum.Content = this.Lab_ShowJobNum.Content;
                ph.Lab_ShowBINName.Content = this.Lab_BINName.Content;
                ph.Show();
                this.Hide();


            }
        }










































    }
}
