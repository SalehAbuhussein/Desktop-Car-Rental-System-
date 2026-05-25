using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CustomersDataAccess
    {
        public static DataTable GetCustomersData(int pageNumber = 1, int rowsPerPage = 10)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT * FROM CustomersView 
                    ORDER BY CustomerID
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

        public static bool Find(int? customerId, ref int? personID, ref string licenseNumber, ref string status, ref DateTime createdAt)
        {
            if (customerId == null)
            {
                return false;
            }

            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT * FROM Customers WHERE CustomerID = @CustomerID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", customerId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                personID = (int)reader["PersonID"];
                                licenseNumber = reader["LicenseNumber"].ToString();
                                status = reader["Status"].ToString();
                                createdAt = (DateTime)reader["CreatedAt"];
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
    
        public static bool FindByLicenseNumber(string licenseNumber, ref int? customerId, ref int? personID, ref string status, ref DateTime createdAt)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT * FROM Customers WHERE LicenseNumber = @LicenseNumber";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LicenseNumber", licenseNumber);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                customerId = (int)reader["CustomerID"];
                                personID = (int)reader["PersonID"];
                                status = reader["Status"].ToString();
                                createdAt = (DateTime)reader["CreatedAt"];
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

        public static int? CreateCustomer(int? personID, string licenseNumber)
        {
            int? addedId = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"INSERT INTO [dbo].[Customers]
                           ([PersonID]
                           ,[LicenseNumber])
                     VALUES
                           (@PersonID
                           ,@LicenseNumber); SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", personID);
                        command.Parameters.AddWithValue("@LicenseNumber", licenseNumber);

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int id))
                        {
                            addedId = id;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return addedId;
        }

        public static bool UpdateCustomer(int? customerId, int? personID, string licenseNumber, string status)
        {
            if (customerId == null || personID == null)
            {
                return false;
            }

            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"UPDATE [dbo].[Customers]
                       SET [PersonID] = @PersonID
                          ,[LicenseNumber] = @LicenseNumber
                          ,[Status] = @Status
                    WHERE CustomerID = @CustomerID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", customerId);
                        command.Parameters.AddWithValue("@PersonID", personID);
                        command.Parameters.AddWithValue("@LicenseNumber", licenseNumber);
                        command.Parameters.AddWithValue("@Status", status);

                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return rowsAffected > 0;
        }

        public static bool DeleteCustomer(int? customerID)
        {
            if (!customerID.HasValue)
            {
                return false;
            }

            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"DELETE FROM Customers WHERE CustomerID = @CustomerID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", customerID);

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

        public static int GetCustomersCount()
        {
            int customersCount = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT COUNT(*) FROM Customers";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int count))
                        {
                            customersCount = count;
                        }
                    }
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return customersCount;
        }

        public static int GetAvailableCustomersCount()
        {
            int customersCount = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT COUNT(*) FROM Customers WHERE Active = 1";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int count))
                        {
                            customersCount = count;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return customersCount;
        }
    }
}
