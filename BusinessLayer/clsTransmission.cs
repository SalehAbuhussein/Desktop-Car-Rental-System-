using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsTransmission
    {
        public enum enMode
        {
            Add,
            Update
        }
        public int? TransmissionID { get; set; }
        public string TransmissionName { get; set; }
        private enMode _Mode = enMode.Add;

        public clsTransmission()
        {
        }

        private clsTransmission(int? transmissionID, string transmissionName)
        {
            _Mode = enMode.Update;
            TransmissionID = transmissionID;
            TransmissionName = transmissionName;
        }

        public static DataTable FindTransmissions(int pageNumber = 1, int rowsPerPage = 10)
        {
            return TransmissionsDataAccess.FindTransmissions(pageNumber, rowsPerPage);
        }

        public static clsTransmission Find(int? transmissionID)
        {
            string transmissionName = string.Empty;

            if (TransmissionsDataAccess.Find(transmissionID, ref transmissionName))
            {
                return new clsTransmission(transmissionID, transmissionName);
            }

            return null;
        }

        public static clsTransmission FindByName(string transmission)
        {
            int? transmissionID = null;

            if (TransmissionsDataAccess.FindByName(transmission, ref transmissionID))
            {
                return new clsTransmission(transmissionID, transmission);
            }

            return null;
        }

        public static bool IsTransmissionExist(int? transmissionID)
        {
            return TransmissionsDataAccess.IsTransmissionExist(transmissionID);
        }

        public static bool IsTransmissionExist(string transmission)
        {
            return TransmissionsDataAccess.IsTransmissionExist(transmission);
        }

        private bool _CreateTransmission()
        {
            TransmissionID = TransmissionsDataAccess.CreateTransmission(TransmissionName);

            return TransmissionID.HasValue;
        }
        
        private bool _UpdateTransmission()
        {
            return TransmissionsDataAccess.UpdateTransmission(TransmissionID, TransmissionName);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.Add:
                    if (_CreateTransmission())
                    {
                        _Mode = enMode.Update;
                        return true;
                    } else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateTransmission();
            }

            return false;
        }
    }
}
