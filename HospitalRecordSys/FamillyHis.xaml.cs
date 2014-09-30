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
    /// FamillyHis.xaml 的交互逻辑
    /// </summary>
    public partial class FamillyHis : Window
    {
        Database db = new Database();
        DataTable dt = new DataTable();
        DataTable dtNum = new DataTable();
        DataTable dtYear = new DataTable();

        DataTable dtMonth = new DataTable();
        DataTable dtDay = new DataTable();



        DataSet ds = new DataSet();
        string sqlString = string.Empty;




        PHI phi = new PHI();
        Num num = new Num();
        Time time = new Time();


        string sick1, sick2, sick3, sickother;
        public FamillyHis()
        {
            InitializeComponent();
            dtNum = num.getnum();
            CB_PassAge_Father.ItemsSource = dtNum.DefaultView;
            CB_PassAge_Father.DisplayMemberPath = "Num";
            CB_PassAge_Father.SelectedValuePath = "Num";


            CB_PassAge_Mother.ItemsSource = dtNum.DefaultView;
            CB_PassAge_Mother.DisplayMemberPath = "Num";
            CB_PassAge_Mother.SelectedValuePath = "Num";


            CB_FamillyHis_Child_Num.ItemsSource = dtNum.DefaultView;
            CB_FamillyHis_Child_Num.DisplayMemberPath = "Num";
            CB_FamillyHis_Child_Num.SelectedValuePath = "Num";
        }

        private void But_update_FamillyHis_Click(object sender, RoutedEventArgs e)
        {
            TB_FamillyHis tfh = new TB_FamillyHis();
            tfh.BIHNum = Lab_ShowBINNum.Content.ToString();
   
            if ((CB_FamillyHis_Father.SelectedItem as ComboBoxItem).Content.ToString() == "已故")
            {
                tfh.Father_State = 1;

                TB_FamillyHis_Mother tfhf = new TB_FamillyHis_Mother();
                tfhf.BIHNum = Lab_ShowBINNum.Content.ToString();
              
                tfhf.PassAge = Convert.ToInt32(CB_PassAge_Father.SelectedValue.ToString());
                tfhf.PassReason = Text_FamillyHis_Father_PassAge_PassReason.Text.Trim();

                if (Lab_FamillyHis_Father_Sick_gxy.IsChecked == true)
                {
                    sick1 = "高血压、";
                }
                if (Lab_FamillyHis_Father_Sick_zl.IsChecked == true)
                {
                    sick2 = "肿瘤、";
                }
                if (Lab_FamillyHis_Father_Sick_tnb.IsChecked == true)
                {
                    sick3 = "糖尿病、";
                }
                if (Lab_FamillyHis_Father_Sick_Other.IsChecked == true)
                {
                    sickother = Father_Sick_other.Text.Trim();
                }

                string sick = sick1 + sick2 + sick3 + sickother;
                if (sick != null)
                {
                    tfhf.Sick_State = 1;
                    TB_FamillyHis_Father_Sick tfhfs = new TB_FamillyHis_Father_Sick();
                    tfhfs.BIHNum = Lab_ShowBINNum.Content.ToString();
                   
                    tfhfs.SickName = sick;
                    tfhfs.update_TB_FamillyHis_Father_Sick();
                }




                if ((CB_FamillyHis_Mother.SelectedItem as ComboBoxItem).Content.ToString() == "已故")
                {
                    tfh.Mother_State = 1;

                    TB_FamillyHis_Mother tfhm = new TB_FamillyHis_Mother();
                    tfhm.BIHNum = Lab_ShowBINNum.Content.ToString();
              
                    tfhm.PassAge = Convert.ToInt32(CB_PassAge_Father.SelectedValue.ToString());
                    tfhm.PassReason = Text_FamillyHis_Father_PassAge_PassReason.Text.Trim();

                    if (Lab_FamillyHis_Father_Sick_gxy.IsChecked == true)
                    {
                        sick1 = "高血压、";
                    }
                    if (Lab_FamillyHis_Mother_Sick_zl.IsChecked == true)
                    {
                        sick2 = "肿瘤、";
                    }
                    if (Lab_FamillyHis_Mother_Sick_tnb.IsChecked == true)
                    {
                        sick3 = "糖尿病、";
                    }
                    if (Lab_FamillyHis_Mother_Sick_Other.IsChecked == true)
                    {
                        sickother = Mother_Sick_other_Copy.Text.Trim();
                    }

                    string sick_mother = sick1 + sick2 + sick3 + sickother;
                    if (sick_mother != null)
                    {
                        tfhm.Sick_State = 1;
                        TB_FamillyHis_Mother_Sick tfhms = new TB_FamillyHis_Mother_Sick();
                        tfhms.BIHNum = Lab_ShowBINNum.Content.ToString();
                      
                        tfhms.SickName = sick_mother;
                        tfhms.update_TB_FamillyHis_Mother_Sick();
                    }





                }

                if ((Text_FamillyHis_Brother.SelectedItem as ComboBoxItem).Content.ToString() == "有")
                {
                    tfh.Brother_State = 1;
                    TB_FamillyHis_Brother tfhb = new TB_FamillyHis_Brother();
                    tfhb.BIHNum = Lab_ShowBINNum.Content.ToString();
                  

                    if (Lab_FamillyHis_Brother_Sick_gxy.IsChecked == true)
                    {
                        sick1 = "高血压、";
                    }
                    if (Lab_FamillyHis_Brother_Sick_zl.IsChecked == true)
                    {
                        sick2 = "肿瘤、";
                    }
                    if (Lab_FamillyHis_Brother_Sick_tnb.IsChecked == true)
                    {
                        sick3 = "糖尿病、";
                    }
                    if (Lab_FamillyHis_Brother_Sick_Other.IsChecked == true)
                    {
                        sickother = Text_FamillyHis_Brother_Sick.Text.Trim();
                    }
                    string sickBrother = sick1 + sick2 + sick3 + sickother;

                    if (sickBrother != null)
                    {
                        TB_FamillyHis_Brother_Sick tfhbs = new TB_FamillyHis_Brother_Sick();
                        tfhbs.BIHNum = Lab_ShowBINNum.Content.ToString();
            

                        tfhbs.SickName = sickBrother;
                        tfhbs.update_TB_FamillyHis_Brother_Sick();
                    }
                }



                if ((CB_FamillyHis_Sister.SelectedItem as ComboBoxItem).Content.ToString() == "有")
                {
                    tfh.Sister_State = 1;
                    TB_FamillyHis_Sister tfhs = new TB_FamillyHis_Sister();
                    tfhs.BIHNum = Lab_ShowBINNum.Content.ToString();
                   

                    if (Lab_FamillyHis_Sister_Sick_gxy_Copy.IsChecked == true)
                    {
                        sick1 = "高血压、";
                    }
                    if (Lab_FamillyHis_Sister_Sick_zl_Copy.IsChecked == true)
                    {
                        sick2 = "肿瘤、";
                    }
                    if (Lab_FamillyHis_Sister_Sick_tnb_Copy.IsChecked == true)
                    {
                        sick3 = "糖尿病、";
                    }
                    if (Lab_FamillyHis_Sister_Sick_Other_Copy.IsChecked == true)
                    {
                        sickother = Text_FamillyHis_Brother_Sick.Text.Trim();
                    }
                    string sickSister = sick1 + sick2 + sick3 + sickother;

                    if (sickSister != null)
                    {
                        TB_FamillyHis_Sister_Sick tfhss = new TB_FamillyHis_Sister_Sick();
                        tfhss.BIHNum = Lab_ShowBINNum.Content.ToString();
                       

                        tfhss.SickName = sickSister;
                        tfhss.update_TB_FamillyHis_Sister_Sick();
                    }
                }

                if ((CB_FamillyHis_Child.SelectedItem as ComboBoxItem).Content.ToString() == "有")
                {

                    tfh.Child_State = 1;
                    TB_FamillyHis_Child tfhc = new TB_FamillyHis_Child();
                    tfhc.BIHNum = Lab_ShowBINNum.Content.ToString();
           

                    tfhc.ChildNum = Convert.ToInt32(CB_FamillyHis_Child_Num.SelectedValue.ToString());
                    tfhc.update_TB_FamillyHis_Child();
                }
            }
                tfh.update_TB_FamillyHis();
                ReadyWord rw = new ReadyWord();
                rw.Lab_ShowBINNum.Content = this.Lab_ShowBINNum.Content;
                rw.Lab_ShowJobNum.Content = this.Lab_ShowJobNum.Content;
                rw.Lab_ShowBINName.Content = this.Lab_BINName.Content;
                rw.Show();
                this.Hide();

           
        }
    }
}