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
    public partial class frmUpdateNewLocalDrivingLecencesApplication : Form
    {
        int _personID = 0;
        int _localDrivingLincense = 0; 
        enum enMode { AddNew, Update }
        enMode _mode = enMode.AddNew;
        public frmUpdateNewLocalDrivingLecencesApplication()
        {
            _mode = enMode.AddNew;
            InitializeComponent();
        }

        public frmUpdateNewLocalDrivingLecencesApplication(int localdrivinglicense)
        {
            _localDrivingLincense = localdrivinglicense;
            _mode = enMode.AddNew;
            InitializeComponent();
        }

        void _SetDefaultDate()
        {
            DateTime time = DateTime.Now;
            lblDate.Text = time.Day.ToString() +" / ";
            lblDate.Text += time.Month.ToString() +" / ";
            lblDate.Text += time.Year.ToString();

        }
        double _SetFees()
        {
            clsApplicationTypes type = clsApplicationTypes.Find(1);
            lblAppFees.Text = type.fees.ToString();
            return type.fees;
        }
        void _setCurrentUser()
        {
            LblUser.Text = clsGlobal.CurrentUser.username;
        }
        void _SetClassesTypeComboBox()
        {
            DataTable dt = clsClassesTypes.GetAllClassTypeName();
            foreach(DataRow dr in dt.Rows)
            {
                cmClassesTypes.Items.Add(dr[0].ToString());
            }
            cmClassesTypes.SelectedIndex = 2;
        }
        void _InitializeControlsDefaultValues()
        {
            lblTitle.Text = "New Local Driving Licences";
            ctrlFindPersoncs1.dataBack += _GetTheData;
            _SetDefaultDate();
            _SetFees();
            _setCurrentUser();
            _SetClassesTypeComboBox();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _GetTheData(object sender, int PersonID)
        {
            _personID = PersonID;
            ctrlPersonCard1.SetIDValue(PersonID);
            ctrlPersonCard1.LoadInfo();
        }
        private void frmNewLocalDrivingLecencesApplication_Load(object sender, EventArgs e)
        {
           _InitializeControlsDefaultValues();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_personID == 0)
            {
                MessageBox.Show("Please enter a person information , or Add a person");
            }
            else
            {
                tabControl1.SelectedIndex = 1;
            }
        }

        private void Find_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _personID = 0;
            ctrlFindPersoncs1.Load();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_personID !=0) { 
                if (tabControl1.SelectedIndex == 0)
                {
                    tabControl1.SelectedIndex = 1;
                }
                else
                {
                    int ID = clsClassesTypes.Find(cmClassesTypes.Text);
                    clsClassesTypes Class = clsClassesTypes.Find(ID);
                    if(clsLicense.IsThisPersonHasALicenseInThisClass(_personID, Class.ID))
                    {
                        MessageBox.Show("This Person Already has License for this Class Please , try another person/class");
                    }
                    else
                    {
                        if (ClsLocalDrivingLecencesAppli.IsExist(_personID, Class.ID))
                        {
                            MessageBox.Show("This Person Already has an Application for this Class Please , try another person/class");
                        }
                        else
                        {

                            clsApplications application = new clsApplications();
                            application.userid = clsGlobal.CurrentUser.UserID;
                            application.ApplicationTypeID = 1;
                            application.paidfees = _SetFees() + Class.fees;
                            application.PersonID = _personID;
                            if (application.Save())
                            {
                                ClsLocalDrivingLecencesAppli lecences = new ClsLocalDrivingLecencesAppli();
                                lecences.licenseClassID = Class.ID;
                                lecences.applicationID = application.applicationID;
                                if (lecences.Save())
                                {
                                    MessageBox.Show("Saved Succefully");
                                }
                                else
                                    MessageBox.Show("Error try agin1");
                            }
                            else
                            {
                                MessageBox.Show("Error try agin");
                            }
                        }
                    }
                }
                }
        }
    }
}
