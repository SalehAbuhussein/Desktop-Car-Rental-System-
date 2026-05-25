using BusinessLayer;
using Cars_Rental.Car.Forms;
using Cars_Rental.Customer.Forms;
using Cars_Rental.Global_Classes;
using Cars_Rental.Rental.Forms;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cars_Rental.Dashboard.Controls
{
    public partial class viewDashboard : UserControl
    {
        public Form Dashboard { get; set; }

        public viewDashboard()
        {
            InitializeComponent();
        }

        private void _LoadDashboardIcons()
        {
            btnNewRental.Image = Utility.GetFontAwesomeImage(IconChar.CalendarPlus, Color.FromArgb(94, 148, 255), 28);
            btnNewRental.ImageSize = new Size(28, 28);
            btnAddVehicle.Image = Utility.GetFontAwesomeImage(IconChar.CarSide, Color.FromArgb(94, 148, 255), 28);
            btnAddVehicle.ImageSize = new Size(28, 28);
            btnReturnVehicle.Image = Utility.GetFontAwesomeImage(IconChar.UndoAlt, Color.FromArgb(40, 110, 80), 28);
            btnReturnVehicle.ImageSize = new Size(28, 28);
            btnAddCustomer.Image = Utility.GetFontAwesomeImage(IconChar.UserPlus, Color.FromArgb(140, 90, 40), 28);
            btnAddCustomer.ImageSize = new Size(28, 28);
            rentIcon.IconChar = IconChar.Clock;
            pbTotalRefunds.IconChar = IconChar.RotateLeft;
        }

        private void ctrlDashboard_Load(object sender, EventArgs e)
        {
            _LoadDashboardIcons();

            lblTotalVehicles.Text = clsCar.GetCarsCount().ToString();
            lblAvailableVehicles.Text = clsCar.GetAvailableCarsCount().ToString();
            lblRentedVehicles.Text = clsCar.GetRentedCarsCount().ToString();
            lblTotalCustomers.Text = clsCustomer.GetCustomersCount().ToString();

            lblTotalPaid.Text = clsCarRentalPayment.GetTotalPaid().ToString();
            lblTotalRefunds.Text = clsCarRentalPayment.GetTotalRefunds().ToString();
            lblNetRevenue.Text = clsCarRentalPayment.GetNetRevenue().ToString();
        }

        private void btnNewRental_Click(object sender, EventArgs e)
        {
            Dashboard.Hide();
            frmAddRental frm = new frmAddRental();
            frm.ShowDialog();
            Dashboard.Show();
        }

        private void btnAddVehicle_Click(object sender, EventArgs e)
        {
            Dashboard.Hide();
            frmAddUpdateCar frm = new frmAddUpdateCar();
            frm.ShowDialog();
            Dashboard.Show();
        }

        private void btnReturnVehicle_Click(object sender, EventArgs e)
        {
            Dashboard.Hide();
            frmRentalManagement frm = new frmRentalManagement();
            frm.ShowDialog();
            Dashboard.Show();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            Dashboard.Hide();
            frmAddUpdateCustomer frm = new frmAddUpdateCustomer();
            frm.ShowDialog();
            Dashboard.Show();
        }
    }
}
