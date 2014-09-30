using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys.ClassInfo
{
    class TB_PersonalHis_OtherHabby
    {
        Database db = new Database();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string sqlString = string.Empty;

        public string BIHNum;
        public string OtherHabbyName;

        public void update_TB_PersonalHis_OtherHabby()
        {
            sqlString = "update TB_PersonalHis_OtherHabby set OtherHabbyName='" + OtherHabbyName + "' where BIHNum='" + BIHNum + "';";
            db.ExecuteSQL(sqlString);
        }

        public void get_TB_PersonalHis_OtherHabby()
        {
            sqlString = "select * from TB_PersonalHis_OtherHabby where BIHNum =" + BIHNum + "';";
            ds = db.GetDataSet(sqlString);
            this.OtherHabbyName = (ds.Tables[0].Rows[0][1].ToString());
           


        }
    }
}
