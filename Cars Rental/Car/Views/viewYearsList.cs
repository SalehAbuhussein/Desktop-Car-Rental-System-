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

namespace Cars_Rental.Car.Views
{
    public partial class viewYearsList : UserControl
    {
        public Form Dashboard { get; set; }

        public viewYearsList()
        {
            InitializeComponent();
        }

        private void viewYears_Load(object sender, EventArgs e)
        {
            LoadYearsList();
        }

        public void LoadYearsList()
        {
            table.Controls.Clear();

            _InitYearsTable();

            DataTable years = clsYear.FindYears();

            foreach (DataRow row in years.Rows)
            {
                int yearID = (int)row["YearID"];
                string yearName = row["Year"].ToString();

                _AddYearRow(yearID, yearName);
            }
        }

        private void _InitYearsTable()
        {
            _SetupYearsTable();
            _AddYearsHeader();
        }

        private void _SetupYearsTable()
        {
            table.Controls.Clear();
            table.ColumnStyles.Clear();
            table.RowStyles.Clear();

            table.ColumnCount = 3;
            table.RowCount = 0;

            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15)); // #
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55)); // Year
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30)); // Actions
        }

        private void _AddYearsHeader()
        {
            table.RowCount++;
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));

            table.Controls.Add(_CreateHeaderLabel("#"), 0, 0);
            table.Controls.Add(_CreateHeaderLabel("Year"), 1, 0);
            table.Controls.Add(_CreateHeaderLabel("Actions"), 2, 0);
        }

        private void _AddYearRow(int yearID, string yearName)
        {
            int rowIndex = table.RowCount;

            table.RowCount++;
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));

            table.Controls.Add(_CreateBadge($"#{yearID}", Color.FromArgb(84, 131, 255)), 0, rowIndex);
            table.Controls.Add(_CreateCellLabel(yearName), 1, rowIndex);
            table.Controls.Add(_CreateYearActionsPanel(yearID), 2, rowIndex);
        }

        private Panel _CreateYearActionsPanel(int yearID)
        {
            Panel panel = new Panel
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(10, 0, 0, 0)
            };

            Guna2Button btnEdit = new Guna2Button
            {
                Text = "Edit",
                Size = new Size(80, 32),
                BorderRadius = 6,
                FillColor = Color.FromArgb(84, 131, 255),
                ForeColor = Color.White,
                Location = new Point(0, 19),
                Animated = true,
                Tag = yearID
            };

            btnEdit.Click += btnEditYear_Click;

            panel.Controls.Add(btnEdit);

            return panel;
        }

        private void btnEditYear_Click(object sender, EventArgs e)
        {
            int yearID = (int)((Guna2Button)sender).Tag;

            // TODO: open frmAddEditYear(yearID)
            MessageBox.Show($"Edit Year #{yearID}");
        }

        private Label _CreateHeaderLabel(string text)
        {
            return new Label
            {
                Text = text,
                AutoSize = false,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(107, 114, 128),
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
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(17, 24, 39),
                Margin = new Padding(6, 0, 6, 0)
            };
        }

        private Guna2Button _CreateBadge(string text, Color color)
        {
            return new Guna2Button
            {
                Text = text,
                Size = new Size(70, 32),
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
    }
}
