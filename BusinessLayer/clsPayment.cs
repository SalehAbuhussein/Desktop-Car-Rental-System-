using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsPayment
    {
        public enum enMode
        {
            Add,
            Update
        }
        public int PaymentID { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime CreatedAt { get; set; }
        private enMode _Mode = enMode.Add;

        public clsPayment()
        {
            _Mode = enMode.Add;
        }

        private clsPayment(int paymentID, decimal amount, string paymentMethod, DateTime createdAt)
        {
            _Mode = enMode.Update;
            PaymentID = paymentID;
            Amount = amount;
            PaymentMethod = paymentMethod;
            CreatedAt = createdAt;
        }

        public static clsPayment FindPayment(int paymentID)
        {
            decimal amount = decimal.MinValue;
            string paymentMethod = string.Empty;
            DateTime createdAt = DateTime.MinValue;

            if (PaymentsDataAccess.FindPayment(paymentID, ref amount, ref paymentMethod, ref createdAt))
            {
                return new clsPayment(paymentID, amount, paymentMethod, createdAt);
            }

            return null;
        }
    }
}
