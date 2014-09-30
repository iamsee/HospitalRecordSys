using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys{
    class TB_PMH_NDC
    {
        Database db = new Database();
        string sqlString = string.Empty;
        DataSet ds = new DataSet();

        public string BIHNum;
        public string SickName;
        public string StartTime;
        public string Cure;
        public string CurativeEffect;

        public void update_TB_PMH_NDC()
        {
            sqlString = "insert into TB_PMH_NDC values ('" + BIHNum + "','" + SickName + "','" + StartTime + "','" + Cure + "','" + CurativeEffect + "');";

            db.ExecuteSQL(sqlString);
        }

        public void get_TB_PMH_NDC()
        {
            sqlString = "select * from TB_PMH_NDC where BIHNum ='" + BIHNum + "';";
            ds = db.GetDataSet(sqlString);
            this.SickName = (ds.Tables[0].Rows[0][1].ToString());
            this.StartTime = (ds.Tables[0].Rows[0][2].ToString());
            this.Cure = (ds.Tables[0].Rows[0][3].ToString());
            this.CurativeEffect = (ds.Tables[0].Rows[0][4].ToString());
            
        }
    }
}
