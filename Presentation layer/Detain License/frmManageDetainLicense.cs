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

namespace DVLD_Project_19.Detain_License
{
    public partial class frmManageDetainLicense : Form
    {
        enum enFilter {None ,NationallNumber,detainID,isrealesd,fullname,releaseappID}
        public frmManageDetainLicense()
        {
            InitializeComponent();
        }
        enFilter _currentfilter = enFilter.None;
        void _refresh()
        {
            DataTable fb = clsDetainedLicense.GetCustumRecords();
            dgvRecords.DataSource = fb;
            lblRecord.Text = fb.Rows.Count.ToString();
        }
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void frmManageDetainLicense_Load(object sender, EventArgs e)
        {
            _refresh();
            cmFilteritem.SelectedIndex = 0;
          
        }
        //(int)dgvRecords.CurrentRow.Cells[4].Value
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if ((bool)dgvRecords.CurrentRow.Cells[3].Value)
            {
                realesemenuitem.Enabled = false;
            }
            else
            {
                realesemenuitem.Enabled = true;
            }
        }

        private void btnRealese_Click(object sender, EventArgs e)
        {
            frmRelease frm  = new frmRelease();
            frm.ShowDialog();
            _refresh();
        }

        private void btmDetain_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
            _refresh();
        }

        private void realesemenuitem_Click(object sender, EventArgs e)
        {
            clsDetainedLicense x = clsDetainedLicense.Find((int)dgvRecords.CurrentRow.Cells[1].Value);
            clsLicense y = clsLicense.Find((int)dgvRecords.CurrentRow.Cells[1].Value);
            frmRelease realese = new frmRelease(x,y);
            realese.ShowDialog();
            _refresh();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void _GetFilter()
        {
            switch (cmFilteritem.SelectedIndex)
            {
                case 0:
                    cmIsRealesed.Visible = false;
                    tbSearchbox.Visible = false;
                    _currentfilter = enFilter.None;
                    break;
                case 3:
                    cmIsRealesed.Visible = true;
                    tbSearchbox.Visible = false;
                    _currentfilter = enFilter.isrealesd;
                    break;
                case 1:
                    cmIsRealesed.Visible = false;
                    tbSearchbox.Visible = true;
                    _currentfilter = enFilter.NationallNumber;
                    break;
                case 2:
                    cmIsRealesed.Visible = false;
                    tbSearchbox.Visible = true;
                    _currentfilter = enFilter.detainID;
                    break;
                case 4:
                    cmIsRealesed.Visible = false;
                    tbSearchbox.Visible = true;
                    _currentfilter = enFilter.fullname;
                    break;
                case 5:
                    cmIsRealesed.Visible = false;
                    tbSearchbox.Visible = true;
                    _currentfilter = enFilter.releaseappID;
                    break;
                default:
                    cmIsRealesed.Visible = false;
                    tbSearchbox.Visible = false;
                    _currentfilter = enFilter.None;
                    break;
            }
        }
        private void cmFilteritem_SelectedIndexChanged(object sender, EventArgs e)
        {
            _GetFilter();
        }
        //filter functions 
        void FilterByNationallNumber()
        {
            DataTable Records = clsDetainedLicense.GetCustumRecords();
            if (!string.IsNullOrEmpty(tbSearchbox.Text))
            {
               DataView view = Records.DefaultView;
               view.RowFilter = "Na_No LIKE '" + tbSearchbox.Text + "%'";
               dgvRecords.DataSource = view;
            }
            else
            {
                _refresh();
            }
        }

        void FilterByDetainID()
        {
            DataTable Records = clsDetainedLicense.GetCustumRecords();
            if (!string.IsNullOrEmpty(tbSearchbox.Text))
            {

                DataView view = Records.DefaultView;
                view.RowFilter = "D_ID = " + tbSearchbox.Text;
                dgvRecords.DataSource = view;
            }
        }

        void FilterByFullName()
        {
            DataTable Records = clsDetainedLicense.GetCustumRecords();
            if (!string.IsNullOrEmpty(tbSearchbox.Text))
            {

                //DataView view = Records.DefaultView;
                //view.RowFilter = "D_ID = " + tbSearchbox.Text;
                //dgvRecords.DataSource = view;
                DataView view = Records.DefaultView;
                view.RowFilter = "full_name  LIKE '" + tbSearchbox.Text + "%'";
                dgvRecords.DataSource = view;
            }
            else
            {
                _refresh();
            }
        }

        void FilterByReleaseApplicationID()
        {
            DataTable Records = clsDetainedLicense.GetCustumRecords();
            if (!string.IsNullOrEmpty(tbSearchbox.Text))
            {

                DataView view = Records.DefaultView;
                view.RowFilter = "ReleaseApplicationID = " + tbSearchbox.Text;
                dgvRecords.DataSource = view;
                //DataView view = Records.DefaultView;
                //view.RowFilter = "full_name  LIKE '" + tbSearchbox.Text + "%'";
                //dgvRecords.DataSource = view;
            }
            else
            {
                _refresh();
            }
        }

        void Filter()
        {
            switch (_currentfilter)
            {
                case enFilter.fullname:FilterByFullName(); break;
                case enFilter.releaseappID:FilterByReleaseApplicationID(); break;
                case enFilter.detainID: FilterByDetainID(); break;
                case enFilter.NationallNumber:FilterByNationallNumber(); break;
            }
        }
        private void cmIsRealesed_SelectedIndexChanged(object sender, EventArgs e)
        {
           
           DataTable Records = clsDetainedLicense.GetCustumRecords();
           DataView view = Records.DefaultView;
           switch (cmIsRealesed.SelectedIndex)
           {
               case 0:      
                   view.RowFilter = "Is_Released = 1";     
                   break;
               case 1:
                   view.RowFilter = "Is_Released = 0";
                   break;
           }
           dgvRecords.DataSource = view;
                
        }

        private void tbSearchbox_TextChanged(object sender, EventArgs e)
        {
            Filter();
           
        }
    }
}
