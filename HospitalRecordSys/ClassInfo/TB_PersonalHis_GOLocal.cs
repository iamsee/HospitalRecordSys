using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys
{
    class TB_PersonalHis_GOLocal
    {
        Database db = new Database();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string sqlString = string.Empty;

        public string BIHNum;
        public string LocalName;
        public string LastTime;

        public void update_TB_PersonalHis_GOLocal()
        {
            sqlString = "update TB_PersonalHis_GOLocal set LocalName='" + LocalName + "',LastTime='" + LastTime + "' where BIHNum='" + BIHNum + "';";
            db.ExecuteSQL(sqlString);
        }
        public void get_TB_PersonalHis_GOLocal()
        {
            sqlString = "select * from TB_PersonalHis_GOLocal where BIHNum =" + BIHNum + "';";
            ds = db.GetDataSet(sqlString);
            this.LocalName = (ds.Tables[0].Rows[0][1].ToString());
            this.LastTime = (ds.Tables[0].Rows[0][2].ToString());


        }

    }
}
