using DataAccessLAyer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{

    public class clsDriver
    {
        public int driverID {  get; set; }
        public int personID { get; set; }

        public clsPerson person { get; set; }
        public int createdbyuserID { get; set; }
        public DateTime createddate { get; set; }

        public clsDriver()
        {
            driverID = 0;
            personID = 0;
            createdbyuserID = 0;
            createddate = DateTime.Now;
        }
        clsDriver(int driverID, int personID, int createdbyuserID, DateTime createddate)
        {
            this.driverID = driverID;
            this.personID = personID;
            this.person = clsPerson.Find(personID);
            this.createdbyuserID = createdbyuserID;
            this.createddate = createddate;
        }

        public static int IsExistByPersonID(int personid)
        {
            return clsDriverDataAccess.IsExistByPersonID(personid) ;
        }

        public bool Save()
        {
            driverID = clsDriverDataAccess.Create(personID, createdbyuserID, createddate);
            return driverID !=0;
        }

        public static clsDriver Find(int personID_)
        {
            int peID = 0;
            int createdbyuserID = 0;
            DateTime createddate = DateTime.Now;
            if (clsDriverDataAccess.Find(personID_, ref peID, ref createdbyuserID, ref createddate))
                return new clsDriver(personID_, peID, createdbyuserID, createddate);
            else 
                return null;
        }
        public static clsDriver FindByPersonID(int peID)
        {
            int driverID = 0;
            int createdbyuserID = 0;
            DateTime createddate = DateTime.Now;
            if (clsDriverDataAccess.FindByPesonID(peID, ref driverID , ref createdbyuserID, ref createddate))
                return new clsDriver(driverID, peID, createdbyuserID, createddate);
            else
                return null;
        }
        public static DataTable GetAll()
        {
            return clsDriverDataAccess.GetAllRecord();
        }
    }
}
