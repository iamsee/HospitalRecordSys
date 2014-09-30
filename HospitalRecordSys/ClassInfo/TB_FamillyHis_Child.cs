using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys
{
    class TB_FamillyHis_Child
    {
        Database db = new Database();
        string sqlString = string.Empty;
        DataSet ds = new DataSet();
        public string BIHNum;

        public int ChildNum;

        public void update_TB_FamillyHis_Child()
        {
            sqlString = "update TB_FamillyHis_Child set ChildNum=" + ChildNum + " where BIHNum='" + BIHNum + "';";
            db.ExecuteSQL(sqlString);
        }

        public void get_TB_FamillyHis_Child()
        {
            sqlString = "select * from TB_FamillyHis_Child where BIHNum ='" + BIHNum + "';";
            ds = db.GetDataSet(sqlString);
            this.ChildNum =Convert.ToInt32(ds.Tables[0].Rows[0][1].ToString());




        }
    }
}
