using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace DataAccessLAyer
{
    public  class clsInternationnalLicenseDataAccess
    {
        static public int AddNewLice(int applicationID,int driverID,int localdrivinglicensID,DateTime issueDae,DateTime expirationDate, bool isactive,int userID)
        {
            int lastid = 0;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
             string query = @"INSERT INTO [dbo].[InternationalLicenses]
                                        VALUES
                                        (@ApplicationID
                                        ,@DriverID
                                        ,@IssuedUsingLocalLicenseID
                                        ,@IssueDate
                                        ,@ExpirationDate
                                        ,@IsActive
                                        ,@CreatedByUserID)"
                                       + "\nselect SCOPE_IDENTITY()";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", applicationID);
            command.Parameters.AddWithValue("@DriverID", driverID);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", localdrivinglicensID);
            command.Parameters.AddWithValue("@IssueDate", issueDae);
            command.Parameters.AddWithValue("@ExpirationDate",expirationDate );
            command.Parameters.AddWithValue("@IsActive", isactive);
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
        static public bool Find(int internationnalLicaenseID,ref int applicationID,ref int driverID,ref int localdrivinglicensID,ref DateTime issueDae,ref DateTime expirationDate,ref bool isactive,ref int userID)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = @"SELECT *From InternationalLicenses Where InternationalLicenseID =  @InternationalLicenseID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@InternationalLicenseID", internationnalLicaenseID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    applicationID = (int)reader["ApplicationID"];
                    driverID = (int)reader["DriverID"];
                    localdrivinglicensID = (int)reader["IssuedUsingLocalLicenseID"];
                    issueDae = (DateTime)reader["IssueDate"];
                    expirationDate = (DateTime)reader["ExpirationDate"];
                    isactive = (bool)reader["IsActive"];
                    userID = (int)reader["CreatedByUserID"];
                    result = true;
                }
                reader.Close();
            }
            catch (Exception ex) 
            {
                string msj = ex.Message;    
            }
            finally { connection.Close(); }
            return result;
        }

        static public bool IsExist(int driverID)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = @"SELECT found = 1 FROM InternationalLicenses WHERE DriverID = @DriverID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", driverID);
           
            try
            {
                connection.Open();
                object obj = command.ExecuteScalar();
                if (obj != null && int.TryParse(obj.ToString(), out int ID))
                    result = ID == 1;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            finally { connection.Close(); }
            return result;
        }
        static public DataTable Get(int driverID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = @"SELECT        InternationalLicenseID, ApplicationID, IssueDate, ExpirationDate, IsActive
FROM            InternationalLicenses
Where DriverID = @DriverID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", driverID);
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

        static public DataTable GetAllInternationnalDrivingLicens()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = "SELECT  InternationalLicenseID as Inter_Li_ID, ApplicationID as App_ID, DriverID, IssuedUsingLocalLicenseID as Lo_LicenseID, IssueDate as Issue_Date,ExpirationDate as  Expiration_Date,IsActive as Is_Active\r\nFROM            InternationalLicenses";
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
    }


}
