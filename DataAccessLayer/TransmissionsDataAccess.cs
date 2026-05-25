using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class TransmissionsDataAccess
    {
        public static DataTable FindTransmissions(int pageNumber = 1, int rowsPerPage = 10)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT * FROM Transmissions
                    ORDER BY TransmissionID
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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return dt;
        }

        public static bool Find(int? transmissionID, ref string transmissionName)
        {
            bool isFound = false;

            if (transmissionID == null)
            {
                return false;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Transmissions WHERE TransmissionID = @TransmissionID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TransmissionID", transmissionID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                transmissionName = reader["Transmission"].ToString();
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

        public static bool FindByName(string transmissionName, ref int? transmissionID)
        {
            bool isFound = false;

            if (string.IsNullOrEmpty(transmissionName))
            {
                return false;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Transmissions WHERE Transmission = @Transmission";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Transmission", transmissionName);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                transmissionID = (int)reader["TransmissionID"];
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

        public static int? CreateTransmission(string transmissionName)
        {
            int? id = null;

            if (string.IsNullOrEmpty(transmissionName))
            {
                return null;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"INSERT INTO [dbo].[Transmissions]
                        ([Transmission])
                    VALUES
                        (@Transmission); SELECT SCOPE_IDENTITY()";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Transmission", transmissionName);

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

        public static bool UpdateTransmission(int? transmissionID, string transmissionName)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"UPDATE [dbo].[Transmissions]
                        SET [Transmission] = @Transmission
                    WHERE TransmissionID = @TransmissionID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Transmission", transmissionName);
                        command.Parameters.AddWithValue("@TransmissionID", transmissionID);

                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return rowsAffected > 0;
        }

        public static bool IsTransmissionExist(int? transmissionID)
        {
            bool isFound = false;

            if (!transmissionID.HasValue)
            {
                return false;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT true=1 FROM Transmissions WHERE TransmissionID = @TransmissionID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TransmissionID", transmissionID);

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

        public static bool IsTransmissionExist(string transmissionName)
        {
            bool isFound = false;

            if (string.IsNullOrEmpty(transmissionName))
            {
                return false;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT true=1 FROM Transmissions WHERE Transmission = @Transmission";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Transmission", transmissionName);

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
    }
}
