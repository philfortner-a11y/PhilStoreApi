using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PhilStoreApi.Data
{
    public class SqlTools
    {
        //Setup constructor
        public SqlTools()
        {
            //Set the SQL Server connection string

        }

        /// <summary>
        /// Open a SQL Server database connection
        /// </summary>
        /// <returns>SQL Connection object</returns>
        public SqlConnection OpenSQLConnection()
        {
            //Declare locals
            string strCon;
            SqlConnection mySqlConnection;

            //Instantiate objects
            mySqlConnection = new SqlConnection();

            //Set values
            strCon = System.Configuration.ConfigurationManager.AppSettings["LocalSqlConnection"];
            mySqlConnection.ConnectionString = strCon;

            //Open SQL connection object
            mySqlConnection.Open();

            return mySqlConnection;
        }

        /// <summary>
        /// Close the SQL connection
        /// </summary>
        /// <param name="theSqlConnection">The SQL connection object to close</param>
        public void CloseSqlConnection(SqlConnection theSqlConnection)
        {
            //Close the SQL connection
            theSqlConnection.Close();
        }
    }
}