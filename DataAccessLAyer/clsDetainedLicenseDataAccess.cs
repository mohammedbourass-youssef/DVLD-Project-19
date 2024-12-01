using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLAyer
{
    public class clsDetainedLicenseDataAccess
    {
        static public bool IsLicenseDetained(int licenseID)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = @"SELECT found = 1 FROM DetainedLicenses WHERE DetainedLicenses.LicenseID = @LicenseID and DetainedLicenses.IsReleased = 0 ; ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", licenseID);
            
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

        static public int Create(int licenseID,DateTime detainDate , double finefess , int userID)
        {
            int lastid = 0;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = @"INSERT INTO [dbo].[DetainedLicenses]
     VALUES
           (@LicenseID
           ,@DetainDate
           ,@FineFees
           ,@CreatedByUserID
           ,0
           ,null
           ,null
           ,null)"+ "select SCOPE_IDENTITY()";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@LicenseID", licenseID);
            cmd.Parameters.AddWithValue("@DetainDate", detainDate);
            cmd.Parameters.AddWithValue("@FineFees", finefess);
            cmd.Parameters.AddWithValue("@CreatedByUserID", userID);
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

        static public bool Update(int detainId ,int licenseID, DateTime detainDate, double finefess, int userID,bool isrealsed,DateTime realeaseDate,int realeasebyUserID,int realeaseapplicationID)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = @"UPDATE [dbo].[DetainedLicenses]
                            SET [LicenseID] = @LicenseID
                               ,[DetainDate] = @DetainDate
                               ,[FineFees] = @FineFees
                               ,[CreatedByUserID] = @CreatedByUserID
                               ,[IsReleased] =  @IsReleased
                               ,[ReleaseDate] = @ReleaseDate
                               ,[ReleasedByUserID] = @ReleasedByUserID
                               ,[ReleaseApplicationID] = @ReleaseApplicationID
                            WHERE DetainID= @DetainID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@DetainID", detainId);
            cmd.Parameters.AddWithValue("@LicenseID", licenseID);
            cmd.Parameters.AddWithValue("@DetainDate", detainDate);
            cmd.Parameters.AddWithValue("@FineFees", finefess);
            cmd.Parameters.AddWithValue("@CreatedByUserID", userID);
            cmd.Parameters.AddWithValue("@IsReleased", isrealsed);
            cmd.Parameters.AddWithValue("@ReleaseDate",realeaseDate );
            cmd.Parameters.AddWithValue("@ReleasedByUserID",realeasebyUserID );
            cmd.Parameters.AddWithValue("@ReleaseApplicationID",realeaseapplicationID );
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

        static public DataTable GetCustomAllRecords()
        {
           DataTable dt = new DataTable();
           SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
           string query = @"SELECT        DetainedLicenses.DetainID as D_ID, DetainedLicenses.LicenseID L_ID, DetainedLicenses.DetainDate as Detain_Date, DetainedLicenses.IsReleased as Is_Released, DetainedLicenses.FineFees as Fine_Fees, DetainedLicenses.ReleaseDate as Release_Date, People.NationalNo as Na_No
,Case 
     When People.ThirdName is null then People.FirstName + People.SecondName + People.LastName
	 when People.ThirdName is not null then People.FirstName + People.SecondName +People.ThirdName + People.LastName
	 end as full_name

,DetainedLicenses.ReleaseApplicationID
FROM            DetainedLicenses INNER JOIN
                         Licenses ON DetainedLicenses.LicenseID = Licenses.LicenseID INNER JOIN
                         Drivers ON Licenses.DriverID = Drivers.DriverID INNER JOIN
                         People ON Drivers.PersonID = People.PersonID";
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

        static public bool FindByLicenseID(int licenseID,ref int detainId,ref DateTime detainDate,ref double finefess, ref int userID,ref bool isrealsed,ref DateTime realeaseDate,ref int realeasebyUserID,ref int realeaseapplicationID)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = @"Select * from DetainedLicenses where LicenseID = @LicenseID and IsReleased = 0";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", licenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    detainId = Convert.ToInt32(reader["DetainID"]);
                    detainDate = Convert.ToDateTime(reader["DetainDate"]);
                    finefess = Convert.ToDouble(reader["FineFees"]);
                    userID = Convert.ToInt32(reader["CreatedByUserID"]);
                    isrealsed = Convert.ToBoolean(reader["IsReleased"]);

                    realeaseDate = reader["ReleaseDate"] != DBNull.Value
                        ? Convert.ToDateTime(reader["ReleaseDate"])
                        : DateTime.MinValue;

                    realeasebyUserID = reader["ReleasedByUserID"] != DBNull.Value
                        ? Convert.ToInt32(reader["ReleasedByUserID"])
                        : 0;

                    realeaseapplicationID = reader["ReleaseApplicationID"] != DBNull.Value
                        ? Convert.ToInt32(reader["ReleaseApplicationID"])
                        : 0;

                    result = true;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return result;

        }



        static public bool Find(ref int licenseID, int detainId, ref DateTime detainDate, ref double finefess, ref int userID, ref bool isrealsed, ref DateTime realeaseDate, ref int realeasebyUserID, ref int realeaseapplicationID)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = @"Select * from DetainedLicenses where DetainID = @LicenseID and IsReleased = 0";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DetainID", detainId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    licenseID = Convert.ToInt32(reader["LicenseID"]);
                    detainDate = Convert.ToDateTime(reader["DetainDate"]);
                    finefess = Convert.ToDouble(reader["FineFees"]);
                    userID = Convert.ToInt32(reader["CreatedByUserID"]);
                    isrealsed = Convert.ToBoolean(reader["IsReleased"]);

                    realeaseDate = reader["ReleaseDate"] != DBNull.Value
                        ? Convert.ToDateTime(reader["ReleaseDate"])
                        : DateTime.MinValue;

                    realeasebyUserID = reader["ReleasedByUserID"] != DBNull.Value
                        ? Convert.ToInt32(reader["ReleasedByUserID"])
                        : 0;

                    realeaseapplicationID = reader["ReleaseApplicationID"] != DBNull.Value
                        ? Convert.ToInt32(reader["ReleaseApplicationID"])
                        : 0;

                    result = true;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return result;

        }
    }
}
