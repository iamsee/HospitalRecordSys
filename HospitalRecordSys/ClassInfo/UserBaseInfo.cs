using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys
{
    class UserBaseClass
    {
        Database db = new Database();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string sqlString = string.Empty;

        public string BIHNum;
        public string Name
        {
            set;
            get;
        }
        public string BirthLocal
        {
            set;
            get;
        }
        public string Sex
        {
            set;
            get;
        }
        public string WorkOrg
        {
            set;
            get;
        }
        public int Age
        {
            set;
            get;
        }
        public string LiveLocal
        {
            set;
            get;
        }
        public string MarryState
        {
            set;
            get;
        }
        public string DeclarePer
        {
            set;
            get;

        }
        public string Nation
        {
            set;
            get;

        }
        public string BINTime
        {
            set;
        get;

        }
        public string Vocation
        {
            set;
            get;
        }
        public string RecordTime
        {
            set;
            get;

        }

        public string JobNum;

        public void update_TB_UserBaseInfo()
        {
            sqlString = "update TB_UserBaseInfo set Name='" + this.Name +"',JobNum='"+JobNum+"',BirthLocal='" + BirthLocal + "',Sex='" + Sex + "',WorkOrg='" + WorkOrg + "',Age=" + Age + ",LiveLocal='" + LiveLocal + "',MaritalSta='" + MarryState + "',DeclarePer='" + DeclarePer + "',Nation='" + Nation + "',BINTime=" + BINTime + ",Vocation='" + Vocation + "',RecordTime=" + RecordTime + " where BIHNum='" + BIHNum + "';";
            db.ExecuteSQL(sqlString);
        }
      public void Get_UserBaseClass()
        {
          sqlString ="select * from TB_UserBaseInfo where BIHNum='"+BIHNum+"';";
          ds = db.GetDataSet(sqlString);
          
          this.JobNum = ds.Tables[0].Rows[0][1].ToString();
          this.Name = ds.Tables[0].Rows[0][2].ToString();
          this.BirthLocal = ds.Tables[0].Rows[0][3].ToString();
          this.Sex = ds.Tables[0].Rows[0][4].ToString();
          this.WorkOrg = ds.Tables[0].Rows[0][5].ToString();
      //    this.Age = Convert.ToInt32(ds.Tables[0].Rows[0][6].ToString());
          this.LiveLocal = ds.Tables[0].Rows[0][7].ToString();
          this.MarryState = ds.Tables[0].Rows[0][8].ToString();
          this.DeclarePer = ds.Tables[0].Rows[0][9].ToString();
          this.Nation = ds.Tables[0].Rows[0][10].ToString();
          this.BINTime = ds.Tables[0].Rows[0][11].ToString();
          this.Vocation = ds.Tables[0].Rows[0][12].ToString();
          this.RecordTime = ds.Tables[0].Rows[0][13].ToString();
        }
            
    }
}
