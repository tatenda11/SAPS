using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace SAPS
{
    class manageUsers : databaseUtilites
    {
        public int userId;
        public string userName;
        public string password;
        public string userType;
        public string email;
        /******************Flags*********************************/
        public Boolean dacCrud;
        public Boolean dacFound;

        public Boolean setUser(string uName, string password, string uTyp, string email)
        {
            try
            {
                checkConnection();
                string sql = "INSERT INTO wizuser (userId,userName,password,userType,email)";
                sql += "VALUES ('','" + uName + "', '" + password + "','" + uTyp + "','" + email + "')";
                query.Connection = connection;
                query.CommandText = sql;
                int i = query.ExecuteNonQuery();
                this.dacCrud = (i > 0) ? true : false;
                return this.dacCrud;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Failed in manageUsers setUser()  " + e);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public Boolean checkExist(string uName)
        {
            try
            {
                checkConnection();
                string sql = "SELECT userId FROM wizuser WHERE userName = '" + uName + "'";
                query.Connection = connection;
                query.CommandText = sql;
                int i = query.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show(i.ToString());
                this.dacFound = (i > 0) ? true : false;
                return this.dacFound;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Failed in manageUsers checkExist()  " + e);
                return false;
            }
            finally
            {
                connection.Close();
            }

        }

        public Boolean loginUser(string uName, string password)
        {
            try
            {
                checkConnection();
                string sql = "SELECT * FROM wizuser WHERE userName = '" + uName + "' AND password = '" + password + "' LIMIT 1";
                query.Connection = connection;
                query.CommandText = sql;
                MySqlDataReader myReader = query.ExecuteReader();
                int count = 0;
                while (myReader.Read())
                {
                    count = count + 1;
                }
                this.dacFound = (count > 0) ? true : false;
                return this.dacFound;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Failed in manageUsers loginUser()  " + e);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public void getUser(int userId)
        {
            try
            {
                checkConnection();
                string sql = "SELECT * FROM wizuser WHERE userId = '" + userId + "'";
                query.Connection = connection;
                query.CommandText = sql;
                MySqlDataReader dataReader = query.ExecuteReader();
                while (dataReader.Read())
                {
                    this.userId = Convert.ToInt32(dataReader["userId"]);
                    this.userName = dataReader["userName"].ToString();
                    this.password = dataReader["password"].ToString();
                    this.email = dataReader["email"].ToString();
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Failed in manageUsers getUser()  " + e);
            }
            finally
            {
                connection.Close();
            }
        }

    }
}
