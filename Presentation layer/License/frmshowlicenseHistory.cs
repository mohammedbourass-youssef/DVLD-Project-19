using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project_19.License
{
    public partial class frmshowlicenseHistory : Form
    {
       
        clsDriver driver = null;
        public frmshowlicenseHistory(int personID)
        {
            driver = clsDriver.FindByPersonID(personID);
            
            InitializeComponent();
        }
        void _FillTheLocalDrivingLicenseDataGridView()
        {
           
            if (driver != null)
            {
                dgvLocalRecords.DataSource = clsLicense.GetAllLicenseOf(driver.driverID);
                label4lblLocal.Text = dgvLocalRecords.RowCount.ToString();
            }
            else
                lblWarningLocal.Visible = true; 
        } 
        void _FillTheInternationnalDrivingLicenseDataGridView()
        {
            if (driver != null)
            {
                dgvInternationnalRecords.DataSource = clsInternationnalLicense.GetAllInternationnalHistoryfor(driver.driverID);
                lblinternationnalRecords.Text = dgvInternationnalRecords.RowCount.ToString();
                if(dgvInternationnalRecords.RowCount == 0)
                    lblWarningInternationnal.Visible = true;
            }
            else
                lblWarningInternationnal.Visible = true;
        }


        private void frmshowlicenseHistory_Load(object sender, EventArgs e)
        {
            ctrlPersonCard1.SetIDValue(driver.personID);
            ctrlPersonCard1.LoadInfo();
            _FillTheLocalDrivingLicenseDataGridView();
            _FillTheInternationnalDrivingLicenseDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmshowlicense_Click(object sender, EventArgs e)
        {
            frmShowLicenseDetails frm = new frmShowLicenseDetails(clsLicense.Find((int)dgvLocalRecords.CurrentRow.Cells[0].Value));
            frm.ShowDialog();
        }
    }
}
