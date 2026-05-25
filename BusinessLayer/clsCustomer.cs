using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsCustomer : clsPerson
    {
        public enum enMode
        {
            Add,
            Update
        } 

        public int? ID { get; set; }
        public string LicenseNumber { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        private enMode _Mode = enMode.Add;

        public clsCustomer()
        {
            _Mode = enMode.Add;
        }

        private clsCustomer(int? id, int? personId, string licenseNumber, string status, DateTime createdAt)
        {
            _Mode = enMode.Update;
            ID = id;
            LicenseNumber = licenseNumber;
            Status = status;
            CreatedAt = createdAt;

            clsPerson person = clsPerson.FindPerson(personId);

            if (person != null)
            {
                base.PersonID = person.PersonID;
                base.Firstname = person.Firstname;
                base.Secondname = person.Secondname;
                base.Thirdname = person.Thirdname;
                base.Lastname = person.Lastname;
                base.Gender = person.Gender;
                base.NationalNumber = person.NationalNumber;
                base.Address = person.Address;
            }
        }

        public static DataTable GetCustomersData(int pageNumber = 1, int rowsPerPage = 10)
        {
            return CustomersDataAccess.GetCustomersData(pageNumber, rowsPerPage);
        }

        public static clsCustomer Find(int? customerID)
        {
            int? personID = null;
            string licenseNumber = string.Empty;
            string status = string.Empty;
            DateTime createdAt = DateTime.MinValue;

            if (CustomersDataAccess.Find(customerID, ref personID, ref licenseNumber, ref status, ref createdAt))
            {
                return new clsCustomer(customerID, personID, licenseNumber, status, createdAt);
            }

            return null;
        }

        public static clsCustomer FindByLicenseNumber(string licenseNumber)
        {
            int? customerID = null;
            int? personID = null;
            string status = string.Empty;
            DateTime createdAt = DateTime.MinValue;

            if (string.IsNullOrEmpty(licenseNumber))
            {
                return null;
            }

            if (CustomersDataAccess.FindByLicenseNumber(licenseNumber, ref customerID, ref personID, ref status, ref createdAt))
            {
                return new clsCustomer(customerID, personID, licenseNumber, status, createdAt);
            }

            return null;
        }

        public static bool IsUniqueByLicenseNumber(string licenseNumber)
        {
            return FindByLicenseNumber(licenseNumber) == null;
        }

        public static bool DeleteCustomer(int? customerID)
        {
            return CustomersDataAccess.DeleteCustomer(customerID);
        }

        private bool _CreateCustomer()
        {
            ID = CustomersDataAccess.CreateCustomer(PersonID, LicenseNumber);
            return ID != null;
        }

        private bool _UpdateCustomer()
        {
            return CustomersDataAccess.UpdateCustomer(ID, PersonID, LicenseNumber, Status);
        }

        public new bool Save()
        {
            if (!base.Save())
            {
                return false;
            }

            switch (_Mode)
            {
                case enMode.Add:
                    if (_CreateCustomer())
                    {
                        _Mode = enMode.Update;
                        return true;
                    } else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateCustomer();
            }

            return false;
        }

        public static int GetCustomersCount()
        {
            return CustomersDataAccess.GetCustomersCount();
        }

        public static int GetAvailableCustomersCount()
        {
            return CustomersDataAccess.GetAvailableCustomersCount();
        }
    }
}
