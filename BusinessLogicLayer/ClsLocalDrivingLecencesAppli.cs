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
    public class ClsLocalDrivingLecencesAppli
    {
        public int LocalDrivingLecencesID { get; set; }
        public int applicationID { get; set; }
        public clsApplications applications { get; set; }
        public clsClassesTypes licenseclass {  get; set; }

        public int licenseClassID { get; set; }

        public ClsLocalDrivingLecencesAppli()
        {
            LocalDrivingLecencesID = 0;
            applicationID = 0;
            licenseClassID = 0;
        }
         ClsLocalDrivingLecencesAppli(int localdrID,int appID,int licenclassID)
        {
            LocalDrivingLecencesID = localdrID;
            applicationID = appID;
            licenseClassID = licenclassID;
            licenseclass = clsClassesTypes.Find(licenclassID);
            applications = clsApplications.Find(appID);
        }
        bool _AddNew()
        {
            LocalDrivingLecencesID = clsLocalDrivingLicencesApplicationDataAccess.AddNewPerson(applicationID, licenseClassID);  
            return LocalDrivingLecencesID !=0;
        }
        public static DataTable GetAllRecord()
        {
            return clsLocalDrivingLicencesApplicationDataAccess.GetAllRcord();
        }
       static public bool IsExist(int personID, int LicencesClassID)
        {
            return clsLocalDrivingLicencesApplicationDataAccess.IsExist(personID, LicencesClassID);
        }
       
        public bool Save()
        {
            return _AddNew();
        }
        public  bool Delete()
        {
            if (clsLocalDrivingLicencesApplicationDataAccess.Delete(LocalDrivingLecencesID))
            {
                return clsApplications.Delete(applicationID);
            }
            return false;
            
        }
        static public ClsLocalDrivingLecencesAppli Find(int LocalAppID)
        {
            
            int appID = 0;
            int licenclassID = 0;
            if (clsLocalDrivingLicencesApplicationDataAccess.Find(LocalAppID, ref appID, ref licenclassID))
                return new ClsLocalDrivingLecencesAppli(LocalAppID, appID, licenclassID);
            else 
                return null;
            
        }

        static public int numberOfPAssedTest(int LocalDrivingLicenseID)
        {
            return clsTestDataAccess.GetNumberOfTestPassed(LocalDrivingLicenseID);
        }

    }
}
