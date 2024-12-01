using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLAyer
{
    public  class clsTestDataAccess
    {
        static public int GetNumberOfTestPassed(int LocalDrivingLicenseID)
        {
            int result = 0;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = "SELECT testresult FROM thefilltertistreslt Where LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseID);
            try
            {
                connection.Open();
                object obj = command.ExecuteScalar();
                if (obj != null && int.TryParse(obj.ToString(), out int ID))
                    result = ID ;
                else 
                    result = 0;
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return result;
        }

        static public int AddNewTest(int testapoitementID,bool testresult,string notes,int userID)
        {
            int lastid = 0;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = @"INSERT INTO [dbo].[Tests]
     VALUES
           (@TestAppointmentID
           ,@TestResult
           ,@Notes
           ,@CreatedByUserID)"+ "\nselect SCOPE_IDENTITY()";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", testapoitementID);
            command.Parameters.AddWithValue("@TestResult", testresult);
            
            if (notes != string.Empty)
                command.Parameters.AddWithValue("@Notes", notes);
            else
                command.Parameters.AddWithValue("@Notes", DBNull.Value);
            command.Parameters.AddWithValue("@CreatedByUserID", userID);
            
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

        static public bool FindByTestApoitemetID(int testapoitementID,ref int testID ,ref bool testresult,ref string notes,ref int userID)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = @"SELECT *FROM Tests  Where Tests.TestAppointmentID = @TestAppointmentID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", testapoitementID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    testID = (int)reader["TestID"];
                    testresult = (bool)reader["TestResult"];
                    if (string.IsNullOrEmpty((string)reader["Notes"]))
                    {
                        notes = string.Empty;
                    }
                    else
                    {
                        notes = (string)reader["Notes"];
                    }
                    userID = (int)reader["CreatedByUserID"];
                    result = true;
                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return result;
        }



        static public bool FindByTestID(int testID, ref int testapoitementID , ref bool testresult, ref string notes, ref int userID)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = @"SELECT *FROM Tests  Where Tests.TestID = @TestAppointmentID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", testID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    testapoitementID = (int)reader["TestAppointmentID"];
                    testresult = (bool)reader["TestResult"];
                    if (string.IsNullOrEmpty((string)reader["Notes"]))
                    {
                        notes = string.Empty;
                    }
                    else
                    {
                        notes = (string)reader["Notes"];
                    }
                    userID = (int)reader["CreatedByUserID"];
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
