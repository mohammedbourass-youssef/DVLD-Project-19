using DataAccessLAyer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class clsDetainedLicense
    {
        public int detainID {  get; set; }
        public int licenseID { get; set; }

        public clsLicense license { get; set; }
        public  DateTime detaindate { get; set; }
        public double finefees { get; set; }
        public int createdbyuserID { get; set; }
        public bool isrealed { get; set; }
        public int realesedbyuserID { get; set; }

        public DateTime realesedate { get; set; }
        public int realeseapplication {  get; set; }
        enum enMode { enUpdate ,enAddnew}
        enMode _mode = enMode.enAddnew;
        public clsDetainedLicense()
        {
            detainID = 0;
            licenseID = 0;
            detaindate = DateTime.Now;
            finefees = 0;
            createdbyuserID = 0;
            isrealed = false;
            realesedbyuserID = 0;
            realeseapplication = 0;
            realesedate = DateTime.Now;
            _mode = enMode.enAddnew;
        }
        clsDetainedLicense(int detainID, int licenseID,DateTime detaindate, double finefees, int createdbyuserID, bool isrealed,DateTime realesedate ,int realesedbyuserID, int realeseapplication)
        {
            this.detainID = detainID;
            this.licenseID = licenseID;
            this.license = clsLicense.Find(licenseID);
            this.detaindate = detaindate;
            this.finefees = finefees;
            this.createdbyuserID = createdbyuserID;
            this.isrealed = isrealed;
            this.realesedate = realesedate;
            this.realesedbyuserID = realesedbyuserID;
            this.realeseapplication = realeseapplication;
            _mode = enMode.enUpdate;
        }
        bool _AddNew()
        {
            detainID = clsDetainedLicenseDataAccess.Create(licenseID, detaindate, finefees, createdbyuserID);
            return detainID > 0;
        }
        bool _Update()
        {
            return clsDetainedLicenseDataAccess.Update(detainID, licenseID,detaindate,finefees,createdbyuserID,isrealed,realesedate,realesedbyuserID,realeseapplication);  
        }

       public bool Save()
        {
            if(_mode == enMode.enUpdate)
            {
                return _Update();
            }
            else 
                return _AddNew();
        }

        static public bool IsDetain(int LicenseID)
        {
            return clsDetainedLicenseDataAccess.IsLicenseDetained(LicenseID);
        }

        static public DataTable GetCustumRecords()
        {
            return clsDetainedLicenseDataAccess.GetCustomAllRecords();
        }
        static public clsDetainedLicense Find(int licenseID)
        {
            int detainId = 0;
            DateTime  detainDate = DateTime.MinValue;
            double finefess = 0;
            int userID = 0;
            bool isrealsed = false;
            DateTime releasedate = DateTime.MinValue;
            int releasebyuserid = 0;
            int releaseappID = 0;
            if(clsDetainedLicenseDataAccess.FindByLicenseID(licenseID,ref detainId,ref detainDate,ref finefess,ref userID,ref isrealsed,ref releasedate,ref releasebyuserid,ref releaseappID))
                return new clsDetainedLicense(detainId, licenseID, detainDate,finefess ,userID,isrealsed,releasedate, releasebyuserid, releaseappID);
            else 
                return null;
        }
        static public clsDetainedLicense FindByID(int detainId)
        {
            int licenseID = 0;
            DateTime detainDate = DateTime.MinValue;
            double finefess = 0;
            int userID = 0;
            bool isrealsed = false;
            DateTime releasedate = DateTime.MinValue;
            int releasebyuserid = 0;
            int releaseappID = 0;
            if (clsDetainedLicenseDataAccess.Find(ref licenseID,  detainId, ref detainDate, ref finefess, ref userID, ref isrealsed, ref releasedate, ref releasebyuserid, ref releaseappID))
                return new clsDetainedLicense(detainId, licenseID, detainDate, finefess, userID, isrealsed, releasedate, releasebyuserid, releaseappID);
            else
                return null;
        }
    }
}
