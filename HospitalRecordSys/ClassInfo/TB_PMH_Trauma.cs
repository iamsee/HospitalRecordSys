using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys
{
    class TB_PMH_Trauma
    {
        Database db = new Database();
        string sqlString = string.Empty;
        DataSet ds = new DataSet();

        public string BIHNum;
        public string TraumaTime;
        public string TraumaPart;

        public void  update_TB_PMH_Trauma()
        {
            sqlString = "update TB_PMH_Trauma set TraumaTime='" + TraumaTime + "',TraumaPart='" + TraumaPart + "' where BIHNum='" + BIHNum + "';";
            db.ExecuteSQL(sqlString);
        }

        public void get_TB_PMH_Trauma()
        {
            sqlString = "select * from TB_PMH_Trauma where BIHNum ='" + BIHNum + "';";
            ds = db.GetDataSet(sqlString);
            this.TraumaTime = (ds.Tables[0].Rows[0][1].ToString());
            this.TraumaPart = (ds.Tables[0].Rows[0][2].ToString());


        }
    }
}
