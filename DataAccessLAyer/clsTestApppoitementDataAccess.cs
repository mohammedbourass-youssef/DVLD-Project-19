using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLAyer
{
    public class clsTestApppoitementDataAccess
    {
        static public bool IsExist(int LocalDrivinfLicense , int TesttypeID)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = "SELECT found = 1FROM TestAppointments WHERE TestTypeID = @TestTypeID and LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID and IsLocked = 0 ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivinfLicense);
            command.Parameters.AddWithValue("@TestTypeID", TesttypeID);
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
        static public bool AlreadyPassedThisTest(int LocalDrivinfLicense , int TesttypeID)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = "SELECT found = 1FROM Tests inner join \r\n(SELECT *FROM TestAppointments WHERE TestTypeID = @TestTypeID and LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID and IsLocked = 1)r1\r\non Tests.TestAppointmentID = r1.TestAppointmentID\r\nWhere TestResult = 1";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivinfLicense);
            command.Parameters.AddWithValue("@TestTypeID", TesttypeID);
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
        static public bool GetApoitementOfLastApoitementNonPAssed(int LocalDrivinfLicense, int TesttypeID)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = @"SELECT *  FROM TestAppointments WHERE TestTypeID = @TestTypeID and LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID and IsLocked = 1 and RetakeTestApplicationID is null";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivinfLicense);
            command.Parameters.AddWithValue("@TestTypeID", TesttypeID);
            try
            {
                
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return result;
        }
        static public DataTable GetRecordOfSpecialTestAndLocalDrivingLicense(int LocalDrLicID,int TestTypeID)
        {
            DataTable db = new DataTable();
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = @"SELECT        TestAppointmentID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, IsLocked
FROM            TestAppointments WHERE LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID  and TestTypeID  = @TestTypeID";
           

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrLicID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    db.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            finally { connection.Close(); }
            return db;
        }
        static public int Create(int testtypeID,int LocalDrivingLicenseApplicationID,DateTime AppointmentDate,double PaidFees,int CreatedByUserID,bool IsLocked)
        {
            int lastid = 0;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = @"INSERT INTO [dbo].[TestAppointments]
                       VALUES
                            (@TestTypeID
                            ,@LocalDrivingLicenseApplicationID
                            ,@AppointmentDate
                            ,@PaidFees
                            ,@CreatedByUserID
                            ,@IsLocked
                            ,@RetakeTestApplicationID)" + "\nselect SCOPE_IDENTITY()";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@TestTypeID", testtypeID);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            cmd.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            cmd.Parameters.AddWithValue("@IsLocked", IsLocked);
            cmd.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);

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
               string message = ex.Message;
            }
            finally { connection.Close(); }
            return lastid;
        }

        static public bool LockedTheTest(int TestApoitementID)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = @"UPDATE [dbo].[TestAppointments]
                                 SET 
                                [IsLocked] = 1
                                WHERE TestAppointmentID = @TestAppointmentID ";
            SqlCommand cmd = new SqlCommand(query, connection);

            
            cmd.Parameters.AddWithValue("@TestAppointmentID", TestApoitementID);
            try
            {
                connection.Open();
                result = cmd.ExecuteNonQuery() > 0;

            }
            catch (Exception ex)
            {
                string msg = ex.Message;    
            }
            finally { connection.Close(); }
            return result;
        }

        static public bool UpdateDate(int TestApoitementID, DateTime AppointmentDate)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = @"UPDATE [dbo].[TestAppointments]
                                 SET 
                                [AppointmentDate] = @AppointmentDate
                                WHERE TestAppointmentID = @TestAppointmentID ";
            SqlCommand cmd = new SqlCommand(query, connection);
            
            cmd.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            cmd.Parameters.AddWithValue("@TestAppointmentID", TestApoitementID);
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
        static public bool RetakeTest(int TestApoitementID, int NewTestApoitementID)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = @"UPDATE [dbo].[TestAppointments]
                                 SET 
                                [RetakeTestApplicationID] = @RetakeTestApplicationID
                                WHERE TestAppointmentID = @TestAppointmentID ";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@RetakeTestApplicationID", NewTestApoitementID);
            cmd.Parameters.AddWithValue("@TestAppointmentID", TestApoitementID);
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
       
        static public bool FindFailledTestAndNonRetakeYet(int LocalDrivingLicenseApplicationID,ref int testApoitementID ,ref int testtypeID,ref DateTime AppointmentDate,ref double PaidFees,ref int CreatedByUserID)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = @"SELECT        Tests.TestResult, TestAppointments.*
FROM            TestAppointments INNER JOIN
                         Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
WHERE 
TestAppointments.IsLocked = 1 and TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID and RetakeTestApplicationID is null";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    testtypeID = (int)reader["TestTypeID"];
                    testApoitementID = (int)reader["TestAppointmentID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = Convert.ToDouble(reader["PaidFees"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                   
                    result = true;
                }
                reader.Close();
            }
            catch (Exception ex) {
                string msg = ex.Message;
            
            }
            finally { connection.Close(); }
            return result;
        }

        static public bool Find(  int testApoitementID, ref int testtypeID,ref int LocalDrivingLicenseApplicationID, ref DateTime AppointmentDate, ref double PaidFees,ref int retaketestapplicationID, ref bool Islocked ,ref int CreatedByUserID)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = @"SELECT *FROM TestAppointments Where TestAppointmentID =@TestAppointmentID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", testApoitementID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    testtypeID = (int)reader["TestTypeID"];
                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = Convert.ToDouble(reader["PaidFees"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                   
                    if(reader["RetakeTestApplicationID"] != DBNull.Value)
                    {
                        retaketestapplicationID = (int)reader["RetakeTestApplicationID"];
                    }
                    else
                    {
                        retaketestapplicationID = -1;
                    }
                    Islocked = (bool)reader["IsLocked"];
                    result = true;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;

            }
            finally { connection.Close(); }
            return result;
        }
    }


}
