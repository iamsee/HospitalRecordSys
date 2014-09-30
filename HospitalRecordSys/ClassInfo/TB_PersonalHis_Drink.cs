using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys
{
    class TB_PersonalHis_Drink
    {
        Database db = new Database();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string sqlString = string.Empty;

        public string BIHNum;
        public string DrinkMode;
        public string DrinkNum;

        public void update_TB_PersonalHis_Drink()
        {
            sqlString = "update TB_PersonalHis_Drink set DrinkMode='" + DrinkMode + "',DrinkNum='" + DrinkNum + "' where BIHNum='" + BIHNum + "';";
            db.ExecuteSQL(sqlString);
        }

        public void get_TB_PersonalHis_Drink()
        {
            sqlString = "select * from TB_PersonalHis_Drink where BIHNum =" + BIHNum + "';";
            ds = db.GetDataSet(sqlString);
            this.DrinkMode = (ds.Tables[0].Rows[0][1].ToString());
            this.DrinkNum = (ds.Tables[0].Rows[0][2].ToString());
            

        }
    }
}
