using BusinessLayer;
using Cars_Rental.Global_Classes;
using FontAwesome.Sharp;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Cars_Rental.User.Forms
{
    public partial class frmAddUpdateUser : Form
    {
        public enum enMode
        {
            Add,
            Update
        }
        private int? _UserID;
        public clsUser UserInfo { get; set; }
        private enMode _Mode = enMode.Add;

        public frmAddUpdateUser()
        {
            InitializeComponent();
        }

        public frmAddUpdateUser(int? userID)
        {
            InitializeComponent();

            if (userID == null)
            {
                return;
            }

            _UserID = userID;
            _Mode = enMode.Update;
        }

        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            _LoadGenders();
            _LoadIcons();
            _LoadRoles();

            if (_Mode == enMode.Update)
            {
                _LoadUserData();
            }
        }

        private void _FillInputsWithDummyData()
        {
            tbFirstname.Text = "Mohammad";
            tbSecondname.Text = "Ahmad";
            tbLastname.Text = "Adawi";
            tbAddress.Text = "Safout, Kamaliya";
            tbUsername.Text = "adawi";
        }

        private void _LoadIcons()
        {
            btnSave.Image = Utility.GetFontAwesomeImage(IconChar.Check, Color.White);
            btnCancel.Image = Utility.GetFontAwesomeImage(IconChar.Xmark, Color.White);
        }

        private void _LoadGenders()
        {
            cbGender.Items.Add("Male");
            cbGender.Items.Add("Female");
            cbGender.SelectedIndex = 0;
        }

        private void _LoadRoles()
        {
            DataTable dt = clsRole.FindAll();

            foreach (DataRow dr in dt.Rows)
            {
                cbRoles.Items.Add(dr["RoleName"].ToString());
            }

            cbRoles.SelectedIndex = cbRoles.FindString("Employee");
        }

        private void _LoadUserData()
        {
            UserInfo = clsUser.FindUser(_UserID);

            if (UserInfo == null)
            {
                guna2MessageDialog1.Icon = MessageDialogIcon.Error;
                guna2MessageDialog1.Show("Invalid User data!", "Error");
                Close();
                return;
            }

            tbFirstname.Text = UserInfo.Firstname;
            tbSecondname.Text = UserInfo.Secondname;
            tbThirdname.Text = UserInfo.Thirdname;
            tbLastname.Text = UserInfo.Lastname;
            tbAddress.Text = UserInfo.Address;
            tbPassword.Text = UserInfo.PasswordHash;
            tbUsername.Text = UserInfo.Username;
            cbGender.SelectedIndex = UserInfo.GenderName == "Male" ? 0 : 1;
            cbRoles.SelectedIndex = cbRoles.FindString(UserInfo.RoleInfo.RoleName);

            if (UserInfo.RoleInfo.RoleName == "Employee")
            {
                cbRoles.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                return;
            }

            if (_Mode == enMode.Add)
            {
                UserInfo = new clsUser();
            }

            UserInfo.Username = tbUsername.Text;
            UserInfo.Firstname = tbFirstname.Text.Trim();
            UserInfo.Secondname = tbSecondname.Text.Trim();
            UserInfo.Thirdname = tbThirdname.Text.Trim();
            UserInfo.Lastname = tbLastname.Text.Trim();
            UserInfo.Gender = Convert.ToByte(cbGender.SelectedItem.ToString() == "Male" ? 0 : 1);
            UserInfo.Address = tbAddress.Text.Trim();
            UserInfo.PasswordHash = tbPassword.Text.Trim();
            UserInfo.NationalNumber = tbNationalNumber.Text.Trim();
            UserInfo.RoleInfo = clsRole.FindByName(cbRoles.SelectedItem.ToString());
            UserInfo.RoleID = UserInfo.RoleInfo.RoleID;

            string statusText = _Mode == enMode.Add ? "Added" : "Updated";

            if (UserInfo.Save())
            {
                guna2MessageDialog1.Icon = MessageDialogIcon.Information;
                guna2MessageDialog1.Show($"User has been {statusText} successfully!", "Success");
                Close();
            } else
            {
                guna2MessageDialog1.Icon = MessageDialogIcon.Error;
                guna2MessageDialog1.Show("Something went wrong", "Error");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
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

        private void tbNationalNumber_Validating(object sender, CancelEventArgs e)
        {
            string nationalNumber = tbNationalNumber.Text.Trim();

            if (_Mode == enMode.Add)
            {
                if (!clsPerson.IsUniqueByNationalNumber(nationalNumber))
                {
                    e.Cancel = true;
                    errorProvider1.SetError((Guna2TextBox)sender, "Existing customer with this number exist!");
                } else if (string.IsNullOrEmpty(nationalNumber))
                {
                    e.Cancel = true;
                    errorProvider1.SetError((Guna2TextBox)sender, "National Number can not be empty!");
                } else
                {
                    errorProvider1.SetError((Guna2TextBox)sender, null);
                }
            } else
            {
                if (string.IsNullOrEmpty(nationalNumber))
                {
                    e.Cancel = true;
                    errorProvider1.SetError((Guna2TextBox)sender, "National Number can not be empty!");
                } else
                {
                    errorProvider1.SetError((Guna2TextBox)sender, null);
                }
            }
        }

        private void tbUsername_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Validators.ValidateControl<Guna2TextBox>(
                (Guna2TextBox)sender,
                errorProvider1,
                tb => string.IsNullOrEmpty(tb.Text.Trim()),
                "Username can not be empty!"
            );
        }

        private void tbPassword_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Validators.ValidateControl<Guna2TextBox>(
                (Guna2TextBox)sender,
                errorProvider1,
                tb => string.IsNullOrEmpty(tb.Text.Trim()),
                "Password can not be empty!"
            );
        }

        private void tbConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (_Mode == enMode.Add)
            {
                e.Cancel = Validators.ValidateControl<Guna2TextBox>(
                    (Guna2TextBox)sender,
                    errorProvider1,
                    tb => string.IsNullOrEmpty(tb.Text.Trim()) || tb.Text.Trim() != tbPassword.Text.Trim(),
                    "Invalid Passwords"
                );
            }
            else
            {
                if (!string.IsNullOrEmpty(tbConfirmPassword.Text.Trim()))
                {
                    bool isChangingPassword = !string.IsNullOrWhiteSpace(tbPassword.Text);

                    if (!isChangingPassword)
                    {
                        errorProvider1.SetError(tbConfirmPassword, null);
                        e.Cancel = false;
                        return;
                    }

                    e.Cancel = Validators.ValidateControl<Guna2TextBox>(
                        tbConfirmPassword,
                        errorProvider1,
                        tb => tbPassword.Text != tbConfirmPassword.Text,
                        "Passwords must match!"
                    );
                } else
                {
                    e.Cancel = false;
                }
            }

        }
    }
}
