using DataAccessLAyer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class clsApplications
    {
        enum enMode { AddNew, Update }
        public int applicationID { get; set; }
        public int PersonID { get; set; }
        public DateTime date { get; set; }
        public int ApplicationTypeID { get; set; }
        public int ApplicationStatus { get; set; }
       public clsPerson person { get; set; }
        public DateTime laststatusdate { get; set; }
        public double paidfees { get; set; }
        public int userid { get; set; }
        enMode mode = enMode.AddNew;

         clsApplications(int _applicationID,int personID, DateTime date, int applicationTypeID, int applicationStatus, DateTime laststatusdate, double paidfees, int userid)
        {
            this.applicationID= _applicationID;
            PersonID = personID;
            this.date = date;
            ApplicationTypeID = applicationTypeID;
            ApplicationStatus = applicationStatus;
            this.laststatusdate = laststatusdate;
            this.paidfees = paidfees;
            this.userid = userid;
            this.person = clsPerson.Find(personID);
            mode = enMode.Update;
        }
        public clsApplications()
        {
            PersonID = 0;
            this.date = DateTime.Now;
            ApplicationTypeID = 0;
            ApplicationStatus = 1;
            this.laststatusdate = DateTime.Now;
            this.paidfees = 0.0;
            this.userid = 0;
            person = null;
            mode = enMode.AddNew;
        }
        bool _Addnew()
        {
            applicationID = clsApplicationDataAccess.AddNew(PersonID, date,ApplicationTypeID,ApplicationStatus,laststatusdate,paidfees,userid);
            return applicationID != 0;
        }
       
        public static bool Delete(int appID)
        {
            return clsApplicationDataAccess.Delete(appID);
        }
        public bool CompleteApplication()
        {
            //this function is to change the application to new status  to 3 , which mean completed , we use this function when the driver pass 3 tests
            return clsApplicationDataAccess.UpdateTheStatus(applicationID);
        }
        public bool Save()
        {
            switch(mode)
            {
                case enMode.AddNew:mode = enMode.Update;return _Addnew();
                case enMode.Update:return false;
                default:return false;
            }
        }
        public static bool CancelApplication(int AppId)
        {
            return clsApplicationDataAccess.CancelApplication(AppId);
        }
        public static clsApplications Find(int AppId,ref string status)
        {
           
            int PersonID = 0;
            DateTime date =DateTime.Now;
            int ApplicationTypeID = 0;
            
            DateTime laststatusdate = DateTime.Now;
            double paidfees = 0;
            int userid = 0;
            if (clsApplicationDataAccess.Find(AppId, ref PersonID,ref date, ref ApplicationTypeID,ref status, ref laststatusdate, ref paidfees, ref userid))
                return new clsApplications(AppId,PersonID, date, ApplicationTypeID, -1, laststatusdate, paidfees, userid);
            else
                return null;
        }
        public static clsApplications Find(int AppId)
        {

            int PersonID = 0;
            DateTime date = DateTime.Now;
            int ApplicationTypeID = 0;
            int status = 0; 
            DateTime laststatusdate = DateTime.Now;
            double paidfees = 0;
            int userid = 0;
            if (clsApplicationDataAccess.Find(AppId, ref PersonID, ref date, ref ApplicationTypeID, ref status, ref laststatusdate, ref paidfees, ref userid))
                return new clsApplications(AppId,PersonID, date, ApplicationTypeID, status, laststatusdate, paidfees, userid);
            else
                return null;
        }



    }
}
