using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsModel
    {
        public enum enMode
        {
            Add,
            Update,
        }
        public int? ModelID { get; set; }
        public string ModelName { get; set; }
        public int? MakeID { get; set; }
        public clsMake MakeInfo { get; set; }
        private enMode _Mode = enMode.Add;

        public clsModel()
        {
            _Mode = enMode.Add;
        }

        private clsModel(int? modelID, string modelName, int? makeID)
        {
            _Mode = enMode.Update;
            ModelID = modelID;
            ModelName = modelName;
            MakeID = makeID;
            MakeInfo = clsMake.Find(makeID);
        }

        public static DataTable FindModels(int pageNumber = 1, int rowsPerPage = 10)
        {
            return ModelsDataAccess.FindModels(pageNumber, rowsPerPage);
        }

        public static DataTable FindModelsByMakeID(int? makeID)
        {
            return ModelsDataAccess.FindModelsByMakeID(makeID);
        }

        public static DataTable FindModelsByMake(string make)
        {
            return ModelsDataAccess.FindModelsByMake(make);
        }

        public static clsModel Find(int? modelID)
        {
            string modelName = string.Empty;
            int? makeID = null;

            if (ModelsDataAccess.Find(modelID, ref modelName, ref makeID))
            {
                return new clsModel(modelID, modelName, makeID);
            }

            return null;
        }

        public static clsModel FindByName(string modelName)
        {
            int? makeID = null;
            int? modelID = null;

            if (ModelsDataAccess.FindByName(modelName, ref modelID, ref makeID))
            {
                return new clsModel(modelID, modelName, makeID);
            }

            return null;
        }

        private bool _AddModel()
        {
            ModelID = ModelsDataAccess.CreateModel(ModelName, MakeID);
            return ModelID != null;
        }

        private bool _UpdateModel()
        {
            return ModelsDataAccess.UpdateModel(ModelID, ModelName, MakeID);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.Add:
                    if (_AddModel())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateModel();
            }

            return false;
        }
    }
}
