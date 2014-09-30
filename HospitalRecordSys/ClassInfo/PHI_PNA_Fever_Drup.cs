using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys
{
    class PHI_PNA_Fever_Drup
    {
        Database db = new Database();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string sqlString = string.Empty;

        public string BIHNum;
        public string DrupName;
        public string DrupEffect;

        public void Update_PHI_PNA_Fever_Drup()
        {
            sqlString = "update TB_PNA_Fever_Drup set DrupName ='" + DrupName + "',DrupEffect='" + DrupEffect + "' where BIHNum='" + BIHNum + "';";
            db.ExecuteSQL(sqlString);
        }
        public void get_TB_PNA_Fever_Drup()
        {
            sqlString = "select * from TB_PNA_Fever_Drup where BIHNum='" + BIHNum + "';";
            ds = db.GetDataSet(sqlString);
            this.DrupName = (ds.Tables[0].Rows[0][1].ToString());
            this.DrupEffect = (ds.Tables[0].Rows[0][2].ToString());
        
        }
    }
}
