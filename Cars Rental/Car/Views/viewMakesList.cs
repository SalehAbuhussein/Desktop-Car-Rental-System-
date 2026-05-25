using BusinessLayer;
using Cars_Rental.Car.Forms.Makes;
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
    public partial class viewMakesList : UserControl
    {
        public Form Dashboard { get; set; }

        public viewMakesList()
        {
            InitializeComponent();
        }

        private void viewMakesList_Load(object sender, EventArgs e)
        {
            LoadMakesList();
        }

        public void LoadMakesList()
        {
            table.Controls.Clear();

            _InitMakesTable();

            DataTable makes = clsMake.FindMakes();

            foreach (DataRow row in makes.Rows)
            {
                int makeID = (int)row["MakeID"];
                string makeName = row["Make"].ToString();

                _AddMakeRow(makeID, makeName);
            }
        }

        private void _InitMakesTable()
        {
            _SetupMakesTable();
            _AddMakesHeader();
        }

        private void _SetupMakesTable()
        {
            table.Controls.Clear();
            table.ColumnStyles.Clear();
            table.RowStyles.Clear();

            table.ColumnCount = 3;
            table.RowCount = 0;

            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15)); // #
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55)); // Make Name
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30)); // Actions
        }

        private void _AddMakesHeader()
        {
            table.RowCount++;
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));

            table.Controls.Add(_CreateHeaderLabel("#"), 0, 0);
            table.Controls.Add(_CreateHeaderLabel("Make Name"), 1, 0);
            table.Controls.Add(_CreateHeaderLabel("Actions"), 2, 0);
        }

        private void _AddMakeRow(int makeID, string makeName)
        {
            int rowIndex = table.RowCount;

            table.RowCount++;
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));

            Guna2Button btnID = _CreateBadge($"#{makeID}", Color.FromArgb(84, 131, 255));
            Label lblMakeName = _CreateCellLabel(makeName);
            Panel actions = _CreateMakeActionsPanel(makeID);

            table.Controls.Add(btnID, 0, rowIndex);
            table.Controls.Add(lblMakeName, 1, rowIndex);
            table.Controls.Add(actions, 2, rowIndex);
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

        private Panel _CreateMakeActionsPanel(int makeID)
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
                Tag = makeID
            };

            Guna2Button btnDelete = new Guna2Button
            {
                Text = "Delete",
                Size = new Size(80, 32),
                BorderRadius = 6,
                FillColor = Color.FromArgb(239, 68, 68),
                ForeColor = Color.White,
                Location = new Point(90, 19),
                Animated = true,
                Tag = makeID
            };

            btnEdit.Click += btnEditMake_Click;
            btnDelete.Click += btnDeleteMake_Click;

            panel.Controls.Add(btnEdit);
            panel.Controls.Add(btnDelete);

            return panel;
        }

        private void btnEditMake_Click(object sender, EventArgs e)
        {
            int makeID = (int)((Guna2Button)sender).Tag;

            Dashboard.Hide();
            frmAddEditMake frm = new frmAddEditMake(makeID);
            frm.ShowDialog();
            Dashboard.Show();
            viewMakesList_Load(null, null);
        }

        private void btnDeleteMake_Click(object sender, EventArgs e)
        {
            int makeID = (int)((Guna2Button)sender).Tag;

            if (MessageBox.Show("Are you sure you want to delete this Make?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsMake.DeleteMake(makeID))
                {
                    MessageBox.Show($"Make with id of {makeID} Deleted Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    viewMakesList_Load(null, null);
                } else
                {
                    MessageBox.Show($"Something went wrong with make delete operation!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
