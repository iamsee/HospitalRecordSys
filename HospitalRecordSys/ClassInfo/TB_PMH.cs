using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys
{
    class TB_PMH
    {
        Database db = new Database();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string sqlString = string.Empty;

        public string BIHNum;
        public int Health_State;
        public int ComplexSice_State;
        public int NDC_State;
        public int Surgery_State;
        public int Trauma_State;
        public string Vaccinate_State;
        public int DrugAllergy;

        public void update_TB_PMH()
        {
            sqlString = "update TB_PMH set Health_State=" + Health_State + ",ComplexSice_State=" + ComplexSice_State + ",NDC_State=" + NDC_State + ",Surgery_State=" + Surgery_State + ",Trauma_State=" + Trauma_State + ",Vaccinate_State='" + Vaccinate_State + "',DrugAllergy=" + DrugAllergy + " where BIHNum='" + BIHNum + "';";
            db.ExecuteSQL(sqlString);
        }


        public void get_TB_PMH()
        {
            sqlString = "select * from TB_PMH where BIHNum ='" + BIHNum + "';";
            ds = db.GetDataSet(sqlString);
            
            this.Health_State = Convert.ToInt32(ds.Tables[0].Rows[0][1].ToString());
            this.ComplexSice_State =Convert.ToInt32(ds.Tables[0].Rows[0][2].ToString());
            this.NDC_State = Convert.ToInt32(ds.Tables[0].Rows[0][3].ToString());
            this.Surgery_State = Convert.ToInt32(ds.Tables[0].Rows[0][4].ToString());
            this.Trauma_State = Convert.ToInt32(ds.Tables[0].Rows[0][5].ToString());
            this.Vaccinate_State = (ds.Tables[0].Rows[0][6].ToString());
            this.DrugAllergy = Convert.ToInt32(ds.Tables[0].Rows[0][7].ToString());
           
          
        }
    }
}
