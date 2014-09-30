using System;
using System.Collections.Generic;
using System.Data;

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
    /// PHI_CA.xaml 的交互逻辑
    /// </summary>
    public partial class PHI_CA : Window
    {

        public PHI_CA()
        {
            InitializeComponent();
            Num num = new Num();
            DataTable dtNum = new DataTable();
            dtNum = num.getnum();


            CB_Cough_LastTime.ItemsSource = dtNum.DefaultView;
            CB_Cough_LastTime.DisplayMemberPath = "Num";
            CB_Cough_LastTime.SelectedValuePath = "Num";

            CB_Cough_Blood_LastTime.ItemsSource = dtNum.DefaultView;
            CB_Cough_Blood_LastTime.DisplayMemberPath = "Num";
            CB_Cough_Blood_LastTime.SelectedValuePath = "Num";

            CB_ChestPain_LastTimeChestPainHour.ItemsSource = dtNum.DefaultView;
            CB_ChestPain_LastTimeChestPainHour.DisplayMemberPath = "Num";
            CB_ChestPain_LastTimeChestPainHour.SelectedValuePath = "Num";



        }

        private void But_Update_CA_Click(object sender, RoutedEventArgs e)
        {
            string Cbox1 = "";
            string Cbox2 = "";
            string Cbox3 = "";
            string Cbox4 = "";
            TB_LunCA tl = new TB_LunCA();
            tl.BIHNum = Lab_ShowBINNum.Content.ToString();
            if ((CB_Cough.SelectedItem as ComboBoxItem).Content.ToString() == "是")
            {
                tl.Cough_State = 1;
                TB_LunCA_Cough tlc = new TB_LunCA_Cough();
                tlc.BIHNum = Lab_ShowBINNum.Content.ToString();

                tlc.LastTime = Convert.ToInt32(CB_Cough_LastTime.SelectedValue.ToString());
                tlc.ClearTime = CB_Cough_ClearTime.SelectedValue.ToString();
                if ((CB_Luggies.SelectedItem as ComboBoxItem).Content.ToString() == "是")
                {
                    tlc.Luggies = 1;
                    TB_LunCA_Cough_Luggies tlcl = new TB_LunCA_Cough_Luggies();

                    tlcl.BIHNum = Lab_ShowBINNum.Content.ToString();


                    tlcl.Color = (CB_ColorLuggiesCough.SelectedItem as ComboBoxItem).Content.ToString();
                    tlcl.ClearTime = (CB_Luggies_Cough.SelectedItem as ComboBoxItem).Content.ToString();
                    tlcl.Blood = ((CB_BloodLuggiesCough.SelectedItem as ComboBoxItem).Content.ToString());
                    tlcl.update_TB_LunCA_Cough_Luggies();

                }

            }
            if ((CB_Cough_Blood.SelectedItem as ComboBoxItem).Content.ToString() == "是")
            {
                tl.CoughBlood_State = 1;
                TB_LunCA_CoughBlood tlcb = new TB_LunCA_CoughBlood();
                tlcb.BIHNum = Lab_ShowBINNum.Content.ToString();


                tlcb.BloodNuture = (CB_BEA_BloodLuggiesCough_Num.SelectedItem as ComboBoxItem).Content.ToString();
                tlcb.Color = (CB_BEA_BloodLuggiesCough_Color.SelectedItem as ComboBoxItem).Content.ToString();
                //MessageBox.Show(CB_Cough_Blood_LastTime.SelectedValue.ToString());
                tlcb.LastTime = Convert.ToInt32(CB_Cough_Blood_LastTime.SelectedValue.ToString());
                tlcb.update_TB_LunCA_CoughBlood();

            }

            if ((CB_WeightFall_Copy.SelectedItem as ComboBoxItem).Content.ToString() == "是")
            {
                tl.ChestPain_State = 1;
                TB_LunCA_ChestPain tlcp = new TB_LunCA_ChestPain();
                tlcp.BIHNum = Lab_ShowBINNum.Content.ToString();


                tlcp.LastTime = Convert.ToInt32(CB_ChestPain_LastTimeChestPainHour.SelectedValue.ToString());
                tlcp.PainNature = (CB_PNA_ChestPain_PainNature.SelectedItem as ComboBoxItem).Content.ToString();
                tlcp.Position = (CB_PNA_ChestPain_Position.SelectedItem as ComboBoxItem).Content.ToString();

                if ((CB_WeightFall.SelectedItem as ComboBoxItem).Content.ToString() == "是")
                {
                    tl.WeightFall_State = 1;
                }
                if ((CB_SwallowHard.SelectedItem as ComboBoxItem).Content.ToString() == "是")
                {
                    tl.SwallowHard_State = 1;

                }
                if ((CB_VoiceDumb.SelectedItem as ComboBoxItem).Content.ToString() == "是")
                {
                    tl.VoiceDumb_State = 1;
                }

                if (CBox_1.IsChecked == true)
                {
                    Cbox1 = "无";
                }
                if (CBox_1_Copy.IsChecked == true)
                {
                    Cbox2 = "头、面部、颈部、上肢水肿、";
                }
                if (CBox_1_Copy1.IsChecked == true)
                {
                    Cbox3 = "胸前淤血和静脉曲张、";
                }
                if (CBox_1_Copy2.IsChecked == true)
                {
                    Cbox4 = "头昏、头痛、眩晕";
                }

                if (Cbox1 == "无")
                {
                    tl.SVCS_State = 1;
                    TB_LunCA_SVCS tls = new TB_LunCA_SVCS();
                    tls.BIHNum = Lab_ShowBINNum.Content.ToString();


                    tls.SVCSShow = Cbox2 + Cbox3 + Cbox4;

                    tls.update_TB_LunCA_SVCS();

                }

                if ((CB_BonePartPain.SelectedItem as ComboBoxItem).Content.ToString() == "是")
                {
                    tl.BonePartPain_State = 1;
                    TB_LunCA_BonePartPain tlbpp = new TB_LunCA_BonePartPain();
                    tlbpp.BIHNum = Lab_ShowBINNum.Content.ToString();
                    tlbpp.BonePartPainShow = Text_BonePartPain.Text.Trim();
                    tlbpp.update_TB_LunCA_BonePartPain();
                }

                if ((CB_Anorexia.SelectedItem as ComboBoxItem).Content.ToString() == "是")
                {
                    tl.Anorexia_State = 1;
                }
                if ((CB_LymphGrow.SelectedItem as ComboBoxItem).Content.ToString() == "是")
                {
                    tl.LymphGrow_State = 1;
                    TB_LunCA_LymphGrow tllg = new TB_LunCA_LymphGrow();
                    tllg.BIHNum = Lab_ShowBINNum.Content.ToString();

                    tllg.LymphGrowShow = Text_LymphGrow.Text.Trim();
                }
                tl.EarlierCheck_State = 1;
                TB_LunCA_EarlierCheck tlec = new TB_LunCA_EarlierCheck();
                tlec.BIHNum = Lab_ShowBINNum.Content.ToString();
                tlec.CTShow = Text_EarlierCheck_CT.Text.Trim();
                tlec.LuggiesSickShow = Text_EarlierCheck_Lug.Text.Trim();
                tlec.update_TB_LunCA_EarlierCheck();
                tl.update_TB_LunCA();
                ;


            }
            PHI phi = new PHI();
            PHI_Pleuraleffusion peff = new PHI_Pleuraleffusion();
            PHI_State ps = new PHI_State();
            ps.BIHNum = Lab_ShowBINNum.Content.ToString();
            ps.get_TB_PHI();

            if (ps.peff == 1)
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
