using BusinessLayer;
using Cars_Rental.Global_Classes;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cars_Rental.Car.Forms.Years
{
    public partial class frmAddEditYear : Form
    {
        public enum enMode
        {
            Add,
            Update
        }
        public clsYear YearInfo { get; set; }
        private int? _YearID;
        private enMode _Mode = enMode.Add;

        public frmAddEditYear()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbYear_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Validators.ValidateControl(
                (Guna2TextBox)sender,
                errorProvider1,
                (tb) => string.IsNullOrEmpty(tb.Text.Trim()),
                "Year can not be empty!"
            );

            if (!e.Cancel)
            {
                e.Cancel = Validators.ValidateControl(
                    (Guna2TextBox)sender,
                    errorProvider1,
                    (tb) => !int.TryParse(tb.Text.ToString(), out int result),
                    "Year can be only number!"
                );
            }

            if (!e.Cancel && _Mode == enMode.Add)
            {
                e.Cancel = Validators.ValidateControl(
                    (Guna2TextBox)sender,
                    errorProvider1,
                    (tb) => clsYear.IsYearExist(Convert.ToInt32(tb.Text.Trim())),
                    "Year must be unique!"
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
                YearInfo = new clsYear();
            }

            YearInfo.Year = Convert.ToInt32(tbYear.Text.Trim());

            string status = _Mode == enMode.Add ? "Added" : "Updated";

            if (YearInfo.Save())
            {
                popup.Buttons = MessageDialogButtons.OK;
                popup.Icon = MessageDialogIcon.Information;
                popup.Show($"Year with id of {YearInfo.YearID} was {status} Successfully!", "Success");
                Close();
            } else
            {
                string operation = _Mode == enMode.Add ? "Add" : "Update";

                popup.Buttons = MessageDialogButtons.OK;
                popup.Icon = MessageDialogIcon.Error;
                popup.Show($"Something went wrong with Year {operation}!", "Error");
            }
        }
    }
}
