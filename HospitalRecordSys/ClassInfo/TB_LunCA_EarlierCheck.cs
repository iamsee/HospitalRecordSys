using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys
{
    class TB_LunCA_EarlierCheck
    {
        Database db = new Database();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string sqlString = string.Empty;

        public string BIHNum;
        public string CTShow;
        public string LuggiesSickShow;

        public void update_TB_LunCA_EarlierCheck()
        {
            sqlString = "update TB_LunCA_EarlierCheck set CTShow='" + CTShow + "',LuggiesSickShow='" + LuggiesSickShow + "' where BIHNum='"+BIHNum+"';";
            db.ExecuteSQL(sqlString);
        }

        public void get_TB_LunCA_EarlierCheck()
        {
            sqlString = "select * from TB_LunCA_EarlierCheck where BIHNum =" + BIHNum + "';";
            ds = db.GetDataSet(sqlString);
            this.CTShow = (ds.Tables[0].Rows[0][1].ToString());
            this.LuggiesSickShow = (ds.Tables[0].Rows[0][2].ToString());
          

        }
    }
}
