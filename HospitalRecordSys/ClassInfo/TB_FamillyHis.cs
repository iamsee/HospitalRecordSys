using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys
{
    class TB_FamillyHis
    {
        Database db = new Database();
        string sqlString = string.Empty;
        DataSet ds = new DataSet();
        public string BIHNum;
        public int Father_State;
        public int Mother_State;
        public int Brother_State;
        public int Sister_State;
        public int Child_State;

        public void update_TB_FamillyHis()
        {
            sqlString = "update TB_FamillyHis set Father_State=" + Father_State + ",Mother_State=" + Mother_State + ",Brother_State=" + Brother_State + ",Sister_State=" + Sister_State + ",Child_State=" + Child_State + " where BIHNum='" + BIHNum + "';";
            db.ExecuteSQL(sqlString);
        }

        public void get_TB_FamillyHis()
        {
            sqlString = "select * from TB_FamillyHis where BIHNum ='" + BIHNum + "';";
            ds = db.GetDataSet(sqlString);
            this.Father_State =Convert.ToInt32(ds.Tables[0].Rows[0][1].ToString());
            this.Mother_State =Convert.ToInt32(ds.Tables[0].Rows[0][2].ToString());
            this.Brother_State = Convert.ToInt32(ds.Tables[0].Rows[0][3].ToString());
            this.Sister_State =Convert.ToInt32(ds.Tables[0].Rows[0][4].ToString());
            this.Child_State = Convert.ToInt32(ds.Tables[0].Rows[0][5].ToString());
           

        }
    }
}
