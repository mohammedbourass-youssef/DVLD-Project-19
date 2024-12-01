using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLAyer
{
    public class ClsCountriesDataAccess
    {
        static public DataTable GetAllCountries()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = "SELECT *\r\n  FROM [dbo].[Countries] Order By CountryName ASC";
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
 

        static public bool FindById(int ID, ref string Name)
        {
            bool res = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = "SELECT *\r\n  FROM Countries\r\n  Where Countries.CountryID = @ID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    Name = (string)reader["CountryName"];
                    res = true;
                }


                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                res = false;
            }
            finally { connection.Close(); }
            return res;
        }

        static public bool FindByName(ref int ID, string Name)
        {
            bool res = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = "Select CountryID from Countries Where CountryName = @ID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", Name);

            try
            {
                connection.Open();
               object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int nID))
                {
                    ID = nID;
                    res = true;
                }
                    
                else
                    ID = 0;


      
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                res = false;
            }
            finally { connection.Close(); }
            return res;
        }

    }
}
