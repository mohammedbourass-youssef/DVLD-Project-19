using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLAyer
{
    public class clsPeopleDataAccess
    {
        static public int AddNewPerson(string nationalNO ,string firstname,string secondname,string thirdname,string lastname,DateTime dateofbirth,byte gender,string address,string phone,string email,int countryID,string imagepath)
        {
            int lastid = 0;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = @"INSERT INTO [dbo].[People]
                                         ([NationalNo]
                                         ,[FirstName]
                                         ,[SecondName]
                                         ,[ThirdName]
                                         ,[LastName]
                                         ,[DateOfBirth]
                                         ,[Gendor]
                                         ,[Address]
                                         ,[Phone]
                                         ,[Email]
                                         ,[NationalityCountryID]
                                         ,[ImagePath])
                                   VALUES
                                         (@NationalNo
                                         ,@FirstName
                                         ,@SecondName
                                         ,@ThirdName
                                         ,@LastName
                                         ,@DateOfBirth
                                         ,@Gendor
                                         ,@Address
                                         ,@Phone
                                         ,@Email
                                         ,@NationalityCountryID
                                         ,@ImagePath)" 
                                       + "\nselect SCOPE_IDENTITY()";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", nationalNO);
            command.Parameters.AddWithValue("@FirstName", firstname);
            command.Parameters.AddWithValue("@SecondName", secondname);
            if(thirdname != string.Empty)
                command.Parameters.AddWithValue("@ThirdName", thirdname);
            else
                command.Parameters.AddWithValue("@ThirdName",DBNull.Value);
            command.Parameters.AddWithValue("@LastName", lastname);
            command.Parameters.AddWithValue("@DateOfBirth", dateofbirth);
            command.Parameters.AddWithValue("@Gendor", gender);
            command.Parameters.AddWithValue("@Address", address);
            command.Parameters.AddWithValue("@Phone", phone);
            if(email != string.Empty)
                command.Parameters.AddWithValue("@Email", email);
            else
                command.Parameters.AddWithValue("@Email", DBNull.Value);
            command.Parameters.AddWithValue("@NationalityCountryID", countryID);
            if(imagepath != string.Empty)
                command.Parameters.AddWithValue("@ImagePath", imagepath);
            else
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int ID))
                    lastid = ID;
                else
                    lastid = 0;
            }
            catch (Exception ex){
                string Message  = ex.Message;
             
            }
            finally {connection.Close();}
            return lastid;
        }
       
        static public DataTable GetPeopleList()
        {
            DataTable db = new DataTable();
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = "SELECT *FROM People";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    db.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                  
            }
            finally { connection.Close(); }
            return db;
        }

        static public DataTable GetPeopleListWithCountryName()
        {
            DataTable db = new DataTable();
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = "SELECT        People.PersonID, People.NationalNo, People.FirstName, People.SecondName, People.ThirdName, People.LastName, People.DateOfBirth,  CASE People.Gendor When 0 then 'Male' When 1 then 'Female' end as gender , People.Address, People.Phone, People.Email, \r\n                         Countries.CountryName\r\nFROM            Countries INNER JOIN\r\n                         People ON Countries.CountryID = People.NationalityCountryID";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    db.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }
            return db;
        }

        static public bool Delete(int personID)
        {
            bool result = false;
            
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = "DELETE  People WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", personID);
            try
            {
                connection.Open();
                result = command.ExecuteNonQuery()>0;
            }
            catch (Exception ex)
            {
                
            }
            finally { connection.Close(); }
            return result;
        }
        static public bool Update(int personid , string nationalNO, string firstname, string secondname, string thirdname, string lastname, DateTime dateofbirth, byte gender, string address, string phone, string email, int countryID, string imagepath)
        {
           bool result = false; 
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = @"UPDATE [dbo].[People]
                                      SET [NationalNo] =@NationalNo
                                         ,[FirstName] = @FirstName
                                         ,[SecondName] = @SecondName
                                         ,[ThirdName] = @ThirdName
                                         ,[LastName] = @LastName
                                         ,[DateOfBirth] =@DateOfBirth
                                         ,[Gendor] =@Gendor
                                         ,[Address] =@Address
                                         ,[Phone] =@Phone
                                         ,[Email] =@Email
                                         ,[NationalityCountryID] = @NationalityCountryID
                                         ,[ImagePath] =@ImagePath
                                    WHERE PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", personid);
            command.Parameters.AddWithValue("@NationalNo", nationalNO);
            command.Parameters.AddWithValue("@FirstName", firstname);
            command.Parameters.AddWithValue("@SecondName", secondname);
            if (thirdname != string.Empty)
                command.Parameters.AddWithValue("@ThirdName", thirdname);
            else
                command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
            command.Parameters.AddWithValue("@LastName", lastname);
            command.Parameters.AddWithValue("@DateOfBirth", dateofbirth);
            command.Parameters.AddWithValue("@Gendor", gender);
            command.Parameters.AddWithValue("@Address", address);
            command.Parameters.AddWithValue("@Phone", phone);
            if (email != string.Empty)
                command.Parameters.AddWithValue("@Email", email);
            else
                command.Parameters.AddWithValue("@Email", DBNull.Value);
            command.Parameters.AddWithValue("@NationalityCountryID", countryID);
            if (imagepath != string.Empty)
                command.Parameters.AddWithValue("@ImagePath", imagepath);
            else
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
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

        static public bool IsExist(int personid)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = "Select found = 1 from People Where PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", personid);
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

        static public bool IsExistByNationnalNumber(string natonnalNo)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = "Select found = 1 from People Where NationalNo = @NationalNo";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", natonnalNo);
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

        static public bool Find(int personid,ref string nationalNO,ref string firstname,ref string secondname,ref string thirdname,ref string lastname,ref DateTime dateofbirth,ref byte gender,ref string address,ref string phone,ref string email,ref int countryID,ref string imagepath)
        {
            bool result = false;    
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = "Select *from People Where PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", personid);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = true;
                    nationalNO = (string)reader["NationalNo"];
                    firstname = (string)reader["FirstName"];
                    secondname = (string)reader["SecondName"];
                    if (reader["ThirdName"] != DBNull.Value)
                        thirdname = (string)reader["ThirdName"];
                    else
                        thirdname = string.Empty;
                    lastname = (string)reader["LastName"];
                    dateofbirth = (DateTime)reader["DateOfBirth"];
                    gender = (byte)reader["Gendor"];
                    address = (string)reader["Address"];
                    phone = (string)reader["Phone"];
                    if (reader["Email"] != DBNull.Value)
                        email = (string)reader["Email"];
                    else
                        email = string.Empty;
                    countryID = (int)reader["NationalityCountryID"];
                    if (reader["ImagePath"] != DBNull.Value)
                        imagepath = (string)reader["ImagePath"];
                    else
                        imagepath = string.Empty;
                }
                else
                    result = false;
                reader.Close();

            }
            catch (Exception ex)
            {

            }
            finally {connection.Close(); }
            return result;
        }

        static public bool Find(string nationalNO, ref int personid, ref string firstname, ref string secondname, ref string thirdname, ref string lastname, ref DateTime dateofbirth, ref byte gender, ref string address, ref string phone, ref string email, ref int countryID, ref string imagepath)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = "Select *from People Where NationalNo = @NationalNo";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", nationalNO);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = true;
                    personid = (int)reader["PersonID"];
                    firstname = (string)reader["FirstName"];
                    secondname = (string)reader["SecondName"];
                    if (reader["ThirdName"] != DBNull.Value)
                        thirdname = (string)reader["ThirdName"];
                    else
                        thirdname = string.Empty;
                    lastname = (string)reader["LastName"];
                    dateofbirth = (DateTime)reader["DateOfBirth"];
                    gender = (byte)reader["Gendor"];
                    address = (string)reader["Address"];
                    phone = (string)reader["Phone"];
                    if (reader["Email"] != DBNull.Value)
                        email = (string)reader["Email"];
                    else
                        email = string.Empty;
                    countryID = (int)reader["NationalityCountryID"];
                    if (reader["ImagePath"] != DBNull.Value)
                        imagepath = (string)reader["ImagePath"];
                    else
                        imagepath = string.Empty;
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

        static public bool Find(string lastname, ref string nationalNO, ref int personid, ref string secondname, ref string thirdname, ref string firstname, ref DateTime dateofbirth, ref byte gender, ref string address, ref string phone, ref string email, ref int countryID, ref string imagepath)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionWay);
            string query = "Select *from People Where LastName = @LastName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LastName", lastname);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = true;
                    firstname = (string)reader["FirstName"];
                    nationalNO = (string)reader["NationalNo"];
                    personid = (int)reader["PersonID"];
                    secondname = (string)reader["SecondName"];
                    if (reader["ThirdName"] != DBNull.Value)
                        thirdname = (string)reader["ThirdName"];
                    else
                        thirdname = string.Empty;
                    
                    dateofbirth = (DateTime)reader["DateOfBirth"];
                    gender = (byte)reader["Gendor"];
                    address = (string)reader["Address"];
                    phone = (string)reader["Phone"];
                    if (reader["Email"] != DBNull.Value)
                        email = (string)reader["Email"];
                    else
                        email = string.Empty;
                    countryID = (int)reader["NationalityCountryID"];
                    if (reader["ImagePath"] != DBNull.Value)
                        imagepath = (string)reader["ImagePath"];
                    else
                        imagepath = string.Empty;
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