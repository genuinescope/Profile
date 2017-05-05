using System;
using System.Data;
using System.Data.SqlClient;

namespace SongCatalog.MPM.Data
{
    /// <summary>
    /// This class provide general database services
    /// </summary>
    public class DatabaseUtils
    {
        private string DBConnectionStr;

        #region Constructor

        public DatabaseUtils()
        {
            // reads Connection string from .config file
            string s = System.Configuration.ConfigurationSettings.AppSettings.Get("DBConnectionStr");
            if (s == null)
                throw new NullReferenceException("DBConnectionStr setting not found in .config file.");
            //else
            this.DBConnectionStr = s;
        }

        #endregion

        #region Open/Close DB Connections

        private SqlConnection OpenConnection()
        {
            SqlConnection cn = new SqlConnection(DBConnectionStr);
            cn.Open();
            return cn;
        }

        SqlConnection oTransCon;
        SqlTransaction oTrans;

        //Open transaction
        public void OpenTransactionConnection()
        {

            oTransCon = new SqlConnection(DBConnectionStr);
            oTransCon.Open();
            oTrans = oTransCon.BeginTransaction();

            //return oTrans ;
        }

        private void CloseConnection(SqlConnection cn)
        {
            cn.Close();
            cn.Dispose();
        }

        //Close Transaction
        public void CloseTransactionConnection()
        {
            if (oTransCon.State == ConnectionState.Open)
            {
                oTrans.Commit();
            }
            oTransCon.Close();
            oTransCon.Dispose();
        }
        //Close Transaction
        public void RollBackTransactionConnection()
        {
            if (oTransCon.State == ConnectionState.Open)
            {
                oTrans.Rollback();
            }
            oTransCon.Close();
            oTransCon.Dispose();
        }


        #endregion

        #region  Execute General SQL statemenets

        public object ExecuteScalar(string sCommand)
        {
            SqlConnection cn = this.OpenConnection();
            SqlCommand cmd = new SqlCommand(sCommand, cn);
            object ret = cmd.ExecuteScalar();
            cmd.Dispose();
            this.CloseConnection(cn);
            return ret;
        }

        // Execute SQL Command
        public bool ExecuteCommand(string sCommand)
        {
            SqlConnection cn = this.OpenConnection();
            SqlCommand cmd = new SqlCommand(sCommand, cn);
            int ret = cmd.ExecuteNonQuery();
            cmd.Dispose();
            this.CloseConnection(cn);

            return (ret > 0);
        }

        // Execute SQL Query
        public DataTable ExecuteQuery(string sQuery)
        {
            SqlConnection cn = this.OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter(sQuery, cn);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            da.Fill(dt);
            da.Dispose();


            //if (ds != null)
            //    dt = ds.Tables[0];

            this.CloseConnection(cn);
            return dt;
        }

        public DataSet ExecuteDSQuery(string sQuery)
        {
            SqlConnection cn = this.OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter(sQuery, cn);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            da.Fill(ds);
            da.Dispose();


            //if (ds != null)
            //    dt = ds.Tables[0];

            this.CloseConnection(cn);
            return ds;
        }


        // Execute SQL Query with Transaction
        public void ExecuteQuery_Batch(string sQuery)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = oTransCon;
            cmd.Transaction = oTrans;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sQuery;

            cmd.ExecuteNonQuery();


        }

        // Execute SQL Query with Transaction
        /// <summary>
        /// Transact begin & retrive data
        /// </summary>
        /// <param name="sQuery"></param>
        /// <returns>Return Data Table</returns>
        public DataTable ExecuteQuery_BatchDT(string sQuery)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = oTransCon;
            cmd.Transaction = oTrans;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sQuery;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            da.Dispose();

            return dt;
        }

        /* Function intorduced by M.D Weerasingha
           Date : 10th March 2011
         */
        public static string ToRelativeDate(DateTime dateTime)
        {

            var timeSpan = DateTime.Now - dateTime;


            // span is less than or equal to 60 seconds, measure in seconds.

            if (timeSpan <= TimeSpan.FromSeconds(60))
            {

                return timeSpan.Seconds + "seconds ago";

            }

            // span is less than or equal to 60 minutes, measure in minutes.

            if (timeSpan <= TimeSpan.FromMinutes(60))
            {

                return timeSpan.Minutes > 1

                    ? "about " + timeSpan.Minutes + " minutes ago"

                    : "about a minute ago";

            }

            // span is less than or equal to 24 hours, measure in hours.

            if (timeSpan <= TimeSpan.FromHours(24))
            {

                return timeSpan.Hours > 1

                    ? "about " + timeSpan.Hours + " hours ago"

                    : "about an hour ago";

            }

            // span is less than or equal to 30 days (1 month), measure in days.

            if (timeSpan <= TimeSpan.FromDays(30))
            {

                return timeSpan.Days > 1

                    ? "about " + timeSpan.Days + " days ago"

                    : "about a day ago";

            }

            // span is less than or equal to 365 days (1 year), measure in months.

            if (timeSpan <= TimeSpan.FromDays(365))
            {

                return timeSpan.Days > 30

                    ? "about " + timeSpan.Days / 30 + " months ago"

                    : "about a month ago";

            }



            // span is greater than 365 days (1 year), measure in years.

            return timeSpan.Days > 365

                ? "about " + timeSpan.Days / 365 + " years ago"

                : "about a year ago";

        }

        public int CountQuery(string sQuery)
        {
            SqlConnection cn = this.OpenConnection();
            SqlCommand cmd = new SqlCommand(sQuery, cn);
            object o = cmd.ExecuteScalar();
            int k = 0;
            if (!(o is DBNull))
                k = int.Parse(o.ToString());

            cmd.Dispose();
            this.CloseConnection(cn);
            return k;
        }

        #endregion

        #region Insert/Update/Delete

        // Inserts new record, and returns the @@identity value (autonumber) generated for the 'id' field.
        public int Insert(DataTable dt)
        {
            return this.Insert(dt, "*");
        }

        // Inserts new record, and returns the @@identity value (autonumber) generated for the 'id' field.
        public int Insert(DataTable dt, string FieldList)
        {
            if (dt.Rows.Count == 0)
            {
                return -1;
            }

            string sql = "SELECT " + FieldList + " FROM " + dt.TableName + " WHERE 1=0";

            SqlConnection cn = this.OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);

            dt.Rows[0]["id"] = -1;

            da.RowUpdated += new SqlRowUpdatedEventHandler(OnTableRowUpdated);

            da.Update(dt);
            cb.Dispose();
            da.Dispose();
            this.CloseConnection(cn);
            return Convert.ToInt32(dt.Rows[0]["id"]);
        }

        // this is a private event handler to get the identity/auto_number generated on a inserted row
        private void OnTableRowUpdated(object sender, SqlRowUpdatedEventArgs args)
        {
            if (args.StatementType == StatementType.Insert)
            {
                // Retrieve the identity value and save it back in the row's ID field
                SqlConnection cn = args.Command.Connection;
                SqlCommand cmd = new SqlCommand("SELECT @@IDENTITY", cn);
                object o = cmd.ExecuteScalar();
                if (!(o is DBNull))
                    args.Row["id"] = int.Parse(o.ToString());

                cmd.Dispose();
            }
        }

        // Update Database Returns True if Success
        public bool Update(DataTable dt)
        {
            string sql = "SELECT * FROM " + dt.TableName + " WHERE 1=0";
            SqlConnection cn = this.OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            int ret = da.Update(dt);
            cb.Dispose();
            da.Dispose();
            this.CloseConnection(cn);
            return (ret > 0);
        }

        // a DataTable will be returned with table metadata so that new rows can be inserted
        public DataTable GetDataTableForInsert(string TableName)
        {
            return this.GetDataTableForInsert(TableName, "*");
        }

        // a DataTable will be returned with table metadata so that new rows can be inserted
        public DataTable GetDataTableForInsert(string TableName, string FieldList)
        {
            string sql = "SELECT " + FieldList + "  FROM " + TableName + " WHERE 1=0";
            SqlConnection cn = this.OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable(TableName);
            da.Fill(dt);
            da.Dispose();
            this.CloseConnection(cn);
            return dt;
        }

        // a DataTable will be returned with table metadata so that the row with 'id' can be updated
        public DataTable GetDataTableForUpdate(string TableName, int id)
        {
            return this.GetDataTableForUpdate(TableName, "*", id);
        }

        // a DataTable will be returned with table metadata so that the row with 'id' can be updated
        public DataTable GetDataTableForUpdate(string TableName, string FieldList, int id)
        {
            string sql = "SELECT " + FieldList + " FROM " + TableName + " WHERE id=" + id;
            return this.GetDataTableForUpdate(TableName, sql);
        }

        // a DataTable will be returned with table metadata so that the row(s) can be updated
        public DataTable GetDataTableForUpdate(string TableName, string SelectCommand)
        {
            SqlConnection cn = this.OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter(SelectCommand, cn);
            DataTable dt = new DataTable(TableName);
            da.Fill(dt);
            da.Dispose();
            this.CloseConnection(cn);
            return dt;
        }

        // execute a SQL Delete command to delete the row containing the 'id'
        public bool DeleteTableRow(string TableName, int id)
        {
            string sql = "DELETE FROM " + TableName + " WHERE id=" + id;
            return this.ExecuteCommand(sql);
        }

        #endregion

        #region Formatting for database field comparrisons when constructing SQL statements

        // returns a string enclosed in ' formatted correctly to be used in a SQL
        // eg:  abc'def will return 'abc''def'
        public string FormatStr(string s)
        {
            return "'" + s.Replace("'", "''") + "'";
        }
        // returns a date formatted correctly to be used in a SQL.
        // we convert the date to SQL date-format-type: 101
        // eg:  Convert(datetime, '06/20/2003', 101)
        public string FormatDate(DateTime d)
        {
            return "Convert(datetime, '" + d.ToString("MM/dd/yyyy") + "', 101)";
        }

        // returns a date-time formatted correctly to be used in a SQL
        // we convert the date to SQL date-format-type: 120
        // eg:  Convert(datetime, '2003-06-20 14:15:16', 120)
        public string FormatDateTime(DateTime d)
        {
            return "Convert(datetime, '" + d.ToString("yyyy-MM-dd HH:mm:ss") + "', 120)";
        }


        public string TimeFormat()
        {
            return "h:mm tt";
        }
        public string ToRelativeDate_ForNotifi(DateTime dateTime)
        {

            return String.Format("{0:dddd, MMMM d, yyyy}", dateTime);

        }



        #endregion

    }
}

