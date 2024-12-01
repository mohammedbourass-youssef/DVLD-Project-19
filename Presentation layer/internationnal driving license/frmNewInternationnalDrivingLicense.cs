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

namespace DVLD_Project_19.internationnal_driving_license
{
    public partial class frmNewInternationnalDrivingLicense : Form
    {
        public frmNewInternationnalDrivingLicense()
        {
            InitializeComponent();
        }
        int _CreateApplication(clsLicense license)
        {
            clsApplications application = new clsApplications();
            application.date = DateTime.Now;
            application.PersonID = license.driver.person.personID;
            application.userid = clsGlobal.CurrentUser.UserID;
            application.ApplicationStatus = 3; 
            application.laststatusdate = DateTime.Now;
            application.ApplicationTypeID = 6;
            application.paidfees = int.Parse(lblfees.Text.Trim());
            return (application.Save()) ? application.applicationID : 0;
        }

        bool _CreateNewInternationnalLicense(clsLicense license)
        {
            clsInternationnalLicense Internationnallicense = new clsInternationnalLicense();
            Internationnallicense.issuedate = DateTime.Now;
            Internationnallicense.expirationdate = Convert.ToDateTime(lblExpiation.Text.Trim());
            Internationnallicense.localdrivinglicenseID = license.licenseID;
            Internationnallicense.driverID = license.driverID;
            int appID = _CreateApplication(license);
            if(appID == 0)
            {
                MessageBox.Show("Error !!!");
                return false;
            }
            Internationnallicense.applicationID = appID;
            Internationnallicense.isactive = true;
            Internationnallicense.userID = clsGlobal.CurrentUser.UserID;

            if(Internationnallicense.Save())
            {
                lblInternationnalID.Text = Internationnallicense.internationnaldrivinglicenseID.ToString();
                lblInternationalApplicationID.Text = appID.ToString();
                return true;
            }
            else 
                return false;
        }

        void _FillApplicationInfo(clsLicense lece)
        {
            lblApplicationDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lblIssueDate.Text = lblApplicationDate.Text;
            clsApplicationTypes types = clsApplicationTypes.Find(6);
            lblfees.Text = types.fees.ToString();   
            lblLocalDrivingLicense.Text = lece.licenseID.ToString();
            clsClassesTypes type = clsClassesTypes.Find(lece.licenseclassID);
            lblExpiation.Text = DateTime.Now.AddYears(type.ValidaateLength).ToString("dd/MMM/yyyy");
            lblUserName.Text = clsGlobal.CurrentUser.username;
        }

      
        clsLicense _license = null; 
        void _GetLicense(object sender, clsLicense license)
        {
            _license = license;
             btnSave.Enabled = true;
            ctrlDriverLicenseInfo1.LoadInfo(license);
            _FillApplicationInfo(license);
            linkHistory.Enabled = true;
        }

        private void frmNewInternationnalDrivingLicense_Load(object sender, EventArgs e)
        {
            filter.dataBack += _GetLicense;
            filter.Load(true);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure ? you want to issue an internationnal license for this person ... .. ... .", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (!clsInternationnalLicense.IsExist(_license.driverID))
                {
                    if (DateTime.Compare(_license.expirationDate, DateTime.Now) > 0)
                    {
                        if (_CreateNewInternationnalLicense(_license))
                        {
                            MessageBox.Show("Internationnal license added succefully (- ...");
                            btnSave.Enabled = false;
                            LinkLicense.Enabled = true; 
                        }
                        else
                            MessageBox.Show("Error Invalid ...");
                    }
                }
                else
                {
                    MessageBox.Show("This Person Has already an internationnal license ....");
                }
            }
            
        }

        private void linkHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmshowlicenseHistory history = new frmshowlicenseHistory(_license.driver.personID);
            history.ShowDialog();
        }

        private void LinkLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int ID = int.Parse(lblInternationnalID.Text.Trim());
           
            frmInternationnalDriverLicenseInfo frm = new frmInternationnalDriverLicenseInfo(clsInternationnalLicense.Find(ID));
            frm.ShowDialog();
        }
    }
}

