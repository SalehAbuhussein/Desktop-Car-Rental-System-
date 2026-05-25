using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsFuelType
    {
        public enum enMode
        {
            Add,
            Update
        }
        public int? FuelTypeID { get; set; }
        public string FuelTypeName { get; set; }
        private enMode _Mode = enMode.Add;

        public clsFuelType()
        {
        }

        private clsFuelType(int? fuelTypeID, string fuelTypeName)
        {
            _Mode = enMode.Update;
            FuelTypeID = fuelTypeID;
            FuelTypeName = fuelTypeName;
        }

        public static DataTable FindFuelTypes(int pageNumber = 1, int rowsPerPage = 10)
        {
            return FuelTypesDataAccess.FindFuelTypes(pageNumber, rowsPerPage);
        }

        public static clsFuelType Find(int? fuelTypeID)
        {
            string fuelTypeName = string.Empty;

            if (FuelTypesDataAccess.Find(fuelTypeID, ref fuelTypeName))
            {
                return new clsFuelType(fuelTypeID, fuelTypeName);
            }

            return null;
        }

        public static clsFuelType FindByName(string fuelTypeName)
        {
            int? fuelTypeID = null;

            if (FuelTypesDataAccess.FindByName(fuelTypeName, ref fuelTypeID))
            {
                return new clsFuelType(fuelTypeID, fuelTypeName);
            }

            return null;
        }

        public static bool IsFuelTypeExist(int? fuelTypeID)
        {
            return FuelTypesDataAccess.IsFuelTypeExist(fuelTypeID);
        }

        public static bool IsFuelTypeExist(string fuelTypeName)
        {
            return FuelTypesDataAccess.IsFuelTypeExist(fuelTypeName);
        }

        private bool _CreateFuelType()
        {
            FuelTypeID = FuelTypesDataAccess.CreateFuelType(FuelTypeName);

            return FuelTypeID.HasValue;
        }

        private bool _UpdateFuelType()
        {
            return FuelTypesDataAccess.UpdateFuelType(FuelTypeID, FuelTypeName);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.Add:
                    if (_CreateFuelType())
                    {
                        _Mode = enMode.Update;
                        return true;
                    } else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateFuelType();
            }

            return false;
        }
    }
}
