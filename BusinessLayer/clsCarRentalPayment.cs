using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsCarRentalPayment : clsPayment
    {
        public enum enMode
        {
            Add,
            Update
        }
        public int? ID { get; set; }
        public int CarRentalID { get; set; }
        public clsCarRental CarRentalInfo { get; set; }
        public decimal PaidAmount { get; set; }
        public string Status { get; set; }
        private enMode _Mode = enMode.Add;

        public clsCarRentalPayment()
        {
            _Mode = enMode.Add;
        }

        private clsCarRentalPayment(int? carRentalPaymentID, int carRentalID, int paymentID, decimal paidAmount, string status)
        {
            _Mode = enMode.Update;
            ID = carRentalPaymentID;
            CarRentalID = carRentalID;
            PaidAmount = paidAmount;
            Status = status;

            base.PaymentID = paymentID;

            clsPayment payment = clsPayment.FindPayment(paymentID);

            if (payment != null)
            {
                base.Amount = payment.Amount;
                base.PaymentMethod = payment.PaymentMethod;
                base.CreatedAt = payment.CreatedAt;
            }
        }

        public static DataTable GetRentalPaymentsData(int pageNumber = 1, int rowsPerPage = 10)
        {
            return CarRentalPaymentsDataAccess.GetRentalPaymentsData(pageNumber, rowsPerPage);
        }

        public static DataTable GetRentalPaymentsDataByStatus(int pageNumber = 1, int rowsPerPage = 10, string status = "Active")
        {
            return CarRentalPaymentsDataAccess.GetRentalPaymentsDataByStatus(pageNumber, rowsPerPage, status);
        }

        public static DataTable GetRentalPaymentsDataByType(int pageNumber = 1, int rowsPerPage = 10, string type = "Initial")
        {
            return CarRentalPaymentsDataAccess.GetRentalPaymentsDataByType(pageNumber, rowsPerPage, type);
        }

        public static DataTable GetRentalPaymentsDataByCarRentalID(int? carRentalID, int pageNumber = 1, int rowsPerPage = 10)
        {
            return CarRentalPaymentsDataAccess.GetRentalPaymentsDataByCarRentalID(carRentalID, pageNumber, rowsPerPage);
        }

        public static DataTable GetRentalPaymentsDataByCarRentalIDByStatus(int? carRentalID, int pageNumber = 1, int rowsPerPage = 10, string status = "Active")
        {
            return CarRentalPaymentsDataAccess.GetRentalPaymentsDataByCarRentalIDByStatus(carRentalID, pageNumber, rowsPerPage, status);
        }

        public static DataTable GetRentalPaymentsDataByCarRentalIDByType(int? carRentalID, int pageNumber = 1, int rowsPerPage = 10, string type = "Initial")
        {
            return CarRentalPaymentsDataAccess.GetRentalPaymentsDataByCarRentalIDByType(carRentalID, pageNumber, rowsPerPage, type);
        }

        public static decimal GetTotalPaid()
        {
            return CarRentalPaymentsDataAccess.GetTotalPaid();
        }

        public static decimal GetTotalRefunds()
        {
            return CarRentalPaymentsDataAccess.GetTotalRefunds();
        }

        public static decimal GetNetRevenue()
        {
            return CarRentalPaymentsDataAccess.GetNetRevenue();
        }

        public static clsCarRentalPayment FindByID(int? carRentalPaymentID)
        {
            int carRentalID = 0;
            int paymentID = 0;
            decimal paidAmount = 0;
            string status = string.Empty;

            if (CarRentalPaymentsDataAccess.FindByID(carRentalPaymentID, ref carRentalID, ref paymentID, ref paidAmount, ref status))
            {
                return new clsCarRentalPayment(carRentalPaymentID, carRentalID, paymentID, paidAmount, status);
            }

            return null;
        }
    }
}
