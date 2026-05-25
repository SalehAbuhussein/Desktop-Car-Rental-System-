using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsCar
    {
        public enum enMode
        {
            Add,
            Update,
        }
        public enum enStatus
        {
            Available = 1,
            Rented = 2,
            Maintenance = 3
        }
        public int? CarID { get; set; }
        public string CarName { get; set; }
        public string CarImage { get; set; }
        public string Vin { get; set; }
        public string PlateNumber { get; set; }
        public int Mileage { get; set; }
        public bool Active { get; set; }
        public int? ModelID { get; set; }
        public clsModel ModelInfo { get; set; }
        public int? YearID { get; set; }
        public clsYear YearInfo { get; set; }
        public int? FuelTypeID { get; set; }
        public clsFuelType FuelTypeInfo { get; set; }
        public int? TransmissionID { get; set; }
        public clsTransmission TransmissionInfo { get; set; }
        public int? CreatedByUserID { get; set; }
        public clsUser CreatedByUserInfo { get; set; }
        public decimal PricePerDay { get; set; }
        public enStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsAvailable { get; set; }
        private enMode _Mode = enMode.Add;

        public clsCar()
        {
            _Mode = enMode.Add;
        }

        private clsCar(
            int? carID, 
            string carName,
            string carImage,
            string vin,
            string plateNumber,
            int mileage,
            bool active,
            int? modelID,
            int? yearID,
            int? fuelTypeID,
            int? transmissionID,
            int? createdByUserID,
            decimal pricePerDay,
            enStatus status,
            bool isAvailable,
            DateTime createdAt,
            DateTime updatedAt
        )
        {
            _Mode = enMode.Update;
            CarID = carID;
            CarName = carName;
            CarImage = carImage;
            Vin = vin;
            PlateNumber = plateNumber;
            Mileage = mileage;
            Active = active;
            ModelID = modelID;
            ModelInfo = clsModel.Find(modelID);
            YearID = yearID;
            YearInfo = clsYear.Find(yearID);
            FuelTypeID = fuelTypeID;
            FuelTypeInfo = clsFuelType.Find(fuelTypeID);
            TransmissionID = transmissionID;
            TransmissionInfo = clsTransmission.Find(transmissionID);
            CreatedByUserID = createdByUserID;
            Status = status;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            PricePerDay = pricePerDay;
            IsAvailable = isAvailable;
        }

        public static DataTable FindCars(int pageNumber = 1, int rowsPerPage = 10)
        {
            return CarsDataAccess.FindCars(pageNumber, rowsPerPage);
        }

        public static DataTable FindAvailableCars(int pageNumber = 1, int rowsPerPage = 10)
        {
            return CarsDataAccess.FindAvailableCars(pageNumber, rowsPerPage);
        }

        public static clsCar Find(int? carID)
        {
            string carName = string.Empty;
            string vin = string.Empty;
            string plateNumber = string.Empty;
            int mileage = int.MinValue;
            bool active = false;
            int? modelID = null;
            int? yearID = null;
            int? fuelTypeID = null;
            int? transmissionID = null;
            int? createdByUserID = null;
            string carImage = string.Empty;
            int status = (int)enStatus.Available;
            decimal pricePerDay = decimal.MaxValue;
            DateTime createdAt = DateTime.MinValue;
            DateTime updatedAt = DateTime.MinValue;
            bool isAvailable = false;

            if (CarsDataAccess.Find(
                carID,
                ref carName,
                ref carImage,
                ref vin,
                ref plateNumber,
                ref mileage,
                ref active,
                ref modelID,
                ref yearID,
                ref fuelTypeID,
                ref transmissionID,
                ref createdByUserID,
                ref status,
                ref pricePerDay,
                ref isAvailable,
                ref createdAt,
                ref updatedAt
            ))
            {
                return new clsCar(
                    carID,
                    carName,
                    carImage,
                    vin,
                    plateNumber,
                    mileage,
                    active,
                    modelID,
                    yearID,
                    fuelTypeID,
                    transmissionID,
                    createdByUserID,
                    pricePerDay,
                    (enStatus)status,
                    isAvailable,
                    createdAt,
                    updatedAt
                );
            }

            return null;
        }

        public static clsCar FindByName(string carName)
        {
            int carID = int.MinValue;
            string vin = string.Empty;
            string plateNumber = string.Empty;
            int mileage = int.MinValue;
            bool active = false;
            int? modelID = null;
            int? yearID = null;
            int? fuelTypeID = null;
            int? transmissionID = null;
            int? createdByUserID = null;
            string carImage = string.Empty;
            int status = (int)enStatus.Available;
            decimal pricePerDay = decimal.MaxValue;
            DateTime createdAt = DateTime.MinValue;
            DateTime updatedAt = DateTime.MinValue;
            bool isAvailable = false;

            if (CarsDataAccess.FindByName(
                carName,
                ref carID,
                ref carImage,
                ref vin,
                ref plateNumber,
                ref mileage,
                ref active,
                ref modelID,
                ref yearID,
                ref fuelTypeID,
                ref transmissionID,
                ref createdByUserID,
                ref status,
                ref pricePerDay,
                ref isAvailable,
                ref createdAt,
                ref updatedAt
            ))
            {
                return new clsCar(
                    carID,
                    carName,
                    carImage,
                    vin,
                    plateNumber,
                    mileage,
                    active,
                    modelID,
                    yearID,
                    fuelTypeID,
                    transmissionID,
                    createdByUserID,
                    pricePerDay,
                    (enStatus)status,
                    isAvailable,
                    createdAt,
                    updatedAt
                );
            }

            return null;
        }

        public static clsCar FindByPlateNumber(string plateNumber)
        {
            int? carID = null;
            string carName = string.Empty;
            string vin = string.Empty;
            int mileage = int.MinValue;
            bool active = false;
            int? modelID = null;
            int? yearID = null;
            int? fuelTypeID = null;
            int? transmissionID = null;
            int? createdByUserID = null;
            int status = (int)enStatus.Available;
            string carImage = string.Empty;
            DateTime createdAt = DateTime.MinValue;
            DateTime updatedAt = DateTime.MinValue;
            decimal pricePerDay = decimal.MaxValue;
            bool isAvailable = false;

            if (CarsDataAccess.FindByPlateNumber(
                plateNumber,
                ref carID,
                ref carName,
                ref carImage,
                ref vin,
                ref mileage,
                ref active,
                ref modelID,
                ref yearID,
                ref fuelTypeID,
                ref transmissionID,
                ref createdByUserID,
                ref status,
                ref pricePerDay,
                ref isAvailable,
                ref createdAt,
                ref updatedAt
            ))
            {
                return new clsCar(
                    carID,
                    carName,
                    carImage,
                    vin,
                    plateNumber,
                    mileage,
                    active,
                    modelID,
                    yearID,
                    fuelTypeID,
                    transmissionID,
                    createdByUserID,
                    pricePerDay,
                    (enStatus)status,
                    isAvailable,
                    createdAt,
                    updatedAt
                );
            }

            return null;
        }

        public static bool IsCarExistByPlateNumber(string plateNumber)
        {
            return FindByPlateNumber(plateNumber) != null;
        }

        public static clsCar FindByVin(string vin)
        {
            int? carID = null;
            string carName = string.Empty;
            string plateNumber = string.Empty;
            int mileage = int.MinValue;
            bool active = false;
            int? modelID = null;
            int? yearID = null;
            int? fuelTypeID = null;
            int? transmissionID = null;
            int? createdByUserID = null;
            string carImage = string.Empty;
            int status = (int)enStatus.Available;
            DateTime createdAt = DateTime.MinValue;
            DateTime updatedAt = DateTime.MinValue;
            decimal pricePerDay = Decimal.MaxValue;
            bool isAvailable = false;

            if (CarsDataAccess.FindByVin(
                vin,
                ref carID,
                ref carName,
                ref carImage,
                ref plateNumber,
                ref mileage,
                ref active,
                ref modelID,
                ref yearID,
                ref fuelTypeID,
                ref transmissionID,
                ref createdByUserID,
                ref status,
                ref pricePerDay,
                ref isAvailable,
                ref createdAt,
                ref updatedAt
            ))
            {
                return new clsCar(
                    carID,
                    carName,
                    carImage,
                    vin,
                    plateNumber,
                    mileage,
                    active,
                    modelID,
                    yearID,
                    fuelTypeID,
                    transmissionID,
                    createdByUserID,
                    pricePerDay,
                    (enStatus)status,
                    isAvailable,
                    createdAt,
                    updatedAt
                );
            }

            return null;
        }

        public static bool IsCarExistByVin(string vin)
        {
            return FindByVin(vin) != null;
        }

        public static bool DeleteCar(int? carID)
        {
            return CarsDataAccess.DeleteCar(carID);
        }

        public static int GetCarsCount()
        {
            return CarsDataAccess.GetCarsCount();
        }

        public static int GetAvailableCarsCount()
        {
            return CarsDataAccess.GetAvailableCarsCount();
        }

        public static int GetRentedCarsCount()
        {
            return CarsDataAccess.GetRentedCarsCount();
        }

        private bool _AddCar()
        {
            CarID = CarsDataAccess.CreateCar(
                CarName,
                CarImage,
                Vin,
                PlateNumber,
                Mileage,
                PricePerDay,
                ModelID,
                YearID,
                FuelTypeID,
                TransmissionID,
                CreatedByUserID
            );

            return CarID != null;
        }

        private bool _UpdateCar()
        {
            return CarsDataAccess.UpdateCar(
                CarID,
                CarName,
                CarImage,
                Vin,
                PlateNumber,
                Mileage,
                Active,
                PricePerDay,
                ModelID,
                YearID,
                FuelTypeID,
                TransmissionID,
                CreatedByUserID,
                IsAvailable
            );
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.Add:
                    if (_AddCar())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateCar();
            }

            return false;
        }

        public static bool MarkAvailable(int? carID)
        {
            return CarsDataAccess.UpdateCarStatus(carID, (int)enStatus.Available);
        }
        
        public bool MarkAvailable()
        {
            return MarkAvailable(CarID);
        }

        public static bool MarkRented(int? carID)
        {
            return CarsDataAccess.UpdateCarStatus(carID, (int)enStatus.Rented);
        }

        public bool MarkRented()
        {
            return MarkRented(CarID);
        }

        public static bool MarkForMaintenance(int? carID)
        {
            return CarsDataAccess.UpdateCarStatus(carID, (int)enStatus.Maintenance);
        }

        public bool MarkForMaintenance()
        {
            return MarkForMaintenance(CarID);
        }

        public static bool IsAnyCarAvailable()
        {
            return CarsDataAccess.IsAnyCarAvailable();
        }
    }
}
