using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys
{
    class TB_PersonalHis_Marriage
    {
        Database db = new Database();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string sqlString = string.Empty;

        public string BIHNum;
        public int MarryAge;
        public string BetterHalfNow;
        public int GraviditasTimes;
        public int GiveBirthToTimes;
        public string MensesStart;
        public string MensesOver;
        public int MensesCycle;
        public int MensesDays;
        public string MensesNum;
        public int MensesPain;
        public string Leukorrhea;

        public void update_TB_PersonalHis_Marriage()
        {
            sqlString = "update TB_PersonalHis_Marriage set MarryAge=" + MarryAge + ",BetterHalfNow='" + BetterHalfNow + "',GraviditasTimes=" + GraviditasTimes + ",GiveBirthToTimes=" + GiveBirthToTimes + ",MensesStart='" + MensesStart + "',MensesOver='" + MensesOver + "',MensesCycle=" + MensesCycle + ",MensesDays=" + MensesDays + ",MensesNum='" + MensesNum + "',MensesPain=" + MensesPain + ",Leukorrhea='" + Leukorrhea+"' where BIHNum='"+BIHNum+"';";
            db.ExecuteSQL(sqlString);
        }
        public void get_TB_PersonalHis_Marriage()
        {
            sqlString = "select * from TB_PersonalHis_Marriage where BIHNum =" + BIHNum + "';";
            ds = db.GetDataSet(sqlString);
            this.MarryAge =Convert.ToInt32(ds.Tables[0].Rows[0][1].ToString());
            this.BetterHalfNow = (ds.Tables[0].Rows[0][2].ToString());

            this.GraviditasTimes = Convert.ToInt32(ds.Tables[0].Rows[0][3].ToString());
            this.GiveBirthToTimes = Convert.ToInt32(ds.Tables[0].Rows[0][4].ToString());
            this.MensesStart = (ds.Tables[0].Rows[0][5].ToString());
            this.MensesOver = (ds.Tables[0].Rows[0][6].ToString());
            this.MensesCycle = Convert.ToInt32(ds.Tables[0].Rows[0][7].ToString());
            this.MensesDays = Convert.ToInt32(ds.Tables[0].Rows[0][8].ToString());
            this.MensesNum = (ds.Tables[0].Rows[0][9].ToString());
            this.MensesPain = Convert.ToInt32(ds.Tables[0].Rows[0][10].ToString());
            this.Leukorrhea = (ds.Tables[0].Rows[0][11].ToString());


        }
    }
}
