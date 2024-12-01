using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DataAccessLAyer
{
    public class clsApplicationDataAccess
    {
        static public bool CancelApplication(int applicationID)
        {
            bool lastid = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = @"UPDATE [dbo].[Applications]
                     SET
               [ApplicationStatus] = 2
                WHERE ApplicationID = @ApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", applicationID);
            try
            {
                connection.Open();
                lastid = command.ExecuteNonQuery() >0; 
               
            }
            catch (Exception ex)
            {
                string Message = ex.Message;

            }
            finally { connection.Close(); }
            return lastid;
        }
        static public int AddNew(int PersonID, DateTime date, int ApplicationTypeID, int ApplicationStatus, DateTime laststatusdate, double paidfees, int userid)
        {
            int lastid = 0;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = @"INSERT INTO [dbo].[Applications]
     VALUES
           (@ApplicantPersonID
           ,@ApplicationDate
           ,@ApplicationTypeID
           ,@ApplicationStatus
           ,@LastStatusDate
           ,@PaidFees
           ,@CreatedByUserID)"
                          + "\nselect SCOPE_IDENTITY()";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicantPersonID", PersonID);
            command.Parameters.AddWithValue("@ApplicationDate", date);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", laststatusdate);
            command.Parameters.AddWithValue("@PaidFees", paidfees);
            command.Parameters.AddWithValue("@CreatedByUserID", userid);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int ID))
                    lastid = ID;
                else
                    lastid = 0;
            }
            catch (Exception ex)
            {
                string Message = ex.Message;

            }
            finally { connection.Close(); }
            return lastid;
        }
        static public bool Find(int appID,ref int PersonID,ref DateTime date,ref int ApplicationTypeID,ref string ApplicationStatus,ref DateTime laststatusdate,ref double paidfees,ref int userid)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = @"SELECT        ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID, LastStatusDate, PaidFees, CreatedByUserID ,
CASE 
     When ApplicationStatus = 1 then 'NEW'
     When  ApplicationStatus = 2 then 'Cancel'
	 When ApplicationStatus = 3 then 'Completed'
	 end As ApplicationStatus
FROM            Applications
 WHERE ApplicationID = @ApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", appID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    userid = (int)reader["CreatedByUserID"];
                    date = Convert.ToDateTime(reader["ApplicationDate"]);
                    laststatusdate = Convert.ToDateTime(reader["LastStatusDate"]);
                    ApplicationTypeID = (int)reader["ApplicationTypeID"];
                    ApplicationStatus = Convert.ToString(reader["ApplicationStatus"]);
                    PersonID = (int)reader["ApplicantPersonID"];
                    paidfees = Convert.ToDouble(reader["PaidFees"]);
                    result = true;
                }
                reader.Close();
            }
            catch (Exception ex) {
              string message = ex.Message;
            }
            finally { connection.Close(); }
            return result;

        }
        static public bool Find(int appID, ref int PersonID, ref DateTime date, ref int ApplicationTypeID, ref int ApplicationStatus, ref DateTime laststatusdate, ref double paidfees, ref int userid)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = @"SELECT *FROM Applications WHERE Applications.ApplicationID = @ApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", appID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    userid = (int)reader["CreatedByUserID"];
                    date = Convert.ToDateTime(reader["ApplicationDate"]);
                    laststatusdate = Convert.ToDateTime(reader["LastStatusDate"]);
                    ApplicationTypeID = (int)reader["ApplicationTypeID"];
                    ApplicationStatus = Convert.ToInt32(reader["ApplicationStatus"]);
                    PersonID = (int)reader["ApplicantPersonID"];
                    paidfees = Convert.ToDouble(reader["PaidFees"]);
                    result = true;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            finally { connection.Close(); }
            return result;

        }
        static public bool Delete(int applicationID)
        {
            bool result = false;

            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = "DELETE Applications Where Applications.ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", applicationID);
            try
            {
                connection.Open();
                result = command.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return result;
        }

        static public bool UpdateTheStatus(int applicationID)
        {
            bool result = false; 
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = @"UPDATE [dbo].[Applications]
   SET 
      [ApplicationStatus] = 3
      
 WHERE Applications.ApplicationID = @ApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", applicationID);
            try
            {
                connection.Open();
                 result = command.ExecuteNonQuery()>0;
                
            }
            catch (Exception ex)
            {
                string Message = ex.Message;

            }
            finally { connection.Close(); }
            return result;
        }
        
    }
}
