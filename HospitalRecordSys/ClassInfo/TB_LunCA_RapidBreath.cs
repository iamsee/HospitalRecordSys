using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys.ClassInfo
{
    class TB_LunCA_RapidBreath
    {
        Database db = new Database();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string sqlString = string.Empty;

        public string BIHNum;
        public string DeepLevel;
        public string StartTime;
        public string DeepTime;
        public string Drup;

        public void  update_TB_LunCA_RapidBreath()
        {
            sqlString = "update TB_LunCA_RapidBreath set DeepLevel='" + DeepLevel + "',StartTime='" + StartTime + "',DeepTime='" + DeepTime + "',Drup='" + Drup + "' where BIHNum='" + BIHNum + "';";
            db.ExecuteSQL(sqlString);
        }

        public void get_TB_LunCA_RapidBreath()
        {
            sqlString = "select * from TB_LunCA_RapidBreath where BIHNum =" + BIHNum + "';";
            ds = db.GetDataSet(sqlString);

            this.DeepLevel = (ds.Tables[0].Rows[0][1].ToString());
            this.StartTime = (ds.Tables[0].Rows[0][2].ToString());
            this.DeepTime = (ds.Tables[0].Rows[0][3].ToString());
            this.Drup = (ds.Tables[0].Rows[0][4].ToString());
         


        }
    }
}
