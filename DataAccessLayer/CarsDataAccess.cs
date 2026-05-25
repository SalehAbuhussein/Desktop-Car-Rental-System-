using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CarsDataAccess
    {
        public static DataTable FindCars(int pageNumber = 1, int rowsPerPage = 10)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT * FROM Cars
                    WHERE Active = 1
                    ORDER BY CarID
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

        public static DataTable FindAvailableCars(int pageNumber = 1, int rowsPerPage = 10)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT * FROM Cars
                    WHERE Active = 1 AND IsAvailable = 1
                    ORDER BY CarID
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
            int? carID,
            ref string carName,
            ref string carImage,
            ref string vin,
            ref string plateNumber,
            ref int mileage,
            ref bool active,
            ref int? modelID,
            ref int? yearID,
            ref int? fuelTypeID,
            ref int? transmissionID,
            ref int? createdByUserID,
            ref int status,
            ref decimal pricePerDay,
            ref bool isAvailable,
            ref DateTime createdAt,
            ref DateTime updatedAt
        )
        {
            bool isFound = false;

            if (carID == null)
            {
                return false;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT * FROM Cars WHERE CarID = @CarID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CarID", carID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                carName = reader["CarName"].ToString();
                                vin = reader["VIN"].ToString();
                                plateNumber = reader["PlateNumber"].ToString();
                                mileage = (int)reader["Mileage"];
                                active = Convert.ToBoolean(reader["Active"]);
                                modelID = (int)reader["ModelID"];
                                yearID = (int)reader["YearID"];
                                fuelTypeID = (int)reader["FuelTypeID"];
                                transmissionID = (int)reader["TransmissionID"];
                                createdByUserID = (int)reader["CreatedByID"];
                                status = (int)reader["Status"];
                                createdAt = (DateTime)reader["CreatedAt"];
                                updatedAt = (DateTime)reader["UpdatedAt"];
                                pricePerDay = Convert.ToDecimal(reader["PricePerDay"]);
                                isAvailable = Convert.ToBoolean(reader["IsAvailable"]);

                                if (reader["Image"] != null)
                                {
                                    carImage = reader["Image"].ToString();
                                } else
                                {
                                    carImage = string.Empty;
                                }
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

        public static bool FindByName(
            string carName,
            ref int carID,
            ref string carImage,
            ref string vin,
            ref string plateNumber,
            ref int mileage,
            ref bool active,
            ref int? modelID,
            ref int? yearID,
            ref int? fuelTypeID,
            ref int? transmissionID,
            ref int? createdByUserID,
            ref int status,
            ref decimal pricePerDay,
            ref bool isAvailable,
            ref DateTime createdAt,
            ref DateTime updatedAt
        )
        {
            bool isFound = false;

            if (string.IsNullOrEmpty(carName))
            {
                return false;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT * FROM Cars WHERE CarName = @CarName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CarName", carName);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                carID = (int)reader["CarID"];
                                vin = reader["VIN"].ToString();
                                plateNumber = reader["PlateNumber"].ToString();
                                mileage = (int)reader["Mileage"];
                                active = Convert.ToBoolean(reader["Active"]);
                                modelID = (int)reader["ModelID"];
                                yearID = (int)reader["YearID"];
                                fuelTypeID = (int)reader["FuelTypeID"];
                                transmissionID = (int)reader["TransmissionID"];
                                createdByUserID = (int)reader["CreatedByID"];
                                status = (int)reader["Status"];
                                createdAt = (DateTime)reader["CreatedAt"];
                                updatedAt = (DateTime)reader["UpdatedAt"];
                                pricePerDay = Convert.ToDecimal(reader["PricePerDay"]);
                                isAvailable = Convert.ToBoolean(reader["IsAvailable"]);

                                if (reader["Image"] != null)
                                {
                                    carImage = reader["Image"].ToString();
                                }
                                else
                                {
                                    carImage = string.Empty;
                                }
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

        public static bool FindByPlateNumber(
            string plateNumber,
            ref int? carID,
            ref string carName,
            ref string carImage,
            ref string vin,
            ref int mileage,
            ref bool active,
            ref int? modelID,
            ref int? yearID,
            ref int? fuelTypeID,
            ref int? transmissionID,
            ref int? createdByUserID,
            ref int status,
            ref decimal pricePerDay,
            ref bool isAvailable,
            ref DateTime createdAt,
            ref DateTime updatedAt
        )
        {
            bool isFound = false;

            if (string.IsNullOrEmpty(plateNumber))
            {
                return false;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT * FROM Cars WHERE PlateNumber = @PlateNumber";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PlateNumber", plateNumber);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                carID = (int)reader["CarID"];
                                carName = reader["CarName"].ToString();
                                vin = reader["VIN"].ToString();
                                mileage = (int)reader["Mileage"];
                                active = Convert.ToBoolean(reader["Active"]);
                                modelID = (int)reader["ModelID"];
                                yearID = (int)reader["YearID"];
                                fuelTypeID = (int)reader["FuelTypeID"];
                                transmissionID = (int)reader["TransmissionID"];
                                createdByUserID = (int)reader["CreatedByID"];
                                status = (int)reader["Status"];
                                createdAt = (DateTime)reader["CreatedAt"];
                                updatedAt = (DateTime)reader["UpdatedAt"];
                                pricePerDay = Convert.ToDecimal(reader["PricePerDay"]);
                                isAvailable = Convert.ToBoolean(reader["IsAvailable"]);

                                if (reader["Image"] != null)
                                {
                                    carImage = reader["Image"].ToString();
                                }
                                else
                                {
                                    carImage = string.Empty;
                                }
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

        public static bool FindByVin(
            string vin,
            ref int? carID,
            ref string carName,
            ref string carImage,
            ref string plateNumber,
            ref int mileage,
            ref bool active,
            ref int? modelID,
            ref int? yearID,
            ref int? fuelTypeID,
            ref int? transmissionID,
            ref int? createdByUserID,
            ref int status,
            ref decimal pricePerDay,
            ref bool isAvailable,
            ref DateTime createdAt,
            ref DateTime updatedAt    
        )
        {
            bool isFound = false;

            if (string.IsNullOrEmpty(vin))
            {
                return false;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT * FROM Cars WHERE VIN = @VIN";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@VIN", vin);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                carID = (int)reader["CarID"];
                                carName = reader["CarName"].ToString();
                                plateNumber = reader["PlateNumber"].ToString();
                                mileage = (int)reader["Mileage"];
                                active = Convert.ToBoolean(reader["Active"]);
                                modelID = (int)reader["ModelID"];
                                yearID = (int)reader["YearID"];
                                fuelTypeID = (int)reader["FuelTypeID"];
                                transmissionID = (int)reader["TransmissionID"];
                                createdByUserID = (int)reader["CreatedByID"];
                                status = (int)reader["Status"];
                                createdAt = (DateTime)reader["CreatedAt"];
                                updatedAt = (DateTime)reader["UpdatedAt"];
                                pricePerDay = Convert.ToDecimal(reader["PricePerDay"]);
                                isAvailable = Convert.ToBoolean(reader["IsAvailable"]);

                                if (reader["Image"] != null)
                                {
                                    carImage = reader["Image"].ToString();
                                }
                                else
                                {
                                    carImage = string.Empty;
                                }
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

        public static int? CreateCar(
            string carName,
            string carImage,
            string vin,
            string plateNumber,
            int mileage,
            decimal pricePerDay,
            int? modelID,
            int? yearID,
            int? fuelTypeID,
            int? transmissionID,
            int? createdByUserID
        )
        {
            int? id = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"INSERT INTO [dbo].[Cars]
                           ([CarName]
                           ,[Image]
                           ,[VIN]
                           ,[PlateNumber]
                           ,[Mileage]
                           ,[ModelID]
                           ,[YearID]
                           ,[FuelTypeID]
                           ,[TransmissionID]
                           ,[PricePerDay],
                           ,[CreatedByID])
                     VALUES
                           (@CarName
                           ,@CarImage
                           ,@VIN
                           ,@PlateNumber
                           ,@Mileage
                           ,@ModelID
                           ,@YearID
                           ,@FuelTypeID
                           ,@TransmissionID
                           ,@PricePerDay
                           ,@CreatedByID); SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CarName", carName);
                        command.Parameters.AddWithValue("@VIN", vin);
                        command.Parameters.AddWithValue("@PlateNumber", plateNumber);
                        command.Parameters.AddWithValue("@Mileage", mileage);
                        command.Parameters.AddWithValue("@ModelID", modelID);
                        command.Parameters.AddWithValue("@YearID", yearID);
                        command.Parameters.AddWithValue("@FuelTypeID", fuelTypeID);
                        command.Parameters.AddWithValue("@TransmissionID", transmissionID);
                        command.Parameters.AddWithValue("@CreatedByID", createdByUserID);
                        command.Parameters.AddWithValue("@PricePerDay", pricePerDay);

                        if (string.IsNullOrEmpty(carImage))
                        {
                            command.Parameters.AddWithValue("@CarImage", DBNull.Value);
                        } else
                        {
                            command.Parameters.AddWithValue("@CarImage", carImage);
                        }

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedId))
                        {
                            id = insertedId;
                        }
                    }
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return id;
        }

        public static bool UpdateCar(
            int? carID,
            string carName,
            string carImage,
            string vin,
            string plateNumber,
            int mileage,
            bool active,
            decimal pricePerDay,
            int? modelID,
            int? yearID,
            int? fuelTypeID,
            int? transmissionID,
            int? createdByUserID,
            bool isAvailable
        )
        {
            int rowsAffected = 0;

            if (
                carID == null ||
                modelID == null ||
                yearID == null ||
                fuelTypeID == null || 
                transmissionID == null ||
                createdByUserID == null
            )
            {
                return false;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"
                    UPDATE [dbo].[Cars]
                       SET [CarName] = @CarName
                          ,[Image] = @CarImage
                          ,[VIN] = @VIN
                          ,[PlateNumber] = @PlateNumber
                          ,[Mileage] = @Mileage
                          ,[Active] = @Active
                          ,[ModelID] = @ModelID
                          ,[YearID] = @YearID
                          ,[FuelTypeID] = @FuelTypeID
                          ,[TransmissionID] = @TransmissionID
                          ,[CreatedByID] = @CreatedByID
                          ,[PricePerDay] = @PricePerDay
                          ,[IsAvailable] = @IsAvailable
                     WHERE CarID = @CarID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CarID", carID);
                        command.Parameters.AddWithValue("@CarName", carName);
                        command.Parameters.AddWithValue("@VIN", vin);
                        command.Parameters.AddWithValue("@PlateNumber", plateNumber);
                        command.Parameters.AddWithValue("@Mileage", mileage);
                        command.Parameters.AddWithValue("@Active", active);
                        command.Parameters.AddWithValue("@ModelID", modelID);
                        command.Parameters.AddWithValue("@YearID", yearID);
                        command.Parameters.AddWithValue("@FuelTypeID", fuelTypeID);
                        command.Parameters.AddWithValue("@TransmissionID", transmissionID);
                        command.Parameters.AddWithValue("@CreatedByID", createdByUserID);
                        command.Parameters.AddWithValue("@PricePerDay", pricePerDay);
                        command.Parameters.AddWithValue("@IsAvailable", isAvailable);

                        if (string.IsNullOrEmpty(carImage))
                        {
                            command.Parameters.AddWithValue("@CarImage", DBNull.Value);
                        } else
                        {
                            command.Parameters.AddWithValue("@CarImage", carImage);
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

        public static bool DeleteCar(int? carID)
        {
            if (carID == null)
            {
                return false;
            }

            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"DELETE FROM Cars WHERE CarID = @CarID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CarID", carID);

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

        public static bool UpdateCarStatus(int? carID, int status)
        {
            int rowsAffected = 0;

            if (carID == null)
            {
                return false;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"
                    UPDATE [dbo].[Cars]
                       SET [Status] = @Status
                    WHERE CarID = @CarID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CarID", carID);

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

        public static int GetCarsCount()
        {
            int carsCount = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT COUNT(*) FROM Cars";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int count))
                        {
                            carsCount = count;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return carsCount;
        }

        public static int GetAvailableCarsCount()
        {
            int carsCount = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT COUNT(*) FROM Cars WHERE IsAvailable = 1";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int count))
                        {
                            carsCount = count;
                        }
                    }
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return carsCount;
        }

        public static int GetRentedCarsCount()
        {
            int carsCount = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT COUNT(*) FROM Cars WHERE IsAvailable = 0";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int count))
                        {
                            carsCount = count;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return carsCount;
        }

        public static bool IsAnyCarAvailable()
        {
            bool isAvailable = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT TOP 1 true=1 FROM Cars WHERE IsAvailable = 1";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            isAvailable = reader.HasRows;
                        }
                    }
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            return isAvailable;
        }
    }
}
