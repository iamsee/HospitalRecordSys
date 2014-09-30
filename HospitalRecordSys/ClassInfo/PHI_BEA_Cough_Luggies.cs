using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys
{

    class PHI_BEA_Cough_Luggies
    {
        Database db = new Database();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string sqlString = string.Empty;

        public string BIHNum;
        public string Color;
        public string LuggiesAmount;
        public string ClearTime;
        public int BloodLuggies_State;

        public void update_PHI_BEA_Cough_Luggies()
        {
            sqlString = "update TB_BEA_Cough_Luggies set Color= '" + Color + "',LuggiesAmount='" + LuggiesAmount + "',BloodLuggies_State=" + BloodLuggies_State + " where BIHNum ='"+BIHNum+"';";
            db.ExecuteSQL(sqlString);
        }
        public void get_TB_BEA_Cough_Luggies()
        {
            sqlString = "select * from TB_BEA_Cough_Luggies where BIHNum='" + BIHNum + "';";
            ds = db.GetDataSet(sqlString);
            this.Color = (ds.Tables[0].Rows[0][1].ToString());
            this.LuggiesAmount = (ds.Tables[0].Rows[0][1].ToString());
            this.BloodLuggies_State = Convert.ToInt32(ds.Tables[0].Rows[0][2].ToString());


        }
    }
}
