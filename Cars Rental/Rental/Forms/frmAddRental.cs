using BusinessLayer;
using Cars_Rental.Customer.Forms;
using Cars_Rental.Global_Classes;
using Cars_Rental.Person.Forms;
using FontAwesome.Sharp;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cars_Rental.Rental.Forms
{
    public partial class frmAddRental : Form
    {
        public enum enMode
        {
            Add,
            Update
        }
        public clsCarRental CarRentalInfo { get; set; }
        private enMode _Mode = enMode.Add;

        public frmAddRental()
        {
            InitializeComponent();

            CarRentalInfo = new clsCarRental();
        }

        private void frmAddUpdateRental_Load(object sender, EventArgs e)
        {
            _InitIcons();
            _InitCars();
            _InitPaymentMethod();
            _SetDatesLimits();
        }

        private void _InitIcons()
        {
            btnSave.Image = Utility.GetFontAwesomeImage(IconChar.Check, Color.White);
            btnCancel.Image = Utility.GetFontAwesomeImage(IconChar.Xmark, Color.White);
            btnAddCustomer.Image = Utility.GetFontAwesomeImage(IconChar.UserPlus, Color.FromArgb(79, 125, 243));
            pbCustomerIcon.IconChar = IconChar.UserCircle;
        }

        private void _SetDatesLimits()
        {
            dtpPickupDate.MinDate = DateTime.Now;
            dtpReturnDate.MinDate = DateTime.Now.AddDays(1);
        }

        private int _GetRentedDays()
        {
            return Math.Abs(Convert.ToInt32((dtpPickupDate.Value - dtpReturnDate.Value).TotalDays));
        }

        private void _InitCars()
        {
            DataTable cars = clsCar.FindAvailableCars();

            cbFilter.SelectedIndex = 0;
            cbCar.Items.Clear();

            foreach (DataRow row in cars.Rows)
            {
                cbCar.Items.Add(row["CarName"]);
            }
        }

        private void _InitPaymentMethod()
        {
            cbPaymentMethod.Items.Clear();

            cbPaymentMethod.Items.Add("Cash");
            cbPaymentMethod.Items.Add("Card");
            cbPaymentMethod.Items.Add("Bank Transfer");
            cbPaymentMethod.Items.Add("Mobile Wallet");
        }

        private void cbCar_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsCar car = clsCar.FindByName(cbCar.SelectedItem.ToString());

            if (car == null)
            {
                return;
            }

            CarRentalInfo.CarInfo = car;
            CarRentalInfo.CarID = car.CarID;

            tbPricePerDay.Text = car.PricePerDay.ToString();
            tbTotalPrice.Text = (car.PricePerDay * _GetRentedDays()).ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbCar_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Validators.ValidateControl(
                (Guna2ComboBox)sender,
                errorProvider1,
                (tb) => string.IsNullOrEmpty(tb.SelectedItem?.ToString().Trim()),
                "Car field can not be empty!"
            );
        }

        private void tbPricePerDay_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Validators.ValidateControl(
                (Guna2TextBox)sender,
                errorProvider1,
                (tb) => string.IsNullOrEmpty(tb.Text.Trim()),
                "Price Per Day can not be empty!"
            );
        }

        private void tbTotalPrice_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Validators.ValidateControl(
                (Guna2TextBox)sender,
                errorProvider1,
                (tb) => string.IsNullOrEmpty(tb.Text.Trim()),
                "Total Price can not be empty!"
            );
        }

        private void tbTotalPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            Guna2TextBox tb = (Guna2TextBox)sender;

            if (char.IsControl(e.KeyChar))
                return;

            if (char.IsDigit(e.KeyChar))
                return;

            // Allow ONE decimal point
            if (e.KeyChar == '.' && !tb.Text.Contains("."))
                return;

            // Block everything else
            e.Handled = true;
        }

        private void tbDeposit_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Validators.ValidateControl(
                (Guna2TextBox)sender,
                errorProvider1,
                (tb) => string.IsNullOrEmpty(tb.Text.Trim()),
                "Deposit can not be empty!"
            ) || Validators.ValidateControl(
                (Guna2TextBox)sender,
                errorProvider1,
                (tb) => Convert.ToDecimal(tb.Text.Trim()) <= 0,
                "Deposit should be greater than 0"
            );
        }

        private void tbDeposit_KeyPress(object sender, KeyPressEventArgs e)
        {
            Guna2TextBox tb = (Guna2TextBox)sender;

            if (char.IsControl(e.KeyChar))
                return;

            if (char.IsDigit(e.KeyChar))
                return;

            // Allow ONE decimal point
            if (e.KeyChar == '.' && !tb.Text.Contains("."))
                return;

            // Block everything else
            e.Handled = true;
        }

        private void tbInitialPayment_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cbPaymentMethod.SelectedItem?.ToString()) && string.IsNullOrEmpty(tbInitialPayment.Text.Trim()))
            {
                return;
            }

            e.Cancel = Validators.ValidateControl(
                (Guna2TextBox)sender,
                errorProvider1,
                (tb) => string.IsNullOrEmpty(tb.Text.Trim()),
                "Initial Payment can not be empty!"
            ) || Validators.ValidateControl(
                (Guna2TextBox)sender,
                errorProvider1,
                (tb) => Convert.ToDecimal(tb.Text.Trim()) <= 0,
                "Initial Payment can not be 0"
            ) || Validators.ValidateControl(
                (Guna2TextBox)sender,
                errorProvider1,
                (tb) => Convert.ToDecimal(tb.Text.Trim()) > Convert.ToDecimal(tbTotalPrice.Text.Trim()),
                "Initial Payment can not be greater than total price"
            );
        }

        private void cbPaymentMethod_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbInitialPayment.Text.Trim()))
            {
                return;
            }

            e.Cancel = Validators.ValidateControl(
                (Guna2ComboBox)sender,
                errorProvider1,
                (tb) => string.IsNullOrEmpty(tb.Text.Trim()),
                "Payment method can not be empty!"
            );
        }

        private void tbInitialPayment_KeyPress(object sender, KeyPressEventArgs e)
        {
            Guna2TextBox tb = (Guna2TextBox)sender;

            if (char.IsControl(e.KeyChar))
                return;

            if (char.IsDigit(e.KeyChar))
                return;

            // Allow ONE decimal point
            if (e.KeyChar == '.' && !tb.Text.Contains("."))
                return;

            // Block everything else
            e.Handled = true;
        }

        private void tbPickupLocation_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Validators.ValidateControl(
                (Guna2TextBox)sender,
                errorProvider1,
                (tb) => string.IsNullOrEmpty(tb.Text.Trim()),
                "Pickup Location can not be empty!"
            );
        }

        private void dtpPickupDate_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Validators.ValidateControl(
                (Guna2DateTimePicker)sender,
                errorProvider1,
                (dtp) => dtp.Value >= dtpReturnDate.Value,
                "Pickup date can not be equal or greater than return date"
            );
        }

        private void dtpPickupDate_ValueChanged(object sender, EventArgs e)
        {
            tbTotalPrice.Text = (CarRentalInfo?.CarInfo?.PricePerDay * _GetRentedDays()).ToString();
        }

        private void dtpReturnDate_ValueChanged(object sender, EventArgs e)
        {
            tbTotalPrice.Text = (CarRentalInfo?.CarInfo?.PricePerDay * _GetRentedDays()).ToString();
        }

        private void cbPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarRentalInfo.PaymentMethod = cbPaymentMethod.SelectedItem?.ToString();
        }

        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (cbFilter.SelectedItem.ToString())
            {
                case "ID":
                    e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
                    break;
                default:
                    break;
            }
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbSearch.Text = string.Empty;
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAddUpdateCustomer frm = new frmAddUpdateCustomer();

            frm.CustomerCompleted += frmAddUpdateCustomer_CustomerCompleted;

            frm.ShowDialog();
            this.Show();
        }

        private void frmAddUpdateCustomer_CustomerCompleted(object sender, int? customerID)
        {
            CarRentalInfo.CustomerID = customerID;
            CarRentalInfo.CustomerInfo = clsCustomer.Find(customerID);

            tbSearch.Enabled = false;
            cbFilter.Enabled = false;
            btnSearch.Enabled = false;
            btnAddCustomer.Enabled = false;

            _FillCustomerInfo();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string filterTxt = tbSearch.Text.Trim();

            switch (cbFilter.SelectedItem.ToString())
            {
                case "ID":
                    if (!string.IsNullOrEmpty(filterTxt))
                    {
                        CarRentalInfo.CustomerInfo = clsCustomer.Find(Convert.ToInt32(filterTxt));
                        
                        if (CarRentalInfo.CustomerInfo != null)
                        {
                            CarRentalInfo.CustomerID = CarRentalInfo.CustomerInfo.ID;
                        }
                    }
                    break;
                case "License Number":
                    CarRentalInfo.CustomerInfo = clsCustomer.FindByLicenseNumber(filterTxt);
                    
                    if (CarRentalInfo.CustomerInfo != null)
                    {
                        CarRentalInfo.CustomerID = CarRentalInfo.CustomerInfo.ID;
                    }
                    break;
            }

            _FillCustomerInfo();
        }

        private void _FillCustomerInfo()
        {
            if (CarRentalInfo == null || CarRentalInfo.CustomerInfo == null)
            {
                MessageBox.Show("Customer not found!", "Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblCustomerName.Text = CarRentalInfo.CustomerInfo.Fullname;
            lblCustomerID.Text = CarRentalInfo.CustomerInfo.ID.ToString();
            lblNationalNo.Text = CarRentalInfo.CustomerInfo.NationalNumber;
            lblAddress.Text = CarRentalInfo.CustomerInfo.Address;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                return;
            }

            if (CarRentalInfo.CustomerInfo == null || CarRentalInfo.CustomerID == null)
            {
                dialogBox.Icon = MessageDialogIcon.Error;
                dialogBox.Buttons = MessageDialogButtons.OK;
                dialogBox.Show("Customer is not filled", "Error");
                return;
            }

            CarRentalInfo.Deposit = Convert.ToDecimal(tbDeposit.Text.Trim());
            CarRentalInfo.PickupLocation = tbPickupLocation.Text.Trim();
            CarRentalInfo.CreatedByUserID = CurrentUser.UserInfo.UserID;
            CarRentalInfo.PickupDate = dtpPickupDate.Value;
            CarRentalInfo.ReturnDate = dtpReturnDate.Value;
            CarRentalInfo.TotalPrice = Convert.ToDecimal(tbTotalPrice.Text.Trim());
            CarRentalInfo.PaymentMethod = cbPaymentMethod?.SelectedItem?.ToString();
            CarRentalInfo.InitialPayment = Convert.ToDecimal(tbInitialPayment.Text.Trim());
            CarRentalInfo.PricePerDaySnapshot = Convert.ToDecimal(tbPricePerDay.Text.Trim());

            if (CarRentalInfo.Save())
            {
                _Mode = enMode.Update;
                cbCar.Enabled = false;
                cbPaymentMethod.Enabled = false;
                tbInitialPayment.Enabled = false;
                tbDeposit.Enabled = false;

                dialogBox.Icon = MessageDialogIcon.Information;
                dialogBox.Buttons = MessageDialogButtons.OK;
                dialogBox.Show("Car Renting has been Added Successfully!", "Success");
                Close();
            } else
            {
                dialogBox.Icon = MessageDialogIcon.Error;
                dialogBox.Buttons = MessageDialogButtons.OK;
                dialogBox.Show("Something went wrong with renting operation", "Error");
            }
        }
    }
}
