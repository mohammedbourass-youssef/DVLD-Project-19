using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Tracing;

namespace DataAccessLAyer
{
    public class clsClassTypeDataAccess
    {
        static public DataTable GetAllClassTypeName()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = "SELECT ClassName FROM LicenseClasses";
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

        static public bool Find(ref int ID,  string Name)
        {
            bool res = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = "SELECT LicenseClassID FROM LicenseClasses WHERE ClassName = @ClassName";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClassName", Name);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    ID = (int)reader["LicenseClassID"];
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

        static public bool Find(int ID, ref string Name,ref string description,ref int MinAge,ref int ValidaateLength,ref double fees)
        {
            bool res = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = "SELECT * FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseClassID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Name = (string)reader["ClassName"];
                    description = (string)reader["ClassDescription"];
                    MinAge = Convert.ToInt32(reader["MinimumAllowedAge"]);
                    ValidaateLength = Convert.ToInt32(reader["DefaultValidityLength"].ToString());
                    fees = Convert.ToDouble(reader["ClassFees"]);
                    res = true;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                
              string Message = ex.ToString();
                Console.WriteLine(Message);
                
            }
            finally { connection.Close(); }
            return res;
        }
    }
}
