using System.Data;
using System.Configuration;
using System.Data.SqlClient;
/// <summary>
/// Class1 的摘要说明
/// </summary>
public class Class1
{
    static SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["connString"].ToString());
	public Class1()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
        
	}
    public static class ColorClass
    {
        //
        //FFFF66
        public const string SelectColor = "CCCC33";
    }
    public static DataTable GetDataTable(string sql)
    {
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataSet ds = new DataSet();
        da.Fill(ds, "tabel");
        return ds.Tables[0] ;
    }
    public static int UpdateData(string sql)
    {
        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
        SqlCommand com = new SqlCommand(sql, con);
        con.Open();
        int m= com.ExecuteNonQuery();
        
        con.Close();
        return m;
    }
}
