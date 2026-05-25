using DataAccessLayer;
using System;
using System.Data;
using System.Linq;
using System.Text;

namespace BusinessLayer
{
    public class clsCarRental
    {
        public enum enMode
        {
            Add,
            Update,
        }
        public int? CarRentalID { get; set; }
        public int? CarID { get; set; }
        public clsCar CarInfo { get; set; }
        public decimal Deposit { get; set; }
        public decimal TotalPrice { get; set; }
        public string PickupLocation { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Status { get; set; } // Active, Pending, Completed
        public decimal PricePerDaySnapshot { get; set; }
        public int? CreatedByUserID { get; set; }
        public clsUser CreatedByUserInfo { get; set; }
        public int? CustomerID { get; set; }
        public clsCustomer CustomerInfo { get; set; }
        private enMode _Mode = enMode.Add;

        public decimal? InitialPayment { get; set; }
        private string _PaymentMethod = "Cash";
        public string PaymentMethod { 
            get
            {
                return _PaymentMethod;
            }
            set
            {
                _PaymentMethod = value;
            }
        }

        public clsCarRental()
        {
            _Mode = enMode.Add;
        }

        private clsCarRental(
            int? carRentalID,
            int? carID,
            decimal deposit,
            decimal totalPrice,
            string pickupLocation,
            DateTime pickupDate,
            DateTime returnDate,
            string status,
            decimal pricePerDaySnapshot,
            int createdByUserID,
            int customerID
        )
        {
            _Mode = enMode.Update;

            CarRentalID = carRentalID;
            CarID = carID;
            CarInfo = clsCar.Find(carID);
            Deposit = deposit;
            TotalPrice = totalPrice;
            PickupLocation = pickupLocation;
            PickupDate = pickupDate;
            ReturnDate = returnDate;
            Status = status;
            PricePerDaySnapshot = pricePerDaySnapshot;
            CreatedByUserID = createdByUserID;
            CreatedByUserInfo = clsUser.FindUser(createdByUserID);
            CustomerID = customerID;
            CustomerInfo = clsCustomer.Find(customerID);
        }

        public static DataTable FindRentalsByStatus(int pageNumber = 1, int rowsPerPage = 10, string status = "Active")
        {
            return CarRentalsDataAccess.FindRentalsByStatus(pageNumber, rowsPerPage, status);
        }

        public static DataTable FindRentals(int pageNumber = 1, int rowsPerPage = 10)
        {
            return CarRentalsDataAccess.FindRentals(pageNumber, rowsPerPage);
        }

        public static clsCarRental Find(int? carRentalID)
        {
            int? carID = null;
            decimal deposit = Decimal.MinValue;
            decimal totalPrice = Decimal.MinValue;
            string pickupLocation = string.Empty;
            DateTime pickupDate = DateTime.MinValue;
            DateTime returnDate = DateTime.MinValue;
            string status = string.Empty;
            int createdByUserID = int.MinValue;
            decimal pricPerDaySnapshot = decimal.MinValue;
            int customerID = 0;

            if (CarRentalsDataAccess.Find(
                carRentalID,
                ref carID,
                ref deposit,
                ref totalPrice,
                ref pickupLocation,
                ref pickupDate,
                ref returnDate,
                ref status,
                ref pricPerDaySnapshot,
                ref createdByUserID,
                ref customerID
            ))
            {
                return new clsCarRental(
                    carRentalID,
                    carID,
                    deposit,
                    totalPrice,
                    pickupLocation,
                    pickupDate,
                    returnDate,
                    status,
                    pricPerDaySnapshot,
                    createdByUserID,
                    customerID
                );
            }

            return null;
        }

        public static DataTable GetInitialPaymentData(int? carRentalID)
        {
            return CarRentalsDataAccess.GetInitialPaymentData(carRentalID);
        }

        public static bool ExtendRental(int? carRentalID, DateTime newReturnDate)
        {
            return CarRentalsDataAccess.ExtendRental(carRentalID, newReturnDate);
        }

        public bool ExtendRental(DateTime newReturnDate)
        {
            return ExtendRental(CarRentalID, newReturnDate);
        }

        public static bool ReturnCar(int? carRentalID, DateTime actualReturnDate, int? createdByUserID)
        {
            return CarRentalsDataAccess.ReturnCar(carRentalID, actualReturnDate, createdByUserID);
        }

        public bool ReturnCar(DateTime actualReturnDate, int createdByUserID)
        {
            return ReturnCar(CarRentalID, actualReturnDate, createdByUserID);
        }

        public static decimal GetPaidAmount(int? carRentalID)
        {
            return CarRentalsDataAccess.GetPaidAmount(carRentalID);
        }

        public decimal GetPaidAmount()
        {
            return GetPaidAmount(CarRentalID);
        }

        private bool _CreateRental()
        {
            CarRentalID = CarRentalsDataAccess.RentCar(
                CarID,
                Deposit,
                PickupLocation,
                CreatedByUserID,
                PickupDate,
                ReturnDate,
                InitialPayment,
                PaymentMethod,
                CustomerID
            );

            return CarRentalID != null;
        }

        private bool _UpdateRental()
        {
            return CarRentalsDataAccess.UpdateRental(
                CarRentalID,
                CarID,
                Deposit,
                TotalPrice,
                PickupLocation,
                PickupDate,
                ReturnDate,
                CreatedByUserID
            );
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.Add:
                    if (_CreateRental())
                    {
                        _Mode = enMode.Update;
                        return true;
                    } else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateRental();
            }

            return false;
        }

        public bool HasCarReturned()
        {
            return clsRentalReturn.HasCarReturnedByCarRentalID(CarRentalID);
        }
    }
}
