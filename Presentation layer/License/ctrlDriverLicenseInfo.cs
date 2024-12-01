using BusinessLogicLayer;
using DVLD_Project_19.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project_19.License
{
    public partial class ctrlDriverLicenseInfo : UserControl
    {
        public ctrlDriverLicenseInfo()
        {
            InitializeComponent();
        }
        void _SetGender(int gender)
        {
            if(gender == 0)
            {
                lblGender.Text = "Male";
                pbGender.Image = Resources.Man_32;
            }
            else
            {
                lblGender.Text = "Female";
                pbGender.Image= Resources.Woman_32;
            }

        }

        void _SetIsActive(bool isActive)
        {
            if (isActive)
                lblIsActive.Text = "Yes";
            else
                lblIsActive.Text = "No";
        }
        void _SetIsDetained(bool isDetaned)
        {
            if (isDetaned)
                lblISDetainned.Text = "Yes";
            else
                lblISDetainned.Text = "No";
        }
        void _SetNote(string notes)
        {
            if (string.IsNullOrEmpty(notes))
                lblNotes.Text = "No Notes";
            else 
                lblNotes.Text = notes;
        }

        void _SetPicture(string picture,int gendor)
        {
            if (string.IsNullOrEmpty(picture))
            {
                if (gendor == 0)//its a man 
                    pbProfile.Image = Resources.Male_512;
                else
                    pbProfile.Image = Resources.Female_512;
            }
            else
            {
                try
                {
                    pbProfile.ImageLocation = picture;
                }
                catch
                {
                    pbProfile.Image = Resources.NotFound;
                }
            } 
        }

        void _SetIssueReason(int issuereason)
        {
            //issue reason : 1-FirstTime, 2-Renew, 3-Replacement for Damaged, 4- Replacement for Lost.
            if (issuereason == 1)
                lblIssueReason.Text = "First Time";
            else if (issuereason == 2)
                lblIssueReason.Text = "Renew";
            else if (issuereason == 3)
                lblIssueReason.Text = "Replacement for Damaged";
            else if (issuereason == 4)
                lblIssueReason.Text = "Replacement for Lost";
        }
        void _SetInfo(clsLicense license)
        {
           
            lblClassType.Text = license.classtype.Name;
            lblfullName.Text = license.driver.person.firstname + " " +license.driver.person.secondname +" " ;
            if (license.driver.person.thirdname == string.Empty)
                lblfullName.Text += license.driver.person.lastname;
            else
                lblfullName.Text += license.driver.person.thirdname +" " +  license.driver.person.lastname;
            lblLicenseID.Text = license.licenseID.ToString();
            lblNationnalNumber.Text = license.driver.person.nationalNO;
            _SetGender(license.driver.person.gender);
            lblIssuedate.Text = license.issuedate.ToString("dd/MMM/yyyy");
            _SetIssueReason(license.issuereason);
            _SetNote(license.notes);
            _SetIsActive(license.isactive);
            lblDateOfBirth.Text = license.driver.person.dateofbirth.ToString("dd/MMM/yyyy");
            lblDriverID.Text = license.driverID.ToString();
            lblExpirationDate.Text = license.expirationDate.ToString("dd/MMM/yyyy");
            _SetIsDetained(clsLicense.IsDetained(license.licenseID));
            _SetPicture(license.driver.person.imagepath, license.driver.person.gender);
        }
        public void LoadInfo(clsLicense License)
        {
           _SetInfo(License);

        }


        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
