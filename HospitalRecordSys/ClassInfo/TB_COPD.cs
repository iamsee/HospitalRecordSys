using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys
{
    class TB_COPD
    {
        Database db = new Database();
        string sqlString = string.Empty;
        DataSet ds = new DataSet();

        public string BIHNum;
        public int Cough_State;
        public int RapidBreath_State;
        
        public void update_TB_COPD()
        {

            sqlString = "update TB_COPD set Cough_State=" + Cough_State + ",RapidBreath_State=" + RapidBreath_State + " where BIHNum='" + BIHNum + "';";
            db.ExecuteSQL(sqlString);
        }
        public void get_TB_COPD()
        {
            sqlString = "select * from TB_COPD wher BIHNum=" + BIHNum + "';";
            ds = db.GetDataSet(sqlString);
            this.Cough_State = Convert.ToInt32(ds.Tables[0].Rows[0][1].ToString());
            this.RapidBreath_State = Convert.ToInt32(ds.Tables[0].Rows[0][2].ToString());
          
        }


    }
}
