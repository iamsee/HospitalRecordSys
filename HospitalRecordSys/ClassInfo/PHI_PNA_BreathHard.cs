using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys
{
    class PHI_PNA_BreathHard
    {
        Database db = new Database();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string sqlString = string.Empty;

        public string BIHNum;
        public string Level;
        public string StartTime;
        public string StartDeepTime;
        public string HaveDrug;
        public string HaveDrugName;

        public void update_PHI_PNA_BreathHard()
        {
            sqlString = "update TB_PNA_BreathHard set Level_Show='" + Level + "',StartTime=" + StartTime + ",StartDeepTime=" + StartDeepTime + ",HaveDrug='" + HaveDrug + "',HaveDrugName='"+HaveDrugName+"' where BIHNum='" + BIHNum + "';";
            db.ExecuteSQL(sqlString);
        }
        public void get_TB_PNA_BreathHard()
        {
            sqlString = "select * from TB_PNA_BreathHard where BIHNum='" + BIHNum + "';";
            ds = db.GetDataSet(sqlString);
            this.Level = ds.Tables[0].Rows[0][1].ToString();
            this.StartTime = ds.Tables[0].Rows[0][2].ToString();
            this.StartDeepTime = ds.Tables[0].Rows[0][3].ToString();
            this.HaveDrug = ds.Tables[0].Rows[0][4].ToString();
            this.HaveDrugName = ds.Tables[0].Rows[0][5].ToString();
        }
    }
}
