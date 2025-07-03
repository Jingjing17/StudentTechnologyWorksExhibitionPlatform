using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SDM.DAL
{
    public class DbHelperSQL
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionSQLstring"].ConnectionString;

        public static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans,
            string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open) conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null) cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;
            if (cmdParms != null)
            {
                foreach (SqlParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput
                        || parameter.Direction == ParameterDirection.Input)
                        && (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }

        public static DataSet Query(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return ds;
                }

            }
        }
        public static int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                PrepareCommand(cmd, conn, null, sql, parameters);
                int result = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return result;
            }
        }

        // 使用查询验证是否存在
        public static bool Exists(string strSql, SqlParameter[] parameters)
        {
            object obj = GetSingle(strSql, parameters);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // 用于执行查询并返回单一结果
        public static object GetSingle(string strSql, SqlParameter[] parameters)
        {
            // 你可以根据数据库连接字符串来实现此方法
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["WorkDataBaseConnectionString"].ToString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(strSql, connection);
                cmd.Parameters.AddRange(parameters);
                connection.Open();
                object obj = cmd.ExecuteScalar(); // 获取第一行第一列的值
                connection.Close();
                return obj;
            }
        }
    }
}
