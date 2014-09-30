using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys
{
    class PHI_PNA
    {
        Database db = new Database();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string sqlString = string.Empty;
        

        public string BIHNum;
        public int Fever_State;
        public int Cough_State;
        public int BreathHard_State;
        public int ChestPain_State;
        public int Follow;

        public void update_TB_PNA()
        {
          
            sqlString = "update TB_PNA set Fever_State =" + Fever_State + ",Cough_State=" + Cough_State + ",BreathHard_State=" + BreathHard_State + ",ChestPain_State=" + ChestPain_State + ",Follow=" + Follow + " where BIHNum= '" + this.BIHNum + "';";
            db.ExecuteSQL(sqlString);
        }
        public void get_TB_PNA()
        {
            sqlString = "select * from TB_PNA where BIHNum ='"+BIHNum+"';";
            ds = db.GetDataSet(sqlString);
            this.Fever_State = Convert.ToInt32(ds.Tables[0].Rows[0][1].ToString());
            this.Cough_State = Convert.ToInt32(ds.Tables[0].Rows[0][2].ToString());
            this.BreathHard_State = Convert.ToInt32(ds.Tables[0].Rows[0][3].ToString());
            this.ChestPain_State = Convert.ToInt32(ds.Tables[0].Rows[0][4].ToString());
            this.Follow = Convert.ToInt32(ds.Tables[0].Rows[0][5].ToString());

        }
    
    }
}
