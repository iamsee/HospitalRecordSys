using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys
{
    class TB_LunCA_CoughBlood
    {
        Database db = new Database();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string sqlString = string.Empty;

        public string BIHNum;
        public string BloodNuture;
        public string Color;
        public int LastTime;
        public void update_TB_LunCA_CoughBlood()
        {

            sqlString = "update TB_LunCA_CoughBlood set BloodNature ='" + BloodNuture + "',Color='" + Color + "',LastTime='" + LastTime + "' where BIHNum='" + BIHNum + "';";
            db.ExecuteSQL(sqlString);
        }

        public void get_TB_LunCA_CoughBlood()
        {
            sqlString = "select * from TB_LunCA_CoughBlood where BIHNum =" + BIHNum + "';";
            ds = db.GetDataSet(sqlString);
            this.BloodNuture = (ds.Tables[0].Rows[0][1].ToString());
            this.Color = (ds.Tables[0].Rows[0][2].ToString());
            this.LastTime = Convert.ToInt32(ds.Tables[0].Rows[0][3].ToString());

        }
    }
}
