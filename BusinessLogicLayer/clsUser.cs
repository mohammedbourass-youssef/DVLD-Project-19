using System;
using System.Collections.Generic;
using DataAccessLAyer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Security.Cryptography;

namespace BusinessLogicLayer
{
    public  class clsUser 
    {
        public int UserID { get; set; }
        public string password {  get; set; }
        public string username {  get; set; }
        public bool IsActive { get; set; }
        public int personID { get; set; }
        enum enMode { Addnew,Update}
        enMode _mode = enMode.Addnew;
        bool _AddNew()
        {
            UserID = clsUserDataAccees.Create(username, password,personID,IsActive);
            return UserID != 0;
        }
        bool _Update()
        {
            return clsUserDataAccees.Update(UserID,password,username, IsActive);
        }
        public clsUser()
        {
            
            password = string.Empty;
            username = string.Empty;
            personID = 0;
            _mode = enMode.Addnew;
        }
        clsUser(int userid, string password, string username, int personID,bool IsActive)
        {
            this.UserID = userid;
            this.password = password;
            this.username = username;
            this.personID = personID;
            this.IsActive = IsActive;
            _mode = enMode.Update;
        }

        public static DataTable GetAllUsers()
        {
            return clsUserDataAccees.GetAllUsers();
        }
        public static bool IsExistByPersonID(int personid)
        {
            return clsUserDataAccees.IsExistByPersonID(personid);
        }
        public static bool IsExistByUserName(string username)
        {
            return clsUserDataAccees.IsExist(username);
        }
        public bool Save()
        {
            switch(_mode)
            {
                case enMode.Addnew:_mode = enMode.Update;return _AddNew();
                case enMode.Update: return _Update();
                default : return false;
            }
        }

        static public clsUser Find(int userid)
        {
             
             string password = string.Empty;
             string username  = string.Empty;
             int personid = 0;
             bool isactive= false;
            if (clsUserDataAccees.Find(userid, ref password, ref username, ref personid,ref isactive))
            {
                return new clsUser(userid, password, username, personid,isactive);
            }
            else
                return null;
        }
        static public clsUser Find(string username)
        {

            string password = string.Empty;
            int userid = 0;
            int personid = 0;
            bool isactive = false;
            if (clsUserDataAccees.Find(ref userid, ref password,  username, ref personid, ref isactive))
            {
                return new clsUser(userid, password, username, personid, isactive);
            }
            else
                return null;
        }

        static public bool Delete(int userid)
        {
            return clsUserDataAccees.Delete(userid);
        }

    }
}
