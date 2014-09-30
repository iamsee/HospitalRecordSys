using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys
{
    class Time
    {
        Database db = new Database();
        DataTable dtYear = new DataTable();
        DataTable dtMonth = new DataTable();
        DataTable dtDay = new DataTable();
        DataSet ds = new DataSet();
        string sqlString = string.Empty;

        public string GetYear { set; get; }
        public string GetMonth { set; get; }
        public string GetDay { set; get; }
        public string SelectYear { set; get; }
        public string SelectMonth { set; get; }


        private int checkleap()
        {
            int show;
            //if(SelectYear == null)
            //{
            //    SelectYear = "0";
            //}
            if (((Convert.ToInt32(SelectYear) % 4 == 0) && (Convert.ToInt32(SelectYear) % 100 != 0)) || (Convert.ToInt32(SelectYear) % 400 == 0))
            {
                show=0;
                
            }
            else
            {
                show=1;
            }
            return show;
                    
          
         

                
        }
        public DataTable getyear()
        {
            dtYear = db.GetDataTable("select * from S_Year");
            return dtYear;
        }

        public DataTable getmonth()
        {
            dtMonth = db.GetDataTable("select * from S_Month");
            return dtMonth;

        }

        public DataTable getday()
        {
            //if(SelectMonth ==null)
            //{
            //    SelectMonth = "0";
            //}
            switch (Convert.ToInt32(SelectMonth))
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    dtDay = db.GetDataTable("select * from S_Day31");
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    dtDay = db.GetDataTable("select * from S_Day30");
                    break;
                case 2:
                    if (checkleap()==0)
                    {
                        dtDay = db.GetDataTable("select * from S_Day29");
                    }
                    else
                    {
                        dtDay = db.GetDataTable("select * from S_Day28");
                    }
                    break;
            }
            return dtDay;

        }
    }
}