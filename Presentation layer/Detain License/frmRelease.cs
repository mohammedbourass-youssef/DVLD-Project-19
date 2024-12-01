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

namespace DVLD_Project_19.Detain_License
{
    public partial class frmRelease : Form
    {
        clsLicense _license = null;
        clsApplicationTypes _applicationType = clsApplicationTypes.Find(5);
        clsDetainedLicense _detainedLicense = null;
        bool x = true;
        public frmRelease()
        {
            InitializeComponent();
        }
        public frmRelease(clsDetainedLicense detainedLicense, clsLicense license)
        {
            InitializeComponent();
            _license = license;
            _detainedLicense= detainedLicense;
            x= false;
        }
        void _fillDetainThings()
        {
            lblDetainID.Text = _detainedLicense.detainID.ToString();
            lblfinefees.Text = _detainedLicense.finefees.ToString();
            lblDetainDate.Text = _detainedLicense.detaindate.ToString("dd-MM-yyyy");
            lblTotalFees.Text = Convert.ToString(_detainedLicense.finefees + _applicationType.fees);
        }
        void _GetInfoFromctrlFind(object sender, clsLicense License)
        {
            if (!clsDetainedLicense.IsDetain(License.licenseID))
            {
                MessageBox.Show("this License is not detained");
                ctrlFilterLocalDrivingLicense1.Load(false);
            }
            else
            {
                ctrlDriverLicenseInfo1.LoadInfo(License);
                linkHistory.Enabled = true;
                lblLocalDrivingLicense.Text = License.licenseID.ToString();
                ctrlFilterLocalDrivingLicense1.Enabled = false;
                linkHistory.Enabled = true;
                _license = License;
                btnSave.Enabled = true;
                _detainedLicense = clsDetainedLicense.Find(_license.licenseID);
                _fillDetainThings();
            }
        }
        bool Realese()
        {
            clsApplications application = new clsApplications();
            application.date = DateTime.Now;
            application.laststatusdate = DateTime.Now;
            application.paidfees = _applicationType.fees;
            application.ApplicationStatus = 3;
            application.ApplicationTypeID = 5;
            application.userid = clsGlobal.CurrentUser.UserID;
            application.PersonID = _license.application.PersonID;
            if (application.Save())
            {
                lblapplicationID.Text = application.applicationID.ToString();   
                _detainedLicense.realesedate = DateTime.Now;
                _detainedLicense.realeseapplication = application.applicationID;
                _detainedLicense.isrealed = true;
                _detainedLicense.realesedbyuserID = application.userid;
                bool x =  _detainedLicense.Save();
                return x;
            }
            else 
                return false;
        }


        void GetInfo()
        {
            ctrlDriverLicenseInfo1.LoadInfo(_license);
            linkHistory.Enabled = true;
            lblLocalDrivingLicense.Text = _license.licenseID.ToString();
            ctrlFilterLocalDrivingLicense1.Enabled = false;
            linkHistory.Enabled = true;
            btnSave.Enabled = true;
            _fillDetainThings();
        }
        private void frmRelease_Load(object sender, EventArgs e)
        {
            ctrlFilterLocalDrivingLicense1.dataBack += _GetInfoFromctrlFind;
            lblAppFees.Text = _applicationType.fees.ToString();
            lblUserName.Text = clsGlobal.CurrentUser.username;
            btnSave.Enabled = false;
            ctrlFilterLocalDrivingLicense1.Enabled = x;
            if (!x)
            {
                GetInfo();
                btnSave.Enabled = true;
            }
                
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Realese())
            {
                MessageBox.Show("License released succefully . . . . ");
                btnSave.Enabled = false;
                ctrlDriverLicenseInfo1.LoadInfo(_license);
            }
            else
            {
                MessageBox.Show("Error 404 . . . . .  . . .");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void linkHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmshowlicenseHistory history = new frmshowlicenseHistory(_license.application.PersonID);
            history.ShowDialog();
        }
    }
}
