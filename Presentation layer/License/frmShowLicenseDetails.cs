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

namespace DVLD_Project_19.License
{
    public partial class frmShowLicenseDetails : Form
    {
        clsLicense _license = null;
        public frmShowLicenseDetails(clsLicense LicenseID)
        {
            _license= LicenseID;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowLicenseDetails_Load(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfo1.LoadInfo(_license);
        }
    }
}
