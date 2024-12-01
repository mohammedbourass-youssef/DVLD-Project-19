using BusinessLogicLayer;
using DVLD_Project_19.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project_19.License
{
    public partial class ctrlinternationnaldriverinfo : UserControl
    {
        public ctrlinternationnaldriverinfo()
        {
            InitializeComponent();
        }
        void _SetFullName(clsPerson person)
        {
            lblfullName.Text = person.firstname + " "+ person.secondname + " ";
            if(person.thirdname  == string.Empty)
            {
                lblfullName.Text += person.lastname;
            }
            else
            {
                lblfullName.Text += person.thirdname + " " + person.lastname;
            }
        }
        void _SetIsActive(bool isactive)
        {
            if (isactive)
            {
                lblIsActive.Text = "YES";
            }
            else
            {
                lblIsActive.Text = "NO";
            }
        }

        void _SetPicture(string picture, int gendor)
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
        void _SetGendor(int gendor)
        {
            if(gendor == 0)
            {
                lblGender.Text = "Male";
                pbGender.Image = Resources.Man_32;
            }
            else
            {
                lblGender.Text = "Female";
                pbGender.Image = Resources.Woman_32;
            }
        }
        public void LoadInfo(clsInternationnalLicense license)
        {
            _SetFullName(license.driver.person);
            lblInternationnalID.Text = license.internationnaldrivinglicenseID.ToString();
            lblLicenseID.Text = license.localdrivinglicenseID.ToString();
            lblNationnalNumber.Text = license.driver.person.nationalNO.ToString();
            _SetGendor(license.driver.person.gender);
            lblIssuedate.Text = license.issuedate.ToString("ddd/MMM/yyyy");
            lblApplicationID.Text = license.applicationID.ToString();
            _SetIsActive(license.isactive);
            lblDateOfBirth.Text = license.driver.person.dateofbirth.ToString("ddd/MMM/yyyy");
            lblDriverID.Text = license.driverID.ToString();
            lblExpirationDate.Text = license.expirationdate.ToString("ddd/MMM/yyyy");
            _SetPicture(license.driver.person.nationalNO,license.driver.person.gender);
        }

    }
}
