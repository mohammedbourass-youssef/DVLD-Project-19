using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project_19.License
{
    public partial class frmIssueLicenseFirstTime : Form
    {
        ClsLocalDrivingLecencesAppli _lecencesAppli = null;
        public frmIssueLicenseFirstTime(int localdrivinglicense)
        {
            _lecencesAppli = ClsLocalDrivingLecencesAppli.Find(localdrivinglicense);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();
        }
        int _CreateNewDriver()
        {
            int driver = clsDriver.IsExistByPersonID(_lecencesAppli.applications.PersonID);
            if ( driver!= 0)
            {
                return driver;
            }
            else
            {
                clsDriver newdriver = new clsDriver();
                newdriver.personID = _lecencesAppli.applications.PersonID;
                newdriver.createddate = DateTime.Now;
                newdriver.createdbyuserID = clsGlobal.CurrentUser.UserID;
                if(newdriver.Save())
                    return newdriver.driverID;
            }
            return 0;
        }

        bool _CreateNewLicense()
        {
            clsLicense license = new clsLicense();
            license.notes = tbNotes.Text;
            license.issuedate = DateTime.Now;
            license.paidfees = _lecencesAppli.licenseclass.fees;
            license.licenseclassID = _lecencesAppli.licenseclass.ID;
            license.applicationID = _lecencesAppli.applicationID;
            int driver = _CreateNewDriver();
            if(driver != 0)
            {
                license.driverID = driver;
            }
            license.expirationDate = license.issuedate.AddYears(_lecencesAppli.licenseclass.ValidaateLength);
            license.isactive = true;
            //issue reason : 1-FirstTime, 2-Renew, 3-Replacement for Damaged, 4- Replacement for Lost.
            license.issuereason = 1;
            license.userID = clsGlobal.CurrentUser.UserID;
            if (license.Save())
            {
                _lecencesAppli.applications.CompleteApplication();
                return true;
            }
            return false;   
        }
        //Show license History 
        private void button2btnIssue_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to issue this license ?? ", "warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (_CreateNewLicense()){
                    MessageBox.Show("License Added Succefully ");
                    button2btnIssue.Enabled = false;
                }
                else
                    MessageBox.Show("Error !!!!");
            }
        }

        private void frmIssueLicenseFirstTime_Load(object sender, EventArgs e)
        {
            ctrlLdrLicenAppInfo1.LoadInfo(_lecencesAppli.LocalDrivingLecencesID);
        }
    }
}
