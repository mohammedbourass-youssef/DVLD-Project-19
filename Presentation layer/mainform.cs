using BusinessLogicLayer;
using DVLD_Project_19.Application;
using DVLD_Project_19.Detain_License;
using DVLD_Project_19.Drivers;
using DVLD_Project_19.internationnal_driving_license;
using DVLD_Project_19.LocalDrivingLecencesApplication;
using DVLD_Project_19.Renew_Driving_License;
using DVLD_Project_19.replace_for_damage_or_lost;
using DVLD_Project_19.Test_types;
using DVLD_Project_19.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project_19
{
    public partial class frmMainForm : Form
    {
      

        public frmMainForm()
        {
            
            InitializeComponent();
        }
        public static bool CreateFolderIfDoesNotExist(string FolderPath)
        {

            // Check if the folder exists
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    // If it doesn't exist, create the folder
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating folder: " + ex.Message);
                    return false;
                }
            }

            return true;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CreateFolderIfDoesNotExist("C:\\\\DVLD Images");
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnPeople_Click(object sender, EventArgs e)
        {
            frmManagePeople frm = new frmManagePeople();
            
           
            frm.ShowDialog();
        }

        private void btnApplication_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void acountSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageUsers frm = new frmManageUsers();
            frm.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void changePAsswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmchangePassword frmchange = new frmchangePassword();
            frmchange.ShowDialog();
        }

        private void currentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowUserInfo frm = new frmShowUserInfo(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void applicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageApplications frm = new frmManageApplications();
            frm.ShowDialog();
        }

        private void manageTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestTypes frm = new frmManageTestTypes();
            frm.ShowDialog();
        }

        private void localDrivingLeceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMAnageLocalDrivingLecences frm = new frmMAnageLocalDrivingLecences();
            frm.ShowDialog();
        }

        private void localDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateNewLocalDrivingLecencesApplication frm = new frmUpdateNewLocalDrivingLecencesApplication();
            frm.ShowDialog();
        }

        private void applicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDriver frm = new frmManageDriver();
            frm.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewInternationnalDrivingLicense newinterdr = new frmNewInternationnalDrivingLicense();
            newinterdr.ShowDialog();
        }

        private void internationnalLicencsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageInternationnalDrivinglicens frm = new frmManageInternationnalDrivinglicens();
            frm.ShowDialog();
        }

        private void renewDrivingLicencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
             frmRenewDrivingLicenseApp frm = new frmRenewDrivingLicenseApp();
            frm.ShowDialog();
        }

        private void replacementForALostDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplaceForReplacedOrDamaged frmReplace = new frmReplaceForReplacedOrDamaged();
            frmReplace.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
        }

        private void manageDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDetainLicense detainLicense = new frmManageDetainLicense();
            detainLicense.ShowDialog();
        }

        private void releaseDetainedDrivingLicsenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRelease frm = new frmRelease();
            frm .ShowDialog();  
        }
    }
}
