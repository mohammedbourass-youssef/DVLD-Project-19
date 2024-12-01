using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLAyer
{
    public class clsTestTypesDataAccess
    {
        static public DataTable GetApplicationstypes()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = "SELECT *FROM [dbo].[TestTypes]";
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

        static public bool Update(int testtypeID,  string title,  string desription,  double fees)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = @"UPDATE [dbo].[TestTypes]
                                SET [TestTypeTitle] = @TestTypeTitle
                                   ,[TestTypeDescription] = @TestTypeDescription
                                   ,[TestTypeFees] = @TestTypeFees
                                WHERE testtypeID = @testtypeID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@testtypeID", testtypeID);
            command.Parameters.AddWithValue("@TestTypeTitle", title);
            command.Parameters.AddWithValue("@TestTypeDescription", desription);
            command.Parameters.AddWithValue("@TestTypeFees", fees);

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

        static public bool Find(int testtypeID, ref string title,ref string desription,ref double fees)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = "Select *from [dbo].[TestTypes] WHERE TestTypeID = @TestTypeID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID", testtypeID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = true;
                    title = (string)reader["TestTypeTitle"];
                    desription = (string)reader["TestTypeDescription"];
                    fees = Convert.ToDouble(reader["TestTypeFees"]);

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
