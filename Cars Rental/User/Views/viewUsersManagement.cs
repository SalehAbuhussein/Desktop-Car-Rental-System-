using BusinessLayer;
using Cars_Rental.Global_Classes;
using Cars_Rental.User.Forms;
using Cars_Rental.User.Roles.Forms;
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

namespace Cars_Rental.User
{
    public partial class viewUsersManagement : UserControl
    {
        public Form Dashboard { get; set; }

        public viewUsersManagement()
        {
            InitializeComponent();
        }

        private void ctrlUsersManagement_Load(object sender, EventArgs e)
        {
            LoadUsersList();
            _InitIcons();
        }

        public void LoadUsersList()
        {
            table.Controls.Clear();

            _InitTable();

            DataTable users = clsUser.FindUsers();

            foreach (DataRow row in users.Rows)
            {
                int userID = (int)row["UserID"];

                _AddUserRow(userID);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int userID = (int)((Guna2Button)sender).Tag;

            Dashboard.Hide();
            frmAddUpdateUser frm = new frmAddUpdateUser(userID);
            frm.ShowDialog();
            Dashboard.Show();
            LoadUsersList();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            int userID = (int)((Guna2Button)sender).Tag;
            
            guna2MessageDialog1.Parent = Dashboard;
            guna2MessageDialog1.Icon = MessageDialogIcon.Question;
            guna2MessageDialog1.Buttons = MessageDialogButtons.OKCancel;
            
            if (guna2MessageDialog1.Show("Are you sure you want to delete this user?", "Confirmation") == DialogResult.Yes)
            {
                if (clsUser.DeleteUser(userID))
                {
                    guna2MessageDialog1.Icon = MessageDialogIcon.Information;
                    guna2MessageDialog1.Buttons = MessageDialogButtons.OK;
                    guna2MessageDialog1.Show("User Deleted Successfully!", "Success");
                    LoadUsersList();
                } else
                {
                    guna2MessageDialog1.Icon = MessageDialogIcon.Error;
                    guna2MessageDialog1.Show("Delete operation went wrong!", "Error");
                }
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            Dashboard.Hide();
            frmAddUpdateUser frm = new frmAddUpdateUser();
            frm.ShowDialog();
            Dashboard.Show();
            ctrlUsersManagement_Load(null, null);
        }

        private void _InitIcons()
        {
            btnAddUser.Image = Utility.GetFontAwesomeImage(IconChar.UserPlus, Color.White);
            btnRoles.Image = Utility.GetFontAwesomeImage(IconChar.UserShield, Color.FromArgb(79, 125, 243));

            btnRoles.Visible = CurrentUser.UserInfo.RoleInfo.RoleName != "Employee";
        }

        private void _InitTable()
        {
            _SetupTable();
            _AddHeader();
        }

        private void _SetupTable()
        {
            table.Controls.Clear();
            table.ColumnStyles.Clear();
            table.RowStyles.Clear();

            table.ColumnCount = 5;
            table.RowCount = 0;

            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160)); // #
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220)); // Name
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200)); // Username
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180)); // Role
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300)); // Actions
        }

        private void _AddHeader()
        {
            table.RowCount++;
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));

            table.Controls.Add(_CreateHeaderLabel("#"), 0, 0);
            table.Controls.Add(_CreateHeaderLabel("Name"), 1, 0);
            table.Controls.Add(_CreateHeaderLabel("Username"), 2, 0);
            table.Controls.Add(_CreateHeaderLabel("Role"), 3, 0);
            table.Controls.Add(_CreateHeaderLabel("Actions"), 4, 0);
        }

        private void _AddUserRow(int userId)
        {
            clsUser user = clsUser.FindUser(userId);

            if (user == null)
            {
                guna2MessageDialog1.Icon = MessageDialogIcon.Error;
                guna2MessageDialog1.Show("Invalid user Data!", "Error");
                return;
            }

            int rowIndex = table.RowCount;

            table.RowCount++;
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 55F));

            // ID badge
            Guna2Button btnID = _CreateBadge($"#{userId}", Color.FromArgb(84, 131, 255));

            // Name
            Label lblName = _CreateCellLabel(user.ShortName);

            // Username
            Label lblUsername = _CreateCellLabel(user.Username);

            // Role
            Label lblRole = _CreateCellLabel(user.RoleInfo.RoleName);

            // Actions
            Panel actions = _CreateActionsPanel(userId);

            table.Controls.Add(btnID, 0, rowIndex);
            table.Controls.Add(lblName, 1, rowIndex);
            table.Controls.Add(lblUsername, 2, rowIndex);
            table.Controls.Add(lblRole, 3, rowIndex);
            table.Controls.Add(actions, 4, rowIndex);
        }

        private Label _CreateHeaderLabel(string text, Padding? padding = null)
        {
            if (Padding == null)
            {
                padding = new Padding(6, 0, 6, 0);
            }

            return new Label
            {
                Text = text,
                AutoSize = false,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                ForeColor = Color.FromArgb(107, 114, 128),
                Margin = padding ?? new Padding(6, 0, 6, 0),
                BackColor = Color.Transparent
            };
        }

        private Panel _CreateActionsPanel(int userId)
        {
            var panel = new Panel
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(16, 0, 0, 0)
            };

            var btnEdit = new Guna2Button
            {
                Text = "Edit",
                Size = new Size(80, 30),
                BorderRadius = 6,
                FillColor = Color.FromArgb(84, 131, 255),
                ForeColor = Color.White,
                Location = new Point(0, 12),
                Animated = true,
                Tag = userId
            };

            var btnDelete = new Guna2Button
            {
                Text = "Delete",
                Size = new Size(80, 30),
                BorderRadius = 6,
                FillColor = Color.FromArgb(239, 68, 68),
                ForeColor = Color.White,
                Location = new Point(90, 12),
                Animated = true,
                Tag = userId,
            };

            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDeleteUser_Click;

            panel.Controls.Add(btnEdit);
            panel.Controls.Add(btnDelete);

            return panel;
        }

        private Guna2Button _CreateBadge(string text, Color color)
        {
            return new Guna2Button
            {
                Text = text,
                Size = new Size(80, 30),
                BorderRadius = 8,
                FillColor = color,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Enabled = false,
                DisabledState =
                {
                    FillColor = color,
                    ForeColor = Color.White
                },
                Anchor = AnchorStyles.Left,
                Margin = new Padding(6, 0, 6, 0)
            };
        }

        private Label _CreateCellLabel(string text)
        {
            return new Label
            {
                Text = text,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Segoe UI", 9F),
                Margin = new Padding(6, 0, 6, 0)
            };
        }

        private void btnRoles_Click(object sender, EventArgs e)
        {
            Dashboard.Hide();
            frmRolesManagement frm = new frmRolesManagement();
            frm.ShowDialog();
            Dashboard.Show();
        }
    }
}
