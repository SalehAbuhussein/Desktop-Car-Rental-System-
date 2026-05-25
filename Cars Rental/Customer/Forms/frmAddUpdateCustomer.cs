using BusinessLayer;
using Cars_Rental.Global_Classes;
using Cars_Rental.Person.Forms;
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
using System.Web.UI;
using System.Windows.Forms;

namespace Cars_Rental.Customer.Forms
{
    public partial class frmAddUpdateCustomer : Form
    {
        public event EventHandler<int?> CustomerCompleted;
        protected virtual void OnCustomerCompleted(int? customerID)
        {
            CustomerCompleted?.Invoke(this, customerID);
        }

        public enum enMode
        {
            Add,
            Update
        }
        public clsCustomer CustomerInfo { get; set; }
        private int? _CustomerID = null;
        private enMode _Mode = enMode.Add;

        public frmAddUpdateCustomer(int? customerID = null)
        {
            InitializeComponent();

            if (customerID.HasValue)
            {
                _Mode = enMode.Update;
                return;
            }

            _Mode = enMode.Add;
            _CustomerID = customerID;
        }

        private void frmAddUpdateCustomer_Load(object sender, EventArgs e)
        {
            _InitIcons();
            _LoadGenders();
            _LoadCustomerData();
        }

        private void _LoadGenders()
        {
            cbGender.Items.Add("Male");
            cbGender.Items.Add("Female");
            cbGender.SelectedIndex = 0;
        }

        private void _InitIcons()
        {
            btnSave.Image = Utility.GetFontAwesomeImage(IconChar.Check, Color.White);
            btnCancel.Image = Utility.GetFontAwesomeImage(IconChar.Xmark, Color.White);
        }

        private void _LoadCustomerData()
        {
            CustomerInfo = clsCustomer.Find(_CustomerID);

            if (CustomerInfo == null)
            {
                CustomerInfo = new clsCustomer();
                return;
            }

            _FillPersonInfo();

            tbLicenseNumber.Text = CustomerInfo.LicenseNumber;
        }

        private void _FillPersonInfo()
        {
            tbFirstname.Text = CustomerInfo.Firstname;
            tbSecondname.Text = CustomerInfo.Secondname;
            tbThirdname.Text = CustomerInfo.Thirdname;
            tbLastname.Text = CustomerInfo.Lastname;
            tbAddress.Text = CustomerInfo.Address;
            cbGender.SelectedIndex = CustomerInfo.GenderName == "Male" ? 0 : 1;
        }

        private void tbFirstname_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Validators.ValidateControl<Guna2TextBox>(
                (Guna2TextBox)sender,
                errorProvider1,
                (tb) => string.IsNullOrEmpty(tb.Text.Trim()),
                "First Name can not be empty!"
            );
        }

        private void tbSecondname_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Validators.ValidateControl<Guna2TextBox>(
                (Guna2TextBox)sender,
                errorProvider1,
                tb => string.IsNullOrEmpty(tb.Text.Trim()),
                "Second Name can not be empty!"
            );
        }

        private void tbLastname_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Validators.ValidateControl<Guna2TextBox>(
                (Guna2TextBox)sender,
                errorProvider1,
                tb => string.IsNullOrEmpty(tb.Text.Trim()),
                "Last Name can not be empty!"
            );
        }

        private void tbAddress_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Validators.ValidateControl<Guna2TextBox>(
                (Guna2TextBox)sender,
                errorProvider1,
                tb => string.IsNullOrEmpty(tb.Text.Trim()),
                "Address can not be empty!"
            );
        }

        private void tbLicenseNumber_Validating(object sender, CancelEventArgs e)
        {
            string licenseNumber = tbLicenseNumber.Text.Trim();

            if (_Mode == enMode.Add)
            {
                if (!clsCustomer.IsUniqueByLicenseNumber(licenseNumber))
                {
                    e.Cancel = true;
                    errorProvider1.SetError((Guna2TextBox)sender, "Existing Customer with this number exist!");
                }
                else if (string.IsNullOrEmpty(licenseNumber))
                {
                    e.Cancel = true;
                    errorProvider1.SetError((Guna2TextBox)sender, "License Number can not be empty!");
                }
                else
                {
                    errorProvider1.SetError((Guna2TextBox)sender, null);
                }
            }
            else
            {
                if (string.IsNullOrEmpty(licenseNumber))
                {
                    e.Cancel = true;
                    errorProvider1.SetError((Guna2TextBox)sender, "License Number can not be empty!");
                }
                else
                {
                    errorProvider1.SetError((Guna2TextBox)sender, null);
                }
            }
        }

        private void tbNationalNumber_Validating(object sender, CancelEventArgs e)
        {
            string nationalNumber = tbNationalNumber.Text.Trim();

            if (_Mode == enMode.Add)
            {
                if (!clsPerson.IsUniqueByNationalNumber(nationalNumber))
                {
                    e.Cancel = true;
                    errorProvider1.SetError((Guna2TextBox)sender, "Existing Person with this number exist!");
                }
                else if (string.IsNullOrEmpty(nationalNumber))
                {
                    e.Cancel = true;
                    errorProvider1.SetError((Guna2TextBox)sender, "National Number can not be empty!");
                }
                else
                {
                    errorProvider1.SetError((Guna2TextBox)sender, null);
                }
            }
            else
            {
                if (string.IsNullOrEmpty(nationalNumber))
                {
                    e.Cancel = true;
                    errorProvider1.SetError((Guna2TextBox)sender, "National Number can not be empty!");
                }
                else
                {
                    errorProvider1.SetError((Guna2TextBox)sender, null);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                return;
            }

            CustomerInfo.Firstname = tbFirstname.Text.Trim();
            CustomerInfo.Secondname = tbSecondname.Text.Trim();
            CustomerInfo.Thirdname = tbThirdname.Text.Trim();
            CustomerInfo.Lastname = tbLastname.Text.Trim();
            CustomerInfo.Gender = Convert.ToByte(cbGender.SelectedItem.ToString() == "Male" ? 0 : 1);
            CustomerInfo.Address = tbAddress.Text.Trim();
            CustomerInfo.NationalNumber = tbNationalNumber.Text.Trim();
            CustomerInfo.LicenseNumber = tbLicenseNumber.Text.Trim();

            if (CustomerInfo.Save())
            {
                OnCustomerCompleted(CustomerInfo.ID);
                MessageBox.Show("Customer Created Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Something went wrong with adding/update customer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
