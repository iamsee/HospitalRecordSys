using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys
{
    class PHI_PNA_Fever
    {

        Database db = new Database();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string sqlString = string.Empty;

        public string BIHNum;
        public int LastTime;
        public float   HighestHeat;
		public string TimeRange;
        public string Shakes;
        public int UserDrug;

        public void Update_PHI_PNA_Fever()
        {
            sqlString = "update TB_PNA_Fever set LastTime ="+LastTime+",HighestHeat="+HighestHeat+",TimeRange = '"+TimeRange+"',Shakes= '"+Shakes+"',UserDrug="+UserDrug+" where BIHNum='"+this.BIHNum+"';";
            db.ExecuteSQL(sqlString);
        }

        public void get_TB_PNA_Fever()
        {
            sqlString = "select * from TB_PNA_Fever where BIHNum='" + BIHNum + "';";
            ds = db.GetDataSet(sqlString);
            this.LastTime = Convert.ToInt32(ds.Tables[0].Rows[0][1].ToString());
            this.HighestHeat = Convert.ToInt32(ds.Tables[0].Rows[0][2].ToString());
            this.TimeRange = ds.Tables[0].Rows[0][3].ToString();
            this.Shakes = (ds.Tables[0].Rows[0][4].ToString());
            this.UserDrug = Convert.ToInt32(ds.Tables[0].Rows[0][1].ToString());
        }

    }
}
