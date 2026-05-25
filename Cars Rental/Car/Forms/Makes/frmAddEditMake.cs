using BusinessLayer;
using Cars_Rental.Global_Classes;
using FontAwesome.Sharp;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cars_Rental.Car.Forms.Makes
{
    public partial class frmAddEditMake : Form
    {
        public enum enMode
        {
            Add,
            Update
        };

        private int? _makeID;
        public clsMake MakeInfo;
        private enMode _Mode = enMode.Add;

        public frmAddEditMake(int? makeID = null)
        {
            InitializeComponent();

            if (makeID == null)
            {
                _Mode = enMode.Add;
            } else
            {
                _Mode = enMode.Update;
                _makeID = makeID;
            }
        }

        private void frmAddEditMake_Load(object sender, EventArgs e)
        {
            _InitIcons();

            if (_Mode == enMode.Update)
            {
                _LoadMakeInfo();
            }
        }

        private void _LoadMakeInfo()
        {
            MakeInfo = clsMake.Find(_makeID);

            if (MakeInfo == null)
            {
                return;
            }

            tbMake.Text = MakeInfo.MakeName;
        }

        private void _InitIcons()
        {
            btnSave.Image = Utility.GetFontAwesomeImage(IconChar.Check, Color.White);
            btnCancel.Image = Utility.GetFontAwesomeImage(IconChar.Xmark, Color.White);
        }

        private void tbMake_Validating(object sender, CancelEventArgs e)
        {
            if (_Mode == enMode.Add)
            {
                e.Cancel = Validators.ValidateControl(
                    (Guna2TextBox)sender,
                    errorProvider1,
                    (tb) => string.IsNullOrEmpty(tb.Text.Trim()),
                    "Make can not be empty!"
                ) || Validators.ValidateControl(
                    (Guna2TextBox)sender,
                    errorProvider1,
                    (tb) => clsMake.FindByName(tb.Text.Trim()) != null,
                    "Existing Make exist!"
                );
            } else
            {
                string makeName = MakeInfo.MakeName;
                string newMakeName = tbMake.Text.Trim();

                if (newMakeName != makeName)
                {
                    e.Cancel = Validators.ValidateControl(
                        (Guna2TextBox)sender,
                        errorProvider1,
                        (tb) => clsMake.FindByName(tb.Text.Trim()) != null,
                        "Existing Make exist!"
                    ) || Validators.ValidateControl(
                        (Guna2TextBox)sender,
                        errorProvider1,
                        (tb) => string.IsNullOrEmpty(tb.Text.Trim()),
                        "Make can not be empty!"
                    );
                } else
                {
                    e.Cancel = Validators.ValidateControl(
                        (Guna2TextBox)sender,
                        errorProvider1,
                        (tb) => clsMake.FindByName(tb.Text.Trim()) != null,
                        "Existing Make exist!"
                    );
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                return;
            }

            if (_Mode == enMode.Add)
            {
                MakeInfo = new clsMake();
            }

            MakeInfo.MakeName = tbMake.Text.Trim();

            string status = _Mode == enMode.Add ? "Added" : "Updated";

            if (MakeInfo.Save())
            {
                MessageBox.Show($"Make {status} Successfully!", "Success", MessageBoxButtons.OK);
            } else
            {
                MessageBox.Show("Something went wrong with make Add/Update operation");
            }
        }
    }
}
