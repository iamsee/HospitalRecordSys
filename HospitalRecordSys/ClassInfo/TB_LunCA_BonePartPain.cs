using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys
{
    class TB_LunCA_BonePartPain
    {
        Database db = new Database();
        string sqlString = string.Empty;
        DataSet ds = new DataSet();

        public string BIHNum;
        public string BonePartPainShow;

        public void update_TB_LunCA_BonePartPain()
        {
            sqlString = "update TB_LunCA_BonePartPain set BonePartPainShow='" + BonePartPainShow + "' where BIHNum='" + BIHNum + "';";
            db.ExecuteSQL(sqlString);
        }
        public void get_TB_LunCA_BonePartPain()
        {
            sqlString = "select * from TB_LunCA_BonePartPain where BIHNum =" + BIHNum + "';";
            ds = db.GetDataSet(sqlString);
            this.BonePartPainShow =(ds.Tables[0].Rows[0][1].ToString());
            
        }
    }
}
