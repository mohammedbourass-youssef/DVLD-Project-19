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

namespace DVLD_Project_19.Drivers
{
    public partial class frmManageDriver : Form
    {
        enum enFilterMode {none,driverID,personID,nationnalNo,fullNAem,activeLicenses }

        enFilterMode _currentfilter = enFilterMode.none;
        DataTable _records = null;
        public frmManageDriver()
        {
            InitializeComponent();
        }

        enFilterMode _GetFilterMode()
        {
            switch (cmFilteritem.SelectedIndex)
            {
                case 0:return enFilterMode.none;
                case 1: return enFilterMode.driverID;
                case 2: return enFilterMode.personID;
                case 3: return enFilterMode.nationnalNo;
                case 4: return enFilterMode.fullNAem;
                case 5: return enFilterMode.activeLicenses;
                default: return enFilterMode.none;
            }
        }

        void _ShowSearchBox()
        {
            if (_currentfilter == enFilterMode.none)
            {
                tbSearchbox.Visible = false;
            }
            else
            {
                
                tbSearchbox.Visible = true;
                tbSearchbox.Focus();
            }
        }

        void _Filter()
        {
            DataView filtred= _records.DefaultView;

            if (_currentfilter != enFilterMode.nationnalNo && _currentfilter != enFilterMode.fullNAem)
            {

                filtred.RowFilter = cmFilteritem.Text +" = " + tbSearchbox.Text;
                dgvRecords.DataSource = filtred;
            }
            else
            {
               
                filtred.RowFilter = cmFilteritem.Text + "  LIKE '" + tbSearchbox.Text + "%'";
                dgvRecords.DataSource = filtred;
            }
        }
        void _refresh()
        {
            _records = clsDriver.GetAll();
            dgvRecords.DataSource = _records;
            lblrecordcount.Text = dgvRecords.RowCount.ToString();
        }
          
        
        private void frmManageDriver_Load(object sender, EventArgs e)
        {
            _refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmFilteritem_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentfilter = _GetFilterMode();
            _ShowSearchBox();
            _refresh();
        }

        private void tbSearchbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(_currentfilter != enFilterMode.fullNAem && _currentfilter != enFilterMode.nationnalNo)
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
        }

        private void tbSearchbox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbSearchbox.Text))
            {
                _Filter();
            }
            else
            {
                _refresh();
            }
        }
    }
}
