using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys
{
    
    class PHI_State
    {
        Database db = new Database();
        string sqlString = string.Empty;
        DataSet ds = new DataSet();
        

        public string BIHNum;
        public int PNA;
        public int BEA;
        public int CA;
        public int COPD;
        public int peff;
        public void update_TB_PHI()
        {
            sqlString = "update TB_PHI set PNA_State=" + PNA + ",BEA_State=" + BEA + ",LunCA_State=" + CA + ",COPD_State=" + COPD + ",Pleuraleffusion_State=" + peff + " where BIHNum='" + BIHNum + "';";
            db.ExecuteSQL(sqlString);
        }

        public void get_TB_PHI()
        {
            sqlString = "select * from TB_PHI where BIHNum='"+BIHNum+"';";
            ds =db.GetDataSet(sqlString);
            this.PNA = Convert.ToInt32(ds.Tables[0].Rows[0][1].ToString());
            this.BEA = Convert.ToInt32(ds.Tables[0].Rows[0][2].ToString());
            this.CA = Convert.ToInt32(ds.Tables[0].Rows[0][3].ToString());
            this.COPD = Convert.ToInt32(ds.Tables[0].Rows[0][4].ToString());
            this.peff = Convert.ToInt32(ds.Tables[0].Rows[0][5].ToString());


        }
    }


    
}
