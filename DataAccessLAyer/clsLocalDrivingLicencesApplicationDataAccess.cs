using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLAyer
{
    public class clsLocalDrivingLicencesApplicationDataAccess
    {
        public static DataTable GetAllRcord()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = "\r\nSELECT ApplicationID, LocalDrivingLicenseApplicationID,ClassName, NationalNo, fullname,ApplicationDate, \r\n                        case \r\n\t\t\t\t\t\t   when  PassedTest is null then 0 \r\n\t\t\t\t\t\t   when PassedTest is not null then PassedTest \r\n\t\t\t\t\t\t   end As PassedTest\r\n\t\t\t\t\t\t ,Status\r\nFrom (SELECT        MyCurrentTable.ApplicationID, MyCurrentTable.LocalDrivingLicenseApplicationID, MyCurrentTable.ClassName, MyCurrentTable.NationalNo, MyCurrentTable.fullname, MyCurrentTable.ApplicationDate, \r\n                         the_GetallLocalDrabiveLicence.PassedTest, case \r\n\t\t\t\t\t\t                                                when MyCurrentTable.ApplicationStatus = 1 then 'New' \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\twhen MyCurrentTable.ApplicationStatus = 2 then 'Cancelled' \r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\twhen MyCurrentTable.ApplicationStatus = 3 then 'Completed'\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tEND AS Status\r\nFROM            the_GetallLocalDrabiveLicence  right outer JOIN\r\n                         MyCurrentTable ON the_GetallLocalDrabiveLicence.LocalDrivingLicenseApplicationID = MyCurrentTable.LocalDrivingLicenseApplicationID)r1\r\n";
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
        static public bool IsExist(int personID, int LicencesClassID)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = @"SELECT Found = 1 From (
SELECT        LocalDrivingLicenseApplications.LicenseClassID, Applications.ApplicantPersonID,Applications.ApplicationStatus
FROM            Applications INNER JOIN
                         LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID)r1
WHERE r1.ApplicantPersonID = @ApplicantPersonID and r1.LicenseClassID = @LicenseClassID and r1.ApplicationStatus = 1";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicantPersonID", personID);
            command.Parameters.AddWithValue("@LicenseClassID", LicencesClassID);
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

        static public int AddNewPerson(int applicationID, int LicencesClassID) { 
            int lastid = 0;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = @"INSERT INTO [dbo].[LocalDrivingLicenseApplications]
           
                                             VALUES
                                               (@ApplicationID
                                               ,@LicenseClassID)"
                                       + "\nselect SCOPE_IDENTITY()";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", applicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicencesClassID);
        
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

        static public bool Delete(int LocalDrivingID)
        {
            bool result = false;

            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = "DELETE LocalDrivingLicenseApplications Where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", LocalDrivingID);
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

        static public bool Find(int LocalDrivingLecencesID,ref int applicationID,ref int licenseClassID)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = @"Select *from LocalDrivingLicenseApplications Where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLecencesID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    applicationID = (int)reader["ApplicationID"];
                    licenseClassID = (int)reader["LicenseClassID"];
                    
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
