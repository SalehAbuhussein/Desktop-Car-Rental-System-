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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cars_Rental.Payment.Forms
{
    public partial class frmPaymentHistory : Form
    {
        private int? _CarRentalID;
        public clsCarRental CarRentalInfo { get; set; }

        public frmPaymentHistory(int? carRentalID)
        {
            InitializeComponent();

            _CarRentalID = carRentalID;
        }

        private void frmPaymentHistory_Load(object sender, EventArgs e)
        {
            _InitButtonIcons();
            LoadPayments();
        }

        private void _AddHeader()
        {
            table.RowCount++;
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));

            table.Controls.Add(_CreateHeaderLabel("#"), 0, 0);
            table.Controls.Add(_CreateHeaderLabel("Customer"), 1, 0);
            table.Controls.Add(_CreateHeaderLabel("Amount"), 2, 0);
            table.Controls.Add(_CreateHeaderLabel("Type"), 3, 0);
            table.Controls.Add(_CreateHeaderLabel("Status"), 4, 0);
            table.Controls.Add(_CreateHeaderLabel("Date"), 5, 0);
        }

        private void LoadPayments()
        {
            CarRentalInfo = clsCarRental.Find(_CarRentalID);

            if (CarRentalInfo == null)
            {
                return;
            }

            _InitTable();

            DataTable dt = clsCarRentalPayment.GetRentalPaymentsDataByCarRentalID(_CarRentalID, 1, 10);

            lblTotalPayments.Text = dt.Rows.Count.ToString();

            if (dt.Rows.Count <= 0)
            {
                _ShowEmptyState();
                return;
            }

            foreach (DataRow row in dt.Rows)
            {
                int paymentID = Convert.ToInt32(row["CarRentalPaymentID"]);
                string customerName = row["CustomerName"].ToString();
                decimal amount = Convert.ToDecimal(row["Amount"]);
                string type = row["Type"].ToString();
                string status = row["Status"].ToString();
                DateTime createdAt = Convert.ToDateTime(row["CreatedAt"]);

                _AddPaymentRow(paymentID, customerName, amount, type, status, createdAt);
            }
        }

        private void _InitTable()
        {
            table.Controls.Clear();
            table.ColumnStyles.Clear();
            table.RowStyles.Clear();

            table.ColumnCount = 6;
            table.RowCount = 0;

            table.AutoSize = true;
            table.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            table.Dock = DockStyle.Top;
            table.BackColor = Color.White;

            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120)); // #
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 280)); // Customer
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150)); // Amount
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160)); // Type
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160)); // Status
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180)); // Date

            _AddHeader();
        }

        private void _AddPaymentRow(
            int paymentID,
            string customerName,
            decimal amount,
            string type,
            string status,
            DateTime createdAt)
        {
            int rowIndex = table.RowCount;

            table.RowCount++;
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));

            table.Controls.Add(_CreateBadge($"#{paymentID}", Color.FromArgb(84, 131, 255)), 0, rowIndex);
            table.Controls.Add(_CreateCellLabel(customerName), 1, rowIndex);
            table.Controls.Add(_CreateAmountLabel(amount), 2, rowIndex);
            table.Controls.Add(_CreateTypeBadge(type), 3, rowIndex);
            table.Controls.Add(_CreateStatusBadge(status), 4, rowIndex);
            table.Controls.Add(_CreateCellLabel(createdAt.ToString("yyyy-MM-dd")), 5, rowIndex);

            if (amount > 0)
            {
                lblTotalPaid.Text = (Convert.ToDecimal(lblTotalPaid.Text) + amount).ToString();
            }
            
            if (amount < 0)
            {
                lblTotalRefunds.Text = (Convert.ToDecimal(lblTotalRefunds.Text) + amount).ToString();
            }

            lblNetPaid.Text = (Convert.ToDecimal(lblNetPaid.Text) + amount).ToString();
        }

        private Guna2Button _CreateStatusBadge(string status)
        {
            return new Guna2Button
            {
                Text = status,
                Size = new Size(110, 28),
                BorderRadius = 8,
                FillColor = Color.FromArgb(220, 252, 231),
                ForeColor = Color.FromArgb(22, 101, 52),
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                Enabled = false,
                DisabledState =
                {
                    FillColor = Color.FromArgb(220, 252, 231),
                    ForeColor = Color.FromArgb(22, 101, 52)
                },
                Anchor = AnchorStyles.None,
                Margin = new Padding(0)
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
                Anchor = AnchorStyles.None,
                Margin = new Padding(0)
            };
        }

        private void _ShowEmptyState()
        {
            table.RowCount++;
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 430F));

            TableLayoutPanel emptyContainer = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                ColumnCount = 1,
                RowCount = 1,
                Margin = new Padding(0)
            };

            emptyContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            emptyContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            FlowLayoutPanel content = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Anchor = AnchorStyles.None,
                BackColor = Color.Transparent
            };

            Label icon = new Label
            {
                Text = "💳",
                Size = new Size(420, 70),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI Emoji", 30F)
            };

            Label lblTitle = new Label
            {
                Text = "No Payments Found",
                Size = new Size(420, 35),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(31, 41, 55)
            };

            Label lblDescription = new Label
            {
                Text = "Payments will appear here automatically.",
                Size = new Size(420, 28),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = Color.FromArgb(107, 114, 128)
            };

            content.Controls.Add(icon);
            content.Controls.Add(lblTitle);
            content.Controls.Add(lblDescription);

            emptyContainer.Controls.Add(content, 0, 0);

            table.Controls.Add(emptyContainer, 0, 1);
            table.SetColumnSpan(emptyContainer, table.ColumnCount);
        }

        private Label _CreateHeaderLabel(string text)
        {
            return new Label
            {
                Text = text,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(37, 99, 235),
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
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(17, 24, 39),
                BackColor = Color.White,
                Margin = new Padding(0),
                AutoEllipsis = true
            };
        }

        private Label _CreateAmountLabel(decimal amount)
        {
            return new Label
            {
                Text = $"{amount:0.00}",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = amount < 0
                    ? Color.FromArgb(220, 38, 38)
                    : Color.FromArgb(22, 163, 74),
                BackColor = Color.White,
                Margin = new Padding(0)
            };
        }

        private Guna2Button _CreateTypeBadge(string type)
        {
            Color fillColor;

            switch (type)
            {
                case "Initial":
                    fillColor = Color.FromArgb(37, 99, 235);
                    break;

                case "Return":
                    fillColor = Color.FromArgb(124, 58, 237);
                    break;

                case "Extension":
                    fillColor = Color.FromArgb(234, 88, 12);
                    break;

                default:
                    fillColor = Color.Gray;
                    break;
            }

            return new Guna2Button
            {
                Text = type,
                Size = new Size(110, 28),
                BorderRadius = 8,
                FillColor = fillColor,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                Enabled = false,
                DisabledState =
                {
                    FillColor = fillColor,
                    ForeColor = Color.White
                },
                Anchor = AnchorStyles.None,
                Margin = new Padding(0)
            };
        }


        private void _InitButtonIcons()
        {
            btnTotalPaid.Image = Utility.GetFontAwesomeImage(IconChar.Wallet, Color.White, 22);
            btnTotalRefunds.Image = Utility.GetFontAwesomeImage(IconChar.RotateLeft, Color.White, 22);
            btnNetPaid.Image = Utility.GetFontAwesomeImage(IconChar.Receipt, Color.White, 22);
            btnTotalPayments.Image = Utility.GetFontAwesomeImage(IconChar.MoneyBillWave, Color.White, 22);
        }
    }
}
