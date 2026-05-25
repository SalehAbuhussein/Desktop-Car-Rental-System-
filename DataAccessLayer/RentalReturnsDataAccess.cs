using System;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccessLayer
{
    public class RentalReturnsDataAccess
    {
        public static bool FindByCarRentalID(
            int? carRentalID, 
            ref int? rentalReturnID, 
            ref DateTime returnDate, 
            ref int? createdByUserID, 
            ref DateTime createdAt
        )
        {
            bool isFound = false;

            if (!carRentalID.HasValue)
            {
                return false;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT * FROM RentalReturns WHERE CarRentalID = @CarRentalID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CarRentalID", carRentalID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                rentalReturnID = (int)reader["CarRentalID"];
                                returnDate = (DateTime)reader["ReturnDate"];
                                createdByUserID = (int)reader["CreatedByUserID"];
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
    }
}
