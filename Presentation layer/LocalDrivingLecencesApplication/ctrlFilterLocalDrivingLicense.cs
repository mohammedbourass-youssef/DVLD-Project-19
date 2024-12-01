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
    public partial class ctrlFilterLocalDrivingLicense : UserControl
    {
        

        
        public ctrlFilterLocalDrivingLicense()
        {
            InitializeComponent();
        }
      

         bool IsSenderIsInternationnalLicense = false;
        public delegate void DataBackHandler(object sender, clsLicense LicenseID);
        public event DataBackHandler dataBack;
        public void Load(bool ISinterlice)
        {
            IsSenderIsInternationnalLicense = ISinterlice; 
            tbSearchbox.Text = string.Empty;
           
            this.Enabled = true;
        }
        public void CloseMe()
        {
            this.Enabled = false;
        }
        void _FindLicense()
        {
            clsLicense license = null;
            if (IsSenderIsInternationnalLicense)
                license = clsLicense.FindTheClassOrdinarydrivinglicense(int.Parse(tbSearchbox.Text.Trim()));
            else
                license = clsLicense.Findlicense(int.Parse(tbSearchbox.Text.Trim()));
            if (license != null)
            {
                dataBack?.Invoke(this, license);
                //this.Enabled = false;
            }
            else
                MessageBox.Show("this license didn\'t exist , try again !!!");
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbSearchbox.Text))
            {
                MessageBox.Show("The search box is empty");
            }
            else
            {
                _FindLicense();
            }
        }

        private void tbSearchbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbSearchbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
