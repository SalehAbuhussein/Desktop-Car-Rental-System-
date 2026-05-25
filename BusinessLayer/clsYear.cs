using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsYear
    {
        public enum enMode
        {
            Add,
            Update
        }

        public int? YearID { get; set; }
        public int? Year { get; set; }
        private enMode _Mode = enMode.Add;

        public clsYear()
        {
            _Mode = enMode.Add;
        }

        private clsYear(int? yearID, int? year)
        {
            _Mode = enMode.Update;
            YearID = yearID;
            Year = year;
        }

        public static DataTable FindYears(int pageNumber = 1, int rowsPerPage = 10)
        {
            return YearsDataAccess.FindYears(pageNumber, rowsPerPage);
        }

        public static clsYear Find(int? yearID)
        {
            int? year = null;

            if (YearsDataAccess.Find(yearID, ref year))
            {
                return new clsYear(yearID, year);
            }

            return null;
        }

        public static clsYear FindByYear(int? year)
        {
            int? yearID = null;

            if (YearsDataAccess.FindByYear(year, ref yearID))
            {
                return new clsYear(yearID, year);
            }

            return null;
        }

        public static bool IsYearExist(int? year)
        {
            return FindByYear(year) != null;
        }

        private bool _CreateYear()
        {
            YearID = YearsDataAccess.CreateYear(Year);

            return YearID.HasValue;
        }

        private bool _UpdateYear()
        {
            return YearsDataAccess.UpdateYear(YearID, Year);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.Add:
                    if (_CreateYear())
                    {
                        _Mode = enMode.Update;
                        return true;
                    } else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateYear();
            }

            return false;
        }
    }
}
