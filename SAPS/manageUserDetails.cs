using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SAPS
{
    class manageUserDetails : databaseUtilites
    {
        /*class attribute are made excactly to match table collums !important*/
        public int detailId;
        public int userId;
        public string firstName;
        public string lastName;
        public string phoneNumber;
        public Boolean dacFound;
        public Boolean dacCrud;

        public Boolean setDetails(int userId, string firstName, string lastName, string phoneNumber)
        {
            try
            {
                string sql = "SELECT firstName FROM wizuserdetails WHERE userId =" + userId;
                if (rowCount(sql) == 0)
                {
                    sql = "INSERT INTO wizuserdetails (userId,firstName,lastName,phoneNumber) VALUES ('" + userId + "','" + firstName + "','" + lastName + "','" + phoneNumber + "')";
                    return executeQuery(sql);
                }
                else
                {
                    this.dacFound = true;
                    return false;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Failed in manageUsers loginUser()  " + ex);
                return false;
            }
        }

        public void getUserDetails(int userId)
        {
            try
            {
                string sql = "SELECT * FROM wizuserdetails WHERE userId =" + userId.ToString();
                query.Connection = connection;
                query.CommandText = sql;
                MySqlDataReader dataReader = query.ExecuteReader();
                while (dataReader.Read())
                {
                    this.userId = Convert.ToInt32(dataReader["userId"]);
                    this.firstName = dataReader["firstName"].ToString();
                    this.lastName = dataReader["lastName"].ToString();
                    this.phoneNumber = dataReader["phoneNumber"].ToString();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Failed in manageUsers loginUser()  " + ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public Boolean updateUser(int userId)
        {
            try
            {
                string sql = "UPDATE wizuserdetails SET firstName = '" + this.firstName + "', lastName = '" + this.lastName + "',phoneNumber = '" + this.phoneNumber + "' WHERE userId = '" + userId + "' LIMIT 1 ";
                return executeQuery(sql);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Failed in getClass()  " + ex);
                return false;
            }
        }

        public Boolean deleteUser(int userId)
        {
            try
            {
                string sql = "DELETE FROM wizuserdetails WHERE userId =" + userId + " LIMIT 1";
                return executeQuery(sql);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Failed in getClass()  " + ex);
                return false;
            }
        }

    }
}
