using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys
{
    class TB_PMH_ComplexSick
    {
        Database db = new Database();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string sqlString = string.Empty;

        public string BIHNum;
        public string SickName;
        public string StartTime;
        public string LastTime;
        public string DrugName;
        public string CurativeEffect;

       
        


        public void update_TB_PMH_ComplexSick()
        {
            sqlString = "insert into TB_PMH_ComplexSick (BIHNum,SickName,StartTime,LastTime,DrugName,CurativeEffect) values ('" + BIHNum + "','" + SickName + "','" + StartTime + "','" + LastTime + "','" + DrugName + "','" + CurativeEffect + "');";
            db.ExecuteSQL(sqlString);
        }

        public void get_TB_PMH_ComplexSick()
        {
            sqlString = "select * from TB_PMH_ComplexSick where BIHNum ='" + BIHNum + "';";
            ds = db.GetDataSet(sqlString);
            this.SickName = (ds.Tables[0].Rows[0][1].ToString());
            this.StartTime = (ds.Tables[0].Rows[0][2].ToString());
            this.LastTime =(ds.Tables[0].Rows[0][3].ToString());
            this.DrugName = (ds.Tables[0].Rows[0][4].ToString());
            this.CurativeEffect = (ds.Tables[0].Rows[0][5].ToString());

        }
    }
}
