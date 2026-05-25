using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UsersDataAccess
    {
        public static DataTable FindUsers(int pageNumber = 1, int rowsPerPage = 10)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT * FROM Users
                    WHERE Active = 1
                    ORDER BY UserID
                    OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
                    FETCH NEXT @RowsPerPage ROWS ONLY";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PageNumber", pageNumber);
                        command.Parameters.AddWithValue("@RowsPerPage", rowsPerPage);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return dt;
        }

        public static bool Find(int? userID, ref string username, ref string passwordHash, ref bool isActive, ref int? personID, ref int? roleID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                connection.Open();

                string query = @"SELECT * FROM Users WHERE UserID = @UserID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;
                            username = reader["Username"].ToString();
                            passwordHash = reader["PasswordHash"].ToString();
                            isActive = Convert.ToBoolean(reader["Active"]);
                            roleID = (int)reader["RoleID"];
                            personID = (int)reader["PersonID"];
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

        public static bool FindByUsernameAndPassword(
            string username, 
            string passwordHash, 
            ref int? userID, 
            ref bool isActive, 
            ref int? personID,
            ref int? roleID
        )
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                connection.Open();

                string query = @"SELECT * FROM Users WHERE Username = @Username AND PasswordHash = @PasswordHash";
            
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@PasswordHash", passwordHash);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;
                            isActive = Convert.ToBoolean(reader["Active"]);
                            userID = (int)reader["UserID"];
                            roleID = (int)reader["RoleID"];
                            personID = (int)reader["PersonID"];
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

        public static int? CreateUser(
            string username, 
            string passwordHash, 
            int? personId
        )
        {
            int? id = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"INSERT INTO [dbo].[Users]
                       ([Username]
                       ,[PasswordHash]
                       ,[PersonID]
                       ,[Active])
                    VALUES
                       (@Username
                       ,@PasswordHash
                       ,@PersonID
                       ,1); SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@PasswordHash", passwordHash);

                        if (personId != null)
                        {
                            command.Parameters.AddWithValue("@PersonID", personId);
                        }

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

        public static bool UpdateUser(
            int? userID,
            string username,
            string passwordHash,
            int? personId,
            bool active
        )
        {
            int rowsAffected = 0;

            if (userID == null)
            {
                return false;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"UPDATE [dbo].[Users]
                       SET [Username] = @Username
                          ,[PasswordHash] = @PasswordHash
                          ,[PersonID] = @PersonID
                          ,[Active] = @Active
                    WHERE UserID = @UserID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", userID);
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@PasswordHash", passwordHash);
                        command.Parameters.AddWithValue("@Active", active);

                        if (personId != null)
                        {
                            command.Parameters.AddWithValue("@PersonID", personId);
                        }

                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return rowsAffected > 0;
        }

        public static bool DeleteUser(int? userID)
        {
            if (userID == null)
            {
                return false;
            }

            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"DELETE FROM Users WHERE UserID = @UserID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", userID);

                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return rowsAffected > 0;
        }
    }
}
