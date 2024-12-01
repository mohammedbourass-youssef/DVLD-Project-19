using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLAyer
{
    public  class clsDriverDataAccess
    {
        static public int IsExistByPersonID(int personid)
        {
            int result = 0;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = "Select DriverID from Drivers Where PersonID =  @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", personid);
            try
            {
                connection.Open();
                object obj = command.ExecuteScalar();
                if (obj != null && int.TryParse(obj.ToString(), out int ID))
                    result = ID;
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return result;
        }
        static public DataTable GetAllRecord()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = @"Select drivers_people_view.*, ActiveLicenses
  From License_Drivers_view 
inner join drivers_people_view 
 on License_Drivers_view.DriverID = drivers_people_view.DriverID";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dt.Load(Reader);
                }
                Reader.Close();
            }
            catch (Exception ex)
            {
                dt = null;
            }
            finally { connection.Close(); }
            return dt;
        }

        static public int Create(int personID , int userID,DateTime createdate)
        {
            int lastid = 0;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = @"INSERT INTO [dbo].[Drivers]
     VALUES
           (@PersonID
           ,@CreatedByUserID
           ,@CreatedDate)" + "select SCOPE_IDENTITY()";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@PersonID", personID);
            cmd.Parameters.AddWithValue("@CreatedByUserID", userID);
            cmd.Parameters.AddWithValue("@CreatedDate", createdate);
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
                 string msg = ex.Message;   
            }
            finally { connection.Close(); }
            return lastid;
        }

        static public bool Find(int driverID,ref int personID,ref int userID,ref DateTime createddate)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = @"SELECT *FROM Drivers WHERE DriverID = @DriverID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", driverID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    personID = (int)reader["PersonID"]; 
                    userID = (int)reader["CreatedByUserID"];
                    createddate = (DateTime)reader["CreatedDate"];
                    result = true;
                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return result;
        }
        static public bool FindByPesonID(int personID, ref int driverID, ref int userID, ref DateTime createddate)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = @"SELECT *FROM Drivers WHERE PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", personID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    driverID = (int)reader["DriverID"];
                    userID = (int)reader["CreatedByUserID"];
                    createddate = (DateTime)reader["CreatedDate"];
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
