using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys
{
    class BIHNum
    {
        Database db = new Database();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string sqlString = string.Empty;

        public string BIHnum { set; get; }

        public bool checkBIHNum (string bihnum)
        {
            this.BIHnum = bihnum;
            sqlString = "select  * from TB_UserBaseInfo where BIHNum= '"+this.BIHnum+"';";
            ds = db.GetDataSet(sqlString);
            
            if(ds.Tables[0].Rows.Count>0)
            {
                return false;
            }
            else
            { return true; }

        }
        public void insertBIHNum ()
        {

            sqlString = "insert into TB_UserBaseInfo (BIHNum) values ('" + this.BIHnum + "');"
               + "insert into TB_BEA (BIHNum) values ('" + this.BIHnum + "');"
+ "insert into TB_BEA_Cough (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_BEA_Cough_Luggies (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_BEA_Cough_Luggies_BloodLuggies (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_BEA_EarlierCheck (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_BEA_RapidBreath (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_BEA_RapidBreath_RelieveShow (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_COPD (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_COPD_Cough (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_COPD_Cough_Luggies (BIHNum) values ('" + this.BIHnum + "');"
+ "insert into TB_COPD_RapidBreath (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_FamillyHis (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_FamillyHis_Father (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_FamillyHis_Father_Sick (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_FamillyHis_Mother (BIHNum) values ('" + this.BIHnum + "');"
+ "insert into TB_FamillyHis_Mother_Sick (BIHNum) values ('"+this.BIHnum+"')"
+ "insert into TB_FamillyHis_Sister (BIHNum) values ('" + this.BIHnum + "')"

+ "insert into TB_FamillyHis_Sister_Sick (BIHNum) values ('" + this.BIHnum + "')"
+ "insert into TB_FamillyHis_Brother (BIHNum) values ('" + this.BIHnum + "')"
+ "insert into TB_FamillyHis_Brother_Sick (BIHNum) values ('" + this.BIHnum + "')"

+ "insert into TB_FamillyHis_Child (BIHNum) values ('" + this.BIHnum + "')"

+ "insert into TB_LunCA (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_LunCA_BonePartPain (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_LunCA_ChestPain (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_LunCA_Complex (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_LunCA_Cough (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_LunCA_Cough_Luggies (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_LunCA_CoughBlood (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_LunCA_EarlierCheck (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_LunCA_LymphGrow (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_LunCA_RapidBreath (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_LunCA_SVCS (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_LunCA_WeightFall (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_PersonalHis (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_PersonalHis_Drink (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_PersonalHis_GOLocal (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_PersonalHis_JobEnviron (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_PersonalHis_Marriage (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_PersonalHis_OtherHabby (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_PersonalHis_Smoke (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_PHI (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_Pleuraleffusion (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_Pleuraleffusion_BreathHard (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_Pleuraleffusion_ChestPain (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_Pleuraleffusion_Cough (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_Pleuraleffusion_Cough_Luggies (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_Pleuraleffusion_Fever (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_Pleuraleffusion_Fever_Drup (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_Pleuraleffusion_RapidBreath (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_Pleuraleffusion_RapidBreath_RelieveShow (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_Pleuraleffusion_Wasting (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_PMH (BIHNum) values ('" + this.BIHnum + "');"



+ "insert into TB_PMH_DrugAllergy (BIHNum) values ('" + this.BIHnum + "');"



+ "insert into TB_PMH_Surgery (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_PMH_Trauma (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_PNA (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_PNA_BreathHard (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_PNA_ChestPain (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_PNA_Cough (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_PNA_Cough_Luggies (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_PNA_Fever (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_PNA_Fever_Drup (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_PNA_Follow (BIHNum) values ('" + this.BIHnum + "');"

+ "insert into TB_PNA_Follow_Diarrhea (BIHNum) values ('" + this.BIHnum + "');";


            db.ExecuteSQL(sqlString);



        }
    }


}
