using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys
{
    class TB_PersonalHis_JobEnviron
    {
        Database db = new Database();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string sqlString = string.Empty;

        public string BIHNum;
        public string CompanyName;
        public string TypeOfWork;

        public void update_TB_PersonalHis_JobEnviron()
        {
            sqlString = "update TB_PersonalHis_JobEnviron set CompanyName='" + CompanyName + "',TypeOfWork='" + TypeOfWork + "' where BIHNum='" + BIHNum + "';";
            db.ExecuteSQL(sqlString);
        }

        public void get_TB_PersonalHis_JobEnviron()
        {
            sqlString = "select * from TB_PersonalHis_JobEnviron where BIHNum =" + BIHNum + "';";
            ds = db.GetDataSet(sqlString);
            this.CompanyName = (ds.Tables[0].Rows[0][1].ToString());
            this.TypeOfWork = (ds.Tables[0].Rows[0][2].ToString());


        }

    }
}
