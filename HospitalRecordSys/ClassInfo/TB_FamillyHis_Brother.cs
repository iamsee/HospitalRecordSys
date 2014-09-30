using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys
{
    class TB_FamillyHis_Brother
    {
        Database db = new Database();
        string sqlString = string.Empty;
        DataSet ds = new DataSet();
        public string BIHNum;
        public string BreatherNum;
        public int Sick_State;
       

        public void update_TB_FamillyHis_Brother()
        {
            sqlString = "update TB_FamillyHis_Brother set Breather='" + BreatherNum + "',Sick_State=" + Sick_State + " where BIHNum='"+BIHNum+"' ;";
            db.ExecuteSQL(sqlString);
        }

        public void get_TB_FamillyHis_Brother()
        {
            sqlString = "select * from TB_FamillyHis_Brother where BIHNum ='" + BIHNum + "';";
            ds = db.GetDataSet(sqlString);
            this.BreatherNum = (ds.Tables[0].Rows[0][1].ToString());
    //      this.Sick_State = Convert.ToInt32(ds.Tables[0].Rows[0][2].ToString());
          


        }
    }
}
