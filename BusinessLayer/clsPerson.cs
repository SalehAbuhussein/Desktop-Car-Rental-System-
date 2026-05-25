using DataAccessLayer;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsPerson
    {
        public enum enMode
        {
            Add,
            Update,
        }

        public int? PersonID { get; set; }
        public string Firstname { get; set; }
        public string Secondname { get; set; }
        public string Thirdname { get; set; }
        public string Lastname { get; set; }
        public string Fullname
        {
            get
            {
                return string.Join(" ", new[]
                {
                    Firstname,
                    Secondname,
                    Thirdname,
                    Lastname
                }.Where(name => !string.IsNullOrWhiteSpace(name)));
            }
        }
        public string ShortName
        {
            get
            {
                return $"{Firstname} {Lastname}";
            }
        }
        public byte Gender { get; set; }
        public string GenderName
        {
            get
            {
                return Gender == 0 ? "Male" : "Female";
            }
        }
        public string Address { get; set; }
        public string NationalNumber { get; set; } // Include it in the add/update
        private enMode _Mode;

        public clsPerson()
        {
            _Mode = enMode.Add;
        }

        private clsPerson(
            int personID, 
            string firstname, 
            string secondname,
            string thirdname,
            string lastname,
            byte gender,
            string address,
            string nationalNumber
        )
        {
            _Mode = enMode.Update;
            Firstname = firstname;
            Secondname = secondname;
            Thirdname = thirdname;
            Lastname = lastname;
            Gender = gender;
            Address = address;
            NationalNumber = nationalNumber;
        }

        public static clsPerson FindPerson(int? personID)
        {
            string firstname = string.Empty;
            string secondname = string.Empty;
            string thirdname = string.Empty;
            string lastname = string.Empty;
            byte gender = byte.MinValue;
            string address = string.Empty;
            string nationalNumber = string.Empty;

            if (personID is null)
            {
                return null;
            }

            if (PeopleDataAccess.Find(personID ?? -1, ref firstname, ref secondname, ref thirdname, ref lastname, ref gender, ref address, ref nationalNumber))
            {
                return new clsPerson(personID ?? -1, firstname, secondname, thirdname, lastname, gender, address, nationalNumber);
            }

            return null;
        }

        public static clsPerson FindByNationalNumber(string nationalNumber)
        {
            int personID = 0; 
            string firstname = string.Empty;
            string secondname = string.Empty;
            string thirdname = string.Empty;
            string lastname = string.Empty;
            byte gender = byte.MinValue;
            string address = string.Empty;

            if (string.IsNullOrEmpty(nationalNumber))
            {
                return null;
            }

            if (PeopleDataAccess.FindByNationalNumber(nationalNumber, ref personID, ref firstname, ref secondname, ref thirdname, ref lastname, ref gender, ref address, ref nationalNumber))
            {
                return new clsPerson(personID, firstname, secondname, thirdname, lastname, gender, address, nationalNumber);
            }

            return null;
        }

        public static bool IsCustomer(int? personID)
        {
            return PeopleDataAccess.IsCustomer(personID);
        }

        public static bool IsUniqueByNationalNumber(string nationalNumber)
        {
            if (string.IsNullOrEmpty(nationalNumber))
            {
                return false;
            }

            return FindByNationalNumber(nationalNumber) == null; 
        }

        public bool IsCustomer()
        {
            return IsCustomer(PersonID);
        }

        private bool _AddPerson()
        {
            PersonID = PeopleDataAccess.AddPerson(Firstname, Secondname, Thirdname, Lastname, Gender, Address, NationalNumber);
            return PersonID != null;
        }

        private bool _UpdatePerson()
        {
            return PeopleDataAccess.UpdatePerson(PersonID, Firstname, Secondname, Thirdname, Lastname, Gender, Address);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.Add:
                    if (_AddPerson())
                    {
                        _Mode = enMode.Update;
                        return true;
                    } else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdatePerson();
            }

            return false;
        }
    }
}
