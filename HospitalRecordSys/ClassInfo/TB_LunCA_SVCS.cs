using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys{
    class TB_LunCA_SVCS
    {
        Database db = new Database();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string sqlString = string.Empty;

        public string BIHNum;
        public string SVCSShow;

        public void update_TB_LunCA_SVCS()
        {
            sqlString = "update TB_LunCA_SVCS set SVCSShow='" + SVCSShow + "' where BIHNum='" + BIHNum + "';";
                db.ExecuteSQL(sqlString);
        }

        public void get_TB_LunCA_SVCS()
        {
            sqlString = "select * from TB_LunCA_SVCS where BIHNum =" + BIHNum + "';";
            ds = db.GetDataSet(sqlString);

            this.SVCSShow = (ds.Tables[0].Rows[0][1].ToString());
            


        }
    }
}
