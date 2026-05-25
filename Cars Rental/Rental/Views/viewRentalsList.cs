using BusinessLayer;
using Cars_Rental.Rental.Forms;
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

namespace Cars_Rental.Rental.Views
{
    public partial class viewRentalsList : UserControl
    {
        public Form Dashboard { get; set; }
        public DataTable carRentalListInfo;
        public static string ActiveStatus = "Active";

        public viewRentalsList()
        {
            InitializeComponent();
        }

        private void viewRentalsList_Load(object sender, EventArgs e)
        {
            LoadRentalsList();
        }

        public void LoadRentalsList()
        {
            table.Controls.Clear();

            _InitRentalsTable();

            carRentalListInfo = clsCarRental.FindRentalsByStatus(1, 10, ActiveStatus);

            if (carRentalListInfo.Rows.Count == 0)
            {
                table.RowCount++;
                table.RowStyles.Add(new RowStyle(SizeType.Absolute, 260F));

                table.Controls.Add(_CreateEmptyState(), 0, 1);
                table.SetColumnSpan(table.Controls[table.Controls.Count - 1], table.ColumnCount);

                return;
            }

            foreach (DataRow row in carRentalListInfo.Rows)
            {
                _AddRentalRow(row);
            }
        }

        private Control _CreateEmptyState()
        {
            Panel panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };

            Label icon = new Label
            {
                Text = "🚗",
                AutoSize = false,
                Size = new Size(120, 60),
                Location = new Point((table.Width / 2) - 60, 90),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI Emoji", 32F)
            };

            Label title = new Label
            {
                Text = "No rentals found",
                AutoSize = false,
                Size = new Size(300, 30),
                Location = new Point((table.Width / 2) - 150, 155),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = Color.FromArgb(17, 24, 39)
            };

            Label subtitle = new Label
            {
                Text = "There are no rentals in this section yet.",
                AutoSize = false,
                Size = new Size(400, 25),
                Location = new Point((table.Width / 2) - 200, 190),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = Color.FromArgb(107, 114, 128)
            };

            panel.Controls.Add(icon);
            panel.Controls.Add(title);
            panel.Controls.Add(subtitle);

            return panel;
        }

        private void _InitRentalsTable()
        {
            _SetupRentalsTable();
            _AddRentalsHeader();
        }

        private void _SetupRentalsTable()
        {
            table.Controls.Clear();
            table.ColumnStyles.Clear();
            table.RowStyles.Clear();

            table.ColumnCount = 6;
            table.RowCount = 0;

            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6));   // #
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24));  // Car
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14));  // Pickup Date
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14));  // Return Date
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14));  // Paid
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28));  // Actions
        }

        private void _AddRentalsHeader()
        {
            table.RowCount++;
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));

            table.Controls.Add(_CreateHeaderLabel("#"), 0, 0);
            table.Controls.Add(_CreateHeaderLabel("Car"), 1, 0);
            table.Controls.Add(_CreateHeaderLabel("Pickup Date"), 2, 0);
            table.Controls.Add(_CreateHeaderLabel("Return Date"), 3, 0);
            table.Controls.Add(_CreateHeaderLabel("Paid"), 4, 0);
            table.Controls.Add(_CreateHeaderLabel("Actions"), 5, 0);
        }

        private void _AddRentalRow(DataRow row)
        {
            int rowIndex = table.RowCount;

            int carRentalID = Convert.ToInt32(row["CarRentalID"]);
            string carName = row["CarName"].ToString();

            decimal pricePerDay = Convert.ToDecimal(row["PricePerDay"]);
            DateTime pickupDate = Convert.ToDateTime(row["PickupDate"]);
            DateTime returnDate = Convert.ToDateTime(row["ReturnDate"]);
            string status = row["Status"].ToString();

            decimal totalPaidAmount = row["TotalPaidAmount"] == DBNull.Value
                ? 0
                : Convert.ToDecimal(row["TotalPaidAmount"]);

            int rentalDays = Math.Max(1, (returnDate.Date - pickupDate.Date).Days);
            decimal totalPrice = pricePerDay * rentalDays;

            table.RowCount++;
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 86F));

            table.Controls.Add(_CreateCellLabel(carRentalID.ToString()), 0, rowIndex);
            table.Controls.Add(_CreateCellLabel(carName), 1, rowIndex);
            table.Controls.Add(_CreateCellLabel(pickupDate.ToString("M/d/yyyy")), 2, rowIndex);
            table.Controls.Add(_CreateCellLabel(returnDate.ToString("M/d/yyyy")), 3, rowIndex);
            table.Controls.Add(_CreatePaidPanel(totalPaidAmount, totalPrice), 4, rowIndex);
            table.Controls.Add(_CreateActionsPanel(carRentalID, status), 5, rowIndex);
        }

        private Label _CreateHeaderLabel(string text)
        {
            return new Label
            {
                Text = text,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(55, 65, 81),
                Margin = new Padding(6, 0, 6, 0),
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
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = Color.FromArgb(17, 24, 39),
                Margin = new Padding(6, 0, 6, 0)
            };
        }

        private Panel _CreatePaidPanel(decimal paidAmount, decimal totalPrice)
        {
            Panel panel = new Panel
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(6, 0, 6, 0)
            };

            decimal percent = totalPrice <= 0 ? 0 : (paidAmount / totalPrice) * 100;
            int progressValue = Math.Min(100, Math.Max(0, (int)percent));

            Label lblAmount = new Label
            {
                Text = $"{paidAmount:0.##} / {totalPrice:0.##}",
                Location = new Point(0, 17),
                Size = new Size(120, 20),
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(17, 24, 39)
            };

            Guna2ProgressBar progress = new Guna2ProgressBar
            {
                Location = new Point(0, 43),
                Size = new Size(95, 8),
                BorderRadius = 4,
                Value = progressValue,
                FillColor = Color.FromArgb(229, 231, 235),
                ProgressColor = progressValue >= 100
                    ? Color.FromArgb(22, 163, 74)
                    : Color.FromArgb(37, 99, 235),
                ProgressColor2 = progressValue >= 100
                    ? Color.FromArgb(22, 163, 74)
                    : Color.FromArgb(37, 99, 235)
            };

            panel.Controls.Add(lblAmount);
            panel.Controls.Add(progress);

            return panel;
        }

        private Panel _CreateActionsPanel(int carRentalID, string status = "Active")
        {
            Panel panel = new Panel
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(6, 0, 0, 0)
            };

            Guna2Button btnReturn = new Guna2Button
            {
                Text = "Return",
                Size = new Size(68, 32),
                BorderRadius = 6,
                FillColor = Color.FromArgb(37, 99, 235),
                ForeColor = Color.White,
                Location = new Point(0, 27),
                Animated = true,
                Tag = carRentalID
            };

            Guna2Button btnExtend = new Guna2Button
            {
                Text = "Extend",
                Size = new Size(68, 32),
                BorderRadius = 6,
                FillColor = Color.FromArgb(59, 130, 246),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F),
                Location = new Point(74, 27),
                Animated = true,
                Cursor = Cursors.Hand,
                Tag = carRentalID
            };

            Guna2Button btnView = new Guna2Button
            {
                Text = "View",
                Size = new Size(58, 32),
                BorderRadius = 6,
                FillColor = Color.White,
                ForeColor = Color.FromArgb(17, 24, 39),
                BorderThickness = 1,
                BorderColor = Color.FromArgb(229, 231, 235),
                Animated = true,
                Tag = carRentalID
            };

            if (status == "Active")
            {
                btnReturn.Click += btnReturnRental_Click;
                btnExtend.Click += btnExtenRental_Click;

                panel.Controls.Add(btnReturn);
                panel.Controls.Add(btnExtend);

                // Place after Return + Extend
                btnView.Location = new Point(148, 27);
            }
            else
            {
                // Move View to the beginning when others are hidden
                btnView.Location = new Point(0, 27);
            }

            btnView.Click += btnViewRental_Click;
            panel.Controls.Add(btnView);

            return panel;
        }

        private void btnReturnRental_Click(object sender, EventArgs e)
        {
            int carRentalID = (int)((Guna2Button)sender).Tag;
            Dashboard.Hide();
            frmReturnRental frm = new frmReturnRental(carRentalID);
            frm.ShowDialog();
            Dashboard.Show();
            viewRentalsList_Load(null, null);
        }

        private void btnExtenRental_Click(object sender, EventArgs e)
        {
            int carRentalID = (int)((Guna2Button)sender).Tag;
            Dashboard.Hide();
            frmExtendRental frm = new frmExtendRental(carRentalID);
            frm.ShowDialog();
            Dashboard.Show();
            viewRentalsList_Load(null, null);
        }

        private void btnViewRental_Click(object sender, EventArgs e)
        {
            int carRentalID = (int)((Guna2Button)sender).Tag;

            Dashboard.Hide();
            frmViewRental frm = new frmViewRental(carRentalID);
            frm.ShowDialog();
            Dashboard.Show();
            viewRentalsList_Load(null, null);
        }
    }
}
