using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys
{
    class PHI_BEA_Cough
    {
        Database db = new Database();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string sqlString = string.Empty;

        public string BIHNum;
        public string StartTime;
        public int Luggies;

        public void update_PHI_BEA_Cough()
        {
            sqlString = "update TB_BEA_Cough set StartTime='" + StartTime + "',Luggies=" + Luggies + " where BIHNum='"+BIHNum+"';";
            db.ExecuteSQL(sqlString);
        }
        public void get_TB_BEA_Cough()
        {
            sqlString = "select * from TB_BEA_Cough where BIHNum='" + BIHNum + "';";
            ds = db.GetDataSet(sqlString);
            this.StartTime = (ds.Tables[0].Rows[0][1].ToString());
            this.Luggies = Convert.ToInt32(ds.Tables[0].Rows[0][2].ToString());


        }
    }
}
