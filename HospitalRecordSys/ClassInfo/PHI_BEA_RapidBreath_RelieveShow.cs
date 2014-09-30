using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys
{
    class PHI_BEA_RapidBreath_RelieveShow
    {
        Database db = new Database();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string sqlString = string.Empty;

        public string BIHNum;
        public string NoDrugGood;
        public string DrugGood;
        public string DrugBad;

        public void update_PHI_BEA_RapidBreath_RelieveShow()
        {
            sqlString = "update TB_BEA_RapidBreath_RelieveShow set NoDrugGood ='" + NoDrugGood + "',DrugGood='" + DrugGood + "',DrugBad='" + DrugBad + "' where BIHNum='" + BIHNum + "';";
            db.ExecuteSQL(sqlString);
        }

          public void get_TB_BEA_BEA_RapidBreath_RelieveShow()
        {
            sqlString = "select * from TB_BEA_RapidBreath where BIHNum='" + BIHNum + "';";
            ds = db.GetDataSet(sqlString);
            this.NoDrugGood = (ds.Tables[0].Rows[0][1].ToString());
            this.DrugGood = (ds.Tables[0].Rows[0][1].ToString());
            this.DrugBad = (ds.Tables[0].Rows[0][1].ToString());
           

        }
    }
}
