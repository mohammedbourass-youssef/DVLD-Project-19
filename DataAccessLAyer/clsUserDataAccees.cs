using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLAyer
{
    public class clsUserDataAccees
    {
        static public int Create(string username, string password, int personid, bool IsActive)
        {
            int lastid = 0;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = @"INSERT INTO [dbo].[Users]
                                      VALUES
                                           (@PersonID
                                           ,@UserName
                                           ,@Password
                                           ,@IsActive)" 
                              + "select SCOPE_IDENTITY()";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@UserName", username);
            cmd.Parameters.AddWithValue ("@Password", password);
            cmd.Parameters.AddWithValue ("@PersonID", personid);
            cmd.Parameters.AddWithValue ("@IsActive", IsActive); 
                
                try
                {
                    connection.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int ID))
                        lastid = ID;
                    else
                        lastid = 0;
                }
                catch (Exception ex)
                {
                    lastid = 0;
                }
                finally { connection.Close(); }
                return lastid;
        }
        static public DataTable GetAllUsers()
        {
            DataTable db = new DataTable();
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = @"SELECT        Users.UserID, Users.PersonID , People.FirstName+' '+ People.SecondName+' '+ People.ThirdName+' '+ People.LastName As FullName,Users.UserName, Users.IsActive
FROM            Users INNER JOIN
                         People ON Users.PersonID = People.PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    db.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
               
            }
            finally { connection.Close(); }
            return db;
        }
        static public bool Update(int userid, string password,string username, bool IsActive)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = @"UPDATE [dbo].[Users]
                                SET [UserName] = @UserName
                                   ,[Password] = @Password
                                   ,[IsActive] = @IsActive
                              WHERE UserID = @UserID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@UserName", username);
            cmd.Parameters.AddWithValue("@Password", password);
            cmd.Parameters.AddWithValue("@UserID", userid);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);
            

            try
            {
                connection.Open();
                 result = cmd.ExecuteNonQuery()>0;
                
            }
            catch (Exception ex)
            {
                result = false;
            }
            finally { connection.Close(); }
            return result;
        }
        static public bool Delete(int userid)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = @"DELETE FROM [dbo].[Users]
                              WHERE UserID = @UserID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@UserID", userid);
            try
            {
                connection.Open();
                result = cmd.ExecuteNonQuery() > 0;

            }
            catch (Exception ex)
            {
                result = false;
            }
            finally { connection.Close(); }
            return result;
        }
        static public bool IsExist(int userid)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = "Select *from Users WHERE UserID = @UserID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", userid);
            try
            {
                connection.Open();
                object obj = command.ExecuteScalar();
                if (obj != null && int.TryParse(obj.ToString(), out int ID))
                    result = ID == 1;
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return result;
        }
        static public bool IsExistByPersonID(int personid)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = "Select *from Users WHERE PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", personid);
            try
            {
                connection.Open();
                object obj = command.ExecuteScalar();
                if (obj != null && int.TryParse(obj.ToString(), out int ID))
                    result = ID == 1;
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return result;
        }
        static public bool IsExist(string username)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = "Select *from Users WHERE UserName = @UserName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", username);
            try
            {
                connection.Open();
                object obj = command.ExecuteScalar();
                if (obj != null && int.TryParse(obj.ToString(), out int ID))
                    result = ID == 1;
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return result;
        }
        static public bool Find(int userid,ref string password,ref string username,ref int personid,ref bool IsActive)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = @"Select *from Users Where UserID = @UserID";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@UserID", userid);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    username = (string)reader["UserName"];
                    password = (string)reader["Password"];
                    personid = (int)reader["PersonID"];
                    IsActive = (bool)reader["IsActive"];
                    result = true;
                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return result;
        }
        static public bool Find(ref int userid, ref string password,  string username, ref int personid, ref bool IsActive)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = @"Select *from Users Where UserName = @UserName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", username);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    userid = (int)reader["UserID"];
                    password = (string)reader["Password"];
                    personid = (int)reader["PersonID"];
                    IsActive = (bool)reader["IsActive"];
                    result = true;
                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return result;
        }

    }
}
