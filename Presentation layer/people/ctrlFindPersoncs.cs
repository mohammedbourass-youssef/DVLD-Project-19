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

namespace DVLD_Project_19.people
{
    public partial class ctrlFindPersoncs : UserControl
    {
        public ctrlFindPersoncs()
        {
            InitializeComponent();
        }
        public delegate void DataBackHandler(object sender, int PersonID);
        public event DataBackHandler dataBack;
        public void Load()
        {
            tbSearchbox.Text =string.Empty;
           cmfilteritems.SelectedIndex = 0;
            this.Enabled = true;
        }
        private bool _GetPersonInfo()
        {
            if (cmfilteritems.SelectedIndex == 1)
            {
                if (string.IsNullOrWhiteSpace(tbSearchbox.Text))
                {
                    MessageBox.Show("The search box is empty");
                    return false;
                }
                else
                {
                    int PersonID = int.Parse(tbSearchbox.Text);
                    clsPerson person = clsPerson.Find(PersonID);
                    if (person != null)
                    {
                        dataBack?.Invoke(this, PersonID);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("this ID unfound");
                        return false;
                    }
                }
            }
            else if (cmfilteritems.SelectedIndex == 2)//find by nationallno
            {
                if (string.IsNullOrWhiteSpace(tbSearchbox.Text))
                {
                    MessageBox.Show("The search box is empty");
                    return false;
                }
                else
                {
                    clsPerson person = clsPerson.Find(tbSearchbox.Text);

                    if (person != null)
                    {
                        dataBack?.Invoke(this, person.personID);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("this ID unfound");
                        return false;
                    }
                }
            }
            else if (cmfilteritems.SelectedIndex == 3)//find by FirstName
            {
                if (string.IsNullOrWhiteSpace(tbSearchbox.Text))
                {
                    MessageBox.Show("The search box is empty");
                    return false;
                }
                else
                {
                    clsPerson person = clsPerson.FindByFirstName(tbSearchbox.Text);

                    if (person != null)
                    {
                        dataBack?.Invoke(this, person.personID);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("this ID unfound");
                        return false;
                    }
                }
            }
            else if (cmfilteritems.SelectedIndex == 4)//find by LastName
            {
                if (string.IsNullOrWhiteSpace(tbSearchbox.Text))
                {
                    MessageBox.Show("The search box is empty");
                    return false;
                }
                else
                {
                    clsPerson person = clsPerson.FindByLastName(tbSearchbox.Text);

                    if (person != null)
                    {
                        dataBack?.Invoke(this, person.personID);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("this ID unfound");
                        return false;
                    }
                }
            }
            return false;
        }
        private void cmfilteritems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmfilteritems.SelectedIndex != 0)
            {
                tbSearchbox.Visible = true;
            }
            else
                tbSearchbox.Visible = false;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (_GetPersonInfo())
            {
                this.Enabled = false;
            }

        }

        private void tbSearchbox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void tbSearchbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cmfilteritems.SelectedIndex == 1)
            {
                if (char.IsLetter(e.KeyChar))
                {
                    e.Handled = true;
                }
                else
                    e.Handled = false;
            }

        }
        void _getID(object obj,int ID)
        {
            tbSearchbox.Text = ID.ToString();
            cmfilteritems.SelectedIndex = 1;
            dataBack?.Invoke(this, ID);
            this.Enabled = false;
        }
        private void btmAddPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.DataBack += _getID;
            frm.ShowDialog();
        }
    }
}
