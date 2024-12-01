using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Security.Policy;

namespace DataAccessLAyer
{
    public class clsApplicationsTypeDataAccess
    {
        static public DataTable GetApplicationstypes()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = "SELECT *FROM [dbo].[ApplicationTypes]";
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

        static public bool Update(int apptypesID,string name,double fees)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = @"UPDATE [dbo].[ApplicationTypes]
                                SET [ApplicationTypeTitle] = @ApplicationTypeTitle
                                    ,[ApplicationFees] = @ApplicationFees
                                WHERE ApplicationTypeID =@ApplicationTypeID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationTypeID", apptypesID);
            command.Parameters.AddWithValue("@ApplicationTypeTitle", name);
            command.Parameters.AddWithValue("@ApplicationFees", fees);
            
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
        
       
        static public bool Find(int apptypesID,ref string name,ref double fees)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = "SELECT *FROM [dbo].[ApplicationTypes]  WHERE ApplicationTypeID =@ApplicationTypeID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationTypeID", apptypesID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = true;
                    name = (string)reader["ApplicationTypeTitle"];
                    fees = Convert.ToDouble(reader["ApplicationFees"]);
                    
                }
                else
                   result = false;
                reader.Close();

            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return result;
        }
    }
}
