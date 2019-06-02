using System;
using System.Data;
using System.Data.SqlClient;

public class SqlAccess
{
    //2018-05-07
    //注意：該類別目前只先使用在 SSHIS 類別下

    //校護端連線字串
    public static readonly string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog = Health; Integrated Security = True;";

    public static object ExecuteScalar(string cmdText)
    {
        return ExecuteScalar(cmdText, connectionString);
    }
    public static object ExecuteScalar(string cmdText, string connectionString)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    return cmd.ExecuteScalar();
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public static int ExecuteNonQuery(string cmdText)
    {
        return ExecuteNonQuery(cmdText, connectionString);
    }
    public static int ExecuteNonQuery(string cmdText, string connectionString)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public static DataTable SqlDataAdapterToDataTable(string cmdText)
    {
        return SqlDataAdapterToDataTable(cmdText, connectionString);
    }
    public static DataTable SqlDataAdapterToDataTable(string cmdText, string connectionString)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmdText, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public static DataSet SqlDataAdapterToDataSet(string cmdText)
    {
        return SqlDataAdapterToDataSet(cmdText, connectionString);
    }
    public static DataSet SqlDataAdapterToDataSet(string cmdText, string connectionString)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmdText, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    return ds;
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    #region Parameter 
    public static object ExecuteScalar(string cmdText, SqlParameter[] parameters)
    {
        return ExecuteScalar(cmdText, connectionString, parameters);
    }
    public static object ExecuteScalar(string cmdText, string connectionString, SqlParameter[] parameters)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteScalar();
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    public static int ExecuteNonQuery(string cmdText, SqlParameter[] parameters)
    {
        return ExecuteNonQuery(cmdText, connectionString, parameters);
    }
    public static int ExecuteNonQuery(string cmdText, string connectionString, SqlParameter[] parameters)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    public static DataTable SqlDataAdapterToDataTable(string cmdText, SqlParameter[] parameters)
    {
        return SqlDataAdapterToDataTable(cmdText, connectionString, parameters);
    }
    public static DataTable SqlDataAdapterToDataTable(string cmdText, string connectionString, SqlParameter[] parameters)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmdText, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.SelectCommand.Parameters.AddRange(parameters);
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    public static DataSet SqlDataAdapterToDataSet(string cmdText, SqlParameter[] parameters)
    {
        return SqlDataAdapterToDataSet(cmdText, connectionString, parameters);
    }
    public static DataSet SqlDataAdapterToDataSet(string cmdText, string connectionString, SqlParameter[] parameters)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmdText, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.SelectCommand.Parameters.AddRange(parameters);
                    adapter.Fill(ds);
                    return ds;
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    #endregion
}