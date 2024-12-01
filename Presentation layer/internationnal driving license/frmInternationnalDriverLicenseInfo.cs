using BusinessLogicLayer;
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
    public partial class frmInternationnalDriverLicenseInfo : Form
    {
        clsInternationnalLicense _interlicense = null;
        public frmInternationnalDriverLicenseInfo(clsInternationnalLicense license)
        {
            _interlicense = license;
            InitializeComponent();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInternationnalDriverLicenseIndo_Load(object sender, EventArgs e)
        {
            ctrlinternationnaldriverinfo1.LoadInfo(_interlicense);
        }
    }
}
