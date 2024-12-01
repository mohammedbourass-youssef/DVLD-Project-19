using DVLD_Project_19.people;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project_19
{
    public partial class frmPersonDetails : Form
    {
        int _personID;
        public frmPersonDetails(int personID)
        {
            InitializeComponent();
            _personID = personID;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

        private void frmPersonDetails_Load(object sender, EventArgs e)
        {
            ctrlPersonCard1.SetIDValue(this._personID);
            ctrlPersonCard1.LoadInfo();
        }

        private void likedlabelEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson(_personID);
            frm.ShowDialog();
            ctrlPersonCard1.SetIDValue(this._personID);
            ctrlPersonCard1.LoadInfo();
        }
    }
}
