using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys
{
    class TB_Pleuraleffusion_RapidBreath_RelieveShow
    {
        Database db = new Database();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string sqlString = string.Empty;

        public string BIHNum;
        public string NoDrugGood;
        public string DrugGood;
        public string DrugBad;

        public void update_TB_Pleuraleffusion_RapidBreath_RelieveShow()
        {
            sqlString = "update TB_TB_Pleuraleffusion_RapidBreath_RelieveShow set NoDrupGood ='" + NoDrugGood + "',DrupGood='" + DrugGood + "',DrugBad='" + DrugBad + "' where BIHNum='" + BIHNum + "';";
            db.ExecuteSQL(sqlString);
        }

        public void get_TB_Pleuraleffusion_RapidBreath_RelieveShow()
        {
            sqlString = "select * from TB_Pleuraleffusion_RapidBreath_RelieveShow where BIHNum =" + BIHNum + "';";
            ds = db.GetDataSet(sqlString);

            this.NoDrugGood = (ds.Tables[0].Rows[0][1].ToString());
            this.DrugGood = (ds.Tables[0].Rows[0][2].ToString());
            this.DrugBad = (ds.Tables[0].Rows[0][3].ToString());
    




        }
    }
}
