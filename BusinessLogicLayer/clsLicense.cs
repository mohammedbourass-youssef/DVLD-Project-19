using DataAccessLAyer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace BusinessLogicLayer
{
    public class clsLicense
    {

        public int licenseID {  get; set; }
        public int applicationID { get; set; }
        public clsApplications application { get; set; }
        public int driverID { get; set; }
        public clsDriver driver { get; set; }
        public int licenseclassID { get; set; }
        public clsClassesTypes classtype { get; set; }
        public DateTime issuedate { get; set; }
        public DateTime expirationDate { get; set; }
        public string notes { get; set; }
        public double paidfees { get; set; }
        public bool isactive { get; set; }
        public byte issuereason { get; set; }  //issue reason : 1-FirstTime, 2-Renew, 3-Replacement for Damaged, 4- Replacement for Lost.
        public int userID { get; set; }
        enum enMode { addnew , update}

        enMode _mode = enMode.addnew ;
        bool _AddNew()
        {
            licenseID =  clsLicenceDataAccess.AddNewLicense(applicationID, driverID,licenseclassID,issuedate,expirationDate,notes,paidfees,isactive,issuereason,userID);
            return licenseID != 0;
        }
        bool _Update()
        {
            return clsLicenceDataAccess.UpdateLicense(this.licenseID, applicationID, driverID, licenseclassID, issuedate, expirationDate, notes, paidfees, isactive, issuereason, userID);
            
        }
        
        public clsLicense()
        {
            licenseID = 0;
            applicationID = 0;
            licenseclassID = 0;
            driverID = 0;   
            issuedate = DateTime.MinValue;
            expirationDate = DateTime.MinValue;
            notes = string.Empty;
            paidfees = 0;
            isactive = false;
            issuereason = 0;
            userID = 0;
            _mode = enMode.addnew ;
        }
        clsLicense(int ID,int appID,int driID,int liceclassID,DateTime issDate,DateTime expidate,string note,double pafes , bool isact,byte issreasn,int userid)
        {
            licenseID = ID;
            applicationID = appID;
            application = clsApplications.Find(appID);
            licenseclassID = liceclassID;
            classtype = clsClassesTypes.Find(liceclassID);
            driverID = driID;
            driver = clsDriver.Find(driID);
            issuedate = issDate;
            expirationDate = expidate;
            notes = note;
            paidfees = pafes;
            isactive = isact;
            issuereason = issreasn;
            userID = userid;
            _mode = enMode.update;
        }  

        public static bool IsThisPersonHasALicenseInThisClass(int PersonID , int licenseclass)
        {
            return clsLicenceDataAccess.IsThisPersonHasLicenseInThisClass(PersonID , licenseclass);
        } 
        public static bool IsThisLecenseActive(int licenseID)
        {
            return clsLicenceDataAccess.IsThisLecenseActive(licenseID);
        }
        public bool Save()
        {
            if(_mode  == enMode.addnew )
            {
                return _AddNew();
            }
            else 
                return _Update();
        }
        public static clsLicense Find(int lcesnseID)
        {
            int appID = 0;
            int driID = 0;
            int liceclassID = 0;
            DateTime issDate = DateTime.UtcNow;
            DateTime expidate = DateTime.MinValue;
            string note = "";
            double pafes = 0;
            bool isact = false;
            byte issreasn = 0;
            int userid = 0;
            if(clsLicenceDataAccess.Find(lcesnseID,ref appID,ref driID,ref liceclassID,ref issDate,ref expidate,ref note,ref pafes,ref isact,ref issreasn,ref userid))
            {
                return new clsLicense(lcesnseID,appID,driID,liceclassID,issDate,expidate,note,pafes,isact,issreasn,userid);
            }
            else
            {
                return null;
            }
        }
        public static clsLicense FindTheClassOrdinarydrivinglicense(int lcesnseID)
        {
            int appID = 0;
            int driID = 0;
            
            DateTime issDate = DateTime.UtcNow;
            DateTime expidate = DateTime.MinValue;
            string note = "";
            double pafes = 0;
            bool isact = false;
            byte issreasn = 0;
            int userid = 0;
            if (clsLicenceDataAccess.Find(lcesnseID, ref appID, ref driID, ref issDate, ref expidate, ref note, ref pafes, ref isact, ref issreasn, ref userid))
            {
                return new clsLicense(lcesnseID, appID, driID, 3, issDate, expidate, note, pafes, isact, issreasn, userid);
            }
            else
            {
                return null;
            }
        }
        public static clsLicense Findlicense(int lcesnseID)
        {
            int appID = 0;
            int driID = 0;

            DateTime issDate = DateTime.UtcNow;
            DateTime expidate = DateTime.MinValue;
            string note = "";
            double pafes = 0;
            int licensclass = 0;
            bool isact = false;
            byte issreasn = 0;
            int userid = 0;
            if (clsLicenceDataAccess.Find(lcesnseID, ref appID, ref driID,ref licensclass, ref issDate, ref expidate, ref note, ref pafes, ref isact, ref issreasn, ref userid))
            {
                return new clsLicense(lcesnseID, appID, driID, licensclass, issDate, expidate, note, pafes, isact, issreasn, userid);
            }
            else
            {
                return null;
            }
        }
        public static clsLicense FindByAppID(int ApplicationID)
        {
            int licenID = 0;
            int driID = 0;
            int liceclassID = 0;
            DateTime issDate = DateTime.UtcNow;
            DateTime expidate = DateTime.MinValue;
            string note = "";
            double pafes = 0;
            bool isact = false;
            byte issreasn = 0;
            int userid = 0;
            if (clsLicenceDataAccess.FindByApplicationID(ApplicationID, ref licenID, ref driID, ref liceclassID, ref issDate, ref expidate, ref note, ref pafes, ref isact, ref issreasn, ref userid))
            {
                return new clsLicense(licenID, ApplicationID, driID, liceclassID, issDate, expidate, note, pafes, isact, issreasn, userid);
            }
            else
            {
                return null;
            }
        }

        public static bool IsDetained(int license)
        {
            return clsDetainedLicenseDataAccess.IsLicenseDetained(license);
        }

        public static DataTable GetAllLicenseOf(int DriverID)
        {
            return clsLicenceDataAccess.Get(DriverID);
        }

    }
}
