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

namespace Cars_Rental.Car.Forms.FuelTypes
{
    public partial class frmAddEditFuelType : Form
    {
        public enum enMode
        {
            Add,
            Update
        }
        public clsFuelType FuelTypeInfo { get; set; }
        private int? _FuelTypeID;
        private enMode _Mode = enMode.Add;

        public frmAddEditFuelType()
        {
            InitializeComponent();
            _Mode = enMode.Add;
        }

        public frmAddEditFuelType(int? fuelTypeID)
        {
            InitializeComponent();

            _FuelTypeID = fuelTypeID;
            _Mode = enMode.Update;
        }

        private void frmAddEditFuelType_Load(object sender, EventArgs e)
        {
            _InitIcons();

            if (_Mode == enMode.Update)
            {
                _LoadFuelTypeData();
            }
        }

        private void _InitIcons()
        {
            btnSave.Image = Utility.GetFontAwesomeImage(IconChar.Check, Color.White);
            btnCancel.Image = Utility.GetFontAwesomeImage(IconChar.Xmark, Color.White);
        }

        private void _LoadFuelTypeData()
        {
            FuelTypeInfo = clsFuelType.Find(_FuelTypeID);

            if (FuelTypeInfo == null)
            {
                popup.Icon = MessageDialogIcon.Error;
                popup.Buttons = MessageDialogButtons.OK;
                popup.Show("Invalid Fuel Type Data!", "Error");
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbFuelType_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Validators.ValidateControl(
                (Guna2TextBox)sender,
                errorProvider1,
                (tb) => string.IsNullOrEmpty(tb.Text.Trim()),
                "Fuel Type can not be empty!"
            );

            if (!e.Cancel && _Mode == enMode.Add)
            {
                e.Cancel = Validators.ValidateControl(
                    (Guna2TextBox)sender,
                    errorProvider1,
                    (tb) => clsFuelType.IsFuelTypeExist(tb.Text.Trim()),
                    "Fuel Type should be unique!"
                );
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
                FuelTypeInfo = new clsFuelType();
            }

            FuelTypeInfo.FuelTypeName = tbFuelType.Text.Trim();

            string status = _Mode == enMode.Add ? "Added" : "Updated";

            if (FuelTypeInfo.Save())
            {
                popup.Icon = MessageDialogIcon.Information;
                popup.Buttons = MessageDialogButtons.OK;
                popup.Show($"Fuel Type with ID of {FuelTypeInfo.FuelTypeID} was {status} Successfully!", "Success");
                Close();
            } else
            {
                string operation = _Mode == enMode.Add ? "Add" : "Update";

                popup.Icon = MessageDialogIcon.Error;
                popup.Buttons = MessageDialogButtons.OK;
                popup.Show($"Something went wrong with {operation} Role!", "Error");
            }
        }
    }
}
