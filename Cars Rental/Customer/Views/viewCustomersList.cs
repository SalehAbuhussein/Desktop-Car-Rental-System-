using BusinessLayer;
using Cars_Rental.Customer.Forms;
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

namespace Cars_Rental.Customer.Views
{
    public partial class viewCustomersList : UserControl
    {
        public Form Dashboard { get; set; }

        public viewCustomersList()
        {
            InitializeComponent();
        }

        private void viewCustomersList_Load(object sender, EventArgs e)
        {
            _InitIcons();
            LoadCustomersList();
        }

        private void _InitIcons()
        {
            btnAddCustomer.Image = Utility.GetFontAwesomeImage(IconChar.UserPlus, Color.White);
        }

        public void LoadCustomersList()
        {
            table.Controls.Clear();

            _InitTable();

            DataTable customers = clsCustomer.GetCustomersData();

            if (customers.Rows.Count <= 0)
            {
                _ShowEmptyState();
                return;
            }

            foreach (DataRow row in customers.Rows)
            {
                int customerID = Convert.ToInt32(row["CustomerID"]);
                string customerName = row["CustomerName"].ToString();
                string nationalNo = row["NationalNo"].ToString();

                _AddCustomerRow(customerID, customerName, nationalNo);
            }
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

            table.ColumnCount = 4;
            table.RowCount = 0;

            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180)); // #
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 350)); // Customer Name
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300)); // National Number
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300)); // Actions
        }

        private void _AddHeader()
        {
            table.RowCount++;
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));

            table.Controls.Add(_CreateHeaderLabel("#"), 0, 0);
            table.Controls.Add(_CreateHeaderLabel("Customer Name"), 1, 0);
            table.Controls.Add(_CreateHeaderLabel("National Number"), 2, 0);
            table.Controls.Add(_CreateHeaderLabel("Actions"), 3, 0);
        }

        private void _AddCustomerRow(int customerID, string customerName, string nationalNo)
        {
            int rowIndex = table.RowCount;

            table.RowCount++;
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 55F));

            Guna2Button btnID = _CreateBadge($"#{customerID}", Color.FromArgb(84, 131, 255));

            Label lblName = _CreateCellLabel(customerName);

            Label lblNationalNumber = _CreateCellLabel(nationalNo);

            Panel actions = _CreateActionsPanel(customerID);

            table.Controls.Add(btnID, 0, rowIndex);
            table.Controls.Add(lblName, 1, rowIndex);
            table.Controls.Add(lblNationalNumber, 2, rowIndex);
            table.Controls.Add(actions, 3, rowIndex);
        }

        private Label _CreateHeaderLabel(string text, Padding? padding = null)
        {
            if (padding == null)
                padding = new Padding(6, 0, 6, 0);

            return new Label
            {
                Text = text,
                AutoSize = false,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                ForeColor = Color.FromArgb(107, 114, 128),
                Margin = padding.Value,
                BackColor = Color.Transparent
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
                ForeColor = Color.FromArgb(17, 24, 39),
                Margin = new Padding(6, 0, 6, 0)
            };
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

        private Panel _CreateActionsPanel(int customerID)
        {
            Panel panel = new Panel
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(16, 0, 0, 0)
            };

            Guna2Button btnEdit = new Guna2Button
            {
                Text = "Edit",
                Size = new Size(80, 30),
                BorderRadius = 6,
                FillColor = Color.FromArgb(84, 131, 255),
                ForeColor = Color.White,
                Location = new Point(0, 12),
                Animated = true,
                Tag = customerID
            };

            Guna2Button btnDelete = new Guna2Button
            {
                Text = "Delete",
                Size = new Size(80, 30),
                BorderRadius = 6,
                FillColor = Color.FromArgb(239, 68, 68),
                ForeColor = Color.White,
                Location = new Point(90, 12),
                Animated = true,
                Tag = customerID
            };

            btnEdit.Click += btnEditCustomer_Click;
            btnDelete.Click += btnDeleteCustomer_Click;

            panel.Controls.Add(btnEdit);
            panel.Controls.Add(btnDelete);

            return panel;
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            Dashboard.Hide();

            frmAddUpdateCustomer frm = new frmAddUpdateCustomer();
            frm.ShowDialog();

            Dashboard.Show();
            viewCustomersList_Load(null, null);
        }

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            int customerID = Convert.ToInt32(((Guna2Button)sender).Tag);

            Dashboard.Hide();

            frmAddUpdateCustomer frm = new frmAddUpdateCustomer(customerID);
            frm.ShowDialog();

            Dashboard.Show();
            viewCustomersList_Load(null, null);
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            int customerID = Convert.ToInt32(((Guna2Button)sender).Tag);

            guna2MessageDialog1.Parent = Dashboard;
            guna2MessageDialog1.Icon = MessageDialogIcon.Question;
            guna2MessageDialog1.Buttons = MessageDialogButtons.OKCancel;

            if (guna2MessageDialog1.Show("Are you sure you want to delete this customer?", "Confirmation") == DialogResult.OK)
            {
                if (clsCustomer.DeleteCustomer(customerID))
                {
                    guna2MessageDialog1.Icon = MessageDialogIcon.Information;
                    guna2MessageDialog1.Buttons = MessageDialogButtons.OK;
                    guna2MessageDialog1.Show("Customer Deleted Successfully!", "Success");
                }
                else
                {
                    guna2MessageDialog1.Icon = MessageDialogIcon.Error;
                    guna2MessageDialog1.Buttons = MessageDialogButtons.OK;
                    guna2MessageDialog1.Show("Delete operation went wrong!", "Error");
                }

                viewCustomersList_Load(null, null);
            }
        }

        private void btnAddCustomer_Click_1(object sender, EventArgs e)
        {
            Dashboard.Hide();
            frmAddUpdateCustomer frm = new frmAddUpdateCustomer();
            frm.ShowDialog();
            Dashboard.Show();
        }

        private void _ShowEmptyState()
        {
            table.RowCount++;
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 420F));

            Panel panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(0, 120, 0, 0)
            };

            Label icon = new Label
            {
                Text = "👥",
                Dock = DockStyle.Top,
                Height = 55,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI Emoji", 28F)
            };

            Label lblTitle = new Label
            {
                Text = "No Customers Found",
                Dock = DockStyle.Top,
                Height = 34,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = Color.FromArgb(31, 41, 55)
            };

            Label lblDescription = new Label
            {
                Text = "Start by adding your first customer.",
                Dock = DockStyle.Top,
                Height = 26,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = Color.FromArgb(107, 114, 128)
            };

            panel.Controls.Add(lblDescription);
            panel.Controls.Add(lblTitle);
            panel.Controls.Add(icon);

            table.Controls.Add(panel, 0, 1);
            table.SetColumnSpan(panel, table.ColumnCount);
        }
    }
}
