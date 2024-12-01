using DataAccessLAyer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class clsInternationnalLicense
    {

        public int internationnaldrivinglicenseID {  get; set; }
        public int applicationID { get; set; }
        public clsApplications application { get; set; }
        public int driverID { get; set; }
        public clsDriver driver {  get; set; } 
        public int localdrivinglicenseID { get; set; }
        public DateTime issuedate { get; set; }
        public DateTime expirationdate { get; set; }
        public bool isactive { get; set; }
        public int userID { get; set; }

        public clsInternationnalLicense()
        {
            internationnaldrivinglicenseID = 0;
            applicationID = 0;
            driverID = 0;
            localdrivinglicenseID = 0;
            issuedate = DateTime.MinValue;
            expirationdate = DateTime.MinValue;
            isactive = false;
            userID = 0;
        }
         clsInternationnalLicense(int internationnaldrivinglicenseID, int applicationID, int driverID, int localdrivinglicenseID, DateTime issuedate, DateTime expirationdate, bool isactive, int userID)
        {
            this.internationnaldrivinglicenseID = internationnaldrivinglicenseID;
            this.applicationID = applicationID;
            application = clsApplications.Find(applicationID);
            this.driverID = driverID;
            this.driver = clsDriver.Find(driverID);
            this.localdrivinglicenseID = localdrivinglicenseID;
            this.issuedate = issuedate;
            this.expirationdate = expirationdate;
            this.isactive = isactive;
            this.userID = userID;
        }

        public static DataTable GetAllInternationnalHistoryfor(int driverID)
        {
            return clsInternationnalLicenseDataAccess.Get(driverID);
        }

        public bool Save()
        {
            internationnaldrivinglicenseID =  clsInternationnalLicenseDataAccess.AddNewLice(applicationID, driverID, localdrivinglicenseID, issuedate, expirationdate, isactive, userID) ;
            return internationnaldrivinglicenseID != 0;
        }

        public static clsInternationnalLicense Find(int inter_license)
        {
            int applID = 0;
            int driID = 0;
            int local_license = 0;
            DateTime issuedate = DateTime.MinValue;
            DateTime expirationdate = DateTime.MinValue;
            bool isactive = false;
            int userID = 0;
            if(clsInternationnalLicenseDataAccess.Find(inter_license,ref applID,ref driID,ref local_license,ref issuedate,ref expirationdate,ref isactive,ref userID))
            {
                return new clsInternationnalLicense(inter_license,applID,driID,local_license,issuedate,expirationdate,isactive,userID);
            }
            else
            {
                return null;    
            }
        }
        public static bool IsExist(int driverID)
        {
            return clsInternationnalLicenseDataAccess.IsExist(driverID);
        }

        public static DataTable GetAllInternationnalLicenses()
        {
            return clsInternationnalLicenseDataAccess.GetAllInternationnalDrivingLicens();
        }

    }
}
