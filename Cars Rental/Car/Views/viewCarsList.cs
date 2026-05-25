using BusinessLayer;
using Cars_Rental.Car.Forms;
using Cars_Rental.Global_Classes;
using FontAwesome.Sharp;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cars_Rental.Car.Views
{
    public partial class viewCarsList : UserControl
    {
        public Form Dashboard { get; set; }

        public viewCarsList()
        {
            InitializeComponent();
        }

        private void viewCarsList_Load(object sender, EventArgs e)
        {
            LoadCarsList();
        }

        public void LoadCarsList()
        {
            table.Controls.Clear();

            _InitVehiclesTable();

            DataTable cars = clsCar.FindCars();

            foreach (DataRow row in cars.Rows)
            {
                int carID = (int)row["CarID"];

                _AddCarRow(carID);
            }
        }

        private void _InitVehiclesTable()
        {
            _SetupVehiclesTable();
            _AddVehiclesHeader();
        }

        private void _AddCarRow(int carID)
        {
            clsCar car = clsCar.Find(carID);

            if (car == null)
            {
                guna2MessageDialog1.Icon = MessageDialogIcon.Error;
                guna2MessageDialog1.Show("Invalid car data!", "Error");
                return;
            }

            int rowIndex = table.RowCount;

            table.RowCount++;
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 96F));

            // ID badge
            var btnID = _CreateBadge($"#{carID}", Color.FromArgb(84, 131, 255));

            // Vehicle image
            var picture = _CreateVehiclePicture(car.CarImage);

            // Make & model
            var pnlVehicleInfo = _CreateVehicleInfoPanel(car.ModelInfo.MakeInfo.MakeName, car.ModelInfo.ModelName);

            // Plate number
            var lblPlateNumber = _CreateCellLabel(car.PlateNumber);

            // Status
            //var statusBadge = _CreateStatusBadge(vehicle.Status);

            // Actions
            var actions = _CreateVehicleActionsPanel(carID);

            table.Controls.Add(btnID, 0, rowIndex);
            table.Controls.Add(picture, 1, rowIndex);
            table.Controls.Add(pnlVehicleInfo, 2, rowIndex);
            table.Controls.Add(lblPlateNumber, 3, rowIndex);
            //table.Controls.Add(statusBadge, 4, rowIndex);
            table.Controls.Add(actions, 4, rowIndex);
        }

        private void _SetupVehiclesTable()
        {
            table.Controls.Clear();
            table.ColumnStyles.Clear();
            table.RowStyles.Clear();

            table.ColumnCount = 5;
            table.RowCount = 0;

            // Percentage layout (more flexible)
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10)); // #
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20)); // Image
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30)); // Make & Model
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20)); // Plate
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20)); // Actions
        }

        private Panel _CreateVehicleInfoPanel(string make, string model)
        {
            var panel = new Panel
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(6, 0, 6, 0)
            };

            var lblTitle = new Label
            {
                Text = $"{make} {model}",
                AutoSize = false,
                Dock = DockStyle.Fill,
                Location = new Point(0, 18),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(17, 24, 39),
                TextAlign = ContentAlignment.MiddleLeft,
                Margin = new Padding(0)
            };

            panel.Controls.Add(lblTitle);

            return panel;
        }

        private void _AddVehiclesHeader()
        {
            table.RowCount++;
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));

            table.Controls.Add(_CreateHeaderLabel("#"), 0, 0);
            table.Controls.Add(_CreateHeaderLabel("Image"), 1, 0);
            table.Controls.Add(_CreateHeaderLabel("Make & Model"), 2, 0);
            table.Controls.Add(_CreateHeaderLabel("Plate Number"), 3, 0);
            //table.Controls.Add(_CreateHeaderLabel("Status"), 4, 0);
            table.Controls.Add(_CreateHeaderLabel("Actions"), 4, 0);
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
                Margin = padding ?? new Padding(6, 0, 6, 0),
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

        private Control _CreateVehiclePicture(string imagePath)
        {
            Panel wrapper = new Panel
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(6),
                BackColor = Color.Transparent
            };

            Guna2Panel container = new Guna2Panel
            {
                Size = new Size(120, 80),
                BorderRadius = 12,
                FillColor = Color.FromArgb(243, 244, 246),
                Location = new Point(0, 4)
            };

            Guna2PictureBox picture = new Guna2PictureBox
            {
                Dock = DockStyle.Fill,
                BorderRadius = 12,
                BackColor = Color.Transparent
            };

            if (!string.IsNullOrWhiteSpace(imagePath) && File.Exists(imagePath))
            {
                picture.Image = Utility.LoadImage(imagePath);
                picture.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                picture.Image = Utility.GetFontAwesomeImage(
                    IconChar.CarSide,
                    Color.FromArgb(156, 163, 175),
                    26
                );
                picture.SizeMode = PictureBoxSizeMode.CenterImage;
            }

            container.Controls.Add(picture);
            wrapper.Controls.Add(container);

            return wrapper;
        }

        private Panel _CreateVehicleActionsPanel(int vehicleId)
        {
            var panel = new Panel
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(10, 0, 0, 0)
            };

            var btnEdit = new Guna2Button
            {
                Text = "Edit",
                Size = new Size(80, 32),
                BorderRadius = 6,
                FillColor = Color.FromArgb(84, 131, 255),
                ForeColor = Color.White,
                Location = new Point(0, 26),
                Animated = true,
                Tag = vehicleId
            };

            var btnDelete = new Guna2Button
            {
                Text = "Delete",
                Size = new Size(80, 32),
                BorderRadius = 6,
                FillColor = Color.FromArgb(239, 68, 68),
                ForeColor = Color.White,
                Location = new Point(90, 26),
                Animated = true,
                Tag = vehicleId
            };

            btnEdit.Click += btnEditVehicle_Click;
            btnDelete.Click += btnDeleteVehicle_Click;

            panel.Controls.Add(btnEdit);
            panel.Controls.Add(btnDelete);

            return panel;
        }

        private void btnEditVehicle_Click(object sender, EventArgs e)
        {
            int carID = (int)((Guna2Button)sender).Tag;

            Dashboard.Hide();
            frmAddUpdateCar frm = new frmAddUpdateCar(carID);
            frm.ShowDialog();
            Dashboard.Show();
            viewCarsList_Load(null, null);
        }

        private void btnDeleteVehicle_Click(object sender, EventArgs e)
        {
            int carID = (int)((Guna2Button)sender).Tag;

            guna2MessageDialog1.Parent = Dashboard;
            guna2MessageDialog1.Icon = MessageDialogIcon.Question;
            guna2MessageDialog1.Buttons = MessageDialogButtons.OKCancel;

            if (guna2MessageDialog1.Show("Are you sure you want to delete this Car?", "Confirmation") == DialogResult.Yes)
            {
                if (clsCar.DeleteCar(carID))
                {
                    guna2MessageDialog1.Icon = MessageDialogIcon.Information;
                    guna2MessageDialog1.Buttons = MessageDialogButtons.OK;
                    guna2MessageDialog1.Show("User Deleted Successfully!", "Success");
                    LoadCarsList();
                }
                else
                {
                    guna2MessageDialog1.Icon = MessageDialogIcon.Error;
                    guna2MessageDialog1.Show("Delete operation went wrong!", "Error");
                }
            }
        }

        private Guna2Button _CreateStatusBadge(string status)
        {
            Color fillColor = Color.Gray;

            switch (status.Trim().ToLower())
            {
                case "available":
                    fillColor = Color.FromArgb(34, 197, 94);
                    break;

                case "rented":
                    fillColor = Color.FromArgb(245, 158, 11);
                    break;

                case "maintenance":
                    fillColor = Color.FromArgb(239, 68, 68);
                    break;
            }

            return new Guna2Button
            {
                Text = status,
                Size = new Size(120, 34),
                BorderRadius = 10,
                FillColor = fillColor,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Enabled = false,
                DisabledState =
                {
                    FillColor = fillColor,
                    ForeColor = Color.White
                },
                Anchor = AnchorStyles.Left,
                Margin = new Padding(6, 0, 6, 0)
            };
        }
    }
}
