using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace DataAccessLayer
{
    public class CarRentalsDataAccess
    {
        public static DataTable FindRentalsByStatus(int pageNumber = 1, int rowsPerPage = 10, string status = "Active")
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT * FROM carRental_view
                    WHERE Status = @Status
                    ORDER BY CarRentalID
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

        public static DataTable FindRentals(int pageNumber = 1, int rowsPerPage = 10)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT * FROM carRental_view
                    ORDER BY CarRentalID
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

        public static bool Find(
            int? carRentalID,
            ref int? carID,
            ref decimal deposit,
            ref decimal totalPrice,
            ref string pickupLocation,
            ref DateTime pickupDate,
            ref DateTime returnDate,
            ref string status,
            ref decimal pricePerDaySnapshot,
            ref int createdByUserID,
            ref int customerID
        )
        {
            bool isFound = false;

            if (carRentalID == null)
            {
                return false;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT * FROM CarRentals WHERE CarRentalID = @CarRentalID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CarRentalID", carRentalID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                carID = (int)reader["CarID"];
                                deposit = (decimal)reader["Deposit"];
                                totalPrice = (decimal)reader["TotalPrice"];
                                pickupLocation = reader["PickupLocation"].ToString();
                                pickupDate = (DateTime)reader["PickupDate"];
                                returnDate = (DateTime)reader["ReturnDate"];
                                status = reader["Status"].ToString();
                                createdByUserID = (int)reader["CreatedByUserID"];
                                pricePerDaySnapshot = (decimal)reader["PricePerDaySnapshot"];
                                customerID = (int)reader["CustomerID"];
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

        public static bool UpdateRental(
            int? carRentalID,
            int? carID,
            decimal deposit,
            decimal totalPrice,
            string pickupLocation,
            DateTime pickupDate,
            DateTime returnDate,
            int? createdByUserID
        )
        {
            int rowsAffected = 0;

            if (carRentalID == null)
            {
                return false;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"UPDATE [dbo].[CarRentals]
                       SET [CarID] = @CarID
                          ,[Deposit] = @Deposit
                          ,[TotalPrice] = @TotalPrice
                          ,[PickupLocation] = @PickupLocation
                          ,[PickupDate] = @PickupDate
                          ,[ReturnDate] = @ReturnDate
                          ,[CreatedByUserID] = @CreatedByUserID
                     WHERE CarRentalID = @CarRentalID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CarRentalID", carRentalID);
                        command.Parameters.AddWithValue("@CarID", carID);
                        command.Parameters.AddWithValue("@Deposit", deposit);
                        command.Parameters.AddWithValue("@TotalPrice", totalPrice);
                        command.Parameters.AddWithValue("@PickupLocation", pickupLocation);
                        command.Parameters.AddWithValue("@PickupDate", pickupDate);
                        command.Parameters.AddWithValue("@ReturnDate", returnDate);
                        command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

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

        public static bool UpdateStatus(int carRentalID, string status)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"UPDATE [dbo].[CarRentals]
                       SET [Status] = @Status
                     WHERE CarRentalID = @CarRentalID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CarRentalID", carRentalID);
                        command.Parameters.AddWithValue("@Status", status);

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

        public static DataTable GetInitialPaymentData(int? carRentalID)
        {
            DataTable dt = new DataTable();

            if (carRentalID == null)
            {
                return dt;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT TOP 1 * FROM CarRentalPayments CRP
                    INNER JOIN Payments P ON CRP.PaymentID = P.PaymentID
                    WHERE CarRentalID = @CarRentalID;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
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

        public static int? RentCar(
            int? carID,
            decimal deposit,
            string pickupLocation,
            int? createdByUserID,
            DateTime pickupDate,
            DateTime returnDate,
            decimal? initialPayment,
            string paymentMethod,
            int? customerID
        )
        {
            int? carRentalID = null;

            if (carID == null || createdByUserID == null || customerID == null)
            {
                return null;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("createRentalRecord", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CarID", carID);
                        command.Parameters.AddWithValue("@Deposit", deposit);
                        command.Parameters.AddWithValue("@InitialPayment", initialPayment);
                        command.Parameters.AddWithValue("@PaymentMethod", paymentMethod);
                        command.Parameters.AddWithValue("@PickupLocation", pickupLocation);
                        command.Parameters.AddWithValue("@PickupDate", pickupDate);
                        command.Parameters.AddWithValue("@ReturnDate", returnDate);
                        command.Parameters.AddWithValue("@UserID", createdByUserID);
                        command.Parameters.AddWithValue("@CustomerID", customerID);

                        SqlParameter outputID = new SqlParameter("@CarRentalID", SqlDbType.Int);
                        outputID.Direction = ParameterDirection.Output;
                        command.Parameters.Add(outputID);

                        command.ExecuteNonQuery();

                        carRentalID = Convert.ToInt32(command.Parameters["@CarRentalID"].Value);
                    }
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return carRentalID;
        }

        public static bool ExtendRental(
            int? carRentalID,
            DateTime newReturnDate
        )
        {
            bool isExtended = false;

            if (carRentalID == null)
            {
                return false;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("spExtendRental", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter carRentalIDParam = new SqlParameter();
                        carRentalIDParam.ParameterName = "@CarRentalID";
                        carRentalIDParam.SqlDbType = SqlDbType.Int;
                        carRentalIDParam.Direction = ParameterDirection.Input;
                        carRentalIDParam.Value = carRentalID;

                        command.Parameters.Add(carRentalIDParam);

                        SqlParameter newReturnDateParam = new SqlParameter();
                        newReturnDateParam.ParameterName = "@NewReturnDate";
                        newReturnDateParam.SqlDbType = SqlDbType.DateTime;
                        newReturnDateParam.Direction = ParameterDirection.Input;
                        newReturnDateParam.Value = newReturnDate;

                        command.Parameters.Add(newReturnDateParam);

                        SqlParameter returnValue = new SqlParameter();
                        returnValue.Direction = ParameterDirection.ReturnValue;
                        command.Parameters.Add(returnValue);

                        command.ExecuteNonQuery();

                        isExtended = Convert.ToInt32(returnValue.Value) == 1;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            return isExtended;
        }

        public static bool ReturnCar(int? carRentalID, DateTime actualReturnDate, int? createdByUserID)
        {
            bool hasCarReturned = false;

            if (carRentalID == null || createdByUserID == null)
            {
                return false;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("spReturnCar", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter carRentalIDParam = new SqlParameter();
                        carRentalIDParam.ParameterName = "@CarRentalID";
                        carRentalIDParam.SqlDbType = SqlDbType.Int;
                        carRentalIDParam.Direction = ParameterDirection.Input;
                        carRentalIDParam.Value = carRentalID;

                        command.Parameters.Add(carRentalIDParam);

                        SqlParameter actualReturnDateParam = new SqlParameter();
                        actualReturnDateParam.ParameterName = "@ActualReturnDate";
                        actualReturnDateParam.SqlDbType = SqlDbType.DateTime;
                        actualReturnDateParam.Direction = ParameterDirection.Input;
                        actualReturnDateParam.Value = actualReturnDate;

                        command.Parameters.Add(actualReturnDateParam);

                        SqlParameter createdByUserIDParam = new SqlParameter();
                        createdByUserIDParam.ParameterName = "@CreatedByUserID";
                        createdByUserIDParam.SqlDbType = SqlDbType.Int;
                        createdByUserIDParam.Direction = ParameterDirection.Input;
                        createdByUserIDParam.Value = createdByUserID;

                        command.Parameters.Add(createdByUserIDParam);

                        SqlParameter returnValue = new SqlParameter();
                        returnValue.Direction = ParameterDirection.ReturnValue;
                        command.Parameters.Add(returnValue);

                        command.ExecuteNonQuery();

                        hasCarReturned = Convert.ToInt32(returnValue.Value) == 1;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return hasCarReturned;
        }

        public static decimal GetPaidAmount(int? carRentalID)
        {
            decimal paidAmount = 0;

            if (carRentalID == null)
            {
                return 0;
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT 
	                    TotalPaid = SUM(CRP.PaidAmount)
                    FROM CarRentals CR
                    INNER JOIN CarRentalPayments CRP ON CR.CarRentalID = CRP.CarRentalID
                    WHERE CR.CarRentalID = @CarRentalID;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CarRentalID", carRentalID);

                        object result = command.ExecuteScalar();

                        if (result != null && decimal.TryParse(result.ToString(), out decimal totalPaid))
                        {
                            paidAmount = totalPaid;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return paidAmount;
        }
    }
}
