using System;
using System.Collections.Generic;
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
    /// PHI.xaml 的交互逻辑
    /// </summary>
    public partial class PHI : Window
    {
        public PHI()
        {
            InitializeComponent();
        }

        private void update_PHI_Click(object sender, RoutedEventArgs e)
        {
            PHI_State ps = new PHI_State();
            ps.BIHNum = Lab_ShowBINNum.Content.ToString();
           
            
            PNA pna = new PNA();
            
            COPD copd = new COPD();
            BEA bea = new BEA();
            PHI_CA ca = new PHI_CA();
            PHI_Pleuraleffusion peff = new PHI_Pleuraleffusion();

            if(CBox_PNA.IsChecked == true)
            {
                pna.Lab_ShowBINNum.Content = this.Lab_ShowBINNum.Content;
                pna.Lab_ShowJobNum.Content = this.Lab_ShowJobNum.Content;
                pna.Lab_ShowBINName.Content = this.Lab_ShowBINName.Content;
                pna.Show();
                this.Hide();

                ps.PNA = 1;

                
            }
            else if(CBox_BEA.IsChecked == true)
            {
                bea.Lab_ShowBINNum.Content = this.Lab_ShowBINNum.Content;
                bea.Lab_ShowJobNum.Content = this.Lab_ShowJobNum.Content;
                bea.Lab_ShowBINName.Content = this.Lab_ShowBINName.Content;
                bea.Show();
                this.Hide();
                ps.BEA = 1;
            }

            else if(CBox_COPD.IsChecked ==true)
            {
                copd.Lab_ShowBINNum.Content = this.Lab_ShowBINNum.Content;
                copd.Lab_ShowJobNum.Content = this.Lab_ShowJobNum.Content;
                copd.Lab_ShowBINName.Content = this.Lab_ShowBINName.Content;
                copd.Show();
                this.Hide();
                ps.COPD = 1;
                
            }
            else if(CBox_LunCA.IsChecked ==true)
            {
                ca.Lab_ShowBINNum.Content = this.Lab_ShowBINNum.Content;
                ca.Lab_ShowJobNum.Content = this.Lab_ShowJobNum.Content;
                ca.Lab_ShowBINName.Content = this.Lab_ShowBINName.Content;
                ca.Show();
                this.Hide();
                ps.CA = 1;
            }
            else if(CBox_Pleuraleffusion.IsChecked ==true)
            {
                peff.Lab_ShowBINNum.Content = this.Lab_ShowBINNum.Content;
                peff.Lab_ShowJobNum.Content = this.Lab_ShowJobNum.Content;
                peff.Lab_ShowBINName.Content = this.Lab_ShowBINName.Content;
                peff.Show();
                this.Hide();
                ps.peff = 1;
            }

             if (CBox_BEA.IsChecked == true)
            {
               
                ps.BEA = 1;
            }

             if (CBox_COPD.IsChecked == true)
            {
                
                ps.COPD = 1;

            }
             if (CBox_LunCA.IsChecked == true)
            {
                
                ps.CA = 1;
            }
             if (CBox_Pleuraleffusion.IsChecked == true)
            {
                
                ps.peff = 1;
            }
            ps.update_TB_PHI();
        }
    }
}
