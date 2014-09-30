using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys
{
    class TB_LunCA_Cough_Luggies
    {
        Database db = new Database();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string sqlString = string.Empty;

        public string BIHNum;
        public string Color;
     
        public string ClearTime;
        public string Blood;

        public void update_TB_LunCA_Cough_Luggies()
        {
            sqlString = "update TB_LunCA_Cough_Luggies set Color= '" + Color + "',Blood='" + Blood + "' where BIHNum ='" + BIHNum + "';";
            db.ExecuteSQL(sqlString);
        }

        public void get_TB_LunCA_Cough_Luggies()
        {
            sqlString = "select * from TB_LunCA_Cough_Luggies where BIHNum =" + BIHNum + "';";
            ds = db.GetDataSet(sqlString);
            this.Color =(ds.Tables[0].Rows[0][1].ToString());
            this.ClearTime = (ds.Tables[0].Rows[0][2].ToString());
            this.Blood =(ds.Tables[0].Rows[0][3].ToString());

        }
    }
}
