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
    /// TGJC.xaml 的交互逻辑
    /// </summary>
    public partial class TGJC : Window
    {
        public TGJC()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TB_TGJC tt = new TB_TGJC();
            tt.BIHNum = Lab_ShowBINNum.Content.ToString();


            tt.tw = (CB_tw.SelectedItem as ComboBoxItem).Content.ToString();
            tt.mb = (cb_mb.SelectedItem as ComboBoxItem).Content.ToString();
            tt.hxpl = (cb_hxpl.SelectedItem as ComboBoxItem).Content.ToString();
            tt.xy = (cb_xy.SelectedItem as ComboBoxItem).Content.ToString();
            tt.fayu = (cb_fayu.SelectedItem as ComboBoxItem).Content.ToString();
            tt.yudiao = (cb_yudiao.SelectedItem as ComboBoxItem).Content.ToString();
            tt.tiwei = (cb_tiwei.SelectedItem as ComboBoxItem).Content.ToString();
            tt.yingyang = (cb_yingyang.SelectedItem as ComboBoxItem).Content.ToString();
            tt.mianrong = (cb_mianrong.SelectedItem as ComboBoxItem).Content.ToString();
            tt.tixing = (cb_tixing.SelectedItem as ComboBoxItem).Content.ToString();
            tt.yishi = (cb_yishi.SelectedItem as ComboBoxItem).Content.ToString();
            tt.biaoqing = (cb_biaoqing.SelectedItem as ComboBoxItem).Content.ToString();
            tt.butai = (cb_butai.SelectedItem as ComboBoxItem).Content.ToString();
            tt.yanse = (cb_yanse.SelectedItem as ComboBoxItem).Content.ToString();
            tt.shidu = (cb_shidu.SelectedItem as ComboBoxItem).Content.ToString();
            tt.tanxing = (cb_tanxing.SelectedItem as ComboBoxItem).Content.ToString();
            tt.tfyanse = (cb_tfyanse.SelectedItem as ComboBoxItem).Content.ToString();
            tt.touludaxiao = (cb_touludaxiao.SelectedItem as ComboBoxItem).Content.ToString();
            tt.toufashumi = (cb_toufashumi.SelectedItem as ComboBoxItem).Content.ToString();
            tt.jiemo = (cb_jiemo.SelectedItem as ComboBoxItem).Content.ToString();
            tt.jiaomo = (cb_jiaomo.SelectedItem as ComboBoxItem).Content.ToString();
            tt.sctongkong = (cb_sctongkong.SelectedItem as ComboBoxItem).Content.ToString();
            tt.gongmo = (cb_gongmo.SelectedItem as ComboBoxItem).Content.ToString();
            tt.tkxingzhuang = (cb_tkxingzhuang.SelectedItem as ComboBoxItem).Content.ToString();
            tt.tkdgfs = (cb_tkdgfs.SelectedItem as ComboBoxItem).Content.ToString();
            tt.updat_TB_TGJC();

        }
    }
}
