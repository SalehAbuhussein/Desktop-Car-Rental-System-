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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cars_Rental.Person.Forms
{
    public partial class frmAddEditPerson : Form
    {
        public event EventHandler<int?> PersonCompleted;
        protected virtual void OnPersonCompleted(int? personID)
        {
            PersonCompleted?.Invoke(this, personID);
        }
        public enum enMode
        {
            Add,
            Update
        }

        public clsPerson PersonInfo { get; set; }
        private int? _PersonID;
        private enMode _Mode = enMode.Add;

        public frmAddEditPerson(int? personID = null)
        {
            InitializeComponent();

            if (personID == null)
            {
                _Mode = enMode.Add;
                return;
            }

            _PersonID = personID;
            _Mode = enMode.Update;
        }

        private void frmAddEditPerson_Load(object sender, EventArgs e)
        {
            _InitIcons();
            _LoadGenders();

            if (_Mode == enMode.Update)
            {
                _LoadPersonData();
            }
        }

        private void _InitIcons()
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

        private void _LoadPersonData()
        {
            PersonInfo = clsPerson.FindPerson(_PersonID);

            if (PersonInfo == null)
            {
                return;
            }

            tbFirstname.Text = PersonInfo.Firstname.ToString();
            tbSecondname.Text = PersonInfo.Secondname.ToString();
            tbThirdname.Text = PersonInfo.Thirdname?.ToString();
            tbLastname.Text = PersonInfo.Lastname.ToString();
            cbGender.SelectedIndex = PersonInfo.GenderName == "Male" ? 0 : 1;
            tbAddress.Text = PersonInfo.Address;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                return;
            }

            PersonInfo.Firstname = tbFirstname.Text.Trim();
            PersonInfo.Secondname = tbSecondname.Text.Trim();
            PersonInfo.Thirdname = tbThirdname.Text.Trim();
            PersonInfo.Lastname = tbLastname.Text.Trim();
            PersonInfo.Gender = Convert.ToByte(cbGender.SelectedItem.ToString() == "Male" ? 0 : 1);
            PersonInfo.Address = tbAddress.Text.Trim();

            string statusText = _Mode == enMode.Add ? "Added" : "Updated";

            if (PersonInfo.Save())
            {
                guna2MessageDialog1.Icon = MessageDialogIcon.Information;
                guna2MessageDialog1.Show($"User has been {statusText} successfully!", "Success");
                OnPersonCompleted(PersonInfo.PersonID);
                Close();
            } else
            {
                guna2MessageDialog1.Icon = MessageDialogIcon.Error;
                guna2MessageDialog1.Show("Something went wrong", "Error");
            }
        }
    }
}
