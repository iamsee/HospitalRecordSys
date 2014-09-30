using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys
{
    
    class CityandContury
    {

        Database db = new Database();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string sqlString = string.Empty;
        
        public string ProvinceName { get; set; }
        public string ProvinceID { get; set; }

        public String SelectProvinceName { set; get; }
        public string CityID { set; get; }
        public string CityName { set; get; }
        public String SelectCityName { set; get; }
        
        public string DistrictName { set; get; }

        public  DataTable getprovincename()
        {
            
            
            

            
            this.dt = this.db.GetDataTable("select ProvinceName from S_Province");
            return this.dt;
        }
        public  DataTable getcityname()
        {
            
            
             sqlString = "select ProvinceID from S_Province where ProvinceName = '" + this.SelectProvinceName + "'";
             if (SelectProvinceName != null)
             {
                 this.ds = this.db.GetDataSet(sqlString);

                 this.dt = this.ds.Tables[0];

                 this.ProvinceID = this.dt.Rows[0][0].ToString();
             }

                this.dt = this.db.GetDataTable("select CityName from S_City where ProvinceID = '" + this.ProvinceID+"'");
            return this.dt;
        }
        public  DataTable getdistrictname()
        {
            


            this.dt = this.db.GetDataTable("select CityID from S_District");
            sqlString = "select CityID from S_City where CityName = '" + this.SelectCityName+ "'";
            this.ds = this.db.GetDataSet(sqlString);

            this.dt = this.ds.Tables[0];
            if(this.SelectCityName!= null)
            { 
            this.CityID = this.dt.Rows[0][0].ToString();
            }
            sqlString = "select DistrictName from S_District where CityID = '" + this.CityID + "'";
            this.dt = this.db.GetDataTable(sqlString);
            return this.dt;
        }
    }


}
