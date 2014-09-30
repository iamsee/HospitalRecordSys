using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys
{
    class TB_Admin
    {
        Database db = new Database();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string sqlString = string.Empty;

        public int JobNum;
        public string Pwd;
        public string JobName;
        public int state;

        public void Update_TB_JobAdmin()
        {
            sqlString = "update TB_JobAdmin set JobNum="+JobNum+",Pwd='"+Pwd+"',JobName='"+JobName+"';";
           state =  db.ExecuteSQL(sqlString);
        }
    }
}
