using BusinessLayer;
using Cars_Rental.Car.Views;
using Cars_Rental.Global_Classes;
using Cars_Rental.Rental.Forms;
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
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Cars_Rental.Rental.Views
{
    public partial class viewRentals : UserControl
    {
        public enum enStatus
        {
            Active,
            Completed
        }
        public frmDashboard Dashboard;
        private enStatus? _RentalStatus = null;

        public viewRentals()
        {
            InitializeComponent();
        }

        private void _InitIcons()
        {
            btnAdd.Image = Utility.GetFontAwesomeImage(IconChar.UserPlus, Color.White);
        }

        private void viewRentals_Load(object sender, EventArgs e)
        {
            _InitIcons();
            SetActiveTab(btnActiveTab);
        }

        public void SetActiveTab(Guna2Button activeBtn, enStatus newStatus = enStatus.Active)
        {
            if (_RentalStatus == newStatus)
            {
                return;
            }

            _ResetTabButton(btnActiveTab);
            _ResetTabButton(btnCompletedTab);

            activeBtn.FillColor = Color.FromArgb(84, 131, 255);
            activeBtn.ForeColor = Color.White;

            viewRentalsList1.Dashboard = Dashboard;

            switch (newStatus)
            {
                case enStatus.Active:
                    viewRentalsList.ActiveStatus = "Active";
                    viewRentalsList1.LoadRentalsList();
                    break;
                case enStatus.Completed:
                    viewRentalsList.ActiveStatus = "Completed";
                    viewRentalsList1.LoadRentalsList();
                    break;
            }
        }

        private void _ResetTabButton(Guna2Button btn)
        {
            btn.FillColor = Color.FromArgb(243, 244, 246);
            btn.ForeColor = Color.FromArgb(75, 85, 99);
        }

        private void btnActiveTab_Click(object sender, EventArgs e)
        {
            SetActiveTab((Guna2Button)sender, enStatus.Active);
        }

        private void btnCompletedTab_Click(object sender, EventArgs e)
        {
            SetActiveTab((Guna2Button)sender, enStatus.Completed);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!clsCar.IsAnyCarAvailable())
            {
                popup.Parent = Dashboard;
                popup.Icon = MessageDialogIcon.Error;
                popup.Buttons = MessageDialogButtons.OK;
                popup.Show("No Cars Available Right now!", "No Available Cars");
                return;
            }

            Dashboard?.Hide();
            frmAddRental frm = new frmAddRental();
            frm.ShowDialog();
            Dashboard?.Show();
            viewRentals_Load(null, null);
        }
    }
}
