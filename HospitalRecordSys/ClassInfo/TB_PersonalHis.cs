using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys{
    class TB_PersonalHis
    {
         Database db = new Database();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string sqlString = string.Empty;

        public string BIHNum;
        public string BirthLocal;
        public string LiveLocal;
        public int GoLocal_State;
        public string JobHow;
        public int JobEnviron_State;
        public int Smoke_State;
        public int Drink_State;
        public int OtherHobby_State;
        public int Marriage_State;

        public void update_TB_PersonalHis()
        {
            sqlString = "update TB_PersonalHis set BirthLocal ='"+BirthLocal+"',LiveLocal='"+LiveLocal+"',GoLocal_State="+GoLocal_State+",JobHow='"+JobHow+"',JobEnviron_State="+JobEnviron_State+",Smoke_State="+Smoke_State+",Drink_State="+Drink_State+",OtherHobby_State="+OtherHobby_State+",Marriage_State="+Marriage_State+" where BIHNum='"+BIHNum+"';";
            db.ExecuteSQL(sqlString);
        }

        public void get_TB_PersonalHis()
        {
            sqlString = "select * from TB_PersonalHis where BIHNum ='" + BIHNum + "';";
            ds = db.GetDataSet(sqlString);
            this.BirthLocal = (ds.Tables[0].Rows[0][1].ToString());
            this.LiveLocal = (ds.Tables[0].Rows[0][2].ToString());
 //           this.GoLocal_State = Convert.ToInt32(ds.Tables[0].Rows[0][3].ToString());
            this.JobHow = (ds.Tables[0].Rows[0][4].ToString());
 //           this.JobEnviron_State = Convert.ToInt32(ds.Tables[0].Rows[0][5].ToString());
 //           this.Smoke_State = Convert.ToInt32(ds.Tables[0].Rows[0][6].ToString());
 //           this.Drink_State = Convert.ToInt32(ds.Tables[0].Rows[0][7].ToString());
 //           this.OtherHobby_State = Convert.ToInt32(ds.Tables[0].Rows[0][8].ToString());
 //           this.Marriage_State = Convert.ToInt32(ds.Tables[0].Rows[0][9].ToString());

        }
    }
}
