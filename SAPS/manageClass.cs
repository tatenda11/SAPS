using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SAPS
{
    class manageClass : databaseUtilites
    {
        public int classRoomId;
        public string className;
        public int classGrade;
        public int teacherId;
        public string classDetails;
        /****************************************/
        public Boolean dacFoud;
        public Boolean dacCrud;
        /*************************************/

        public Boolean setClass(string cName, string cGrade, int teacher, string details)
        {
            try
            {
                string sql = "INSERT INTO wizclassrooms (className,classGrade,teacherId,classDetails) VALUES ('" + cName + "','" + cGrade + "','" + teacher + "', '" + details + "') ";
                return executeQuery(sql);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Failed in manageUsers setClass()  " + ex);
                return false;
            }
        }

        public Boolean updateClass(int classId)
        {
            try
            {
                string sql = "UPDATE wizclassrooms SET teacherId = '" + this.teacherId + "', classDetails = '" + this.classDetails + "' WHERE classRoomId = '" + classId + "' LIMIT 1";
                return executeQuery(sql);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Failed in manageUsers setClass()  " + ex);
                return false;
            }
        }

        public void getClass(int classId)
        {
            try
            {
                string sql = "SELECT * FROM wizclassrooms WHERE classRoomId =" + classId.ToString();
                checkConnection();
                query.Connection = connection;
                query.CommandText = sql;
                MySqlDataReader dataReader = query.ExecuteReader();
                while (dataReader.Read())
                {
                    this.classRoomId = Convert.ToInt32(dataReader["classRoomId"]);
                    this.classGrade = Convert.ToInt32(dataReader["classGrade"]);
                    this.teacherId = Convert.ToInt32(dataReader["teacherId"]);
                    this.classDetails = dataReader["classDetails"].ToString();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Failed in getClass()  " + ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public Boolean deleteClass(int classId)
        {
            try
            {
                string sql = "DELETE FROM wizclassrooms WHERE classroomId = '" + classId + "'";
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
