using BusinessLayer;
using Cars_Rental.Car.Forms;
using Cars_Rental.Car.Forms.FuelTypes;
using Cars_Rental.Car.Forms.Makes;
using Cars_Rental.Car.Forms.Models;
using Cars_Rental.Car.Forms.Transmissions;
using Cars_Rental.Car.Forms.Years;
using Cars_Rental.Global_Classes;
using FontAwesome.Sharp;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cars_Rental.Car.Views
{
    public partial class viewCars : UserControl
    {
        public enum enSections
        {
            Cars,
            Makes,
            Models,
            Years,
            Transmissions,
            FuelTypes
        }

        public Form Dashboard { get; set; }
        public UserControl ActiveView
        {
            get
            {
                switch (_activeView.GetType().Name)
                {
                    case "viewMakesList":
                        return viewMakesList1;
                    case "viewModelsList":
                        return viewModelsList1;
                    default:
                        return viewCarsList1;
                }
            }
            set
            {
                _activeView = value;

                switch (_activeView.GetType().Name)
                {
                    case "viewMakesList":
                        viewMakesList1.Dashboard = Dashboard;
                        break;
                    case "viewModelsList":
                        viewModelsList1.Dashboard = Dashboard;
                        break;
                    default:
                        viewCarsList1.Dashboard = Dashboard;
                        break;
                }
            }
        }
        private enSections _activeSection = enSections.Cars;
        private UserControl _activeView;

        public viewCars()
        {
            InitializeComponent();
        }

        private void viewCars_Load(object sender, EventArgs e)
        {
            SetActiveTab(btnCarsTab);
            _InitIcons();
        }

        public void SetActiveTab(Guna2Button activeBtn, enSections section = enSections.Cars)
        {
            _ResetButtons();

            activeBtn.FillColor = Color.FromArgb(84, 131, 255);
            activeBtn.ForeColor = Color.White;

            switch (section)
            {
                case enSections.Cars:
                    _activeSection = enSections.Cars;
                    ActiveView = viewCarsList1;
                    lblTitle.Text = "Cars";
                    btnAdd.Text = "Add Car";
                    viewCarsList1.LoadCarsList();
                    viewCarsList1.Visible = true;
                    break;
                case enSections.Makes:
                    _activeSection = enSections.Makes;
                    ActiveView = viewMakesList1;
                    lblTitle.Text = "Makes";
                    btnAdd.Text = "Add Make";
                    viewMakesList1.LoadMakesList();
                    viewMakesList1.Visible = true;
                    break;
                case enSections.Models:
                    _activeSection = enSections.Models;
                    ActiveView = viewModelsList1;
                    lblTitle.Text = "Models";
                    btnAdd.Text = "Add Model";
                    viewModelsList1.LoadModelsList();
                    viewModelsList1.Visible = true;
                    break;
                case enSections.Years:
                    _activeSection = enSections.Years;
                    ActiveView = viewYears1;
                    lblTitle.Text = "Years";
                    btnAdd.Text = "Add Year";
                    viewYears1.LoadYearsList();
                    viewYears1.Visible = true;
                    break;
                case enSections.Transmissions:
                    _activeSection = enSections.Transmissions;
                    ActiveView = viewTransmissionsList1;
                    lblTitle.Text = "Transmissions";
                    btnAdd.Text = "Add Transmission";
                    viewTransmissionsList1.LoadTransmissionsList();
                    viewTransmissionsList1.Visible = true;
                    break;
                case enSections.FuelTypes:
                    _activeSection = enSections.FuelTypes;
                    ActiveView = viewFuelTypesList1;
                    lblTitle.Text = "Fuel Types";
                    btnAdd.Text = "Add Fuel Type";
                    viewFuelTypesList1.LoadFuelTypesList();
                    viewFuelTypesList1.Visible = true;
                    break;
            }
        }

        private void _ResetTabButton(Guna2Button btn)
        {
            btn.FillColor = Color.FromArgb(243, 244, 246);
            btn.ForeColor = Color.FromArgb(75, 85, 99);
        }

        private void _ResetButtons()
        {
            _ResetTabButton(btnCarsTab);
            _ResetTabButton(btnMakesTab);
            _ResetTabButton(btnModelsTab);
            _ResetTabButton(btnYearsTab);
            _ResetTabButton(btnTransmissionTab);
            _ResetTabButton(btnFuelTypesTab);

            viewCarsList1.Visible = false;
            viewMakesList1.Visible = false;
            viewModelsList1.Visible = false;
            viewYears1.Visible = false;
            viewTransmissionsList1.Visible = false;
            viewFuelTypesList1.Visible = false;
        }

        private void _InitIcons()
        {
            btnAdd.Image = Utility.GetFontAwesomeImage(IconChar.UserPlus, Color.White);
        }

        private void _ShowAddCarForm()
        {
            Dashboard.Hide();
            frmAddUpdateCar frm = new frmAddUpdateCar();
            frm.ShowDialog();
            Dashboard.Show();
        }

        private void _ShowAddMakeForm()
        {
            Dashboard.Hide();
            frmAddEditMake frm = new frmAddEditMake();
            frm.ShowDialog();
            Dashboard.Show();
        }

        private void _ShowAddModelForm()
        {
            Dashboard.Hide();
            frmAddUpdateModel frm = new frmAddUpdateModel();
            frm.ShowDialog();
            Dashboard.Show();
        }

        private void _ShowAddYearForm()
        {
            Dashboard.Hide();
            frmAddEditYear frm = new frmAddEditYear();
            frm.ShowDialog();
            Dashboard.Show();
        }

        private void _ShowAddFuelTypeForm()
        {
            Dashboard.Hide();
            frmAddEditFuelType frm = new frmAddEditFuelType();
            frm.ShowDialog();
            Dashboard.Show();
        }

        private void _ShowAddTransmissionForm()
        {
            Dashboard.Hide();
            frmAddEditTransmission frm = new frmAddEditTransmission();
            frm.ShowDialog();
            Dashboard.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            switch (_activeView.GetType().Name)
            {
                case "viewMakesList":
                    _ShowAddMakeForm();
                    break;
                case "viewModelsList":
                    _ShowAddModelForm();
                    break;
                case "viewYearsList":
                    _ShowAddYearForm();
                    break;
                case "viewFuelTypesList":
                    _ShowAddFuelTypeForm();
                    break;
                case "viewTransmissionsList":
                    _ShowAddTransmissionForm();
                    break;
                default:
                    _ShowAddCarForm();
                    break;
            }

            viewCars_Load(null, null);
        }

        private void btnCarsTab_Click(object sender, EventArgs e)
        {
            SetActiveTab((Guna2Button)sender, enSections.Cars);
        }

        private void btnMakesTab_Click(object sender, EventArgs e)
        {
            SetActiveTab((Guna2Button)sender, enSections.Makes);
        }

        private void btnModelsTab_Click(object sender, EventArgs e)
        {
            SetActiveTab((Guna2Button)sender, enSections.Models);
        }

        private void btnYearTab_Click(object sender, EventArgs e)
        {
            SetActiveTab((Guna2Button)sender, enSections.Years);
        }

        private void btnTransmissionTab_Click(object sender, EventArgs e)
        {
            SetActiveTab((Guna2Button)sender, enSections.Transmissions);
        }

        private void btnFuelTypesTab_Click(object sender, EventArgs e)
        {
            SetActiveTab((Guna2Button)sender, enSections.FuelTypes);
        }
    }
}
