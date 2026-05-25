using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class PeopleDataAccess
    {
        public static bool Find(
            int personID, 
            ref string firstname, 
            ref string secondname,
            ref string thirdname,
            ref string lastname,
            ref byte gender,
            ref string address,
            ref string nationalNumber
        )
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT * FROM People WHERE PersonID = @PersonID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", personID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                firstname = reader["Firstname"].ToString();
                                secondname = reader["Secondname"].ToString();
                                thirdname = reader["Thirdname"]?.ToString();
                                lastname = reader["Lastname"].ToString();
                                gender = Convert.ToByte(reader["Gender"]);
                                address = reader["Address"].ToString();
                                nationalNumber = reader["NationalNumber"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return isFound;
        }

        public static bool FindByNationalNumber(
            string nationalNo,
            ref int personID,
            ref string firstname,
            ref string secondname,
            ref string thirdname,
            ref string lastname,
            ref byte gender,
            ref string address,
            ref string nationalNumber
        )
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT * FROM People WHERE NationalNo = @NationalNo";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NationalNo", nationalNo);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                personID = (int)reader["PersonID"];
                                firstname = reader["Firstname"].ToString();
                                secondname = reader["Secondname"].ToString();
                                thirdname = reader["Thirdname"]?.ToString();
                                lastname = reader["Lastname"].ToString();
                                gender = Convert.ToByte(reader["Gender"]);
                                address = reader["Address"].ToString();
                                nationalNumber = reader["NationalNo"].ToString();
                            }
                        }
                    }
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return isFound;
        }

        public static int? AddPerson(
            string firstname,
            string secondname,
            string thirdname,
            string lastname,
            byte gender,
            string address,
            string nationalNo
        )
        {
            int? id = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"INSERT INTO [dbo].[People]
                           ([Firstname]
                           ,[Secondname]
                           ,[Thirdname]
                           ,[Lastname]
                           ,[Gender]
                           ,[Address]
                           ,[NationalNo])
                     VALUES
                           (@Firstname
                           ,@Secondname
                           ,@Thirdname
                           ,@Lastname
                           ,@Gender
                           ,@Address
                           ,@NationalNo); SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Firstname", firstname);
                        command.Parameters.AddWithValue("@Secondname", secondname);

                        if (string.IsNullOrEmpty(thirdname))
                        {
                            command.Parameters.AddWithValue("@Thirdname", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Thirdname", thirdname);
                        }

                        command.Parameters.AddWithValue("@Lastname", lastname);
                        command.Parameters.AddWithValue("@Gender", gender);
                        command.Parameters.AddWithValue("@Address", address);
                        command.Parameters.AddWithValue("@NationalNo", nationalNo);

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedId))
                        {
                            id = insertedId;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return id;
        }

        public static bool UpdatePerson(
            int? personId,
            string firstname,
            string secondname,
            string thirdname,
            string lastname,
            byte gender,
            string address
        )
        {
            int rowsAffected = 0;

            if (personId == null)
            {
                return false;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"UPDATE [dbo].[People]
                       SET [Firstname] = @Firstname
                          ,[Secondname] = @Secondname
                          ,[Thirdname] = @Thirdname
                          ,[Lastname] = @Lastname
                          ,[Gender] = @Gender
                          ,[Address] = @Address
                    WHERE PersonID = @PersonID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", personId);
                        command.Parameters.AddWithValue("@Firstname", firstname);
                        command.Parameters.AddWithValue("@Secondname", secondname);

                        if (string.IsNullOrEmpty(thirdname))
                        {
                            command.Parameters.AddWithValue("@Thirdname", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Thirdname", thirdname);
                        }

                        command.Parameters.AddWithValue("@Lastname", lastname);
                        command.Parameters.AddWithValue("@Gender", gender);
                        command.Parameters.AddWithValue("@Address", address);

                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            return rowsAffected > 0;
        }

        public static bool IsCustomer(int? personID)
        {
            if (!personID.HasValue)
            {
                return false;
            }

            bool isCustomer = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT true=1 FROM People P 
                    INNER JOIN Customers C ON P.PersonID = C.PersonID
                    WHERE P.PersonID = @PersonID;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", personID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            isCustomer = reader.HasRows;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return isCustomer;
        }
    }
}
