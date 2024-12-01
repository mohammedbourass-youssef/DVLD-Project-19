using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;
using DVLD_Project_19.people;
namespace DVLD_Project_19
{
    public partial class frmManagePeople : Form
    {
        
        enum enFilteritems { None=0,personID=1,nationalNO=2,firstname=3,secondname=4,lastname=5,gender=6}
        enFilteritems _currentfiller = enFilteritems.None;
        enFilteritems _cmitemtoenum()
        {
            tbSearchbox.Visible = true;
            switch(cmFilteritem.SelectedIndex)
            {
                case 0: tbSearchbox.Visible = false;  return enFilteritems.None;
                case 1:return enFilteritems.personID;
                case 2:return enFilteritems.nationalNO;
                case 3: return enFilteritems.firstname;
                case 4: return enFilteritems.secondname;
                case 5 : return enFilteritems.lastname;
                case 6:return enFilteritems.gender;
                default:return enFilteritems.None;
            }
        }
        public frmManagePeople()
        {
            InitializeComponent();
        }
         void _LoadAllRecords()
        {
            DataTable Records = clsPerson.PeopleListWithCountriesName();
            lblRecord.Text =Records.Rows.Count.ToString();
            dgvRecords.DataSource = Records;
            
        }
        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            cmFilteritem.SelectedIndex = 0;
            _LoadAllRecords();
        }

        private void btmAddNew_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frmAddUpdatePerson = new frmAddUpdatePerson();

            frmAddUpdatePerson.ShowDialog();
            _LoadAllRecords();
            frmAddUpdatePerson.Close();
        }

        public static bool CreateFolderIfDoesNotExist(string FolderPath)
        {

            // Check if the folder exists
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    // If it doesn't exist, create the folder
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating folder: " + ex.Message);
                    return false;
                }
            }

            return true;

        }
        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.ShowDialog();
            frm.Dispose();
            
            _LoadAllRecords();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson((int)dgvRecords.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frm.Dispose();
            _LoadAllRecords();
            
        }
        
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = (int)dgvRecords.CurrentRow.Cells[0].Value;
            if (MessageBox.Show("Do you want to delete person ID = "+id.ToString(), "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                clsPerson person = clsPerson.Find(id);
                if (person != null)
                {
                    if (person.Delete())
                    {
                        if(person.imagepath!="")
                            File.Delete(person.imagepath);
                            MessageBox.Show("Deleted Succefully");
                    }
                    else
                        MessageBox.Show("system cant delete this person,it propably in use");
                }
            }
            _LoadAllRecords();
        }

        private void cmFilteritem_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentfiller = _cmitemtoenum();

        }

        private void tbSearchbox_TextChanged(object sender, EventArgs e)
        {
            DataTable Records = clsPerson.PeopleListWithCountriesName();
            if (!string.IsNullOrEmpty(tbSearchbox.Text))
            {
                if(_currentfiller == enFilteritems.personID)
                {
                    DataView view = Records.DefaultView;
                    view.RowFilter = "PersonID = "+tbSearchbox.Text;
                    dgvRecords.DataSource = view;
                }
                else
                {
                    DataView view = Records.DefaultView;
                    view.RowFilter = cmFilteritem.Text + "  LIKE '" + tbSearchbox.Text + "%'";
                    dgvRecords.DataSource = view;
                }
            }
            else
            {
                _LoadAllRecords();
            }

        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmPersonDetails frm = new frmPersonDetails( (int)dgvRecords.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _LoadAllRecords();
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("sorry,this Features not Implented yet");
        }

        private void callPhoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("sorry,this Features not Implented yet");
        }
    }
}
