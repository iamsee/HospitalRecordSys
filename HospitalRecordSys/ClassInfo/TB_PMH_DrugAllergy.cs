using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys{
    class TB_PMH_DrugAllergy
    {

        Database db = new Database();
        string sqlString = string.Empty;

        DataSet ds = new DataSet();

        public string BIHNum;
        public string DrupName;

        public void update_TB_PMH_DrugAllergy()
        {
            sqlString = "update TB_PMH_DrugAllergy set DrupName='" + DrupName + "' where BIHNum='" + BIHNum + "';";
            db.ExecuteSQL(sqlString);
        }

        public void get_TB_PMH_DrugAllergy()
        {
            sqlString = "select * from TB_PMH_DrugAllergy where BIHNum ='" + BIHNum + "';";
            ds = db.GetDataSet(sqlString);
            this.DrupName = (ds.Tables[0].Rows[0][1].ToString());
          

        }

    }
}
