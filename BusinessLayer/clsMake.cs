using DataAccessLayer;
using System.Data;

namespace BusinessLayer
{
    public class clsMake
    {
        public enum enMode
        {
            Add,
            Update,
        }

        public int? MakeID { get; set; }
        public string MakeName { get; set; }
        public bool Active { get; set; }
        private enMode _Mode = enMode.Add;

        public clsMake()
        {
            _Mode = enMode.Add;
        }

        private clsMake(int? makeID, string makeName, bool active)
        {
            _Mode = enMode.Update;
            MakeID = makeID;
            MakeName = makeName;
            Active = active;
        }

        public static DataTable FindMakes(int pageNumber = 1, int rowsPerPage = 10)
        {
            return MakesDataAccess.FindMakes(pageNumber, rowsPerPage);
        }

        public DataTable FindModels()
        {
            return clsModel.FindModelsByMakeID(MakeID);
        }

        public static clsMake Find(int? makeID)
        {
            string makeName = string.Empty;
            bool active = false;

            if (MakesDataAccess.Find(makeID, ref makeName, ref active))
            {
                return new clsMake(makeID, makeName, active);
            }

            return null;
        }

        public static bool IsMakeExist(int? makeID)
        {
            return Find(makeID) != null;
        }

        public static clsMake FindByName(string makeName)
        {
            int? makeID = null;
            bool active = false;

            if (MakesDataAccess.FindByName(makeName, ref makeID, ref active))
            {
                return new clsMake(makeID, makeName, active);
            }

            return null;
        }

        public static bool DeleteMake(int? makeID)
        {
            return MakesDataAccess.DeleteMake(makeID);
        }

        private bool _AddMake()
        {
            MakeID = MakesDataAccess.CreateMake(MakeName);

            return MakeID != null;
        }

        private bool _UpdateMake()
        {
            return MakesDataAccess.UpdateMake(MakeID, MakeName, Active);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.Add:
                    if (_AddMake())
                    {
                        _Mode = enMode.Update;
                        return true;
                    } else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateMake();
            }

            return false;
        }
    }
}
