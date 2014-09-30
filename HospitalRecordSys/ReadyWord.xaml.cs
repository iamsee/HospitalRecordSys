using System;
using System.Collections.Generic;
using System.IO;
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
using Word = Microsoft.Office.Interop.Word;




namespace HospitalRecordSys
{
    /// <summary>
    /// ReadyWord.xaml 的交互逻辑
    /// </summary>
    public partial class ReadyWord : Window
    {
        public ReadyWord()
        {
            InitializeComponent();


        }
        private void But_Update_Word_Click(object sender, RoutedEventArgs e)
        {
            PHI_State ps = new PHI_State();
            UserBaseClass ubc = new UserBaseClass();
            PHI_PNA pp = new PHI_PNA();
            PHI_PNA_BreathHard ppbh = new PHI_PNA_BreathHard();
            PHI_PNA_ChestPain ppcp = new PHI_PNA_ChestPain();
            PHI_PNA_Cough ppc = new PHI_PNA_Cough();
            PHI_PNA_Cough_Luggies ppcl = new PHI_PNA_Cough_Luggies();
            PHI_PNA_Fever ppf = new PHI_PNA_Fever();
            PHI_PNA_Fever_Drup ppfd = new PHI_PNA_Fever_Drup();
            PHI_PNA_Follow ppfoll = new PHI_PNA_Follow();
            ppfoll.BIHNum = Lab_ShowBINNum.Content.ToString();
            ppfd.BIHNum = Lab_ShowBINNum.Content.ToString();;
            ppf.BIHNum = Lab_ShowBINNum.Content.ToString();;
            ppcl.BIHNum = Lab_ShowBINNum.Content.ToString();;
            ppc.BIHNum = Lab_ShowBINNum.Content.ToString();;
            ppcp.BIHNum = Lab_ShowBINNum.Content.ToString();;
            ppbh.BIHNum = Lab_ShowBINNum.Content.ToString();;
            pp.BIHNum = Lab_ShowBINNum.Content.ToString();;

            ubc.BIHNum = Lab_ShowBINNum.Content.ToString();;

            ps.BIHNum = Lab_ShowBINNum.Content.ToString();;
            ubc.Get_UserBaseClass();
            ps.get_TB_PHI();
            pp.get_TB_PNA();
            ppbh.get_TB_PNA_BreathHard();
            ppcp.get_TB_PNA_ChestPain();
            ppc.get_TB_PNA_ChestCough();
            ppcl.get_TB_PNA_Cough_Luggies();
            ppf.get_TB_PNA_Fever();
            ppfd.get_TB_PNA_Fever_Drup();
            ppfoll.get_TB_PNA_Follow();




           




            Word.Application app = new Word.Application();
            //模板文件
            string TemplateFile = @"c:\模板.docx";
            //生成的具有模板样式的新文件
            string FileName = @"c:\" + DateTime.Now.ToString("yyyyMMddHHmmssfffffff") + ".doc";
            string Fname = DateTime.Now.ToString("yyyyMMddHHmmssfffffff") + ".doc";
            //FileName = Server.MapPath("~/UpLoad/TestWord/" + Fname );
            //模板文件拷贝到新文件
            File.Copy(TemplateFile, FileName);
            Word.Document doc = new Word.Document();
            object Obj_FileName = FileName;
            object Visible = false;
            object ReadOnly = false;
            object missing = System.Reflection.Missing.Value;
            //打开文件
            doc = app.Documents.Open(ref Obj_FileName, ref missing, ref ReadOnly, ref missing,
                ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref Visible,
                ref missing, ref missing, ref missing,
                ref missing);
            doc.Activate();

            //            MessageBox.Show(doc.Bookmarks.Count.ToString());
            foreach (Word.Bookmark bm in doc.Bookmarks)
            {

                bm.Select();
                //       MessageBox.Show(bm.Name.ToString());
                if (bm.Name.ToString() == "姓名")
                {
                    bm.Range.Text = ubc.Name;//ViewState["FK_ProdurcePlanID"].ToString();
                }
                else if (bm.Name == "出生地")
                {
                    bm.Range.Text = ubc.BirthLocal;
                }
                else if (bm.Name == "性别")
                {
                    bm.Range.Text = ubc.Sex;
                }
                else if (bm.Name == "工作单位")
                {
                    bm.Range.Text = ubc.WorkOrg;
                }
                else if (bm.Name == "年龄")
                {
                    bm.Range.Text = ubc.Age.ToString();
                }
                else if (bm.Name == "住址")
                {
                    bm.Range.Text = ubc.LiveLocal;
                   

                }
                else if (bm.Name == "婚姻")
                {
                    bm.Range.Text = ubc.MarryState;
                }
                else if (bm.Name == "病史陈述者")
                {
                    bm.Range.Text = ubc.DeclarePer;
                }
                else if (bm.Name == "民族")
                {
                    bm.Range.Text = ubc.Nation;
                   
                }
                else if (bm.Name == "入院日期")
                {
                    bm.Range.Text = ubc.BINTime;
                }
                else if (bm.Name == "记录日期")
                {
                    bm.Range.Text = ubc.RecordTime;
                }
                else if (bm.Name == "职业")
                {
                    bm.Range.Text = ubc.Vocation;
                }

                #region 现病史
                // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                else if (bm.Name == "xbs1")
                {

                    string PNA = "";
                    if (ps.PNA == 1)
                    {
                        PNA += "患有肺炎,";


                        if (pp.Fever_State == 1)
                        {
                            PNA += "发烧:";

                            PNA += "持续" + ppf.LastTime + "天," + "最高" + ppf.HighestHeat + "度，" + "一般" + ppf.TimeRange + "发烧,";
                            if (ppf.UserDrug == 1)
                            {
                                PNA += "吃过药 ";


                                PNA += ppfd.DrupName + ",药效" + ppfd.DrupEffect;
                            }
                            else
                            {
                                PNA += "没吃药";
                            }
                        }
                        else
                        {
                            PNA += "不发烧";
                        }
                        if (pp.Cough_State == 1)
                        {
                            PNA += "咳嗽:";

                            PNA += "持续时间+" + ppc.LastTime + "天," + ppc.ClearTime + "明显";
                            if (ppc.Luggies == 1)
                            {
                                PNA += "，流鼻涕 ";

                                PNA += ppcl.Color + ppcl.ClearTime + "明显," + ppcl.Blood;
                            }
                            else
                            { PNA += "不流鼻涕"; };
                        }
                        if (pp.ChestPain_State == 1)
                        {

                            PNA += "胸痛，" + "持续时间" + ppcp.LastTime + "疼痛性质" + ppcp.PainNature + ",疼痛部位 " + ppcp.Position;
                        }
                        else
                        {
                            PNA += "无胸痛";
                        }
                        if (pp.BreathHard_State == 1)
                        {

                            PNA += "呼吸困难," + "级别：" + ppbh.Level + "开始时间:" + ppbh.StartTime + "加重时间" + ppbh.StartDeepTime + "是否吃药" + ppbh.HaveDrug + ppbh.HaveDrugName;
                        }
                        else
                        {
                            PNA += "没出现呼吸困难";
                        }
                    }
                    bm.Range.Text = PNA;
                }
                else if (bm.Name == "xbs2")
                {
                    string BEA = "";
                    if (ps.BEA == 1)
                    {
                        BEA += "患有支气管哮喘";

                        PHI_BEA pb = new PHI_BEA();

                        if (pb.RapidBreath_State == 1)
                        {
                            BEA += "出现呼吸急促 ";
                            PHI_BEA_RapidBreath pbrb = new PHI_BEA_RapidBreath();

                            BEA += ",急促程度" + pbrb.RadidBreath + ",开始时间" + pbrb.StartTime + ",每次持续时间" + pbrb.LastTime + "，每天发作次数" + pbrb.CoutNum + ",有无明显加重时间" + pbrb.DeepShow + ",有无缓解现象";
                            if (pbrb.RelieveShow_State == 1)
                            {
                                BEA += "出现缓解";
                                PHI_BEA_RapidBreath_RelieveShow pbrbrb = new PHI_BEA_RapidBreath_RelieveShow();
                                BEA += pbrbrb.NoDrugGood + pbrbrb.DrugGood + pbrbrb.DrugBad;
                            }
                            else
                            {
                                BEA += "无缓解";

                            }


                        }
                        if (pb.Cough_State == 1)
                        {
                            BEA += "出现咳嗽";
                            PHI_BEA_Cough pbc = new PHI_BEA_Cough();
                            BEA += ",开始时间 " + pbc.StartTime;
                            if (pbc.Luggies == 1)
                            {
                                BEA += "流鼻涕";

                                PHI_BEA_Cough_Luggies pbcl = new PHI_BEA_Cough_Luggies();
                                BEA += pbcl.Color + pbcl.LuggiesAmount;
                                if (pbcl.BloodLuggies_State == 1)
                                {
                                    BEA += "出血";
                                    PHI_BEA_Cough_Luggies_BloodLuggies pbclbl = new PHI_BEA_Cough_Luggies_BloodLuggies();
                                    BEA += pbclbl.BloodNuture + pbclbl.BloodColor;

                                }
                                else
                                {
                                    BEA += "不出血";
                                }

                            }
                        }



                    }
                    bm.Range.Text = BEA;
                }




                else if (bm.Name == "xbs3")
                {
                    string LunCA = "";
                    if (ps.CA == 1)
                    {
                        LunCA = "患有肺CA";
                        TB_LunCA tlc = new TB_LunCA();
                        if (tlc.Cough_State == 1)
                        {
                            LunCA += "咳嗽";
                            TB_LunCA_Cough tlcc = new TB_LunCA_Cough();
                            LunCA += "持续时间" + tlcc.LastTime + "天" + tlcc.ClearTime;
                            if (tlcc.Luggies == 1)
                            {
                                LunCA += "流鼻涕";

                            }
                            else
                            {
                                LunCA += "不流鼻涕";
                            }

                        }







                        bm.Range.Text = LunCA;




                    }


                }
                #endregion

                #region 既往史
                else if (bm.Name == "jws")
                {
                    string JWS = "";
                    TB_PMH tp = new TB_PMH();
                    tp.BIHNum = Lab_ShowBINNum.Content.ToString();;
                    tp.get_TB_PMH();
                    if (tp.Health_State == 1)
                    {
                        JWS += "以往患有疾病。";
                        if (tp.ComplexSice_State == 1)
                        {
                            JWS += "一般疾病.";
                            TB_PMH_ComplexSick tpcs = new TB_PMH_ComplexSick();
                            tpcs.BIHNum = Lab_ShowBINNum.Content.ToString();;
                            tpcs.get_TB_PMH_ComplexSick();

                            JWS += "：" + tpcs.SickName + "," + tpcs.StartTime + "持续时间" + tpcs.LastTime + "吃药 " + tpcs.DrugName + "药效：" + tpcs.CurativeEffect;

                        }
                        if (tp.NDC_State == 1)
                        {
                            JWS += "传染性疾病：";
                            TB_PMH_NDC tpn = new TB_PMH_NDC();
                            tpn.BIHNum = Lab_ShowBINNum.Content.ToString();;
                            tpn.get_TB_PMH_NDC();
                            JWS += tpn.SickName + " 开始时间" + tpn.StartTime + "疗程 " + tpn.Cure + "治疗效果 " + tpn.CurativeEffect;

                        }
                        if (tp.Surgery_State == 1)
                        {
                            JWS += "有过外科手术";
                            TB_PMH_Surgery tps = new TB_PMH_Surgery();
                            tps.BIHNum = Lab_ShowBINNum.Content.ToString();;
                            tps.get_TB_PMH_Surgery();
                            JWS += tps.OperationName + "手术时间 " + tps.OPerationTime;
                        }
                        if (tp.Trauma_State == 1)
                        {
                            JWS += "有过外伤";
                            TB_PMH_Trauma tpt = new TB_PMH_Trauma();
                            tpt.BIHNum = Lab_ShowBINNum.Content.ToString();;
                            tpt.get_TB_PMH_Trauma();
                            JWS += "外伤时间" + tpt.TraumaTime + " 外伤部位 " + tpt.TraumaPart;
                        }
                        JWS += "接种状况：" + tp.Vaccinate_State;
                        if (tp.DrugAllergy == 1)
                        {
                            JWS += "有药物过敏";
                            TB_PMH_DrugAllergy tpda = new TB_PMH_DrugAllergy();
                            tpda.BIHNum = Lab_ShowBINNum.Content.ToString();;
                            tpda.get_TB_PMH_DrugAllergy();
                            JWS += "药名 " + tpda.DrupName;
                        }
                        
                    }
                    MessageBox.Show(JWS);
                    bm.Range.Text = JWS;

                }
                #region 个人史
                else if (bm.Name == "grx")
                {
                    string GRS = "";
                    TB_PersonalHis tph = new TB_PersonalHis();
                    tph.BIHNum = Lab_ShowBINNum.Content.ToString();;
                    tph.get_TB_PersonalHis();
                    GRS += "出生地：" + tph.BirthLocal + "居住地：" + tph.LiveLocal + "工作：" + tph.JobHow;


                    if (tph.JobEnviron_State == 1)
                    {
                        GRS += "工作环境接触有害物质";
                        TB_PersonalHis_JobEnviron tphje = new TB_PersonalHis_JobEnviron();
                        tphje.BIHNum = Lab_ShowBINNum.Content.ToString();;
                        tphje.get_TB_PersonalHis_JobEnviron();

                        GRS += "工作单位" + tphje.CompanyName + "工作性质" + tphje.TypeOfWork;
                    }
                    if (tph.GoLocal_State == 1)
                    {
                        GRS += "近期去过病源地";
                        TB_PersonalHis_GOLocal tphgl = new TB_PersonalHis_GOLocal();
                        tphgl.BIHNum = Lab_ShowBINNum.Content.ToString();;
                        tphgl.get_TB_PersonalHis_GOLocal();
                        GRS += tphgl.LocalName + "时间：" + tphgl.LastTime;

                    }
                    if (tph.Drink_State == 1)
                    {
                        GRS += "饮酒";
                        TB_PersonalHis_Drink tphd = new TB_PersonalHis_Drink();
                        tphd.BIHNum = Lab_ShowBINNum.Content.ToString();;
                        tphd.get_TB_PersonalHis_Drink();
                        GRS += tphd.DrinkMode + "饮酒量" + tphd.DrinkNum;

                    }
                    if (tph.Smoke_State == 1)
                    {
                        GRS += "吸烟";
                        TB_PersonalHis_Smoke tphs = new TB_PersonalHis_Smoke();
                        tphs.BIHNum = Lab_ShowBINNum.Content.ToString();;
                        tphs.get_TB_PersonalHis_Smoke();
                        GRS += "每天" + tphs.SmokeNum + "包，" + "烟龄" + tphs.SmokeLast + "年";

                    }
                    if (tph.OtherHobby_State == 1)
                    {
                        GRS += "有其它异嗜物";

                    }
                    if (tph.Marriage_State == 1)
                    {
                        GRS += "已经结婚";
                        TB_PersonalHis_Marriage tphm = new TB_PersonalHis_Marriage();
                        tphm.BIHNum = Lab_ShowBINNum.Content.ToString();;
                        tphm.get_TB_PersonalHis_Marriage();

                    }
                    else
                    {
                        GRS += "未婚";
                    }
                    bm.Range.Text = GRS;
                }
                #endregion
                #region 家族史
                else if (bm.Name == "jzs")
                {
                    string JZS = "";
                    TB_FamillyHis tf = new TB_FamillyHis();
                    tf.BIHNum = Lab_ShowBINNum.Content.ToString();;
                    tf.get_TB_FamillyHis();
                    if (tf.Father_State == 1)
                    {
                        JZS += "父亲去世，";
                        TB_FamillyHis_Father tff = new TB_FamillyHis_Father();
                        tff.BIHNum = Lab_ShowBINNum.Content.ToString();;
                        tff.get_TB_FamillyHis_Father();
                        JZS += "去世年龄" + tff.PassAge + "去世原因" + tff.PassReason;
                        if (tff.Sick_State == 1)
                        {
                            JZS += "生前患病：";
                            TB_FamillyHis_Father_Sick tffs = new TB_FamillyHis_Father_Sick();
                            tffs.BIHNum = Lab_ShowBINNum.Content.ToString();;
                            tffs.get_TB_FamillyHis_Father_Sick();
                            JZS += tffs.SickName;
                        }
                    }
                    else
                    {
                        TB_FamillyHis_Father tff = new TB_FamillyHis_Father();
                        tff.BIHNum = Lab_ShowBINNum.Content.ToString();;
                        tff.get_TB_FamillyHis_Father();
                        JZS += "父亲健在，";
                        if (tff.Sick_State == 1)
                        {
                            JZS += "患病：";
                            TB_FamillyHis_Father_Sick tffs = new TB_FamillyHis_Father_Sick();
                            tffs.BIHNum = Lab_ShowBINNum.Content.ToString();;
                            tffs.get_TB_FamillyHis_Father_Sick();
                            JZS += tffs.SickName;
                        }

                    }


                    if (tf.Mother_State == 1)
                    {
                        JZS += "母亲去世，";
                        TB_FamillyHis_Mother tfm = new TB_FamillyHis_Mother();
                        tfm.BIHNum = Lab_ShowBINNum.Content.ToString();;
                        tfm.get_TB_FamillyHis_Mother();
                        JZS += "去世年龄" + tfm.PassAge + "去世原因" + tfm.PassReason;
                        if (tfm.Sick_State == 1)
                        {
                            JZS += "生前患病：";
                            TB_FamillyHis_Mother_Sick tfms = new TB_FamillyHis_Mother_Sick();
                            tfms.BIHNum = Lab_ShowBINNum.Content.ToString();;
                            tfms.get_TB_FamillyHis_Mother_Sick();
                            JZS += tfms.SickName;
                        }

                        bm.Range.Text = JZS;

                    }
                    else
                    {
                        TB_FamillyHis_Mother tfm = new TB_FamillyHis_Mother();
                        tfm.BIHNum = Lab_ShowBINNum.Content.ToString();;
                        tfm.get_TB_FamillyHis_Mother();
                        JZS += "母亲健在";
                        if (tfm.Sick_State == 1)
                        {
                            JZS += "患病：";
                            TB_FamillyHis_Mother_Sick tfms = new TB_FamillyHis_Mother_Sick();
                            tfms.BIHNum = Lab_ShowBINNum.Content.ToString();;
                            tfms.get_TB_FamillyHis_Mother_Sick();
                            JZS += tfms.SickName;
                        }
                    }
                    if (tf.Sister_State == 1)
                    {
                        JZS += " 有姐妹";
                        TB_FamillyHis_Sister tfhs = new TB_FamillyHis_Sister();
                        tfhs.BIHNum = Lab_ShowBINNum.Content.ToString();;
                        tfhs.get_TB_FamillyHis_Sister();
                        JZS += "姐妹数量" + tfhs.SisterNum;
                        if (tfhs.Sick_State == 1)
                        {
                            JZS += "姐妹患病（曾）：";
                            TB_FamillyHis_Sister_Sick tfss = new TB_FamillyHis_Sister_Sick();
                            tfss.BIHNum = Lab_ShowBINNum.Content.ToString();;
                            tfss.get_TB_FamillyHis_Sister_Sick();
                            JZS += tfss.SickName;

                        }
                    }

                    if (tf.Brother_State == 1)
                    {
                        JZS += " 有兄弟 ";
                        TB_FamillyHis_Brother tfhb = new TB_FamillyHis_Brother();
                        tfhb.BIHNum = Lab_ShowBINNum.Content.ToString();;
                        tfhb.get_TB_FamillyHis_Brother();
                        JZS += "兄弟数量" + tfhb.BreatherNum;
                        if (tfhb.Sick_State == 1)
                        {
                            JZS += "兄弟患病（曾）：";
                            TB_FamillyHis_Brother_Sick tfbs = new TB_FamillyHis_Brother_Sick();
                            tfbs.BIHNum = Lab_ShowBINNum.Content.ToString();;
                            tfbs.get_TB_FamillyHis_Brother_Sick();
                            JZS += tfbs.SickName;

                        }
                    }

                    if (tf.Child_State == 1)
                    {
                        JZS += "有孩子";
                        TB_FamillyHis_Child tfc = new TB_FamillyHis_Child();
                        tfc.BIHNum = Lab_ShowBINNum.Content.ToString();;
                        tfc.get_TB_FamillyHis_Child();
                        JZS += tfc.ChildNum + "人";
                    }
                    bm.Range.Text = JZS;
                }

                #endregion
                #endregion
                else
                {
                    bm.Range.Text = "空的";
                }

            }
            object IsSave = true;
            doc.Close(ref IsSave, ref missing, ref missing);

            MessageBox.Show("生成word成功");
        }




    }
}


