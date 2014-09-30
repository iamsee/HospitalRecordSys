using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys.ClassInfo
{
    class PHI_BEA_EarlierCheck
    {
        Database db = new Database();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string sqlString = string.Empty;

        public string BIHNum;
        public string Checked;
        public void update_PHI_BEA_EarlierCheck()
        {

            sqlString = "update TB_BEA_EarlierCheck set Checked='"+Checked+"'  where BIHNum ='"+BIHNum+"';";  
            db.ExecuteSQL(sqlString);
        }

        public void get_TB_BEA_EarlierCheck()
        {
            sqlString = "select * from TB_BEA_EarlierCheck where BIHNum='" + BIHNum + "';";
            ds = db.GetDataSet(sqlString);
            this.Checked = (ds.Tables[0].Rows[0][1].ToString());
          


        }
    }
}
