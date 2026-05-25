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

namespace Cars_Rental.Rental.Forms
{
    public partial class frmRentalManagement : Form
    {
        private const int _RowHeight = 70;
        private const int _ButtonHeight = 32;
        private const int _RowsPerPage = 10;
        private int _CurrentPage = 1;
        private bool _HasNextPage = false;

        public frmRentalManagement()
        {
            InitializeComponent();
        }

        private void frmRentalManagement_Load(object sender, EventArgs e)
        {
            _LoadRentals();
            _LoadIcons();
        }

        private void _LoadRentals()
        {
            SetupRentalsTable();

            DataTable rentals = clsCarRental.FindRentals(_CurrentPage, _RowsPerPage + 1);

            _HasNextPage = rentals.Rows.Count > _RowsPerPage;

            if (_HasNextPage)
            {
                rentals.Rows.RemoveAt(_RowsPerPage); // remove extra row, show only 10
            }

            if (rentals.Rows.Count == 0)
            {
                _ShowEmptyState();
                return;
            }

            foreach (DataRow row in rentals.Rows)
            {
                int rentalID = (int)row["CarRentalID"];
                string customerName = row["CustomerName"].ToString();
                string carName = row["CarName"].ToString();
                DateTime pickupDate = (DateTime)row["PickupDate"];
                DateTime returnDate = (DateTime)row["ReturnDate"];
                string status = row["Status"].ToString();

                AddRentalRow(rentalID, customerName, carName, pickupDate, returnDate, status);
            }

            foreach (DataRow row in rentals.Rows)
            {
                int rentalID = (int)row["CarRentalID"];
                string customerName = row["CustomerName"].ToString();
                string carName = row["CarName"].ToString();
                DateTime pickupDate = (DateTime)row["PickupDate"];
                DateTime returnDate = (DateTime)row["ReturnDate"];
                string status = row["Status"].ToString();

                AddRentalRow(rentalID, customerName, carName, pickupDate, returnDate, status);
            }

            foreach (DataRow row in rentals.Rows)
            {
                int rentalID = (int)row["CarRentalID"];
                string customerName = row["CustomerName"].ToString();
                string carName = row["CarName"].ToString();
                DateTime pickupDate = (DateTime)row["PickupDate"];
                DateTime returnDate = (DateTime)row["ReturnDate"];
                string status = row["Status"].ToString();

                AddRentalRow(rentalID, customerName, carName, pickupDate, returnDate, status);
            }
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
                Text = "🚗",
                Dock = DockStyle.Top,
                Height = 55,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI Emoji", 28F)
            };

            Label lblTitle = new Label
            {
                Text = "No Rentals Found",
                Dock = DockStyle.Top,
                Height = 34,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = Color.FromArgb(31, 41, 55)
            };

            Label lblDescription = new Label
            {
                Text = "There are no rentals available right now.",
                Dock = DockStyle.Top,
                Height = 26,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = Color.FromArgb(107, 114, 128)
            };

            Guna2Button btnAddRental = new Guna2Button
            {
                Text = "Add Rental",
                Size = new Size(150, 40),
                BorderRadius = 8,
                FillColor = Color.FromArgb(59, 130, 246),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Animated = true,
                Anchor = AnchorStyles.None
            };

            btnAddRental.Image = Utility.GetFontAwesomeImage(
                IconChar.Plus,
                Color.White,
                16
            );

            btnAddRental.Location = new Point(
                (panel.Width - btnAddRental.Width) / 2,
                170
            );

            btnAddRental.Click += btnAddRental_Click;

            panel.Controls.Add(btnAddRental);
            panel.Controls.Add(lblDescription);
            panel.Controls.Add(lblTitle);
            panel.Controls.Add(icon);

            table.Controls.Add(panel, 0, 1);
            table.SetColumnSpan(panel, table.ColumnCount);
        }

        private void btnAddRental_Click(object sender, EventArgs e)
        {
            frmAddRental frm = new frmAddRental();
            frm.ShowDialog();

            _LoadRentals();
        }

        private void _LoadIcons()
        {
            btnAddCustomer.Image = Utility.GetFontAwesomeImage(IconChar.UserPlus, Color.White);
        }

        private void SetupRentalsTable()
        {
            table.Controls.Clear();
            table.ColumnStyles.Clear();
            table.RowStyles.Clear();

            table.ColumnCount = 7;
            table.RowCount = 0;

            pnlTable.AutoScroll = true;

            table.AutoSize = true;
            table.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            table.Dock = DockStyle.Top;

            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70));   // #
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24));    // Customer
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));    // Car
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17));    // Pickup
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17));    // Return
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140));  // Status
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 210));  // Actions

            AddHeader();
        }

        private void AddHeader()
        {
            table.RowCount++;
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));

            table.Controls.Add(CreateHeaderLabel("#"), 0, 0);
            table.Controls.Add(CreateHeaderLabel("Customer"), 1, 0);
            table.Controls.Add(CreateHeaderLabel("Car"), 2, 0);
            table.Controls.Add(CreateHeaderLabel("Pickup Date"), 3, 0);
            table.Controls.Add(CreateHeaderLabel("Return Date"), 4, 0);
            table.Controls.Add(CreateHeaderLabel("Status"), 5, 0);
            table.Controls.Add(CreateHeaderLabel("Actions"), 6, 0);
        }

        private void AddRentalRow(int id, string customerName, string carName, DateTime pickupDate, DateTime returnDate, string status)
        {
            int rowIndex = table.RowCount;

            table.RowCount++;
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, _RowHeight));

            table.Controls.Add(CreateCellLabel(id.ToString()), 0, rowIndex);
            table.Controls.Add(CreateCellLabel(customerName), 1, rowIndex);
            table.Controls.Add(CreateCellLabel(carName), 2, rowIndex);
            table.Controls.Add(CreateCellLabel(pickupDate.ToString("yyyy-MM-dd")), 3, rowIndex);
            table.Controls.Add(CreateCellLabel(returnDate.ToString("yyyy-MM-dd")), 4, rowIndex);
            table.Controls.Add(CreateStatusCell(status), 5, rowIndex);
            table.Controls.Add(CreateActionsPanel(id), 6, rowIndex);
        }

        private Guna2Button CreateStatusBadge(string status)
        {
            Color color = status == "Completed"
                ? Color.FromArgb(34, 197, 94)
                : Color.FromArgb(37, 99, 235);

            return new Guna2Button
            {
                Text = status,
                Size = new Size(100, _ButtonHeight),
                BorderRadius = 6,
                FillColor = color,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Cursor = Cursors.Default
            };
        }

        private Panel CreateStatusCell(string status)
        {
            Panel panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Margin = new Padding(0)
            };

            Guna2Button badge = CreateStatusBadge(status);

            badge.Location = new Point(
                20,
                (_RowHeight - badge.Height) / 2
            );

            panel.Controls.Add(badge);

            return panel;
        }

        private Label CreateHeaderLabel(string text)
        {
            return new Label
            {
                Text = text,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(37, 99, 235),
                Margin = new Padding(0)
            };
        }

        private Label CreateCellLabel(string text)
        {
            Label lbl = new Label
            {
                Text = text,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(31, 41, 55),
                BackColor = Color.White,
                Margin = new Padding(0),
                AutoEllipsis = true
            };

            toolTip1.SetToolTip(lbl, text);

            return lbl;
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            Hide();
            frmAddRental frm = new frmAddRental();
            frm.ShowDialog();
            frmRentalManagement_Load(null, null);
            Show();
        }

        private Panel CreateActionsPanel(int rentalID)
        {
            Panel panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Margin = new Padding(0)
            };

            int spacing = 10;
            int centerY = (_RowHeight - _ButtonHeight) / 2;

            bool hasReturned = clsRentalReturn.HasCarReturnedByCarRentalID(rentalID);

            Guna2Button btnView = new Guna2Button
            {
                Text = "View",
                Size = new Size(75, _ButtonHeight),
                BorderRadius = 6,
                FillColor = Color.FromArgb(59, 130, 246),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Tag = rentalID
            };

            btnView.Click += btnViewRental_Click;

            if (hasReturned)
            {
                btnView.Location = new Point((210 - btnView.Width) / 2, centerY);
                panel.Controls.Add(btnView);
                return panel;
            }

            Guna2Button btnReturn = new Guna2Button
            {
                Text = "Return",
                Size = new Size(75, _ButtonHeight),
                BorderRadius = 6,
                FillColor = Color.FromArgb(34, 197, 94),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Tag = rentalID
            };

            btnReturn.Click += btnReturnRental_Click;

            int totalWidth = btnView.Width + spacing + btnReturn.Width;
            int startX = (210 - totalWidth) / 2;

            btnView.Location = new Point(startX, centerY);
            btnReturn.Location = new Point(startX + btnView.Width + spacing, centerY);

            panel.Controls.Add(btnView);
            panel.Controls.Add(btnReturn);

            return panel;
        }

        private void btnViewRental_Click(object sender, EventArgs e)
        {
            int rentalID = Convert.ToInt32(((Guna2Button)sender).Tag);

            Hide();
            frmViewRental frm = new frmViewRental(rentalID);
            frm.ShowDialog();
            Show();
        }

        private void btnReturnRental_Click(object sender, EventArgs e)
        {
            int rentalID = Convert.ToInt32(((Guna2Button)sender).Tag);

            Hide();
            frmReturnRental frm = new frmReturnRental(rentalID);
            frm.ShowDialog();
            Show();

            _LoadRentals();
        }
    }
}
