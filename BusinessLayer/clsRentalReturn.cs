using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsRentalReturn
    {
        public enum enMode
        {
            Add,
            Update
        }

        public int? ID { get; set; }
        public int? CarRentalID { get; set; }
        public clsCarRental CarRentalInfo { get; set; }
        public DateTime ReturnDate { get; set; }
        public int? CreatedByUserID { get; set; }
        public clsUser CreatedByUserInfo { get; set; }
        private enMode _Mode = enMode.Add;

        public clsRentalReturn()
        {
            _Mode = enMode.Add;
        }

        private clsRentalReturn(
            int? id, 
            int? carRentalID, 
            DateTime returnDate, 
            int? createdByUserID
        )
        {
            _Mode = enMode.Update;
            CarRentalID = carRentalID;
            CarRentalInfo = clsCarRental.Find(id);
            ReturnDate = returnDate;
            CreatedByUserID = createdByUserID;
            CreatedByUserInfo = clsUser.FindUser(createdByUserID);
        }

        public static clsRentalReturn FindByCarRentalID(int? carRentalID)
        {
            int? rentalReturnID = null;
            DateTime returnDate = DateTime.MinValue;
            int? createdByUserID = null;
            DateTime createdAt = DateTime.MinValue;

            if (RentalReturnsDataAccess.FindByCarRentalID(carRentalID, ref rentalReturnID, ref returnDate, ref createdByUserID, ref createdAt))
            {
                return new clsRentalReturn(rentalReturnID, carRentalID, returnDate, createdByUserID);
            }

            return null;
        }
    
        public static bool HasCarReturnedByCarRentalID(int? carRentalID)
        {
            return FindByCarRentalID(carRentalID) != null;
        }
    }
}
