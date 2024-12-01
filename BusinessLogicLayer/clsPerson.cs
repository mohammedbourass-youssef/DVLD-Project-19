using DataAccessLAyer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class clsPerson
    {
        public int personID { get; set; }
        public string nationalNO { get; set; }
        public string firstname { get; set; }

        
        public string secondname { get; set; }
        public string thirdname { get; set; }
        public string lastname { get; set; }
        public DateTime dateofbirth { get; set; }
        public byte gender { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public int countryID { get; set; }
        public string imagepath { get; set; }
        enum enMode { AddNew,Update}
        enMode _mode; 
        bool _AddNew()
        {
            personID= clsPeopleDataAccess.AddNewPerson(nationalNO, firstname, secondname, thirdname, lastname, dateofbirth, gender, address, phone, email, countryID, imagepath);
            return personID != 0;
        }
        bool _Update()
        {
            return clsPeopleDataAccess.Update(personID, nationalNO, firstname, secondname, thirdname, lastname, dateofbirth, gender, address, phone, email, countryID, imagepath);
        }
        public clsPerson()
        {
            _mode = enMode.AddNew;
            nationalNO = "";
            firstname = "";
            secondname = "";
            thirdname = "";
            lastname = "";
            dateofbirth = DateTime.Now;
            gender = 0;
            address = string.Empty;
            phone = string.Empty;
            email = string.Empty;
            countryID = 0;
            imagepath = string.Empty;
        }
          clsPerson(int personid,string nationalNO, string firstname, string secondname, string thirdname, string lastname, DateTime dateofbirth, byte gender, string address, string phone, string email, int countryID, string imagepath)
        {
            this.personID = personid;
            this.nationalNO = nationalNO;
            this.firstname = firstname;
            this.secondname = secondname;
            this.thirdname = thirdname;
            this.lastname = lastname;
            this.dateofbirth = dateofbirth;
            this.gender = gender;
            this.address = address;
            this.phone = phone;
            this.email = email;
            this.countryID = countryID;
            this.imagepath = imagepath;
            _mode = enMode.Update;
        }

        
        static public DataTable PeopleList()
        {
            return clsPeopleDataAccess.GetPeopleList();
        }
        static public DataTable PeopleListWithCountriesName()
        {
            return clsPeopleDataAccess.GetPeopleListWithCountryName();
        }
        public bool Save()
        {
            switch (_mode)
            {
                case enMode.Update:return _Update();
                case enMode.AddNew :_mode = enMode.Update; return _AddNew();
                default: return false;
            }
        }

        public bool Delete()
        {

            return clsPeopleDataAccess.Delete(personID);
        }
        static public bool IsExist(int personID)
        {
            return clsPeopleDataAccess.IsExist(personID);
        }
        static public bool IsExist(string nationnalNo)
        {
            return clsPeopleDataAccess.IsExistByNationnalNumber(nationnalNo);
        }
        static public clsPerson Find(int personID)
        {
            
            string nationalNO = string.Empty;
            string firstname = string.Empty;
            string secondname =string.Empty;
            string thirdname =string.Empty;
            string lastname =string.Empty;
            DateTime dateofbirth = DateTime.MinValue;
            byte gender = 0;
            string address =string.Empty;
            string phone = string.Empty;
            string email = string.Empty;
            int countryID =0;
            string imagepath = string.Empty;
            if (clsPeopleDataAccess.Find(personID, ref nationalNO, ref firstname, ref secondname, ref thirdname, ref lastname, ref dateofbirth, ref gender, ref address, ref phone, ref email, ref countryID, ref imagepath))
            {
                return new clsPerson(personID, nationalNO,firstname, secondname, thirdname, lastname, dateofbirth, gender, address, phone, email, countryID, imagepath);
            }
            else
                return null; 
        }
        static public clsPerson Find(string nationalNO)
        {

            int personID = 0;
            string firstname = string.Empty;
            string secondname = string.Empty;
            string thirdname = string.Empty;
            string lastname = string.Empty;
            DateTime dateofbirth = DateTime.MinValue;
            byte gender = 0;
            string address = string.Empty;
            string phone = string.Empty;
            string email = string.Empty;
            int countryID = 0;
            string imagepath = string.Empty;
            if (clsPeopleDataAccess.Find(nationalNO, ref personID, ref firstname, ref secondname, ref thirdname, ref lastname, ref dateofbirth, ref gender, ref address, ref phone, ref email, ref countryID, ref imagepath))
            {
                return new clsPerson(personID, nationalNO, firstname, secondname, thirdname, lastname, dateofbirth, gender, address, phone, email, countryID, imagepath);
            }
            else
                return null;
        }

        static public clsPerson FindByFirstName(string firstname)
        {

            int personID = 0;
            string nationalNO = string.Empty;
            string secondname = string.Empty;
            string thirdname = string.Empty;
            string lastname = string.Empty;
            DateTime dateofbirth = DateTime.MinValue;
            byte gender = 0;
            string address = string.Empty;
            string phone = string.Empty;
            string email = string.Empty;
            int countryID = 0;
            string imagepath = string.Empty;
            if (clsPeopleDataAccess.Find(firstname ,ref nationalNO, ref personID,ref secondname, ref thirdname, ref lastname, ref dateofbirth, ref gender, ref address, ref phone, ref email, ref countryID, ref imagepath))
            {
                return new clsPerson(personID, nationalNO, firstname, secondname, thirdname, lastname, dateofbirth, gender, address, phone, email, countryID, imagepath);
            }
            else
                return null;
        }
        static public clsPerson FindByLastName(string lastname)
        {

            int personID = 0;
            string nationalNO = string.Empty;
            string secondname = string.Empty;
            string thirdname = string.Empty;
            string firstname = string.Empty;
            DateTime dateofbirth = DateTime.MinValue;
            byte gender = 0;
            string address = string.Empty;
            string phone = string.Empty;
            string email = string.Empty;
            int countryID = 0;
            string imagepath = string.Empty;
            if (clsPeopleDataAccess.Find(lastname, ref nationalNO, ref personID, ref secondname, ref thirdname, ref firstname, ref dateofbirth, ref gender, ref address, ref phone, ref email, ref countryID, ref imagepath))
            {
                return new clsPerson(personID, nationalNO, firstname, secondname, thirdname, lastname, dateofbirth, gender, address, phone, email, countryID, imagepath);
            }
            else
                return null;
        }

    }
}
