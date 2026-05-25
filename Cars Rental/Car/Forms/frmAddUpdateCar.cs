using BusinessLayer;
using Cars_Rental.Global_Classes;
using FontAwesome.Sharp;
using Guna.UI2.WinForms;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cars_Rental.Car.Forms
{
    public partial class frmAddUpdateCar : Form
    {
        public enum enMode
        {
            Add,
            Update
        }
        private int? _CarID;
        public clsCar CarInfo;
        private enMode _Mode = enMode.Add;

        public frmAddUpdateCar()
        {
            InitializeComponent();
        }

        public frmAddUpdateCar(int? carID)
        {
            InitializeComponent();

            if (carID == null)
            {
                return;
            }

            _CarID = carID;
            _Mode = enMode.Update;
        }

        private void frmAddUpdateCar_Load(object sender, EventArgs e)
        {
            InitInputs();
            _InitIcons();

            if (_Mode == enMode.Update)
            {
                _InitCarInfo();
            }
        }

        public void InitInputs()
        {
            _InitMakes();
            _InitModels();
            _InitYears();
            _InitFuelTypes();
            _InitTransmissions();
        }

        private void _InitMakes()
        {
            DataTable makes = clsMake.FindMakes();

            cbMake.Items.Clear();

            foreach (DataRow row in makes.Rows)
            {
                cbMake.Items.Add(row["Make"].ToString());
            }
        }

        private void _InitModels()
        {
            cbModel.Enabled = false;
            cbModel.Items.Clear();
        }

        private void _InitYears()
        {
            DataTable years = clsYear.FindYears(1, 50);

            cbYear.Items.Clear();

            foreach (DataRow row in years.Rows)
            {
                cbYear.Items.Add(row["Year"].ToString());
            }
        }

        private void _InitFuelTypes()
        {
            DataTable fuelTypes = clsFuelType.FindFuelTypes();

            cbFuelType.Items.Clear();

            foreach (DataRow row in fuelTypes.Rows)
            {
                cbFuelType.Items.Add(row["FuelType"].ToString());
            }
        }

        private void _InitTransmissions()
        {
            DataTable transmissions = clsTransmission.FindTransmissions();

            foreach (DataRow row in transmissions.Rows)
            {
                cbTransmission.Items.Add(row["Transmission"].ToString());
            }
        }

        private void _InitIcons()
        {
            btnUploadImage.Image = Utility.GetFontAwesomeImage(IconChar.Upload, Color.White);
            btnRemoveImage.Image = Utility.GetFontAwesomeImage(IconChar.TrashAlt, Color.FromArgb(143, 150, 171));
            btnSave.Image = Utility.GetFontAwesomeImage(IconChar.Check, Color.White);
            btnCancel.Image = Utility.GetFontAwesomeImage(IconChar.Xmark, Color.White);
        }

        private void _InitCarInfo()
        {
            CarInfo = clsCar.Find(_CarID);

            if (CarInfo == null)
            {
                return;
            }

            tbCarName.Text = CarInfo.CarName;
            tbPlateNumber.Text = CarInfo.PlateNumber;
            tbVin.Text = CarInfo.Vin;
            tbMileage.Text = CarInfo.Mileage.ToString();
            tbPricePerDay.Text = CarInfo.PricePerDay.ToString();

            clsModel model = clsModel.Find(CarInfo.ModelID);
            clsMake make = CarInfo.ModelInfo.MakeInfo;
            clsFuelType fuelType = CarInfo.FuelTypeInfo;
            clsTransmission transmission = CarInfo.TransmissionInfo;
            clsYear year = CarInfo.YearInfo;

            cbMake.SelectedIndex = cbMake.FindString(make.MakeName);
            cbModel.SelectedIndex = cbModel.FindString(model.ModelName);
            cbYear.SelectedIndex = cbYear.FindString(year.Year.ToString());
            cbFuelType.SelectedIndex = cbFuelType.FindString(fuelType.FuelTypeName);
            cbTransmission.SelectedIndex = cbTransmission.FindString(transmission.TransmissionName);

            if (File.Exists(CarInfo.CarImage))
            {
                pnlEmptyState.Visible = false;
                pbImage.Image = Utility.LoadImage(CarInfo.CarImage);
            }

            cbModel.Enabled = true;
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            string img = Utility.OpenImageFile(openFileDialog1);

            if (!string.IsNullOrEmpty(img))
            {
                pnlEmptyState.Visible = false;
                
                if (pbImage.Image != null)
                {
                    pbImage.Image.Dispose();
                    pbImage.Image = null;
                }
                
                pbImage.Image = Utility.LoadImage(img);
            }
        }

        private void btnRemoveImage_Click(object sender, EventArgs e)
        {
            if (pbImage.Image != null)
            {
                pbImage.Image.Dispose();
                pbImage.Image = null;
                pnlEmptyState.Visible = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbMake_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedMake = cbMake.SelectedItem?.ToString();

            DataTable models = clsModel.FindModelsByMake(selectedMake);

            cbModel.Items.Clear();

            foreach (DataRow row in models.Rows)
            {
                cbModel.Items.Add(row["Model"]);
            }

            cbModel.Enabled = true;
        }

        private void tbCarName_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Validators.ValidateControl(
                (Guna2TextBox)sender,
                errorProvider1,
                (tb) => string.IsNullOrEmpty(tb.Text.Trim()),
                "Name can not be empty!"
            );
        }

        private void tbPricePerDay_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Validators.ValidateControl(
                (Guna2TextBox)sender,
                errorProvider1,
                (tb) => string.IsNullOrEmpty(tb.Text.Trim()),
                "Price can not be empty!"
            );
        }

        private void tbPricePerDay_KeyPress(object sender, KeyPressEventArgs e)
        {
            Guna2TextBox tb = (Guna2TextBox)sender;

            if (char.IsControl(e.KeyChar))
                return;

            if (char.IsDigit(e.KeyChar))
                return;

            // Allow ONE decimal point
            if (e.KeyChar == '.' && !tb.Text.Contains("."))
                return;

            // Block everything else
            e.Handled = true;
        }

        private void tbVin_Validating(object sender, CancelEventArgs e)
        {
            if (_Mode == enMode.Add)
            {
                e.Cancel = Validators.ValidateControl(
                    (Guna2TextBox)sender,
                    errorProvider1,
                    (tb) => clsCar.IsCarExistByVin(tb.Text.Trim()),
                    "Existing Car with Same Vin number exist!"
                ) || Validators.ValidateControl(
                    (Guna2TextBox)sender,
                    errorProvider1,
                    (tb) => string.IsNullOrEmpty(tb.Text.Trim()),
                    "Vin Number can not be empty!"
                );
            } else
            {
                string vinNumber = CarInfo.Vin;
                string newVinNumber = tbVin.Text.Trim();

                if (vinNumber != newVinNumber)
                {
                    e.Cancel = Validators.ValidateControl(
                        (Guna2TextBox)sender,
                        errorProvider1,
                        (tb) => clsCar.IsCarExistByVin(tb.Text.Trim()),
                        "Existing Car with Same Vin number exist!"
                    ) || Validators.ValidateControl(
                        (Guna2TextBox)sender,
                        errorProvider1,
                        (tb) => string.IsNullOrEmpty(tb.Text.Trim()),
                        "Vin Number can not be empty!"
                    );
                }
                else
                {
                    e.Cancel = Validators.ValidateControl(
                        (Guna2TextBox)sender,
                        errorProvider1,
                        (tb) => string.IsNullOrEmpty(tb.Text.Trim()),
                        "Vin Number can not be empty!"
                    );
                }
            }
        }

        private void tbMileage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Validators.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbMileage_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Validators.ValidateControl(
                (Guna2TextBox)sender,
                errorProvider1,
                (tb) => string.IsNullOrEmpty(tb.Text.Trim()),
                "Mileage can not be empty!"
            );
        }

        private void tbPlateNumber_Validating(object sender, CancelEventArgs e)
        {
            if (_Mode == enMode.Add)
            {
                e.Cancel = Validators.ValidateControl(
                    (Guna2TextBox)sender,
                    errorProvider1,
                    (tb) => clsCar.IsCarExistByPlateNumber(tb.Text.Trim()),
                    "Existing Car with Same Plate number exist!"
                ) || Validators.ValidateControl(
                    (Guna2TextBox)sender,
                    errorProvider1,
                    (tb) => string.IsNullOrEmpty(tb.Text.Trim()),
                    "Plate number can not be empty!"
                );
            } else
            {
                string plateNumber = CarInfo.PlateNumber;
                string newPlateNumber = tbPlateNumber.Text.Trim();

                if (plateNumber != newPlateNumber)
                {
                    e.Cancel = Validators.ValidateControl(
                        (Guna2TextBox)sender,
                        errorProvider1,
                        (tb) => clsCar.IsCarExistByPlateNumber(tb.Text.Trim()),
                        "Existing Car with Same Plate number exist!"
                    ) || Validators.ValidateControl(
                        (Guna2TextBox)sender,
                        errorProvider1,
                        (tb) => string.IsNullOrEmpty(tb.Text.Trim()),
                        "Plate number can not be empty!"
                    );
                } else
                {
                    e.Cancel = Validators.ValidateControl(
                        (Guna2TextBox)sender,
                        errorProvider1,
                        (tb) => string.IsNullOrEmpty(tb.Text.Trim()),
                        "Plate number can not be empty!"
                    );
                }
            }
        }

        private void cbMake_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Validators.ValidateControl(
                (Guna2ComboBox)sender,
                errorProvider1,
                (tb) => string.IsNullOrEmpty(tb.Text.Trim()),
                "Make can not be empty!"
            );
        }

        private void cbModel_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Validators.ValidateControl(
                (Guna2ComboBox)sender,
                errorProvider1,
                (tb) => string.IsNullOrEmpty(tb.Text.Trim()),
                "Model can not be empty!"
            );
        }

        private void cbFuelType_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Validators.ValidateControl(
                (Guna2ComboBox)sender,
                errorProvider1,
                (tb) => string.IsNullOrEmpty(tb.Text.Trim()),
                "Fuel type can not be empty!"
            );
        }

        private void cbTransmission_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Validators.ValidateControl(
                (Guna2ComboBox)sender,
                errorProvider1,
                (tb) => string.IsNullOrEmpty(tb.Text.Trim()),
                "Transmission can not be empty!"
            );
        }

        private void cbYear_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Validators.ValidateControl(
                (Guna2ComboBox)sender,
                errorProvider1,
                (tb) => string.IsNullOrEmpty(tb.Text.Trim()),
                "Year can not be empty!"
            );
        }

        private void _HandleImageSave()
        {
            if (_Mode == enMode.Add)
            {
                if (!string.IsNullOrEmpty(openFileDialog1.FileName))
                {
                    string newImgPath = string.Empty;

                    if (Utility.StoreCarImage(openFileDialog1.FileName, ref newImgPath))
                    {
                        CarInfo.CarImage = openFileDialog1.FileName;
                    }
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(openFileDialog1.FileName))
                {
                    string newImgPath = string.Empty;

                    // Delete old Image
                    if (!string.IsNullOrEmpty(CarInfo.CarImage))
                    {
                        pbImage.Image.Dispose();
                        pbImage.Image = null;

                        if (File.Exists(CarInfo.CarImage))
                        {
                            File.Delete(CarInfo.CarImage);
                        }
                    }

                    // Add New Image
                    if (Utility.StoreCarImage(openFileDialog1.FileName, ref newImgPath))
                    {
                        pbImage.Image = Utility.LoadImage(newImgPath);
                        CarInfo.CarImage = newImgPath;
                    }
                }
                else
                {
                    if (File.Exists(CarInfo.CarImage))
                    {
                        File.Delete(CarInfo.CarImage);
                    }

                    CarInfo.CarImage = string.Empty;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                return;
            }

            _HandleImageSave();

            if (_Mode == enMode.Add)
            {
                CarInfo = new clsCar();
                CarInfo.CreatedByUserID = CurrentUser.UserInfo.UserID;
            }

            CarInfo.CarName = tbCarName.Text.Trim();
            CarInfo.Vin = tbVin.Text.Trim();
            CarInfo.PlateNumber = tbPlateNumber.Text.Trim();
            CarInfo.Mileage = Convert.ToInt32(tbMileage.Text.Trim());
            CarInfo.PricePerDay = Convert.ToDecimal(tbPricePerDay.Text.Trim());

            CarInfo.ModelID = clsModel.FindByName(cbModel.SelectedItem?.ToString()).ModelID;
            CarInfo.YearID = clsYear.FindByYear(Convert.ToInt32(cbYear.SelectedItem.ToString())).YearID;
            CarInfo.FuelTypeID = clsFuelType.FindByName(cbFuelType.SelectedItem?.ToString()).FuelTypeID;
            CarInfo.TransmissionInfo = clsTransmission.FindByName(cbTransmission.SelectedItem?.ToString());
            CarInfo.TransmissionID = CarInfo.TransmissionInfo.TransmissionID;

            string status = _Mode == enMode.Add ? "Added" : "Updated";

            if (CarInfo.Save())
            {
                popup.Icon = MessageDialogIcon.Information;
                popup.Show($"Car {status} Successfully!", "Success");
                Close();
            } else
            {
                popup.Icon = MessageDialogIcon.Error;
                popup.Show("Something went wrong", "Error");
            }
        }
    }
}
