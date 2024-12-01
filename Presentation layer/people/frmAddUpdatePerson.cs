using BusinessLogicLayer;
using Guna.UI2.HtmlRenderer.Adapters;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project_19
{
    public partial class frmAddUpdatePerson : Form
    {
        
       public int _personID {  get; set; }
        clsPerson oldperson = null;
        
        string _manDefaultimage = "C:\\DVLD Images\\Male 512.png";
        string _womenDefaultimage = "C:\\DVLD Images\\Female 512.png";
        string _notfoundimage = "C:\\DVLD Images\\NotFound.png";
        string _profilepath;
        public delegate void DataBackHandler(object obj, int personid);
        public event DataBackHandler DataBack;


        bool _IsAllRequiredsRecordFull()
        {
            if (string.IsNullOrEmpty(tbAddress.Text) || string.IsNullOrEmpty(tbFirstName.Text) || string.IsNullOrEmpty(tbLastNme.Text) ||
                string.IsNullOrEmpty(tbSeconName.Text) || string.IsNullOrEmpty(tbNationnalNum.Text) || string.IsNullOrEmpty(tbPhone.Text)
               ) return false; return true;
        }
        public void UserAddUpdatePErson_Load()
        {
            DateTime x = DateTime.Now;
            DateofBirth.MaxDate = x.AddYears(-18);
            rbMale.Checked = true;
            Profile.Image = Image.FromFile(_manDefaultimage);
            DataTable dt = ClsCountry.GetAllCountries();
            foreach (DataRow data in dt.Rows)
            {
                cmCountry.Items.Add(data["CountryName"]);
            }
            cmCountry.SelectedIndex = 117;
            if (_personID > 0)
            {
                oldperson = clsPerson.Find(_personID);
                tbNationnalNum.Text = oldperson.nationalNO;
                tbFirstName.Text = oldperson.firstname;
                tbSeconName.Text = oldperson.secondname;
                tbThirdNAme.Text = oldperson.thirdname;
                tbLastNme.Text = oldperson.lastname;
                tbAddress.Text = oldperson.address;
                if (oldperson.gender == 0)
                    rbMale.Checked = true;
                else
                    rbFemae.Checked = true;
                if (oldperson.imagepath == string.Empty)
                {
                    if (oldperson.gender == 0)
                        Profile.Image = Image.FromFile(_manDefaultimage);
                    else
                        Profile.Image = Image.FromFile(_womenDefaultimage);
                }
                else
                {
                    try
                    {
                        Profile.ImageLocation =oldperson.imagepath;
                        _profilepath = oldperson.imagepath;
                    }
                    catch (Exception ex)
                    {

                        Profile.Image = Image.FromFile(_notfoundimage);

                    }

                }

                tbEmail.Text = oldperson.email;
                tbPhone.Text = oldperson.phone;
                DateofBirth.Value = oldperson.dateofbirth;
                cmCountry.Text = ClsCountry.FindByID(oldperson.countryID);
            }
        }
        void _CreateNewPerson(EventArgs e)
        {
            clsPerson newperson = new clsPerson();
            newperson.nationalNO = tbNationnalNum.Text;
            newperson.firstname = tbFirstName.Text;
            newperson.secondname = tbSeconName.Text;
            if (string.IsNullOrEmpty(tbThirdNAme.Text))
                newperson.thirdname = string.Empty;
            else
                newperson.thirdname = tbThirdNAme.Text;

            newperson.lastname = tbLastNme.Text;
            if (!string.IsNullOrEmpty(_profilepath))
            {
                Image image = Image.FromFile(_profilepath);
                string guid = Guid.NewGuid().ToString();
                newperson.imagepath = "C:\\DVLD Images\\" + guid + ".png";
                image.Save(newperson.imagepath, ImageFormat.Png);
            }
            else
            {
                newperson.imagepath = string.Empty;
            }
            if (string.IsNullOrEmpty(tbEmail.Text))
                newperson.email = string.Empty;
            else
                newperson.email = tbEmail.Text;
            newperson.phone = tbPhone.Text;
            newperson.dateofbirth = DateofBirth.Value;

            newperson.countryID = ClsCountry.FindByName(cmCountry.Text);
            if (rbFemae.Checked)
                newperson.gender = 1;
            else if (rbMale.Checked)
                newperson.gender = 0;
            newperson.address = tbAddress.Text;
            if (MessageBox.Show("Are you sure you want to add this person?", "Attention", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (newperson.Save())
                {
                    DataBack?.Invoke(this, newperson.personID);
                    MessageBox.Show("Data Saved Succefully");
                    _personID = newperson.personID;
                    frmAddUpdatePerson_Load(this, e);
                }


            }
        }
        void _EditPerson(EventArgs e)
        {
            oldperson.nationalNO = tbNationnalNum.Text;
            oldperson.firstname = tbFirstName.Text;
            oldperson.secondname = tbSeconName.Text;
            if (string.IsNullOrEmpty(tbThirdNAme.Text))
                oldperson.thirdname = string.Empty;
            else
                oldperson.thirdname = tbThirdNAme.Text;

            oldperson.lastname = tbLastNme.Text;
            if (!string.IsNullOrEmpty(_profilepath))
            {
                
                Image image = Image.FromFile(_profilepath);
                string guid = Guid.NewGuid().ToString();
                oldperson.imagepath = "C:\\DVLD Images\\" + guid + ".png";
                image.Save(oldperson.imagepath, ImageFormat.Png);
                
            }
            else
            {
                oldperson.imagepath = string.Empty;
            }
            if (string.IsNullOrEmpty(tbEmail.Text))
                oldperson.email = string.Empty;
            else
                oldperson.email = tbEmail.Text;
            oldperson.phone = tbPhone.Text;
            oldperson.dateofbirth = DateofBirth.Value;

            oldperson.countryID = ClsCountry.FindByName(cmCountry.Text);
            if (rbFemae.Checked)
                oldperson.gender = 1;
            else if (rbMale.Checked)
                oldperson.gender = 0;
            oldperson.address = tbAddress.Text;
            if (MessageBox.Show("Are you sure you want to add this person?", "Attention", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (oldperson.Save())
                {
                    MessageBox.Show("Saved Succefully");
                }


            }
        }
        public frmAddUpdatePerson(int ID)
        {
            _personID = ID;
            InitializeComponent();
           
        }
        public frmAddUpdatePerson()
        {
            _personID =0;
            InitializeComponent();

        }
        public void frmAddUpdatePerson_Load(object sender, EventArgs e)
        {
            UserAddUpdatePErson_Load();
            if (_personID == 0)
            {
                lblTitle.Text = "Add new person";
                lblPersonID.Text = "N/A";
            }
            else
            {
                lblTitle.Text = "Edit  Person Information";
                lblPersonID.Text = _personID.ToString();
            }

        }
        void _GetID(object sender, int personid)
        {
            DataBack?.Invoke(this, personid);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_IsAllRequiredsRecordFull())
            {
                if (oldperson == null)
                {
                    _CreateNewPerson(e);
                }
                else
                {
                    _EditPerson(e);
                }
            }
            else
                MessageBox.Show("There Is some empty boxes", "invalid inputs");
        }        
  
       private void tbFirstName_Validating(object sender, CancelEventArgs e)
            {
                TextBox textBox = (TextBox)sender;
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    e.Cancel = true;
                    textBox.Focus();
                    ErrControlEmpty.SetError(textBox, "Required info");
                }
                else
                {
                    e.Cancel = false;
                    ErrControlEmpty.SetError(textBox, "");
                }

            }
       private void rbMale_CheckedChanged(object sender, EventArgs e)
            {

                if (Profile.Tag.ToString() == "Default")
                {
                    Profile.Image = Image.FromFile(_manDefaultimage);
                }

            }
       private void rbFemae_CheckedChanged(object sender, EventArgs e)
            {

                if (Profile.Tag.ToString() == "Default")
                {
                    Profile.Image = Image.FromFile(_womenDefaultimage);
                }

            }
       static bool _IsValidEmail(string email)
            {
                // Regex pattern to match xxxxxxx@xxxx.xxx format
                string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                return Regex.IsMatch(email, pattern);
            }
       private void tbEmail_Validating(object sender, CancelEventArgs e)
            {
                if (!string.IsNullOrEmpty(tbEmail.Text))
                {
                    if (!_IsValidEmail(tbEmail.Text))
                    {
                        e.Cancel = true;
                        tbEmail.Focus();
                        ErrControlEmpty.SetError(tbEmail, "Required info");
                    }
                    else
                    {
                        e.Cancel = false;
                        ErrControlEmpty.SetError(tbEmail, "");
                    }
                }
            }

       private void tbNationnalNum_Validating(object sender, CancelEventArgs e)
            {

                if (string.IsNullOrEmpty(tbNationnalNum.Text))
                {
                    e.Cancel = true;
                    tbNationnalNum.Focus();
                    ErrControlEmpty.SetError(tbNationnalNum, "Required info");
                }
                else if (clsPerson.IsExist(tbNationnalNum.Text))
                {
                    e.Cancel = true;
                    tbNationnalNum.Focus();
                    ErrControlEmpty.SetError(tbNationnalNum, "This Nationnal Number already exist");
                }
                else
                {
                    e.Cancel = false;
                    ErrControlEmpty.SetError(tbNationnalNum, "");
                }
            }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Profile.ImageLocation = openFileDialog1.FileName;
                _profilepath = openFileDialog1.FileName.ToString();
                Profile.Tag = "changed";
            }
            
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Profile.Tag = "Default";
                _profilepath = string.Empty;
            if(rbFemae.Checked)
            {
                Profile.ImageLocation = _womenDefaultimage;
            }
            else
                Profile.ImageLocation = _manDefaultimage;
        }

        private void cmCountry_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    }


