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
using Microsoft.VisualBasic.ApplicationServices;

namespace DVLD_Project_19
{
    public partial class frmLogginScreen : Form
    {
       
        public frmLogginScreen()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chbshowPAssword_CheckedChanged(object sender, EventArgs e)
        {
            if(!chbshowPAssword.Checked)
            {
                tbPassword.PasswordChar = '*';
            }
            else
            {
                tbPassword.PasswordChar = '\0';
            }
        }
        void _SaveRemember(int userID)
        {
            string filePath = "Remember.txt";
            string newData = userID.ToString();
            File.WriteAllText(filePath, newData);
            
        }
        clsUser _getThelastRemmberedUser()
        {
            string filePath = "Remember.txt";
            string fileContent = File.ReadAllText(filePath);
            int ID = 0;
            if (!string.IsNullOrEmpty(fileContent))
            {
                 ID = int.Parse(fileContent);
            }
            return clsUser.Find(ID);
        }
        void DeleteFile()
        {
            string filePath = "Remember.txt";
            string newData = string.Empty;
            File.WriteAllText(filePath, newData);
        }

        void _fillTextBoxes(clsUser user)
        {
            tbUsername.Text = user.username;
            tbPassword.Text = user.password;
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
             clsUser user = clsUser.Find(tbUsername.Text);
            if(user == null)
            {
                MessageBox.Show("this username/password incorrect");
            }
            else
            {
                if(user.password == tbPassword.Text&&user.IsActive)
                {
                    if (chbrememberme.Checked)
                    {
                        _SaveRemember(user.UserID);
                    }
                    else
                    {
                       DeleteFile();    
                    }
                    this.Hide();
                    clsGlobal.CurrentUser = user;   
                    frmMainForm menu = new frmMainForm();
                     menu.ShowDialog();
                     this.Show();
                    clsGlobal.CurrentUser = null;
                }
                else
                {
                    MessageBox.Show("this username/password incorrect");
                }
            }
        }

        private void frmLogginScreen_Load(object sender, EventArgs e)
        {
            chbrememberme.Checked = true;
            chbshowPAssword_CheckedChanged(tbPassword, e);
           clsUser _user = _getThelastRemmberedUser();
            if (_user != null)
            {
                _fillTextBoxes(_user);
            }

        }

        private void frmLogginScreen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar ==(char)Keys.Enter)
            {
                btnClose_Click(sender, e);

            }
        }
    }
}
