using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys.ClassInfo
{
    class TB_LunCA_WeightFall
    {
        Database db = new Database();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string sqlString = string.Empty;

        public string BIHNum;
        public double WeightNum;
        public string StartTime;

        public void update_TB_LunCA_WeightFall()
        {
            sqlString = "update TB_LunCA_WeightFall set WeightNum =" + WeightNum + ",StartTime='" + StartTime + "';";
            db.ExecuteSQL(sqlString);
        }

        public void get_TB_LunCA_WeightFall()
        {
            sqlString = "select * from TB_LunCA_WeightFall where BIHNum =" + BIHNum + "';";
            ds = db.GetDataSet(sqlString);

            this.WeightNum =Convert.ToSingle(ds.Tables[0].Rows[0][1].ToString());
            this.StartTime =(ds.Tables[0].Rows[0][2].ToString());


        }
    }
}
