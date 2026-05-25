using Cars_Rental.Car.Views;
using Cars_Rental.Customer.Views;
using Cars_Rental.Dashboard.Controls;
using Cars_Rental.Global_Classes;
using Cars_Rental.Payment.Views;
using Cars_Rental.Rental.Views;
using Cars_Rental.User;
using FontAwesome.Sharp;
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
    public partial class frmDashboard : Form
    {
        private frmLogin _frmLogin;
        private UserControl _activeTab;

        public frmDashboard(frmLogin frmLogin)
        {
            InitializeComponent();
            _frmLogin = frmLogin;
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            _LoadDashboardIcons();
            _LoadTimer();
            _LoadInitialState();
        }

        private void _LoadInitialState()
        {
            viewDashboard ctrlDashboard = new viewDashboard();
            ctrlDashboard.Dashboard = this;
            _LoadActiveView(ctrlDashboard);
            _SetActiveButton(btnDashboard);
            
            lblNameWelcome.Text += CurrentUser.UserInfo.ShortName;

            btnUsers.Enabled = CurrentUser.UserInfo.RoleInfo.RoleName != "Employee";
            
            if (!btnUsers.Enabled)
            {
                btnUsers.Image = Utility.GetFontAwesomeImage(IconChar.Users, Color.FromArgb(71, 85, 105));
            }
        }

        private void _LoadDashboardIcons()
        {
            btnDashboard.Image = Utility.GetFontAwesomeImage(IconChar.Home, Color.White);
            btnBooking.Image = Utility.GetFontAwesomeImage(IconChar.CalendarAlt, Color.White);
            btnCars.Image = Utility.GetFontAwesomeImage(IconChar.Car, Color.White);
            btnCustomers.Image = Utility.GetFontAwesomeImage(IconChar.User, Color.White);
            btnPayments.Image = Utility.GetFontAwesomeImage(IconChar.CreditCard, Color.White);
            btnUsers.Image = Utility.GetFontAwesomeImage(IconChar.Users, Color.White);
        }

        private void _LoadTimer()
        {
            timer1 = new Timer();
            timer1.Interval = 1000;

            timer1.Tick -= timer1_Tick;
            timer1.Tick += timer1_Tick;

            timer1.Start();
        }

        private void _ResetSidebarButtons()
        {
            foreach (Control control in pnlSidebarMenu.Controls)
            {
                if (control is Guna2Button btn)
                {
                    if (control.Text == "Logout")
                    {
                        continue;
                    }

                    btn.FillColor = Color.FromArgb(94, 148, 255); // your original
                    btn.ForeColor = Color.White;
                    btn.CustomBorderThickness = new Padding(0);
                }
            }
        }

        private void _SetActiveButton(Guna2Button btn)
        {
            _ResetSidebarButtons();

            btn.FillColor = Color.FromArgb(37, 76, 168);

            btn.CustomBorderColor = Color.White;
            btn.CustomBorderThickness = new Padding(4, 0, 0, 0);
        }

        private void _LoadActiveView(UserControl view)
        {
            if (_activeTab?.GetType() == view.GetType())
            {
                return;
            }

            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(view);
            _activeTab = view;
            view.BringToFront();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            CurrentUser.Logout();
            _frmLogin.Show();
            this.Close();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            viewDashboard ctrlDashboard = new viewDashboard();
            ctrlDashboard.Dashboard = this;

            _SetActiveButton((Guna2Button)sender);
            _LoadActiveView(ctrlDashboard);
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            viewRentals rentalView = new viewRentals();
            rentalView.Dashboard = this;

            _SetActiveButton((Guna2Button)sender);
            _LoadActiveView(rentalView);
        }

        private void btnCars_Click(object sender, EventArgs e)
        {
            viewCars carsView = new viewCars();
            carsView.Dashboard = this;

            _SetActiveButton((Guna2Button)sender);
            _LoadActiveView(carsView);
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            viewCustomersList customersList = new viewCustomersList();
            customersList.Dashboard = this;

            _SetActiveButton((Guna2Button)sender);
            _LoadActiveView(customersList);
        }

        private void btnRentals_Click(object sender, EventArgs e)
        {
            _SetActiveButton((Guna2Button)sender);
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            viewPayment viewPayment = new viewPayment();
            viewPayment.Dashboard = this;

            _SetActiveButton((Guna2Button)sender);
            _LoadActiveView(viewPayment);
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            viewUsersManagement usersView = new viewUsersManagement();
            usersView.Dashboard = this;

            _SetActiveButton((Guna2Button)sender);
            _LoadActiveView(usersView);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            btnLogout_Click(null, null);
        }
    }
}
