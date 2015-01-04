using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys
{
    class PHI_PNA_Cough
    {
        Database db = new Database();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string sqlString = string.Empty;

        public string BIHNum;
        public string LastTime;
        public string ClearTime;
        public int Luggies;

        public void update_PHI_PNA_Cough()
        {
            sqlString = "update TB_PNA_Cough set LastTime = '" + LastTime + "',ClearTime= '" + ClearTime + "',Luggies=" + Luggies + " where BIHNum='" + BIHNum + "';";
            db.ExecuteSQL(sqlString);
        }
        public void get_TB_PNA_ChestCough()
        {
            sqlString = "select * from TB_PNA_Cough where BIHNum='" + BIHNum + "';";
            ds = db.GetDataSet(sqlString);
            this.LastTime = (ds.Tables[0].Rows[0][1].ToString());
            this.ClearTime = ds.Tables[0].Rows[0][2].ToString();
       //     this.Luggies =Convert.ToInt32(ds.Tables[0].Rows[0][3].ToString());

        }
    }
}
