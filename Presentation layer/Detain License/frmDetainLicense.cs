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

namespace DVLD_Project_19
{
    public partial class frmDetainLicense : Form
    {
        clsLicense _license = null;
        public frmDetainLicense()
        {
            InitializeComponent();
        }
        bool _saveNewInfo()
        {
            clsDetainedLicense detain = new clsDetainedLicense();
            detain.licenseID = _license.licenseID;
            detain.detaindate = DateTime.Now;
            detain.finefees = Convert.ToDouble(tbFinefeen.Text);
            detain.createdbyuserID = clsGlobal.CurrentUser.UserID;
            if (detain.Save())
            {
                lblDetainID.Text = detain.finefees.ToString();
                return true;
            }
            return false;
        }


        void _GetInfoFromctrlFind(object sender, clsLicense License)
        {
            if (!License.isactive)
            {
                MessageBox.Show("this is Inactive license please enter another ID");
                ctrlFilterLocalDrivingLicense1.Load(false);
            }
            else if (clsDetainedLicense.IsDetain(License.licenseID))
            {
                MessageBox.Show("this License Already Detained");
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
            }
        }

        private void tbFinefeen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((e.KeyChar == '.'&& !tbFinefeen.Text.Contains("."))|| char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
          ctrlFilterLocalDrivingLicense1.Load(false );
          ctrlFilterLocalDrivingLicense1.dataBack += _GetInfoFromctrlFind;
            lblDetainDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
           lblUserName.Text = clsGlobal.CurrentUser.username;
            btnSave.Enabled = false;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(tbFinefeen.Text))
            {
                if (_saveNewInfo())
                {
                    MessageBox.Show("Detained succefully . . . . . ");
                    btnSave.Enabled = false;
                    tbFinefeen.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Error 404 .........");
                }
            }
            else
            {
                MessageBox.Show("Fine fees box is required");
            }
        }
    }
}
