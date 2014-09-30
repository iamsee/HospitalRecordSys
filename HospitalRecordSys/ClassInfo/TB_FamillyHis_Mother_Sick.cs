using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys
{
    class TB_FamillyHis_Mother_Sick
    {
        Database db = new Database();
        string sqlString = string.Empty;
        DataSet ds = new DataSet();
        public string BIHNum;
        public string SickName;
        public void update_TB_FamillyHis_Mother_Sick()
        {
            sqlString = "update TB_FamillyHis_Mother_Sick set SickName='" + SickName + "' where BIHNum='" + BIHNum + "';";
            db.ExecuteSQL(sqlString);
        }

        public void get_TB_FamillyHis_Mother_Sick()
        {
            sqlString = "select * from TB_FamillyHis_Mother_Sick where BIHNum ='" + BIHNum + "';";
            ds = db.GetDataSet(sqlString);
            this.SickName = (ds.Tables[0].Rows[0][1].ToString());




        }
    }
}
