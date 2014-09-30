using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlHelpertest
{
    class SqlHelper
    {
        private static string connStr = ConfigurationManager.ConnectionStrings["dbConnStr"].ConnectionString;
        #region 待改进版本
        //    public static int ExecuteNonQury(string sql)
        //    {
        //        using (SqlConnection conn = new SqlConnection(connStr))
        //        {
        //            conn.Open();
        //            using (SqlCommand cmd = conn.CreateCommand())
        //            {
        //                cmd.CommandText = sql;
        //                return cmd.ExecuteNonQuery();
        //            }
        //        }
        //    }

        //    public static object ExecuteScalar(string sql)
        //    {
        //        using (SqlConnection conn = new SqlConnection(connStr))
        //        {
        //            conn.Open();
        //            using (SqlCommand cmd = conn.CreateCommand())
        //            {
        //                cmd.CommandText = sql;
        //                return cmd.ExecuteScalar();
        //            }
        //    }

        //}
        //    public static DataSet ExecuteDataSet(string sql)
        //    {
        //        using (SqlConnection conn = new SqlConnection(connStr))
        //        {
        //            conn.Open();
        //            using (SqlCommand cmd = conn.CreateCommand())
        //            {
        //                cmd.CommandText = sql;
        //                SqlDataAdapter adapter = new SqlDataAdapter();
        //                DataSet dataset = new DataSet();
        //                adapter.Fill(dataset);
        //                return dataset;
        //            }
        //        }
        //    }
        // }
        #endregion
        #region 改进版本
        public static int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    return cmd.ExecuteNonQuery();
                }
            }
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

        public static DataTable ExecuteDataTable(string sql, params SqlParameter[] sqlparameters)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dataset = new DataSet();
                    adapter.Fill(dataset);
                    return dataset.Tables[0];
                }
            }
        }
        #endregion
    }
}