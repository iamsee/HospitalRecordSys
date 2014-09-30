using System.Configuration;
using System.Data;
using System.Data.SqlClient;

/// <summary>
///Database 的摘要说明
/// </summary>
public class Database
{
    private static string connStr = ConfigurationManager.ConnectionStrings["dbConnStr"].ConnectionString;
   
    /// <summary>
    /// 定义连接字符串字段connstring
    /// </summary>
  
    /// <summary>
    /// 定义连接字符串属性Connstring
    /// </summary>

    /// <summary>
    /// 定义连接对象字段conn
    /// </summary>
    private SqlConnection conn;
    /// <summary>
    /// 定义连接对象属性Conn
    /// </summary>
    public SqlConnection Conn
    {
        get
        {
            return this.conn;
        }
        set
        {
            this.conn = value;
        }
    }
    /// <summary>
    /// Database构造函数逻辑代码用来直接初始化连接字符串connString
    /// </summary>
   
    /// <summary>
    /// 打开连接方法
    /// </summary>
    public void Open()
    {
        if (Conn == null)
        {
            Conn = new SqlConnection(connStr);
        }
        if (Conn.State.Equals(ConnectionState.Closed))
        {
            Conn.ConnectionString = connStr;
            Conn.Open();
        }
    }

    /// <summary>
    /// 关闭数据库连接
    /// </summary>
    public void Close()
    {
        if (Conn != null)
        {
            Conn.Close();
            Conn.Dispose();
        }
    }
    /// <summary>
    /// 用于执行SQL语句的方法针对Update Insert Delete 操作
    /// </summary>
    /// <param name="sqlString">SQL语句</param>
    /// <returns>针对Update Insert Delete 操作返回影响的行数,其他就返回-1</returns>
    public int ExecuteSQL(string sqlString)
    {
        int count = -1;
        this.Open();
        try
        {
            SqlCommand cmd = new SqlCommand(sqlString, Conn);
            count = cmd.ExecuteNonQuery();
        }
        catch
        {
            count = -1;
        }
        finally
        {
            this.Close();
        }
        return count;
    }
    public static object ExecuteScalar(string sql, params SqlParameter[] parameters)
    {
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                return cmd.ExecuteScalar();
            }
        }
    }
    /// <summary>
    /// 根据指定的select语句返回一个数据集DataSet
    /// </summary>
    /// <param name="sqlString">SQL语句</param>
    /// <returns>根据指定的select语句返回一个数据集DataSet</returns>
    public DataSet GetDataSet(string sqlString)
    {
        this.Open();
        SqlDataAdapter sda = new SqlDataAdapter(sqlString, Conn);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        this.Close();
        return ds;
    }
    /// <summary>
    /// 根据指定的select语句返回一个DataTable
    /// </summary>
    /// <param name="sqlString">SQL语句</param>
    /// <returns>根据指定的select语句返回一个DataTable</returns>
    public DataTable GetDataTable(string sqlString)
    {
        this.Open();
        SqlDataAdapter sda = new SqlDataAdapter(sqlString, Conn);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        this.Close();
        DataTable dt = ds.Tables[0];
        return dt;
    }



    /// <summary>
    /// 通过存储过程获取dataset,存储过程没有参数,方法重载1
    /// </summary>
    /// <param name="ProcName">存储过程名称</param>        
    /// <returns>根据指定存储过程返回一个数据集DataSet</returns>
    public DataSet GetDataSetFromProc(string ProcName)
    {
        this.Open();
        SqlDataAdapter sda = new SqlDataAdapter();
        sda.SelectCommand = new SqlCommand();
        sda.SelectCommand.Connection = Conn;
        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
        sda.SelectCommand.CommandText = ProcName;
        DataSet ds = new DataSet();
        sda.Fill(ds);
        this.Close();
        return ds;
    }
    /// <summary>
    /// 通过存储过程获取dataset,存储过程有参数,方法重载2
    /// </summary>
    /// <param name="ProcName">存储过程名称</param>
    /// <param name="ParaHashtable">参数列表</param>
    /// <returns>根据指定存储过程返回一个数据集DataSet</returns>
    public DataSet GetDataSetFromProc(string ProcName, System.Collections.Hashtable ParaHashtable)
    {
        this.Open();
        SqlDataAdapter sda = new SqlDataAdapter();
        sda.SelectCommand = new SqlCommand();
        sda.SelectCommand.Connection = Conn;
        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
        sda.SelectCommand.CommandText = ProcName;
        foreach (object key in ParaHashtable.Keys)
        {
            SqlParameter para = new SqlParameter();
            para.ParameterName = key.ToString();
            para.Value = ParaHashtable[key].ToString();
            sda.SelectCommand.Parameters.Add(para);
        }
        DataSet ds = new DataSet();
        sda.Fill(ds);
        this.Close();
        return ds;
    }
    /// <summary>
    /// 根据指定SQL语句select获取记录集合中的第一行数据
    /// </summary>
    /// <param name="sqlString">SQL语句</param>
    /// <returns>根据指定SQL语句select获取记录集合中的第一行数据</returns>
    public DataRow GetDataRow(string sqlString)
    {
        DataSet ds = GetDataSet(sqlString);
        ds.CaseSensitive = false;//表示DataTable对象中的字符串比较不区分大小写
        if (ds.Tables[0].Rows.Count > 0)
        {
            return ds.Tables[0].Rows[0];
        }
        else
        {
            return null;
        }
    }
}
