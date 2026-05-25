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
    public partial class viewFuelTypesList : UserControl
    {
        public Form Dashboard { get; set; }

        public viewFuelTypesList()
        {
            InitializeComponent();
        }

        private void viewFuelTypesList_Load(object sender, EventArgs e)
        {
            LoadFuelTypesList();
        }

        public void LoadFuelTypesList()
        {
            table.Controls.Clear();

            _InitTable();

            DataTable fuelTypes = clsFuelType.FindFuelTypes();

            foreach (DataRow row in fuelTypes.Rows)
            {
                int fuelTypeID = Convert.ToInt32(row["FuelTypeID"]);
                string fuelTypeName = row["FuelType"].ToString();

                _AddFuelTypeRow(fuelTypeID, fuelTypeName);
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

            table.ColumnCount = 3;
            table.RowCount = 0;

            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
        }

        private void _AddHeader()
        {
            table.RowCount++;
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));

            table.Controls.Add(_CreateHeaderLabel("#"), 0, 0);
            table.Controls.Add(_CreateHeaderLabel("Fuel Type"), 1, 0);
            table.Controls.Add(_CreateHeaderLabel("Actions"), 2, 0);
        }

        private void _AddFuelTypeRow(int fuelTypeID, string fuelTypeName)
        {
            int rowIndex = table.RowCount;

            table.RowCount++;
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));

            table.Controls.Add(_CreateBadge($"#{fuelTypeID}", Color.FromArgb(84, 131, 255)), 0, rowIndex);
            table.Controls.Add(_CreateCellLabel(fuelTypeName), 1, rowIndex);
            table.Controls.Add(_CreateActionsPanel(fuelTypeID), 2, rowIndex);
        }

        private Panel _CreateActionsPanel(int fuelTypeID)
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
                Tag = fuelTypeID
            };

            btnEdit.Click += btnEditFuelType_Click;

            panel.Controls.Add(btnEdit);

            return panel;
        }

        private void btnEditFuelType_Click(object sender, EventArgs e)
        {
            int fuelTypeID = Convert.ToInt32(((Guna2Button)sender).Tag);

            MessageBox.Show($"Edit Fuel Type #{fuelTypeID}");
        }

        private Label _CreateHeaderLabel(string text)
        {
            return new Label
            {
                Text = text,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(107, 114, 128),
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
