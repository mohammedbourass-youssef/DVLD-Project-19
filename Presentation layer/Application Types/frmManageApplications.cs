using BusinessLogicLayer;
using DVLD_Project_19.Application_Types;
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
    public partial class frmManageApplications : Form
    {
        public frmManageApplications()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void _refresh()
        {
            dgvRecords.DataSource = clsApplicationTypes.GetAllApplicationsNAmes();
        }
        private void frmManageApplications_Load(object sender, EventArgs e)
        {
            _refresh();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateApplicationsType frmUpdateApplicationsType = new frmUpdateApplicationsType((int)dgvRecords.CurrentRow.Cells[0].Value);
            frmUpdateApplicationsType.ShowDialog();
            _refresh();
        }
    }
}
