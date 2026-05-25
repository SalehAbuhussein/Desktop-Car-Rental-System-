using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CarRentalPaymentsDataAccess
    {
        public static DataTable GetRentalPaymentsData(int pageNumber = 1, int rowsPerPage = 10)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT * FROM rentalPaymentsView
                                    ORDER BY CarRentalPaymentID DESC
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

        public static DataTable GetRentalPaymentsDataByStatus(int pageNumber = 1, int rowsPerPage = 10, string status = "Active")
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT * FROM rentalPaymentsView
                                    WHERE Status = @Status
                                    ORDER BY CarRentalPaymentID DESC
                                    OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
                                    FETCH NEXT @RowsPerPage ROWS ONLY";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PageNumber", pageNumber);
                        command.Parameters.AddWithValue("@RowsPerPage", rowsPerPage);
                        command.Parameters.AddWithValue("@Status", status);

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

        public static DataTable GetRentalPaymentsDataByType(int pageNumber = 1, int rowsPerPage = 10, string type = "Initial")
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT * FROM rentalPaymentsView
                                    WHERE Type = @Type
                                    ORDER BY CarRentalPaymentID DESC
                                    OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
                                    FETCH NEXT @RowsPerPage ROWS ONLY";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PageNumber", pageNumber);
                        command.Parameters.AddWithValue("@RowsPerPage", rowsPerPage);
                        command.Parameters.AddWithValue("@Type", type);

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

        public static DataTable GetRentalPaymentsDataByCarRentalID(int? carRentalID, int pageNumber = 1, int rowsPerPage = 10)
        {
            DataTable dt = new DataTable();

            if (!carRentalID.HasValue)
            {
                return dt;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT * FROM rentalPaymentsView
                                    WHERE CarRentalID = @CarRentalID
                                    ORDER BY CarRentalPaymentID DESC
                                    OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
                                    FETCH NEXT @RowsPerPage ROWS ONLY";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PageNumber", pageNumber);
                        command.Parameters.AddWithValue("@RowsPerPage", rowsPerPage);
                        command.Parameters.AddWithValue("@CarRentalID", carRentalID);

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

        public static DataTable GetRentalPaymentsDataByCarRentalIDByStatus(int? carRentalID, int pageNumber = 1, int rowsPerPage = 10, string status = "Active")
        {
            DataTable dt = new DataTable();

            if (!carRentalID.HasValue)
            {
                return dt;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT * FROM rentalPaymentsView
                                    WHERE CarRentalID = @CarRentalID AND Status = @Status
                                    ORDER BY CarRentalPaymentID DESC
                                    OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
                                    FETCH NEXT @RowsPerPage ROWS ONLY";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PageNumber", pageNumber);
                        command.Parameters.AddWithValue("@RowsPerPage", rowsPerPage);
                        command.Parameters.AddWithValue("@CarRentalID", carRentalID);
                        command.Parameters.AddWithValue("@Status", status);

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

        public static DataTable GetRentalPaymentsDataByCarRentalIDByType(int? carRentalID, int pageNumber = 1, int rowsPerPage = 10, string type = "Initial")
        {
            DataTable dt = new DataTable();

            if (!carRentalID.HasValue)
            {
                return dt;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT * FROM rentalPaymentsView
                                    WHERE CarRentalID = @CarRentalID AND type = @Type
                                    ORDER BY CarRentalPaymentID DESC
                                    OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
                                    FETCH NEXT @RowsPerPage ROWS ONLY";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PageNumber", pageNumber);
                        command.Parameters.AddWithValue("@RowsPerPage", rowsPerPage);
                        command.Parameters.AddWithValue("@CarRentalID", carRentalID);
                        command.Parameters.AddWithValue("@Type", type);

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

        public static bool FindByID(int? rentalPaymentID, ref int carRentalID, ref int paymentID, ref decimal paidAmount, ref string status)
        {
            bool isFound = false;

            if (!rentalPaymentID.HasValue)
            {
                return false;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT * FROM CarRentalPayments WHERE CarRentalPaymentID = @CarRentalPaymentID";
                
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CarRentalPaymentID", rentalPaymentID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                carRentalID = (int)reader["CarRentalID"];
                                paymentID = (int)reader["PaymentID"];
                                paidAmount = (decimal)reader["PaidAmount"];
                                status = reader["Status"].ToString();
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

        public static decimal GetTotalPaid()
        {
            decimal totalPaid = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT PaidAmountExcludingRefunds = SUM(PaidAmount) FROM CarRentalPayments WHERE PaidAmount > 0";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();

                        if (result != null && decimal.TryParse(result.ToString(), out decimal total))
                        {
                            totalPaid = total;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return totalPaid;
        }

        public static decimal GetTotalRefunds()
        {
            decimal totalPaid = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT TotalRefunds = COALESCE(SUM(ABS(PaidAmount)), 0) FROM CarRentalPayments WHERE PaidAmount < 0";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();

                        if (result != null && decimal.TryParse(result.ToString(), out decimal total))
                        {
                            totalPaid = total;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return totalPaid;
        }

        public static decimal GetNetRevenue()
        {
            decimal totalPaid = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT NetRevenue = SUM(PaidAmount) FROM CarRentalPayments";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();

                        if (result != null && decimal.TryParse(result.ToString(), out decimal total))
                        {
                            totalPaid = total;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return totalPaid;
        }
    }
}
