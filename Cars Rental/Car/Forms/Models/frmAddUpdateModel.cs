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

namespace Cars_Rental.Car.Forms.Models
{
    public partial class frmAddUpdateModel : Form
    {
        public enum enMode
        {
            Add,
            Update,
        }

        private int? _ModelID;
        public clsModel ModelInfo { get; set; }
        private enMode _Mode = enMode.Add;

        public frmAddUpdateModel(int? modelID = null)
        {
            InitializeComponent();

            if (modelID == null)
            {
                _Mode = enMode.Add;
            } else
            {
                _Mode = enMode.Update;
                _ModelID = modelID;
            }
        }

        private void frmAddUpdateModel_Load(object sender, EventArgs e)
        {
            _LoadIcons();
            _InitMakes();

            if (_Mode == enMode.Update)
            {
                _LoadMakeInfo();
            }
        }

        private void _InitMakes()
        {
            DataTable makes = clsMake.FindMakes();

            cbMake.Items.Clear();

            foreach (DataRow row in makes.Rows)
            {
                cbMake.Items.Add(row["Make"].ToString());
            }
        }

        private void _LoadIcons()
        {
            btnSave.Image = Utility.GetFontAwesomeImage(IconChar.Check, Color.White);
            btnCancel.Image = Utility.GetFontAwesomeImage(IconChar.Xmark, Color.White);
        }

        private void _LoadMakeInfo()
        {
            ModelInfo = clsModel.Find(_ModelID);

            if (ModelInfo == null)
            {
                return;
            }

            tbModel.Text = ModelInfo.ModelName;
            cbMake.SelectedIndex = cbMake.FindString(clsMake.Find(ModelInfo.MakeID)?.MakeName);
        }

        private void tbModel_Validating(object sender, CancelEventArgs e)
        {
            if (_Mode == enMode.Add)
            {
                e.Cancel = Validators.ValidateControl(
                    (Guna2TextBox)sender,
                    errorProvider1,
                    (tb) => string.IsNullOrEmpty(tb.Text.Trim()),
                    "Model can not be empty!"
                ) || Validators.ValidateControl(
                    (Guna2TextBox)sender,
                    errorProvider1,
                    (tb) => clsModel.FindByName(tb.Text.Trim()) != null,
                    "Existing Model exist!"
                );
            } else
            {
                string modelName = ModelInfo.ModelName;
                string newModelName = tbModel.Text.Trim();

                if (newModelName != modelName)
                {
                    e.Cancel = Validators.ValidateControl(
                        (Guna2TextBox)sender,
                        errorProvider1,
                        (tb) => clsModel.FindByName(tb.Text.Trim()) != null,
                        "Existing Model exist!"
                    ) || Validators.ValidateControl(
                        (Guna2TextBox)sender,
                        errorProvider1,
                        (tb) => string.IsNullOrEmpty(tb.Text.Trim()),
                        "Model can not be empty!"
                    );
                } else
                {
                    e.Cancel = Validators.ValidateControl(
                        (Guna2TextBox)sender,
                        errorProvider1,
                        (tb) => string.IsNullOrEmpty(tb.Text.Trim()),
                        "Model can not be empty!"
                    );
                }
            }
        }

        private void cbMake_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Validators.ValidateControl(
                (Guna2ComboBox)sender,
                errorProvider1,
                (tb) => string.IsNullOrEmpty(tb.Text.Trim()),
                "Make can not be empty!"
            );
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
                ModelInfo = new clsModel();
            }

            ModelInfo.ModelName = tbModel.Text.Trim();
            ModelInfo.MakeID = clsMake.FindByName(cbMake.SelectedItem?.ToString()).MakeID;

            string status = _Mode == enMode.Add ? "Added" : "Updated";

            if (ModelInfo.Save())
            {
                MessageBox.Show($"Model is {status} Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                MessageBox.Show($"Something went wrong with model delete operation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
