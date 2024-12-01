using BusinessLogicLayer;
using DVLD_Project_19.License;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project_19.replace_for_damage_or_lost
{
    public partial class frmReplaceForReplacedOrDamaged : Form
    {
        clsLicense _currentlicense = null;
        clsApplicationTypes _type = null;
        clsLicense _newlicense = null;
        byte _issuereason = 0;        // 3 - Replacement for Damaged, 4 - Replacement for Lost.
        public frmReplaceForReplacedOrDamaged()
        {
            InitializeComponent();
        }
        void _ChangeTheTitle()
        {
            if(rbDamaged.Checked)
            {
                lblTitle.Text = "Replacement for Damaged Licenses";
                _type = clsApplicationTypes.Find(4);
                lblApplicationFees.Text = _type.fees.ToString();
                _issuereason = 3;
            }
            else
            {
                lblTitle.Text = "Replacement for Lost Licenses";
               _type = clsApplicationTypes.Find(3);
                lblApplicationFees.Text = _type.fees.ToString();
                _issuereason = 4;
            }
        }

        void _GetInfoFromctrlFind(object sender, clsLicense License)
        {
           
            if (!License.isactive)
            {
                
                MessageBox.Show("this is Inactive license please enter another ID");
                ctrlFilterLocalDrivingLicense1.Load(false);
            }
            else
            {
                ctrlDriverLicenseInfo1.LoadInfo(License);
                linkHistory.Enabled = true;
                _currentlicense = License;
                lblOldLocalDrivingLicense.Text = License.licenseID.ToString();
                
            }
        }
        private void frmReplaceForReplacedOrDamaged_Load(object sender, EventArgs e)
        {
            rbDamaged.Checked = true;
            _ChangeTheTitle();
            ctrlFilterLocalDrivingLicense1.Load(false);
            ctrlFilterLocalDrivingLicense1.dataBack += _GetInfoFromctrlFind;
            //fil start thing : 
            lblApplicationDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lblUserName.Text = clsGlobal.CurrentUser.username;
        }

        private void rbDamaged_CheckedChanged(object sender, EventArgs e)
        {
            _ChangeTheTitle();
        }

        private void rbLost_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void linkHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmshowlicenseHistory history = new frmshowlicenseHistory(_currentlicense.application.PersonID);
            history.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        bool _CreateNewLicense()
        {
            clsApplications applications = new clsApplications();
            applications.date = DateTime.Now;
            applications.laststatusdate = DateTime.Now;
            applications.paidfees = Convert.ToDouble(lblApplicationFees.Text);
            applications.ApplicationStatus = 3;
            applications.ApplicationTypeID = _type.ID;
            applications.PersonID = _currentlicense.application.PersonID;
            applications.userid = clsGlobal.CurrentUser.UserID;
            if (applications.Save())
            {
                lblNewApplicatinID.Text = applications.applicationID.ToString();
               clsLicense license = new clsLicense();
                license.applicationID = applications.applicationID;
                license.driverID = _currentlicense.driverID;
                license.licenseclassID = _currentlicense.licenseclassID;
                license.issuedate = _currentlicense.issuedate;
                license.expirationDate = _currentlicense.expirationDate;
                license.notes = _currentlicense.notes;
                license.isactive = true;
                license.issuereason = _currentlicense.issuereason;
                license.userID = clsGlobal.CurrentUser.UserID;
                if (license.Save())
                {
                    lblRepllacedLicenseID.Text = license.licenseID.ToString();
                    _newlicense = clsLicense.Findlicense(license.licenseID);
                    return true;
                }
                 return false;
            }
            else
                return false;
        }

        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_CreateNewLicense())
            {
                _currentlicense.isactive = false;
                if (_currentlicense.Save())
                {
                    MessageBox.Show("Your replaced license added succefully ..... ");
                    btnSave.Enabled = false;
                    linkLicense.Enabled = true;
                }
            }
        }

        private void linkLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseDetails frm = new frmShowLicenseDetails(_newlicense);
            frm.ShowDialog();
        }
    }
}
