using BusinessLayer;
using Cars_Rental.Global_Classes;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cars_Rental
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            _PopulateInputs();

            //string imgPath = @"C:\Users\saleh\OneDrive\Desktop\image.jpg";

            //Utility.StoreCarImage(imgPath);
        }

        private void _PopulateInputs()
        {
            string username = tbUsername.Text.Trim();
            string password = tbPassword.Text.Trim();

            if (Utility.GetStoredUsernameAndPassword(ref username, ref password))
            {
                tbUsername.Text = username;
                tbPassword.Text = password;
                cbRememberMe.Checked = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text.Trim();
            string password = tbPassword.Text.Trim();
            clsUser user = clsUser.FindActiveByUsernameAndPassword(username, password);

            if (user != null)
            {
                CurrentUser.UserInfo = user;

                if (cbRememberMe.Checked)
                {
                    Utility.SaveUsernameAndPassword(username, password);
                }

                this.Hide();
                frmDashboard dashboard = new frmDashboard(this);
                dashboard.ShowDialog();
            } else
            {
                guna2MessageDialog1.Icon = MessageDialogIcon.Error;
                guna2MessageDialog1.Show("Invalid Credintals!", "Error");
            }
        }
    }
}
