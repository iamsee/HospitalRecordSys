using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRecordSys
{
    class TB_TGJC
    {
        Database db = new Database();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string sqlString = string.Empty;


        public string BIHNum;
        public string tw;
        public string mb;
        public string hxpl;
        public string xy;
        public string fayu;
        public string yudiao;
        public string tiwei;
        public string yingyang;
        public string mianrong;
        public string tixing;
        public string yishi;
        public string biaoqing;
        public string butai;
        public string yanse;
        public string shidu;
        public string tanxing;
        public string tfyanse;
        public string touludaxiao;
        public string toufashumi;
        public string jiemo;
        public string jiaomo;
        public string sctongkong;
        public string gongmo;
        public string tkxingzhuang;
        public string tkdgfs;

        public void updat_TB_TGJC()
        {
            sqlString = "update TB_TGJC set tw='" + tw + "',mb='" + mb + "',hxpl='" + hxpl + "',xy='" + xy + "',fayu='" + fayu + "',yudiao='" + yudiao + "',tiwei='" + tiwei + "',yingyang='" + yingyang + "',mianrong='" + mianrong + "',tixing='" + tixing + "',yishi='" + yishi + "',biaoqing='" + biaoqing + "',butai='" + butai + "',yanse='" + yanse + "',shidu='" + shidu + "',tanxing='" + tanxing + "',tfyanse='" + tfyanse + "',touludaxiao='" + touludaxiao + "',jiemo='" + jiemo + "',jiaomo='" + jiaomo + "',sctongkong='" + sctongkong + "',gongmo='" + gongmo + "',tkxingzhuang='" + tkxingzhuang + "',tkdgfs='" + tkdgfs + "' where BIHNum='" + BIHNum + "';";
            db.ExecuteSQL(sqlString);
        }

        public void get_TB_TGJC()
        {

            sqlString = "select * from TB_TGJC";
            ds = db.GetDataSet(sqlString);
            tw = ds.Tables[0].Rows[0][1].ToString();
            mb = ds.Tables[0].Rows[0][2].ToString();
            hxpl = ds.Tables[0].Rows[0][3].ToString();
            xy = ds.Tables[0].Rows[0][4].ToString();
            fayu = ds.Tables[0].Rows[0][5].ToString();
            yudiao = ds.Tables[0].Rows[0][6].ToString();
            tiwei = ds.Tables[0].Rows[0][7].ToString();
            yingyang = ds.Tables[0].Rows[0][8].ToString();
            mianrong = ds.Tables[0].Rows[0][9].ToString();
            tixing = ds.Tables[0].Rows[0][10].ToString();
            yishi = ds.Tables[0].Rows[0][11].ToString();
            biaoqing = ds.Tables[0].Rows[0][12].ToString();
            butai = ds.Tables[0].Rows[0][13].ToString();
            yanse = ds.Tables[0].Rows[0][14].ToString();

            shidu = ds.Tables[0].Rows[0][15].ToString();
            tanxing = ds.Tables[0].Rows[0][16].ToString();

            tfyanse = ds.Tables[0].Rows[0][17].ToString();

            touludaxiao = ds.Tables[0].Rows[0][18].ToString();
            toufashumi = ds.Tables[0].Rows[0][19].ToString();
            jiemo = ds.Tables[0].Rows[0][20].ToString();
            jiaomo = ds.Tables[0].Rows[0][21].ToString();
            sctongkong = ds.Tables[0].Rows[0][22].ToString();
            gongmo = ds.Tables[0].Rows[0][23].ToString();

            tkxingzhuang = ds.Tables[0].Rows[0][24].ToString();
            tkdgfs = ds.Tables[0].Rows[0][25].ToString();


        }


    }
}
