using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys
{
    class PHI_BEA_Cough_Luggies_BloodLuggies
    {
        Database db = new Database();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string sqlString = string.Empty;

        public string BIHNum;
        public string BloodNuture;
        public string BloodColor;
        public void update_PHI_BEA_Cough_Luggies_BloodLuggies()
        {

            sqlString = "update TB_BEA_Cough_Luggies_BloodLuggies set BloodNature ='" + BloodNuture + "',BloodColor='"+BloodColor + "' where BIHNum='" + BIHNum + "';";
            db.ExecuteSQL(sqlString);
        }

        public void get_TB_BEA_Cough_Luggies_BloodLuggies()
        {
            sqlString = "select * from TB_BEA_Cough_Luggies_BloodLuggies where BIHNum='" + BIHNum + "';";
            ds = db.GetDataSet(sqlString);
            this.BloodNuture = (ds.Tables[0].Rows[0][1].ToString());
            this.BloodColor = (ds.Tables[0].Rows[0][2].ToString());


        }
    }
}
