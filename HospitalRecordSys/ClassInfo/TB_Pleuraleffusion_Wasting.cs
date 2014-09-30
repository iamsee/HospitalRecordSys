using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys
{
    class TB_Pleuraleffusion_Wasting
    {
        Database db = new Database();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string sqlString = string.Empty;

        public string BIHNum;
        public int LastTime;
        public double WeightFall; 

        public void update_TB_Pleuraleffusion_Wasting()
        {
            sqlString = "update TB_Pleuraleffusion_Wasting set LastTime=" + LastTime + ",WeightFall=" + WeightFall + " where BIHNum='" + BIHNum + "';";
            db.ExecuteSQL(sqlString);
        }

        public void get_TB_Pleuraleffusion_Wasting()
        {
            sqlString = "select * from TB_Pleuraleffusion_Wasting where BIHNum =" + BIHNum + "';";
            ds = db.GetDataSet(sqlString);

            this.LastTime =Convert.ToInt32(ds.Tables[0].Rows[0][1].ToString());
            this.WeightFall =Convert.ToSingle(ds.Tables[0].Rows[0][2].ToString());
          





        }
    }
}
