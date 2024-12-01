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
    public partial class frmManageInternationnalDrivinglicens : Form
    {
        public frmManageInternationnalDrivinglicens()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void _refresh()
        {
            dgvRecords.DataSource = clsInternationnalLicense.GetAllInternationnalLicenses();
            lblRecord.Text  = dgvRecords.RowCount.ToString();
        }
        private void frmManageInternationnalDrivinglicens_Load(object sender, EventArgs e)
        {
            cmFilteritem.SelectedIndex = 0;
            _refresh();
        }

        private void showPersonLicenceHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsDriver driver = clsDriver.Find((int)dgvRecords.CurrentRow.Cells[2].Value);
            frmshowlicenseHistory history = new frmshowlicenseHistory(driver.personID);
            history.ShowDialog();
            _refresh();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void cmshowlicense_Click(object sender, EventArgs e)
        {
            clsInternationnalLicense license = clsInternationnalLicense.Find((int)dgvRecords.CurrentRow.Cells[0].Value);
            frmInternationnalDriverLicenseInfo frm = new frmInternationnalDriverLicenseInfo(license);
            frm.ShowDialog();
            _refresh();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsDriver driver = clsDriver.Find((int)dgvRecords.CurrentRow.Cells[2].Value);
            frmPersonDetails frm = new frmPersonDetails(driver.personID);
            frm.ShowDialog();
            _refresh();
        }
        //filter items 

        enum enFilterMode { none , internnationallicenseID , applicationID , DriverID , IssuedUsingLocalLicenseID  , isActive}
        enFilterMode _currentfilter = enFilterMode.none;
 
        enFilterMode _DetectCurrentFilterItem()
        {
            //the names of colomn in datagridview is like this 
                /*
        ¨       Inter_Li_ID
                 App_ID
                 DriverID
                 Lo_LicenseID
                 Is_Active
                  */
            //which is differente of names in combo box filters like this : 
               /*     None
                   International License ID
                   Application ID
                   Is Active*/
            //to use it in filter we should fil each name in tag .....

            switch (cmFilteritem.SelectedIndex)
            {
                case 0: cmFilteritem.Tag = ""; 
                    return enFilterMode.none;
                case 1: cmFilteritem.Tag = "Inter_Li_ID";
                    return enFilterMode.internnationallicenseID;
                case 2:cmFilteritem.Tag = "App_ID";
                    return enFilterMode.applicationID;
                case 3:cmFilteritem.Tag = "DriverID"; 
                    return enFilterMode.DriverID;
                case 4:cmFilteritem.Tag = "Lo_LicenseID";
                    return enFilterMode.IssuedUsingLocalLicenseID;
                case 5: cmFilteritem.Tag = "Is_Active"; 
                    return enFilterMode.isActive;
                default:
                    cmFilteritem.Tag = "";
                    return enFilterMode.none;
            }
        }

        void _SearchBoxProprities()
        {

            if(_currentfilter == enFilterMode.none)
            {
                tbSearchbox.Visible = false;
                cmstatus.Visible = false;
            }
            else if (_currentfilter == enFilterMode.isActive)
            {
                tbSearchbox.Visible = false;
                cmstatus.Visible = true; 
            }
            else
            {
                tbSearchbox.Visible = true;
                tbSearchbox.Text = string.Empty;
                tbSearchbox.Focus();
                cmstatus.Visible = false;
            }
        }

        void _Filter()
        {
            DataTable data = clsInternationnalLicense.GetAllInternationnalLicenses();
            DataView dv = data.DefaultView;
            if(_currentfilter != enFilterMode.isActive)
            {
                dv.RowFilter = cmFilteritem.Tag.ToString() + "=" + tbSearchbox.Text.Trim();
                dgvRecords.DataSource = dv;
            }
        }

        private void cmFilteritem_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentfilter = _DetectCurrentFilterItem();
            _SearchBoxProprities();
            _refresh();
        }

        private void tbSearchbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsDigit(e.KeyChar) ||  e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void tbSearchbox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbSearchbox.Text))
            {
                _Filter();
            }
            else 
                _refresh();
        }

        private void cmstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable data = clsInternationnalLicense.GetAllInternationnalLicenses();
            DataView dv = data.DefaultView;
           
            dv.RowFilter = cmFilteritem.Tag.ToString() + "=" + cmstatus.SelectedIndex;
           dgvRecords.DataSource = dv;
            
            
        }
    }
}
