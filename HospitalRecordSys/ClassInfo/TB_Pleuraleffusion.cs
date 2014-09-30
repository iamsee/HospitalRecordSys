using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys
{
    class TB_Pleuraleffusion
    {
        Database db = new Database();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string sqlString = string.Empty;

        public string BIHNum;
        public int BreathHard_State;
        public int Fever_State;
        public int Cough_State;
        public int ChestPain_State;
        public int RapidBreath_State;
        public int Wasting_State;

        public void update_TB_Pleuraleffusion()
        {
            sqlString = "update TB_Pleuraleffusion set BreathHard_State=" + BreathHard_State + ",Fever_State=" + Fever_State + ",Cough_State=" + Cough_State + ",ChestPain_State=" + ChestPain_State + ",RapidBreath_State=" + RapidBreath_State + ",Wasting_State=" + Wasting_State + ";";
            db.ExecuteSQL(sqlString);
        }

        public void get_TB_Pleuraleffusion()
        {
            sqlString = "select * from TB_Pleuraleffusion where BIHNum =" + BIHNum + "';";
            ds = db.GetDataSet(sqlString);
            this.BreathHard_State = Convert.ToInt32(ds.Tables[0].Rows[0][1].ToString());
            this.Fever_State = Convert.ToInt32(ds.Tables[0].Rows[0][2].ToString());
            this.Cough_State = Convert.ToInt32(ds.Tables[0].Rows[0][3].ToString());
            this.ChestPain_State = Convert.ToInt32(ds.Tables[0].Rows[0][4].ToString());
            this.RapidBreath_State = Convert.ToInt32(ds.Tables[0].Rows[0][5].ToString());
            this.Wasting_State = Convert.ToInt32(ds.Tables[0].Rows[0][5].ToString());
           
        }

    }
}
