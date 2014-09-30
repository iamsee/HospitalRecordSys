using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys
{
    class PHI_BEA
    {
        Database db = new Database();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string sqlString = string.Empty;

        public string BIHNum;
        public int RapidBreath_State;
        public int Cough_State;
        public int EarlierCheck;

        public void update_PHI_BEA()
        {
            sqlString = "update TB_BEA set RapidBreath_State =" + RapidBreath_State + ",Cough_State=" + Cough_State + ",EarlierCheck=" + EarlierCheck + " where BIHNum='" + BIHNum + "';";
            db.ExecuteSQL(sqlString);
        }

        public void get_TB_BEA()
        {
            sqlString = "select * from TB_BEA where BIHNum='" + BIHNum + "';";
            ds = db.GetDataSet(sqlString);
            this.RapidBreath_State = Convert.ToInt32(ds.Tables[0].Rows[0][1].ToString());
            this.Cough_State = Convert.ToInt32(ds.Tables[0].Rows[0][2].ToString());
            this.EarlierCheck = Convert.ToInt32(ds.Tables[0].Rows[0][3].ToString());
   
        }

    }
}
