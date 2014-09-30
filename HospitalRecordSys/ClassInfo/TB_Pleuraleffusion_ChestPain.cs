using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys
{
    class TB_Pleuraleffusion_ChestPain
    {
        Database db = new Database();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string sqlString = string.Empty;

        public string BIHNum;
        public int LastTime;

        public string PainNature;
        public string Position;

        public void update_TB_Pleuraleffusion_ChestPain()
        {

            sqlString = "update TB_Pleuraleffusion_ChestPain set LastTime =" + LastTime + ",PainNature='" + PainNature + "',Position='" + Position + "' where BIHNum='" + BIHNum + "';";
            db.ExecuteSQL(sqlString);
        }

        public void get_TB_Pleuraleffusion_ChestPain()
        {
            sqlString = "select * from TB_Pleuraleffusion_ChestPain where BIHNum =" + BIHNum + "';";
            ds = db.GetDataSet(sqlString);
            this.LastTime =Convert.ToInt32(ds.Tables[0].Rows[0][1].ToString());
            this.PainNature = (ds.Tables[0].Rows[0][2].ToString());
            this.Position = (ds.Tables[0].Rows[0][3].ToString());


        }
    }
}
