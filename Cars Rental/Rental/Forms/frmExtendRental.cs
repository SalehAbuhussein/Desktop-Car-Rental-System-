using BusinessLayer;
using Cars_Rental.Global_Classes;
using FontAwesome.Sharp;
using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cars_Rental.Rental.Forms
{
    public partial class frmExtendRental : Form
    {
        public clsCarRental CarRentalInfo { get; set; }
        private int? _CarRentalID = null;

        public frmExtendRental(int? carRentalID)
        {
            InitializeComponent();

            _CarRentalID = carRentalID;
        }

        private void frmExtendRental_Load(object sender, EventArgs e)
        {
            _InitIcons();
            _LoadRentalInfo();
        }

        private void _InitIcons()
        {
            btnCancel.Image = Utility.GetFontAwesomeImage(IconChar.Xmark, Color.White);
            btnSave.Image = Utility.GetFontAwesomeImage(IconChar.Check, Color.White);
        }

        private void _LoadRentalInfo()
        {
            CarRentalInfo = clsCarRental.Find(_CarRentalID);

            if (CarRentalInfo == null)
            {
                return;
            }

            int totalRentDays = Math.Abs((CarRentalInfo.PickupDate - CarRentalInfo.ReturnDate).Days);

            lblCarName.Text = CarRentalInfo.CarInfo.CarName;
            lblTransmission.Text = CarRentalInfo.CarInfo.TransmissionInfo.TransmissionName;
            lblFuelType.Text = CarRentalInfo.CarInfo.FuelTypeInfo.FuelTypeName;
            lblCurrentReturnDate.Text = CarRentalInfo.ReturnDate.ToString();
            lblPickupDate.Text = CarRentalInfo.PickupDate.ToString();
            lblPickupLocation.Text = CarRentalInfo.PickupLocation;
            lblPricePerDay.Text = CarRentalInfo.CarInfo.PricePerDay.ToString();
            lblRentalDuration.Text = totalRentDays.ToString() + " Days";

            dtpReturnDate.MinDate = CarRentalInfo.ReturnDate;
            dtpReturnDate.Value = CarRentalInfo.ReturnDate;

            if (File.Exists(CarRentalInfo.CarInfo.CarImage))
            {
                pnlDefaultImg.Visible = false;
                pbCar.Image = Utility.LoadImage(CarRentalInfo.CarInfo.CarImage);
            }
            else
            {
                pnlDefaultImg.Visible = true;
                pbCar.Visible = false;
            }
        }

        private void dtpReturnDate_ValueChanged(object sender, EventArgs e)
        {
            int totalExtendDays = Math.Abs((CarRentalInfo.ReturnDate - dtpReturnDate.Value).Days);
            decimal additionalAmount = totalExtendDays * CarRentalInfo.CarInfo.PricePerDay;
            decimal newTotalAmount = additionalAmount + CarRentalInfo.TotalPrice;

            lblExtendedDays.Text = $"{totalExtendDays} Days";
            lblAdditionalAmount.Text = $"{additionalAmount}";

            if (totalExtendDays > 0)
            {
                lblNewTotalAmount.Text = $"{newTotalAmount}";
            } else
            {
                lblNewTotalAmount.Text = "0";
            }

        }

        private void dtpReturnDate_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Validators.ValidateControl(
                dtpReturnDate,
                errorProvider1,
                (dtp) => dtp.Value <= CarRentalInfo.ReturnDate,
                "New return date must be after the current return date."
            );
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int totalExtendDays = Math.Abs((CarRentalInfo.ReturnDate - dtpReturnDate.Value).Days);

            if (!ValidateChildren() || totalExtendDays <= 0)
            {
                return;
            }

            if (CarRentalInfo.ExtendRental(dtpReturnDate.Value))
            {
                guna2MessageDialog1.Icon = MessageDialogIcon.Information;
                guna2MessageDialog1.Show("Rental has been Extended Successfully!", "Success");
                Close();
            } else
            {
                guna2MessageDialog1.Icon = MessageDialogIcon.Error;
                guna2MessageDialog1.Show("Something went wrong", "Error");
            }
        }
    }
}
