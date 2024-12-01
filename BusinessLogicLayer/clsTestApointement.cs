using DataAccessLAyer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public  class clsTestApointement
    {
        public int testapoitementID {  get; set; }
       
        public int testtypeID { get; set; }
        public int localdrivinglicenseID { get; set; }
        public DateTime ApoitDate { get; set; } 
        public double paidfees { get; set; }
        public int userID { get; set; }
        public bool islocked { get; set; }
        public int retaketestappoit {  get; set; }

        
        public clsTestApointement()
        {
            this.testapoitementID = 0;
    
            this.testtypeID = 0;
            this.localdrivinglicenseID = 0;
            ApoitDate = DateTime.UtcNow;
            this.paidfees = 0;
            this.userID = 0;
            this.islocked = false;
            this.retaketestappoit = 0;
        }

        clsTestApointement(int testapoiID, int testtypeID, int localdrivinglicenseID, DateTime apoitDate, double paidfees, int userID, bool islocked, int retaketestappoit)
        {
            this.testapoitementID = testapoiID;
           
            this.testtypeID = testtypeID;
            this.localdrivinglicenseID = localdrivinglicenseID;
            ApoitDate = apoitDate;
            this.paidfees = paidfees;
            this.userID = userID;
            this.islocked = islocked;
            this.retaketestappoit = retaketestappoit;
            
        }

        static public bool IsThereNonscheduleTests(int localdrilicenseID , int testtyppeID)
        {
            return clsTestApppoitementDataAccess.IsExist(localdrilicenseID, testtyppeID);
        }
        static public bool AlreadyPassedThisTest(int localdrilicenseID, int testtyppeID)
        {
            return clsTestApppoitementDataAccess.AlreadyPassedThisTest(localdrilicenseID, testtyppeID);
        }
        static public DataTable AllTestsApoitementsTakedByPersonInTestType(int localDrivingLicense,int testtyppeID)
        {
            return clsTestApppoitementDataAccess.GetRecordOfSpecialTestAndLocalDrivingLicense(localDrivingLicense, testtyppeID);
        }
        public bool Save()
        {
            testapoitementID =  clsTestApppoitementDataAccess.Create(testtypeID,localdrivinglicenseID,ApoitDate,paidfees,userID,islocked);
            return testapoitementID > 0;
        }
        public bool SaveNewDate(DateTime newdate)
        {
            return clsTestApppoitementDataAccess.UpdateDate(testapoitementID,newdate);
        }
        public bool ReTakeTest(int NewApoitementsID){
            return clsTestApppoitementDataAccess.RetakeTest(this.testapoitementID,NewApoitementsID);
        }

        public static bool LockThisTestApoitement(int testapoitementID)
        {
            return clsTestApppoitementDataAccess.LockedTheTest(testapoitementID);
        }
        public  bool LockThisTestApoitement()
        {
            return clsTestApppoitementDataAccess.LockedTheTest(testapoitementID);
        }
        public static clsTestApointement Find(int testapoitementID)
        {
            int testtypeID = 0;
            int localdrivinglice = 0;
            DateTime ApoitDate = DateTime.MinValue;
            double paidfees = 0;
            int userID = 0;
            bool islocked = false;
            int retaketestappoit = 0;
            if(clsTestApppoitementDataAccess.Find(testapoitementID,ref testtypeID,ref localdrivinglice,ref ApoitDate,ref paidfees,ref userID,ref islocked,ref retaketestappoit))
            {
                return new clsTestApointement(testapoitementID, testtypeID, localdrivinglice, ApoitDate, paidfees, userID, islocked, retaketestappoit);
            }
            else
            {
                return null;
            }
        }
        public static clsTestApointement FindFailledTestAndNonRetakeYet(int localdrivinglice)
        {
            int testtypeID = 0;
            int testapoitementID = 0;
            DateTime ApoitDate = DateTime.MinValue;
            double paidfees = 0;
            int userID = 0;
            bool islocked = false;
            int retaketestappoit = 0;
            if (clsTestApppoitementDataAccess.FindFailledTestAndNonRetakeYet( localdrivinglice,ref testapoitementID, ref testtypeID,ref ApoitDate, ref paidfees, ref userID))
            {
                return new clsTestApointement(testapoitementID, testtypeID, localdrivinglice, ApoitDate, paidfees, userID, islocked, retaketestappoit);
            }
            else
            {
                return null;
            }
        }

    }
}
