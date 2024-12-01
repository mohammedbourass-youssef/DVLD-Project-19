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

namespace DVLD_Project_19.Application_Types
{
    public partial class frmUpdateApplicationsType : Form
    {
        clsApplicationTypes applicationTypes = null;
        public frmUpdateApplicationsType(int ID)
        {
            applicationTypes = clsApplicationTypes.Find(ID);
            InitializeComponent();
        }
        void _Load()
        {
            lblID.Text = applicationTypes.ID.ToString();
            tbFees.Text = applicationTypes.fees.ToString();
            tbTitle.Text = applicationTypes.title.ToString();
        }
        private void tbFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsLetter(e.KeyChar)&&e.KeyChar != '\0')
            {
                e.Handled = true;
            }
            else
                e.Handled = false;
        }

        private void frmUpdateApplicationsType_Load(object sender, EventArgs e)
        {
            _Load();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        bool _Save()
        {
            applicationTypes.fees = Convert.ToDouble(tbFees.Text);
            applicationTypes.title = tbTitle.Text;
            return applicationTypes.Save();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_Save())
            {
                MessageBox.Show("new information saved succefully");
            }
            else
            {
                MessageBox.Show("error 404");
            }
        }
    }
}
