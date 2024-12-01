using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project_19
{
    public partial class ctrlPersonCard : UserControl
    {
        clsPerson _person = null;
        string _manDefaultimage = "C:\\DVLD Images\\Male 512.png";
        string _womenDefaultimage = "C:\\DVLD Images\\Female 512.png";
        string _notfoundimage = "C:\\DVLD Images\\NotFound.png";
        public ctrlPersonCard()
        {
            InitializeComponent();
        }
        public int GetIG()
        {
            return _person.personID;
        }
        public void SetIDValue(int ID)
        {
            _person= clsPerson.Find(ID); 
        }
        public void SetIDValue(clsPerson person)
        {
            _person = person;
        }
        public void LoadInfo()
        {
            lblPersonID.Text = _person.personID.ToString();
            lblName.Text = _person.firstname+" " + _person.secondname + " " +  _person.thirdname + " " + _person.lastname;
            lblNationnalNo.Text = _person.nationalNO.ToString();
            lblPhone.Text = _person.phone.ToString();
            if (_person.gender == 0)
                lblGender.Text = "Male";
            else
                lblGender.Text = "Female";
            if (string.IsNullOrEmpty(_person.email))
                lblemail.Text = "set an email";
            else
                lblemail.Text = _person.email.ToString();
            lblAddress.Text = _person.address.ToString();
            lblCountry.Text = ClsCountry.FindByID(_person.countryID);
            lblDateOfBirth.Text = _person.dateofbirth.Day.ToString() + " / " +
                _person.dateofbirth.Month.ToString() + " / " + _person.dateofbirth.Year.ToString();
            if (string.IsNullOrEmpty(_person.imagepath))
            {
                if(_person.gender == 0)
                {
                    profile.Image = Image.FromFile(_manDefaultimage);
                }
                else
                    profile.Image= Image.FromFile(_womenDefaultimage);
            }
            else
            {
                try
                {
                    profile.Image = Image.FromFile(_person.imagepath);
                }
                catch
                {
                    profile.Image = Image.FromFile(_notfoundimage);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void profile_Click(object sender, EventArgs e)
        {

        }
    }
}
