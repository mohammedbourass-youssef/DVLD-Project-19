using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLAyer
{
    public class clsLicenceDataAccess
    {
       
        static public DataTable Get()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = " SELECT *FROM Licenses";
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
        static public int AddNewLicense(int applicationID,int driverID,int licenseclassID,DateTime issuedate,DateTime expirationdate,string notes,double paidfees,bool isactive,byte issuereason,int userid)
        {
            //issue reason : 1-FirstTime, 2-Renew, 3-Replacement for Damaged, 4- Replacement for Lost.
            int lastid = 0;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = @"INSERT INTO [dbo].[Licenses]   
     VALUES
           (@ApplicationID
           ,@DriverID
           ,@LicenseClass
           ,@IssueDate
           ,@ExpirationDate
           ,@Notes
           ,@PaidFees
           ,@IsActive
           ,@IssueReason
           ,@CreatedByUserID)" + "\nselect SCOPE_IDENTITY()";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", applicationID);
            command.Parameters.AddWithValue("@DriverID", driverID);
            command.Parameters.AddWithValue("@LicenseClass", licenseclassID);
            command.Parameters.AddWithValue("@IsActive", isactive);
            if (notes != string.Empty)
                command.Parameters.AddWithValue("@Notes", notes);
            else
                command.Parameters.AddWithValue("@Notes", DBNull.Value);

            command.Parameters.AddWithValue("@IssueDate", issuedate);
            command.Parameters.AddWithValue("@ExpirationDate", expirationdate);
            command.Parameters.AddWithValue("@PaidFees", paidfees);
            command.Parameters.AddWithValue("@IssueReason", issuereason);
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

        static public bool  UpdateLicense(int licenseID,int applicationID, int driverID, int licenseclassID, DateTime issuedate, DateTime expirationdate, string notes, double paidfees, bool isactive, byte issuereason, int userid)
        {
            //issue reason : 1-FirstTime, 2-Renew, 3-Replacement for Damaged, 4- Replacement for Lost.
            bool result = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = @"UPDATE [dbo].[Licenses]
   SET [ApplicationID] = @ApplicationID
      ,[DriverID] = @DriverID
      ,[LicenseClass] = @LicenseClass
      ,[IssueDate] = @IssueDate
      ,[ExpirationDate] = @ExpirationDate
      ,[Notes] = @Notes
      ,[PaidFees] = @PaidFees
      ,[IsActive] = @IsActive
      ,[IssueReason] = @IssueReason
      ,[CreatedByUserID] = @CreatedByUserID
 WHERE Licenses.LicenseID = @LicenseID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", applicationID);
            command.Parameters.AddWithValue("@DriverID", driverID);
            command.Parameters.AddWithValue("@LicenseClass", licenseclassID);
            if (notes != string.Empty)
                command.Parameters.AddWithValue("@Notes", notes);
            else
                command.Parameters.AddWithValue("@Notes", DBNull.Value);

            command.Parameters.AddWithValue("@IssueDate", issuedate);
            command.Parameters.AddWithValue("@ExpirationDate", expirationdate);
            command.Parameters.AddWithValue("@PaidFees", paidfees);
            command.Parameters.AddWithValue("@IssueReason", issuereason);
            command.Parameters.AddWithValue("@CreatedByUserID", userid);
            command.Parameters.AddWithValue("@LicenseID", licenseID);
            command.Parameters.AddWithValue("@IsActive", isactive);
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

        static public bool IsThisPersonHasLicenseInThisClass(int personID,int licenseclassID)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = @"SELECT found = 1 From 
(SELECT        Applications.ApplicationID, Licenses.IsActive, Licenses.LicenseClass, Applications.ApplicantPersonID
FROM            Applications INNER JOIN
                         Licenses ON Applications.ApplicationID = Licenses.ApplicationID )R3
			    WHERE LicenseClass = @LicenseClass and ApplicantPersonID = @ApplicantPersonID and IsActive = 1";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseClass", licenseclassID);
            command.Parameters.AddWithValue("@ApplicantPersonID", personID);
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

        static public bool IsThisLecenseActive( int licenseID)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = @"Select IsActive from Licenses Where LicenseID = @LicenseID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", licenseID);
           
            try
            {
                connection.Open();
                object obj = command.ExecuteScalar();
                if (obj != null && bool.TryParse(obj.ToString(), out bool isactive))
                    result = isactive;
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return result;
        }


        static public bool Find(int licenseID, ref int applicationID, ref int driverID, ref int licenseclassID, ref DateTime issuedate, ref DateTime expirationdate, ref string notes, ref double paidfees, ref bool isactive, ref byte issuereason, ref int userid)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = @"Select *from Licenses WHERE Licenses.LicenseID = @LicenseID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", licenseID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    applicationID = (int)reader["ApplicationID"];
                    driverID = (int)reader["DriverID"];
                    licenseclassID = (int)reader["LicenseClass"];
                    issuedate = (DateTime)reader["IssueDate"];
                    expirationdate = (DateTime)reader["ExpirationDate"];
                    if (reader["Notes"] != DBNull.Value)
                        notes = (string)reader["Notes"];
                    else 
                        notes = string.Empty;
                    paidfees = Convert.ToDouble(reader["PaidFees"]);
                    isactive = (bool)reader["IsActive"];
                    issuereason = (byte)reader["IssueReason"];
                    userid = (int)reader["CreatedByUserID"];
                    result = true;
                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return result;
        }

        static public bool Find(int licenseID, ref int applicationID, ref int driverID,ref DateTime issuedate, ref DateTime expirationdate, ref string notes, ref double paidfees, ref bool isactive, ref byte issuereason, ref int userid)
        {
            //find only the driving license of Class 3 - Ordinary driving license
            bool result = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = @"Select *from Licenses WHERE Licenses.LicenseID = @LicenseID and LicenseClass = 3";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", licenseID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    applicationID = (int)reader["ApplicationID"];
                    driverID = (int)reader["DriverID"];
                  
                    issuedate = (DateTime)reader["IssueDate"];
                    expirationdate = (DateTime)reader["ExpirationDate"];
                    if (reader["Notes"] != DBNull.Value)
                        notes = (string)reader["Notes"];
                    else
                        notes = string.Empty;
                    paidfees = Convert.ToDouble(reader["PaidFees"]);
                    isactive = (bool)reader["IsActive"];
                    issuereason = (byte)reader["IssueReason"];
                    userid = (int)reader["CreatedByUserID"];
                    result = true;
                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return result;
        }

        static public bool FindByApplicationID(int  applicationID, ref int licenseID, ref int driverID, ref int licenseclassID, ref DateTime issuedate, ref DateTime expirationdate, ref string notes, ref double paidfees, ref bool isactive, ref byte issuereason, ref int userid)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = @"Select *from Licenses WHERE Licenses.ApplicationID = @applicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@applicationID", applicationID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    licenseID = (int)reader["LicenseID"];
                    driverID = (int)reader["DriverID"];
                    licenseclassID = (int)reader["LicenseClass"];
                    issuedate = (DateTime)reader["IssueDate"];
                    expirationdate = (DateTime)reader["ExpirationDate"];
                    if (reader["Notes"] != DBNull.Value)
                        notes = (string)reader["Notes"];
                    else
                        notes = string.Empty;
                    paidfees = Convert.ToDouble(reader["PaidFees"]);
                    isactive = (bool)reader["IsActive"];
                    issuereason = (byte)reader["IssueReason"];
                    userid = (int)reader["CreatedByUserID"];
                    result = true;
                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return result;
        }

        static public DataTable Get(int driverID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = @"Select  LicenseID ,ApplicationID,ClassName,IssueDate,ExpirationDate,IsActive from 
 ( SELECT  DriverID,      Licenses.LicenseID, Licenses.ApplicationID, LicenseClasses.ClassName, Licenses.IssueDate, Licenses.ExpirationDate, Licenses.IsActive
FROM            Licenses INNER JOIN
                         LicenseClasses ON Licenses.LicenseClass = LicenseClasses.LicenseClassID )r1
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
                string msg = ex.Message;    
            }
            finally { connection.Close(); }
            return dt;
        }


    }
}
