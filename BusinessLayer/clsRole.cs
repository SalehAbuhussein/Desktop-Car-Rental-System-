using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsRole
    {
        public enum enMode
        {
            Add,
            Update
        }
        public int? RoleID { get; set; }
        public string RoleName { get; set; }
        public bool Active { get; set; }
        private enMode _Mode = enMode.Add;
        
        public clsRole()
        {
            _Mode = enMode.Add;
        }

        private clsRole(int? id, string name, bool active)
        {
            _Mode = enMode.Update;
            RoleID = id;
            RoleName = name;
            Active = active;
        }

        public static DataTable FindAll()
        {
            return RolesDataAccess.FindAll();
        }

        public static clsRole Find(int? id)
        {
            string roleName = string.Empty;
            bool active = false;

            if (RolesDataAccess.Find(id, ref roleName, ref active))
            {
                return new clsRole(id, roleName, active);
            }

            return null;
        }

        public static clsRole FindByName(string roleName)
        {
            int? roleID = null;
            bool active = false;

            if (RolesDataAccess.FindByName(roleName, ref roleID, ref active))
            {
                return new clsRole(roleID, roleName, active);
            }

            return null;
        }

        public static bool IsRoleExist(int? roleID)
        {
            return RolesDataAccess.IsRoleExist(roleID);
        }

        public static bool IsRoleExist(string roleName)
        {
            return RolesDataAccess.IsRoleExist(roleName);
        }

        public int? _CreateRole()
        {
            RoleID = RolesDataAccess.CreateRole(RoleName);

            return RoleID;
        }

        private bool _UpdateRole()
        {
            return RolesDataAccess.UpdateRole(RoleID, RoleName, Active);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.Add:
                    if (_CreateRole() != null)
                    {
                        _Mode = enMode.Update;
                        return true;
                    } else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateRole();
            }

            return false;
        }

        public static bool DeleteRole(int? roleID)
        {
            return RolesDataAccess.DeleteRole(roleID);
        }

        public static bool DeleteRole(string roleName)
        {
            return RolesDataAccess.DeleteRole(roleName);
        }
    }
}
