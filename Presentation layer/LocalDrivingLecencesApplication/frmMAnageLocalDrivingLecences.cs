using BusinessLogicLayer;
using DVLD_Project_19.License;
using DVLD_Project_19.LocalDrivingLecencesApplication;
using DVLD_Project_19.Tests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project_19.Application
{
    public partial class frmMAnageLocalDrivingLecences : Form
    {
       
        public frmMAnageLocalDrivingLecences()
        {
            InitializeComponent();
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void _Refresh()
        {
            dgvRecords.DataSource = ClsLocalDrivingLecencesAppli.GetAllRecord();
            lblRecord.Text = dgvRecords.RowCount.ToString();
            
        }
        private void frmMAnageLocalDrivingLecences_Load(object sender, EventArgs e)
        {
            
            _Refresh();
        }

        private void tbSearchbox_TextChanged(object sender, EventArgs e)
        {
            DataTable Records = ClsLocalDrivingLecencesAppli.GetAllRecord();
            if (!string.IsNullOrEmpty(tbSearchbox.Text))
            {
                if (cmFilteritem.SelectedIndex == 1)
                {
                    DataView view = Records.DefaultView;
                    view.RowFilter = "ApplicationID = " + tbSearchbox.Text;
                    dgvRecords.DataSource = view;
                }
                else if (cmFilteritem.SelectedIndex == 2)
                {
                    DataView view = Records.DefaultView;
                    view.RowFilter = "LocalDrivingLicenseApplicationID = " + tbSearchbox.Text;
                    dgvRecords.DataSource = view;
                }
                else if(cmFilteritem.SelectedIndex == 6)
                {
                   cmstatus.SelectedIndex = 0;
                }
                else
                {
                    
                    
                    DataView view = Records.DefaultView;
                    view.RowFilter = cmFilteritem.Text + "  LIKE '" + tbSearchbox.Text + "%'";
                    dgvRecords.DataSource = view;
                }
            }
            else
            {
                _Refresh();
            }
        }

        private void cmFilteritem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmFilteritem.SelectedIndex == 0)
            {
              tbSearchbox.Visible = false;
              cmstatus.Visible = false;
            }
            else
            {
                if (cmFilteritem.SelectedIndex == 6)
                {
                    tbSearchbox.Visible = false;
                    cmstatus.Visible = true;
                    cmstatus.SelectedIndex = 0;
                }
                else
                {
                    cmstatus.Visible = false;
                    tbSearchbox.Visible = true;
                }
                    
                if (cmFilteritem.SelectedIndex == 3)
                {
                    tbSearchbox.Text = "Class ";
                }
                else
                {
                    tbSearchbox.Text = "";
                }
            }
            

        }

        private void tbSearchbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cmFilteritem.SelectedIndex == 1 || cmFilteritem.SelectedIndex == 2)
            {
                if (char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void cmstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable Records = ClsLocalDrivingLecencesAppli.GetAllRecord();
            if ( cmstatus.SelectedIndex != 0)
            {
                DataView view = Records.DefaultView;
                view.RowFilter = cmFilteritem.Text + "  LIKE '" + cmstatus.Text + "%'";
                dgvRecords.DataSource = view;
            }
        }

        private void btmAddNew_Click(object sender, EventArgs e)
        {
            frmUpdateNewLocalDrivingLecencesApplication frm = new frmUpdateNewLocalDrivingLecencesApplication();
            frm.ShowDialog();
            _Refresh();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsLocalDrivingLecencesAppli lecencesAppli = ClsLocalDrivingLecencesAppli.Find((int)dgvRecords.CurrentRow.Cells[1].Value);
            if (MessageBox.Show("Do you want to delete this application , ??","Warning",MessageBoxButtons.YesNo)== DialogResult.Yes)
            {
                if (lecencesAppli.Delete())
                {
                    MessageBox.Show("Application Deleted Succefully");
                }
                else
                {
                    MessageBox.Show("sorry , this Application can\'t be deleted rigth now , try later !! or may be something linked with");
                }
                _Refresh();
            }
            
        }

        private void sechduleViewTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string status = (string)dgvRecords.CurrentRow.Cells[7].Value;
            if(status == "New")
            {
                // 1 im database is vision test 
                //2 in database is writing test
                //3 in database is street test
                frmTestManagement frm = new frmTestManagement((int)dgvRecords.CurrentRow.Cells[1].Value,1);
                frm.ShowDialog();
                _Refresh();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do you want to Cancel This application ? ","Warning",MessageBoxButtons.YesNo)== DialogResult.Yes)
            {
                if (clsApplications.CancelApplication((int)dgvRecords.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Application Canceled Succefully");
                    _Refresh();
                }
            }
        }

        private void sechduleWritingTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string status = (string)dgvRecords.CurrentRow.Cells[7].Value;

            if (status == "New")
            {
                // 1 im database is vision test 
                //2 in database is writing test
                //3 in database is street test
                frmTestManagement frm = new frmTestManagement((int)dgvRecords.CurrentRow.Cells[1].Value, 2);
                frm.ShowDialog();
                _Refresh();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void sechduleViewTestToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string status = (string)dgvRecords.CurrentRow.Cells[7].Value;

            if (status == "New")
            {
                // 1 im database is vision test 
                //2 in database is writing test
                //3 in database is street test
                frmTestManagement frm = new frmTestManagement( (int)dgvRecords.CurrentRow.Cells[1].Value, 3);
                frm.ShowDialog();
                _Refresh();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
        void _EnableAllThing()
        {
            cmViewTest.Enabled = true;
            cmStreetTest.Enabled = true;
            cmWritingtest.Enabled = true;
            cmSchedule.Enabled = true;
            cmIssue.Enabled = true;
            cmDelete.Enabled = true;
            cmedit.Enabled = true;
            cmCancel.Enabled = true;
            cmshowlicense.Enabled = true;
        }
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            clsPerson person = clsPerson.Find((string)dgvRecords.CurrentRow.Cells[3].Value);
             
            _EnableAllThing();
            int tests = ClsLocalDrivingLecencesAppli.numberOfPAssedTest((int)dgvRecords.CurrentRow.Cells[1].Value);
            if (tests > 0)//if the person pass 3 test thats mean he cant pass another test so we disabled the toolmenu of tests
            {
                cmedit.Enabled = false; 
                cmDelete.Enabled = false;
                cmCancel.Enabled = false;
            }
            if (tests<3) // here the person didnt pass the 3 tests yet so : 
            {
                
                if(tests == 0)//  *) 0 mean he didnt pass any test yet so must start with vision test , so we disabled the other toolmenu (street and writing)
                {
                    cmStreetTest.Enabled = false;
                    cmWritingtest.Enabled = false;
                }
                else if(tests == 1)//  **) 1 mean he pass vision test ,so he must pass writing test now , so we disabled the other toolmenu (street and vision)
                {
                    cmStreetTest.Enabled = false;
                    cmViewTest.Enabled = false;
                }
                else if(tests == 2) // ***) 2 mean he pass the writing test , so the same as (**) and (*) he must test the last test test
                {

                    cmWritingtest.Enabled = false;
                    cmViewTest.Enabled = false;
                }
                // here we disable the Issue new license and show license , because not able to issue it yet
                cmIssue.Enabled = false;
                cmshowlicense.Enabled = false;
            }
            else // here mean that the person pass all test and now ready to get hes license 
            {
                cmSchedule.Enabled = false;
                if (!clsLicense.IsThisPersonHasALicenseInThisClass(person.personID, clsClassesTypes.Find((string)dgvRecords.CurrentRow.Cells[2].Value)))
                {
                    cmshowlicense.Enabled = false;
                    cmIssue.Enabled = true;
                }
                else
                {
                    cmshowlicense.Enabled = true;
                    cmIssue.Enabled = false;
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cmIssue_Click(object sender, EventArgs e)
        {
            frmIssueLicenseFirstTime licenseFirstTime = new frmIssueLicenseFirstTime((int)dgvRecords.CurrentRow.Cells[1].Value);
            licenseFirstTime.ShowDialog();
            _Refresh();
        }

        private void cmshowlicense_Click(object sender, EventArgs e)
        {
            clsLicense license = clsLicense.FindByAppID((int)dgvRecords.CurrentRow.Cells[0].Value);
            frmShowLicenseDetails details = new frmShowLicenseDetails(license);
            details.ShowDialog();
            
        }

        private void showPersonLicenceHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsPerson person = clsPerson.Find((string)dgvRecords.CurrentRow.Cells[3].Value);
            frmshowlicenseHistory history = new frmshowlicenseHistory(person.personID);
            history.ShowDialog();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsPerson person = clsPerson.Find((string)dgvRecords.CurrentRow.Cells[3].Value);
            frmPersonDetails frm = new frmPersonDetails(person.personID);
            frm.ShowDialog();
        }
    }
}
