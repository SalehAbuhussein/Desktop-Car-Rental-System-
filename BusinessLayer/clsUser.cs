using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsUser : clsPerson
    {
        public new enum enMode
        {
            Add,
            Update,
        }

        public int? UserID { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public bool Active { get; set; }
        public int? RoleID { get; set; }
        public clsRole RoleInfo { get; set; }
        private enMode _Mode;

        public clsUser()
        {
            _Mode = enMode.Add;
            UserID = null;
            Username = string.Empty;
            Active = false;
            PersonID = null;
        }

        private clsUser(
            int? personId,
            string firstname,
            string secondname,
            string thirdname,
            string lastname,
            byte gender,
            string address,
            int? userID,
            string username, 
            string passwordHash, 
            bool active, 
            int? personID,
            int? roleID
        )
        {
            base.PersonID = personID;
            base.Firstname = firstname;
            base.Secondname = secondname;
            base.Thirdname = thirdname;
            base.Lastname = lastname;
            base.Gender = gender;
            base.Address = address;

            _Mode = enMode.Update;
            UserID = userID;
            Username = username;
            PasswordHash = passwordHash;
            Active = active;
            PersonID = personID;
            RoleID = roleID;
            RoleInfo = clsRole.Find(RoleID);
        }

        public static DataTable FindUsers(int pageNumber = 1, int rowsPerPage = 10)
        {
            return UsersDataAccess.FindUsers(pageNumber, rowsPerPage);
        }

        public static clsUser FindUser(int? userID)
        {
            string username = string.Empty;
            string passwordHash = string.Empty;
            bool active = false;
            int? personID = null;
            int? roleID = null;

            if (userID == null)
            {
                return null;
            }

            if (UsersDataAccess.Find(userID, ref username, ref passwordHash, ref active, ref personID, ref roleID))
            {
                clsPerson person = clsPerson.FindPerson(personID);

                return new clsUser(
                    person.PersonID,
                    person.Firstname,
                    person.Secondname,
                    person.Thirdname,
                    person.Lastname,
                    person.Gender,
                    person.Address,
                    userID,
                    username, 
                    passwordHash, 
                    active, 
                    personID,
                    roleID
                );
            }

            return null;
        }

        public static clsUser FindByUsernameAndPassword(string username, string password)
        {
            int? userID = null;
            int? personID = null;
            int? roleID = null;
            bool active = false;

            if (string.IsNullOrEmpty(username.Trim()) || string.IsNullOrEmpty(password.Trim()))
            {
                return null;
            }

            if (UsersDataAccess.FindByUsernameAndPassword(username, password, ref userID, ref active, ref personID, ref roleID))
            {
                clsPerson person = clsPerson.FindPerson(personID);

                return new clsUser(
                    person.PersonID,
                    person.Firstname,
                    person.Secondname,
                    person.Thirdname,
                    person.Lastname,
                    person.Gender,
                    person.Address,
                    userID, 
                    username, 
                    password, 
                    active, 
                    personID,
                    roleID
                );
            }

            return null;
        }

        public static clsUser FindActiveByUsernameAndPassword(string username, string password)
        {
            clsUser user = FindByUsernameAndPassword(username, password);
            if (user.Active)
            {
                return user;
            }

            return null;
        }

        public static bool DeleteUser(int? userID)
        {
            return UsersDataAccess.DeleteUser(userID);
        }

        private bool _CreateUser()
        {
            this.UserID = UsersDataAccess.CreateUser(Username, PasswordHash, PersonID);
            return this.UserID != null;
        }

        private bool _UpdateUser()
        {
            return UsersDataAccess.UpdateUser(UserID, Username, PasswordHash, PersonID, Active);
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
                    if (_CreateUser())
                    {
                        _Mode = enMode.Update;
                        return true;
                    } else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateUser();
            }

            return false;
        }
    }
}
