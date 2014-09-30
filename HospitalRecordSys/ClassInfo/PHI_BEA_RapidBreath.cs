using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys
{
    class PHI_BEA_RapidBreath
    {
        Database db = new Database();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string sqlString = string.Empty;

        public string BIHNum;
        public string RadidBreath;
        public string StartTime;
        public string LastTime;
        public int CoutNum;
        public string DeepShow;
        public int RelieveShow_State;

        public void update_PHI_BEA_RapidBreath()
        {
            sqlString = "update TB_BEA_RapidBreath set RadidBreath ='" + RadidBreath + "', StartTime='" + StartTime + "',LastTime='" + LastTime + "',CoutNum=" + CoutNum + ",DeepShow='" + DeepShow + "',RelieveShow_State=" + RelieveShow_State + " where BIHNum='" + BIHNum + "';";
            db.ExecuteSQL(sqlString);
        }

        public void get_TB_BEA_BEA_RapidBreath()
        {
            sqlString = "select * from TB_BEA_RapidBreath where BIHNum='" + BIHNum + "';";
            ds = db.GetDataSet(sqlString);
            this.RadidBreath = (ds.Tables[0].Rows[0][1].ToString());
            this.StartTime = (ds.Tables[0].Rows[0][1].ToString());
            this.LastTime = (ds.Tables[0].Rows[0][1].ToString());
            this.CoutNum =Convert.ToInt32(ds.Tables[0].Rows[0][1].ToString());
            this.DeepShow = (ds.Tables[0].Rows[0][1].ToString());
            this.RelieveShow_State =Convert.ToInt32(ds.Tables[0].Rows[0][1].ToString());
        }




    }

}


