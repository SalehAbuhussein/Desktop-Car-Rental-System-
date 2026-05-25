using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccessLayer
{
    public class RolesDataAccess
    {
        public static DataTable FindAll()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT * FROM Roles";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return dt;
        }

        public static bool Find(int? id, ref string name, ref bool active)
        {
            bool isFound = false;

            if (!id.HasValue)
            {
                return false;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT * FROM Roles WHERE RoleID = @RoleID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RoleID", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                name = reader["RoleName"].ToString();
                                active = Convert.ToBoolean(reader["Active"]);
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

        public static bool FindByName(string roleName, ref int? id, ref bool active)
        {
            bool isFound = false;

            if (string.IsNullOrEmpty(roleName))
            {
                return false;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT * FROM Roles WHERE RoleName = @RoleName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RoleName", roleName);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                id = (int)reader["RoleID"];
                                active = Convert.ToBoolean(reader["Active"]);
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

        public static int? CreateRole(string roleName)
        {
            int? id = null;

            if (string.IsNullOrEmpty(roleName))
            {
                return null;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"INSERT INTO [dbo].[Roles]
                        ([RoleName])
                    VALUES
                        (@RoleName); SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RoleName", roleName);

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            id = insertedID;
                        }
                    }
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return id;
        }

        public static bool UpdateRole(int? roleID, string roleName, bool active)
        {
            int rowsAffected = 0;

            if (!roleID.HasValue)
            {
                return false;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"UPDATE [dbo].[Roles]
                    SET [RoleName] = @RoleName
                        ,[Active] = @Active
                    WHERE RoleID = @RoleID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RoleID", roleID);
                        command.Parameters.AddWithValue("@RoleName", roleName);
                        command.Parameters.AddWithValue("@Active", active);

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

        public static bool IsRoleExist(int? roleID)
        {
            bool isFound = false;

            if (!roleID.HasValue)
            {
                return false;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT true=1 FROM Roles WHERE RoleID = @RoleID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RoleID", roleID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            isFound = reader.HasRows;
                        }
                    }
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return isFound;
        }

        public static bool IsRoleExist(string roleName)
        {
            bool isFound = false;

            if (string.IsNullOrEmpty(roleName))
            {
                return false;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT true=1 FROM Roles WHERE RoleName = @RoleName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RoleName", roleName);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            isFound = reader.HasRows;
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

        public static bool DeleteRole(int? id)
        {
            int rowsAffected = 0;

            if (!id.HasValue)
            {
                return false;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"DELETE FROM Roles WHERE RoleID = @RoleID";
                
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RoleID", id);

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

        public static bool DeleteRole(string name)
        {
            int rowsAffected = 0;

            if (string.IsNullOrEmpty(name))
            {
                return false;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"DELETE FROM Roles WHERE RoleName = @RoleName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RoleName", name);

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
