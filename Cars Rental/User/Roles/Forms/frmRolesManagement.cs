using BusinessLayer;
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
    public partial class frmRolesManagement : Form
    {
        public frmRolesManagement()
        {
            InitializeComponent();
        }

        private void frmRolesManagement_Load(object sender, EventArgs e)
        {
            _LoadRoles();
        }

        private void _LoadRoles()
        {
            table.Controls.Clear();

            _SetupTable();

            DataTable roles = clsRole.FindAll();

            if (roles.Rows.Count > 0)
            {
                foreach (DataRow row in roles.Rows)
                {
                    _AddRoleRow((int)row["RoleID"], row["RoleName"].ToString(), Convert.ToBoolean(row["Active"]));
                }
            }

        }

        private void _SetupTable()
        {
            table.Controls.Clear();
            table.ColumnStyles.Clear();
            table.RowStyles.Clear();

            table.ColumnCount = 4;
            table.RowCount = 0;

            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120)); // #
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45));   // Role Name
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));   // Status
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));   // Actions

            _AddHeader();
        }

        private void _AddHeader()
        {
            table.RowCount++;
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));

            table.Controls.Add(_CreateHeaderLabel("#"), 0, 0);
            table.Controls.Add(_CreateHeaderLabel("Role Name"), 1, 0);
            table.Controls.Add(_CreateHeaderLabel("Status"), 2, 0);
            table.Controls.Add(_CreateHeaderLabel("Actions"), 3, 0);
        }

        private void _AddRoleRow(int roleID, string roleName, bool isActive)
        {
            int rowIndex = table.RowCount;

            table.RowCount++;
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));

            table.Controls.Add(_CreateBadge($"#{roleID}"), 0, rowIndex);
            table.Controls.Add(_CreateCellLabel(roleName), 1, rowIndex);
            table.Controls.Add(_CreateStatusBadge(isActive), 2, rowIndex);
            table.Controls.Add(_CreateActionsPanel(roleID), 3, rowIndex);
        }

        private Label _CreateHeaderLabel(string text)
        {
            return new Label
            {
                Text = text,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(107, 114, 128),
                BackColor = Color.Transparent,
                Margin = new Padding(0)
            };
        }

        private Guna2Button _CreateBadge(string text)
        {
            return new Guna2Button
            {
                Text = text,
                Width = 80,
                Height = 30,
                BorderRadius = 8,
                FillColor = Color.FromArgb(79, 125, 243),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Enabled = true,
                Anchor = AnchorStyles.None,
                Margin = new Padding(0)
            };
        }

        private Label _CreateCellLabel(string text)
        {
            return new Label
            {
                Text = text,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(17, 24, 39),
                BackColor = Color.Transparent,
                Margin = new Padding(0),
                AutoEllipsis = true
            };
        }

        private Guna2Button _CreateStatusBadge(bool isActive)
        {
            Color fillColor = isActive
                ? Color.FromArgb(34, 197, 94)
                : Color.FromArgb(239, 68, 68);

            return new Guna2Button
            {
                Text = isActive ? "Active" : "Inactive",
                Width = 95,
                Height = 32,
                BorderRadius = 8,
                FillColor = fillColor,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Enabled = false,
                Anchor = AnchorStyles.None,
                Margin = new Padding(0),

                DisabledState =
        {
            FillColor = fillColor,
            ForeColor = Color.White
        }
            };
        }

        private Panel _CreateActionsPanel(int roleID)
        {
            Panel panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent,
                Margin = new Padding(0)
            };

            Guna2Button btnEdit = new Guna2Button
            {
                Text = "Edit",
                Size = new Size(75, 32),
                BorderRadius = 6,
                FillColor = Color.FromArgb(84, 131, 255),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Tag = roleID
            };

            Guna2Button btnDelete = new Guna2Button
            {
                Text = "Delete",
                Size = new Size(75, 32),
                BorderRadius = 6,
                FillColor = Color.FromArgb(239, 68, 68),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Tag = roleID
            };

            btnEdit.Click += btnEditRole_Click;
            btnDelete.Click += btnDeleteRole_Click;

            int spacing = 10;

            int totalWidth = btnEdit.Width + btnDelete.Width + spacing;

            int startX = (220 - totalWidth) / 2;

            int centerY = (60 - btnEdit.Height) / 2;

            btnEdit.Location = new Point(startX, centerY);

            btnDelete.Location = new Point(startX + btnEdit.Width + spacing, centerY);

            panel.Controls.Add(btnEdit);
            panel.Controls.Add(btnDelete);

            return panel;
        }

        private void btnEditRole_Click(object sender, EventArgs e)
        {
            Guna2Button button = (Guna2Button)sender;

            int roleID = (int)button.Tag;
            frmAddEditRole frm = new frmAddEditRole(roleID);
            frm.ShowDialog();

            _LoadRoles();
        }

        private void btnDeleteRole_Click(object sender, EventArgs e)
        {
            Guna2Button button = (Guna2Button)sender;

            int roleID = (int)button.Tag;

            popup.Buttons = MessageDialogButtons.YesNo;
            popup.Icon = MessageDialogIcon.Warning;

            DialogResult result = popup.Show("Are you sure you want to delete this role?", "Confirm Delete");

            if (result == DialogResult.Yes)
            {
                if (clsRole.DeleteRole(roleID))
                {
                    popup.Buttons = MessageDialogButtons.OK;
                    popup.Icon = MessageDialogIcon.Information;
                    popup.Show("Role deleted successfully.", "Success");

                    _LoadRoles();
                }
                else
                {
                    popup.Buttons = MessageDialogButtons.OK;
                    popup.Icon = MessageDialogIcon.Error;
                    popup.Show("Failed to delete role.","Error");
                }
            }
        }

        private void btnAddRole_Click(object sender, EventArgs e)
        {
            Hide();
            frmAddEditRole frm = new frmAddEditRole();
            frm.ShowDialog();
            Show();
            frmRolesManagement_Load(null, null);
        }
    }
}
