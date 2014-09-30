using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys
{
    class PHI_PNA_Follow
    {
        Database db = new Database();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string sqlString = string.Empty;

        public string BIHNum;
        public int HeadPain;
        public int Nausea;
        public int AbdomenPain;
        public string Diarrhea;

        public void update_PHI_PNA_Follow()
        {
            sqlString = "update TB_PNA_Follow set HeadPain=" + HeadPain + ",Nausea=" + Nausea + ",AbdomenPain=" + AbdomenPain + ",Diarrhea_State=" + Diarrhea + " where BIHNum='" + BIHNum + "';";
            db.ExecuteSQL(sqlString);
        }
        public void get_TB_PNA_Follow()
        {
            sqlString = "select * from TB_PNA_Follow where BIHNum='" + BIHNum + "';";
            ds = db.GetDataSet(sqlString);
            this.HeadPain = Convert.ToInt32(ds.Tables[0].Rows[0][1].ToString());
            this.Nausea = Convert.ToInt32(ds.Tables[0].Rows[0][2].ToString());
            this.AbdomenPain = Convert.ToInt32(ds.Tables[0].Rows[0][3].ToString());
            this.Diarrhea = (ds.Tables[0].Rows[0][4].ToString());           

        }

    }
}
