using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;

namespace SongCatelogApp
{

    public class DBConnection
    {
        string DBConnectionStr = "";
        SqlConnection con;

        public DBConnection()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionStr"].ConnectionString;
        
            if (connectionString == null)
                throw new NullReferenceException("DBConnectionStr setting not found in .config file.");
            //else
            this.DBConnectionStr = connectionString;
        }

        private SqlConnection OpenConnection()
        {
            string DBConnectionStr = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionStr"].ConnectionString;

            this.con = new SqlConnection(DBConnectionStr);
            con.Open();
            return con;
        }

        public SqlDataReader DataReader(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, this.con);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }


        // Execute SQL Query
        public DataTable ExecuteQuery(string sQuery)
        {
            SqlConnection cn = this.OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter(sQuery, this.con);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            if (dt != null)
            {
                da.Fill(dt);
                da.Dispose();
            }

            //if (ds != null)
            //    dt = ds.Tables[0];

            this.CloseConnection(this.con);
            return dt;
        }

        private void CloseConnection(SqlConnection cn)
        {
            cn.Close();
            cn.Dispose();
        }
    }



}