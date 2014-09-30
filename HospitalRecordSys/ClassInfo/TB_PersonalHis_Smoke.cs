using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys
{
    class TB_PersonalHis_Smoke
    {
        Database db = new Database();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string sqlString = string.Empty;

        public string BIHNum;
        public int SmokeLast;
        public int SmokeNum;
        public void update_TB_PersonalHis_Smoke()
        {
            sqlString = "update TB_PersonalHis_Smoke set SmokeLast=" + SmokeLast + ",SmokeNum=" + SmokeNum + " where BIHNum='" + BIHNum + "';";
            db.ExecuteSQL(sqlString);
        }

        public void get_TB_PersonalHis_Smoke()
        {
            sqlString = "select * from TB_PersonalHis_Smoke where BIHNum =" + BIHNum + "';";
            ds = db.GetDataSet(sqlString);
            this.SmokeLast =Convert.ToInt32(ds.Tables[0].Rows[0][1].ToString());
            this.SmokeNum = Convert.ToInt32(ds.Tables[0].Rows[0][2].ToString());



        }
    }
}
