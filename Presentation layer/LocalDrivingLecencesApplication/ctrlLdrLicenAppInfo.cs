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

namespace DVLD_Project_19.LocalDrivingLecencesApplication
{
    public partial class ctrlLdrLicenAppInfo : UserControl
    {
       
        
        public ctrlLdrLicenAppInfo()
        {
            InitializeComponent();
        }
        void _SetClassName(int classID)
        {
            clsClassesTypes cls = clsClassesTypes.Find(classID);
            lblClassType.Text = cls.Name;
            
        }
        void _SetApplicationType(int ID)
        {
            clsApplicationTypes types = clsApplicationTypes.Find(ID);
            lblType.Text = types.title;
        }
        void _SetUserName(int ID)
        {
            clsUser user = clsUser.Find(ID);
            lblUserName.Text = user.username;
        }
        int _personId;
        void _SetPersonFullName(int ID)
        {
            clsPerson person = clsPerson.Find(ID);
            lblfullName.Text = person.firstname + " " + person.secondname + " " + person.thirdname + " " + person.lastname;
            _personId = ID;
        }
        void _SetApplicationsInfo(int AppsID)
        {
            string status = "";
            clsApplications cls = clsApplications.Find(AppsID,ref status);
            lblStatus.Text = status;
            lblID.Text = cls.applicationID.ToString();
            lblfees.Text = cls.paidfees.ToString();
            _SetApplicationType(cls.ApplicationTypeID);
            _SetUserName(cls.userid);
            _SetPersonFullName(cls.PersonID);
            lblDate.Text = cls.date.Year.ToString() + "/" + cls.date.Month.ToString() + "/" + cls.date.Day.ToString();
            lblstatusdate.Text = cls.laststatusdate.Year.ToString() + "/" + cls.laststatusdate.Month.ToString() + "/" + cls.laststatusdate.Day.ToString();
            
        }
        public void LoadInfo(int LocaldrivingLicenseAplicationID)
        {
            
            ClsLocalDrivingLecencesAppli _CurrentLocalApll = ClsLocalDrivingLecencesAppli.Find(LocaldrivingLicenseAplicationID);
            if(_CurrentLocalApll == null )
            {
                MessageBox.Show("this ID not found");
            }
            else
            {
                lblDlAppID.Text = _CurrentLocalApll.LocalDrivingLecencesID.ToString();
                lblPassedTest.Text = ClsLocalDrivingLecencesAppli.numberOfPAssedTest(LocaldrivingLicenseAplicationID).ToString();
                _SetClassName(_CurrentLocalApll.licenseClassID);
                _SetApplicationsInfo(_CurrentLocalApll.applicationID);
            }
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonDetails frm = new frmPersonDetails(_personId);
            frm.ShowDialog();
        }
    }
}
