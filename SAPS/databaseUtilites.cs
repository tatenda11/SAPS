using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace SAPS
{
    class databaseUtilites
    {
        protected static MySqlConnection connection = new MySqlConnection(GetConnectionStrings());
        protected static MySqlCommand query = new MySqlCommand();
       // protected static MySqlDataAdapter da;
        protected static string sql;

        protected static string GetConnectionStrings()
        {

            return ConfigurationManager.ConnectionStrings["DatastoreDataContextConnectionString"].ConnectionString;
        }

        protected static void checkConnection()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
            }
            catch (MySqlException e)
            {
                System.Windows.Forms.MessageBox.Show("Failed in manageUsers checkConnection()  " + e);
            }
        }

        protected static Boolean executeQuery(String sql)
        {
            try
            {
                checkConnection();
                query.Connection = connection;
                query.CommandText = sql;
                int i = query.ExecuteNonQuery();
                return (i > 0) ? true : false;
            }
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Failed execute query  " + ex);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        protected static int rowCount(string sql)
        {
            try
            {
                query.Connection = connection;
                query.CommandText = sql;
                MySqlDataReader myReader = query.ExecuteReader();
                int count = 0;
                while (myReader.Read())
                {
                    count = count + 1;
                }
                return count;
            }
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Failed in manageUsers checkExist()  " + ex);
                return 0;
            }
            finally
            {
                connection.Close();
            }
        }

    }
}
