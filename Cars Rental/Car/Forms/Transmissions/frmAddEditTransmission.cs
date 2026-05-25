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

namespace Cars_Rental.Car.Forms.Transmissions
{
    public partial class frmAddEditTransmission : Form
    {
        public enum enMode
        {
            Add,
            Update
        }
        public clsTransmission TransmissionInfo { get; set; }
        private int? _TransmissionID;
        private enMode _Mode = enMode.Add;

        public frmAddEditTransmission()
        {
            InitializeComponent();
        }

        public frmAddEditTransmission(int? transmissionID)
        {
            InitializeComponent();

            _TransmissionID = transmissionID;
            _Mode = enMode.Update;
        }

        private void frmAddEditTransmission_Load(object sender, EventArgs e)
        {
            _InitIcons();

            if (_Mode == enMode.Update)
            {
                _LoadTransmissionData();
            }
        }

        private void _InitIcons()
        {
            btnSave.Image = Utility.GetFontAwesomeImage(IconChar.Check, Color.White);
            btnCancel.Image = Utility.GetFontAwesomeImage(IconChar.Xmark, Color.White);
        }

        private void _LoadTransmissionData()
        {
            TransmissionInfo = clsTransmission.Find(_TransmissionID);

            if (TransmissionInfo == null)
            {
                popup.Icon = MessageDialogIcon.Error;
                popup.Buttons = MessageDialogButtons.OK;
                popup.Show("Invalid Transmission Data!", "Error");
                return;
            }

            if (_Mode == enMode.Add)
            {
                TransmissionInfo = new clsTransmission();
            }

            TransmissionInfo.TransmissionName = tbTransmission.Text.Trim();
        }

        private void tbTransmission_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Validators.ValidateControl(
                (Guna2TextBox)sender,
                errorProvider1,
                (tb) => string.IsNullOrEmpty(tb.Text.Trim()),
                "Transmission can not be empty!"
            );

            if (!e.Cancel && _Mode == enMode.Add)
            {
                e.Cancel = Validators.ValidateControl(
                    (Guna2TextBox)sender,
                    errorProvider1,
                    (tb) => clsTransmission.IsTransmissionExist(tb.Text.Trim()),
                    "Transmission should be unique!"
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
                TransmissionInfo = new clsTransmission();
            }

            TransmissionInfo.TransmissionName = tbTransmission.Text.Trim();

            string status = _Mode == enMode.Add ? "Added" : "Updated";

            if (TransmissionInfo.Save())
            {
                popup.Icon = MessageDialogIcon.Information;
                popup.Buttons = MessageDialogButtons.OK;
                popup.Show($"Transmission with id of {TransmissionInfo.TransmissionID} was {status} Successfully!", "Success");
                Close();
            } else
            {
                string operation = _Mode == enMode.Add ? "Add" : "Update";

                popup.Icon = MessageDialogIcon.Error;
                popup.Buttons = MessageDialogButtons.OK;
                popup.Show($"Something went wrong with Transmission {operation}", "Error");
            }
        }
    }
}
