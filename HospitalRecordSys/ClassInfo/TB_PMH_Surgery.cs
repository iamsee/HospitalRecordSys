using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys{
    class TB_PMH_Surgery

    {
        Database  db = new Database();
        string sqlString = string.Empty;
        DataSet ds = new DataSet();

        public string BIHNum;
        public string OperationName;
        public string OPerationTime;

        public void update_TB_PMH_Surgery()
        {
            sqlString = "update TB_PMH_Surgery set OperationName='"+OperationName+"',OPerationTime='"+OPerationTime+"' where BIHNum='"+BIHNum+"';";
            db.ExecuteSQL(sqlString);
        }

        public void get_TB_PMH_Surgery()
        {
            sqlString = "select * from TB_PMH_Surgery where BIHNum ='" + BIHNum + "';";
            ds = db.GetDataSet(sqlString);
            this.OperationName = (ds.Tables[0].Rows[0][1].ToString());
            this.OPerationTime = (ds.Tables[0].Rows[0][2].ToString());
           

        }
    }
}
