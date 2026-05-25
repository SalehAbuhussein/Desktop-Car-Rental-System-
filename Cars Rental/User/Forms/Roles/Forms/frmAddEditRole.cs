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

namespace Cars_Rental.User.Roles.Forms
{
    public partial class frmAddEditRole : Form
    {
        public enum enMode
        {
            Add,
            Update
        }
        public clsRole RoleInfo { get; set; }
        private int? _RoleID;
        private enMode _Mode = enMode.Add;

        public frmAddEditRole()
        {
            InitializeComponent();
        }

        public frmAddEditRole(int? roleID)
        {
            InitializeComponent();

            _RoleID = roleID;
            _Mode = enMode.Update;
        }

        private void frmAddEditRole_Load(object sender, EventArgs e)
        {
            _LoadIcons();

            if (_Mode == enMode.Update)
            {
                _LoadRoleData();
            }
        }

        private void _LoadIcons()
        {
            btnSave.Image = Utility.GetFontAwesomeImage(IconChar.Check, Color.White);
            btnCancel.Image = Utility.GetFontAwesomeImage(IconChar.Xmark, Color.White);
        }

        private void _LoadRoleData()
        {
            RoleInfo = clsRole.Find(_RoleID);

            if (RoleInfo == null)
            {
                popup.Icon = MessageDialogIcon.Error;
                popup.Buttons = MessageDialogButtons.OK;
                popup.Show("Invalid Role Data!", "Error");
                return;
            }

            tbRole.Text = RoleInfo.RoleName;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbRole_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Validators.ValidateControl(
                (Guna2TextBox)sender,
                errorProvider1,
                (tb) => string.IsNullOrEmpty(tb.Text.Trim()),
                "Role can not be empty!"
            );

            if (!e.Cancel && _Mode == enMode.Add)
            {
                e.Cancel = Validators.ValidateControl(
                    (Guna2TextBox)sender,
                    errorProvider1,
                    (tb) => clsRole.IsRoleExist(tb.Text.Trim()),
                    "Role should be unique!"
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
                RoleInfo = new clsRole();
            }

            RoleInfo.RoleName = tbRole.Text.Trim();

            string status = _Mode == enMode.Add ? "Added" : "Updated";

            if (RoleInfo.Save())
            {
                popup.Icon = MessageDialogIcon.Information;
                popup.Buttons = MessageDialogButtons.OK;
                popup.Show($"Role with id of {RoleInfo.RoleID} has been {status}", "Success");
                Close();
            } else
            {
                string operation = _Mode == enMode.Add ? "Add" : "Update";

                popup.Icon = MessageDialogIcon.Error;
                popup.Buttons = MessageDialogButtons.OK;
                popup.Show($"Something went wrong with Role {operation}", "Error");
            }
        }
    }
}
