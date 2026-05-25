using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class PaymentsDataAccess
    {
        public static DataTable GetPayments(int pageNumber = 1, int rowsPerPage = 10)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT * FROM Payments
                    ORDER BY PaymentID
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

        public static bool FindPayment(int paymentID, ref decimal amount, ref string paymentMethod, ref DateTime createdAt)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Payments WHERE PaymentID = @PaymentID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PaymentID", paymentID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                amount = (decimal)reader["Amount"];
                                paymentMethod = reader["PaymentMethod"].ToString();
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
    }
}
