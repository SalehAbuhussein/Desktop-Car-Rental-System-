using BusinessLayer;
using Cars_Rental.Car.Forms.Models;
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
    public partial class viewModelsList : UserControl
    {
        public Form Dashboard { get; set; }

        public viewModelsList()
        {
            InitializeComponent();
        }

        private void viewModelsList_Load(object sender, EventArgs e)
        {
            LoadModelsList();
        }

        public void LoadModelsList()
        {
            table.Controls.Clear();

            _InitModelsTable();

            DataTable models = clsModel.FindModels();

            foreach (DataRow row in models.Rows)
            {
                int modelID = (int)row["ModelID"];
                string modelName = row["Model"].ToString();
                string makeName = row["Make"].ToString();

                _AddModelRow(modelID, modelName, makeName);
            }
        }

        private void _InitModelsTable()
        {
            _SetupModelsTable();
            _AddModelsHeader();
        }

        private void _SetupModelsTable()
        {
            table.Controls.Clear();
            table.ColumnStyles.Clear();
            table.RowStyles.Clear();

            table.ColumnCount = 4;
            table.RowCount = 0;

            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15)); // #
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35)); // Model
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25)); // Make
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25)); // Actions
        }

        private void _AddModelsHeader()
        {
            table.RowCount++;
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));

            table.Controls.Add(_CreateHeaderLabel("#"), 0, 0);
            table.Controls.Add(_CreateHeaderLabel("Model Name"), 1, 0);
            table.Controls.Add(_CreateHeaderLabel("Make"), 2, 0);
            table.Controls.Add(_CreateHeaderLabel("Actions"), 3, 0);
        }

        private void _AddModelRow(int modelID, string modelName, string makeName)
        {
            int rowIndex = table.RowCount;

            table.RowCount++;
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));

            Guna2Button btnID = _CreateBadge($"#{modelID}", Color.FromArgb(84, 131, 255));
            Label lblModel = _CreateCellLabel(modelName);
            Label lblMake = _CreateCellLabel(makeName);
            Panel actions = _CreateModelActionsPanel(modelID);

            table.Controls.Add(btnID, 0, rowIndex);
            table.Controls.Add(lblModel, 1, rowIndex);
            table.Controls.Add(lblMake, 2, rowIndex);
            table.Controls.Add(actions, 3, rowIndex);
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

        private Panel _CreateModelActionsPanel(int modelID)
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
                Tag = modelID
            };

            btnEdit.Click += btnEditModel_Click;

            panel.Controls.Add(btnEdit);

            return panel;
        }

        private void btnEditModel_Click(object sender, EventArgs e)
        {
            int modelID = (int)((Guna2Button)sender).Tag;

            Dashboard.Hide();
            frmAddUpdateModel frm = new frmAddUpdateModel(modelID);
            frm.ShowDialog();
            Dashboard.Show();

            LoadModelsList();
        }
    }
}
