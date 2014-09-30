using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys
{
    class TB_LunCA
    {
        Database db = new Database();
        string sqlString = string.Empty;
        DataSet ds = new DataSet();

        public string BIHNum;
        public int Cough_State;
        public int CoughBlood_State;
        public int RapidBreath_State;
        public int WeightFall_State;
        public int ChestPain_State;
        public int SwallowHard_State;
        public int VoiceDumb_State;
        public int SVCS_State;
        public int Complex_State;
        public int BonePartPain_State;
        public int Anorexia_State;
        public int LymphGrow_State;
        public int EarlierCheck_State;

        public void update_TB_LunCA()
        {
            sqlString = "update TB_LunCA set Cough_State=" + Cough_State + ",CoughBlood_State=" + CoughBlood_State + ",RapidBreath_State=" + RapidBreath_State + ",WeightFall_State=" + WeightFall_State + ",ChestPain_State=" + ChestPain_State + ",SwallowHard_State=" + SwallowHard_State + ",VoiceDumb_State=" + VoiceDumb_State + ",SVCS_State=" + SVCS_State + ",Complex_State=" + Complex_State + ",BonePartPain_State=" + BonePartPain_State + ",Anorexia_State=" + Anorexia_State + ",LymphGrow_State=" + LymphGrow_State + ",EarlierCheck_State=" + EarlierCheck_State + " where BIHNum='" + BIHNum + "';";
            db.ExecuteSQL(sqlString);
        }

         public void get_TB_LunCA()
        {
            sqlString = "select * from TB_LunCA where BIHNum ="+BIHNum+"';";
            ds = db.GetDataSet(sqlString);
            this.Cough_State = Convert.ToInt32(ds.Tables[0].Rows[0][1].ToString());
            this.CoughBlood_State = Convert.ToInt32(ds.Tables[0].Rows[0][2].ToString());
            this.RapidBreath_State = Convert.ToInt32(ds.Tables[0].Rows[0][3].ToString());
            this.WeightFall_State = Convert.ToInt32(ds.Tables[0].Rows[0][4].ToString());
            this.ChestPain_State = Convert.ToInt32(ds.Tables[0].Rows[0][5].ToString());
            this.SwallowHard_State = Convert.ToInt32(ds.Tables[0].Rows[0][5].ToString());
            this.VoiceDumb_State = Convert.ToInt32(ds.Tables[0].Rows[0][5].ToString());
            this.SVCS_State = Convert.ToInt32(ds.Tables[0].Rows[0][5].ToString());
            this.Complex_State = Convert.ToInt32(ds.Tables[0].Rows[0][5].ToString());
            this.BonePartPain_State = Convert.ToInt32(ds.Tables[0].Rows[0][5].ToString());
            this.Anorexia_State = Convert.ToInt32(ds.Tables[0].Rows[0][5].ToString());
            this.LymphGrow_State = Convert.ToInt32(ds.Tables[0].Rows[0][5].ToString());
            this.EarlierCheck_State = Convert.ToInt32(ds.Tables[0].Rows[0][5].ToString());

        }

    }
}
