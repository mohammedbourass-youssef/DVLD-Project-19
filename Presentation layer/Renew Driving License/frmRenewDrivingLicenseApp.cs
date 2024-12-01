using BusinessLogicLayer;
using DVLD_Project_19.License;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project_19.Renew_Driving_License
{
    public partial class frmRenewDrivingLicenseApp : Form
    {
        clsLicense _oldlicense = null;
        public frmRenewDrivingLicenseApp()
        {
            InitializeComponent();
        }
        // new application 
        clsApplications _NewApplication()
        {
            clsApplications application = new clsApplications();
            application.ApplicationStatus = 3;
            application.date = Convert.ToDateTime(lblIssueDate.Text);
            application.userid = clsGlobal.CurrentUser.UserID;
            application.ApplicationTypeID = 2;
            application.laststatusdate = DateTime.Now;
            application.PersonID = _oldlicense.application.PersonID;
            application.paidfees = Convert.ToDouble(lblTotalFess.Text);
            return (application.Save())?application : null;
        }
        //Create New Lecence 
        clsLicense _newlicense = null;
        bool _NewLicense()
        {
            clsLicense license = new clsLicense();
            license.notes = tbNotes.Text;
            
            license.paidfees = _oldlicense.paidfees;
            license.licenseclassID = _oldlicense.licenseclassID;
            license.issuedate = DateTime.Now;
            clsClassesTypes typeclass = clsClassesTypes.Find(_oldlicense.licenseclassID);
            license.expirationDate = DateTime.Now.AddYears(typeclass.ValidaateLength);
            license.classtype = _oldlicense.classtype;
            license.applicationID = _NewApplication().applicationID;    
            license.driverID = _oldlicense.driverID;
            // 1-FirstTime, 2-Renew, 3-Replacement for Damaged, 4- Replacement for Lost.
            license.issuereason = 2;
            license.userID = clsGlobal.CurrentUser.UserID;
            license.isactive = true;
            _oldlicense.isactive = false;
            bool x = _oldlicense.Save();
            bool y = license.Save();
            if (x && y)
            {
                _newlicense = license;
                _FillNewApplicationInfo(license);
                return true;
            }
            return false;
        }

        //function to fill the element of groupbox = Application New License Info 
        void _FillApplicationNewLicenseInfo()
        {
            linkLicense.Enabled = true;
            btnSave.Enabled = true;
            lblApplicationDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lblIssueDate.Text = lblApplicationDate.Text;
            //  Renew Driving License Service , ID  = 2 , in database
            clsApplicationTypes type = clsApplicationTypes.Find(2);
            lblApplicationFees.Text = type.fees.ToString();
            lblUserName.Text = clsGlobal.CurrentUser.username;
            clsClassesTypes typeclass = clsClassesTypes.Find(_oldlicense.licenseclassID);
        
            lblLicenseFees.Text = typeclass.fees.ToString();
            lblTotalFess.Text = Convert.ToString(Convert.ToDouble(lblApplicationFees.Text) + Convert.ToDouble(lblLicenseFees.Text));
        }
        //fill the things depend on new application 
        void _FillNewApplicationInfo(clsLicense newlicense)
        {
           
            lblRenewApplicatinID.Text = newlicense.applicationID.ToString();
            lblLicenseFees.Text = newlicense.paidfees.ToString();
            lblRenewedLicenseID.Text = newlicense.licenseID.ToString();
            lblOldLocalDrivingLicense.Text = _oldlicense.licenseID.ToString();
            lblExpiation.Text = newlicense.expirationDate.ToString();
           
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        void _GetInfoFromctrlFind(object sender, clsLicense License)
        {
            ctrlDriverLicenseInfo1.LoadInfo(License);
            //enable linkHistory 
            linkHistory.Enabled = true;
            //make this license global
            _oldlicense = License;
            // <Must Included >
            // You must check  if this person has another active license in same class 
            // do a query and etc 
            //<Must Included>
            if (!clsLicense.IsThisPersonHasALicenseInThisClass(License.application.PersonID, License.licenseclassID))
            {
                if (DateTime.Compare(DateTime.Now, _oldlicense.expirationDate) > 0)
                {
                    _FillApplicationNewLicenseInfo();
                }
                else
                {
                    MessageBox.Show("The expiration date of this licenses " + License.licenseID.ToString() + " is still valid");
                }
            }
            else
                MessageBox.Show("this Person Has another Active licenses in this class");
        }
       
        


        private void frmRenewDrivingLicenseApp_Load(object sender, EventArgs e)
        {
            //load a old license 
            ctrlFilterLocalDrivingLicense1.Load(false);
            ctrlFilterLocalDrivingLicense1.dataBack += _GetInfoFromctrlFind;
            //make unwanted button and linklanel disbled
            linkHistory.Enabled = false;
            btnSave.Enabled = false;
            linkLicense.Enabled = false;
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_NewLicense())
            {
                MessageBox.Show("License AddedSuccefully");
                btnSave.Enabled = false;
                tbNotes.Enabled = false;
            }
            else
            {
                MessageBox.Show("Error 404");
            }
        }

        private void linkHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmshowlicenseHistory history = new frmshowlicenseHistory(_oldlicense.application.PersonID);
            history.ShowDialog();
        }

        private void linkLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _newlicense = clsLicense.Findlicense(_newlicense.licenseID);
            frmShowLicenseDetails frm = new frmShowLicenseDetails(_newlicense);
            frm.ShowDialog();
        }
    }
}
