using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys
{
    class TB_FamillyHis_Father
    {
        Database db = new Database();
        string sqlString = string.Empty;
        DataSet ds = new DataSet();
        public string BIHNum;
        public int PassAge;
        public string PassReason;
        public int Sick_State;

        public void update_TB_FamillyHis_Father()
        {
            sqlString = "update TB_FamillyHis_Father set PassAge=" + PassAge + ",Passreason='" + PassReason + "',SickState=" + Sick_State + "' where BIHNum='"+BIHNum+"';";
            db.ExecuteSQL(sqlString);
        }

        public void get_TB_FamillyHis_Father()
        {
            sqlString = "select * from TB_FamillyHis_Father where BIHNum ='" + BIHNum + "';";
            ds = db.GetDataSet(sqlString);
     //       this.PassAge = Convert.ToInt32(ds.Tables[0].Rows[0][1].ToString());
            this.PassReason = (ds.Tables[0].Rows[0][2].ToString());
      //      this.Sick_State = Convert.ToInt32(ds.Tables[0].Rows[0][3].ToString());




        }
    }
}
