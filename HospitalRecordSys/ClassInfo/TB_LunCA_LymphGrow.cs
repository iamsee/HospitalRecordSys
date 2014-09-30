using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys
{
    class TB_LunCA_LymphGrow
    {
        Database db = new Database();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string sqlString = string.Empty;

        public string BIHNum;
        public string LymphGrowShow;

        public void update_TB_LunCA_LymphGrow()
        {
            sqlString = "update TB_LunCA_LymphGrow set LymphGrowShow='" + LymphGrowShow + "' where BIHNum='" + BIHNum + "';";
            db.ExecuteSQL(sqlString);
        }

        public void get_TB_LunCA_LymphGrow()
        {
            sqlString = "select * from TB_LunCA_LymphGrow where BIHNum =" + BIHNum + "';";
            ds = db.GetDataSet(sqlString);
         
            this.LymphGrowShow = (ds.Tables[0].Rows[0][1].ToString());


        }
    }
}
