using BusinessLayer;
using Cars_Rental.Global_Classes;
using FontAwesome.Sharp;
using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Cars_Rental.Rental.Forms
{
    public partial class frmReturnRental : Form
    {
        public clsCarRental CarRentalInfo { get; set; }
        private int? _CarRentalID;

        public frmReturnRental(int? carRentalID)
        {
            InitializeComponent();

            dtpReturnDate.MinDate = DateTime.Today.AddDays(1);
            _CarRentalID = carRentalID;
        }

        private void frmReturnRental_Load(object sender, EventArgs e)
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

            int totalRentDays = (CarRentalInfo.ReturnDate - CarRentalInfo.PickupDate).Days;
            decimal paidAmount = CarRentalInfo.GetPaidAmount();
            decimal remainingAmount = CarRentalInfo.TotalPrice - paidAmount;
            DateTime actualReturnDate = dtpReturnDate.Value;

            lblCarName.Text = CarRentalInfo.CarInfo.CarName;
            lblTransmission.Text = CarRentalInfo.CarInfo.TransmissionInfo.TransmissionName;
            lblFuelType.Text = CarRentalInfo.CarInfo.FuelTypeInfo.FuelTypeName;
            lblPickupDate.Text = CarRentalInfo.PickupDate.ToString();
            lblPickupLocation.Text = CarRentalInfo.PickupLocation;
            lblPricePerDay.Text = CarRentalInfo.CarInfo.PricePerDay.ToString();
            lblTotalPrice.Text = CarRentalInfo.TotalPrice.ToString();
            lblTotalPaid.Text = paidAmount.ToString();
            lblRentalDuration.Text = totalRentDays.ToString() + " Days";
            lblRemainingAmount.Text = remainingAmount.ToString();
            lblScheduledReturnDate.Text = CarRentalInfo.ReturnDate.ToString();
            lblActualReturnDate.Text = actualReturnDate.ToString();

            _InitLateInfo();

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            dialogPopup.Icon = MessageDialogIcon.Question;

            if (dialogPopup.Show("Are you sure you want to return this car?", "Confirmation") == DialogResult.OK)
            {
                if (CarRentalInfo.ReturnCar(dtpReturnDate.Value, CurrentUser.UserInfo.UserID ?? -1))
                {
                    dialogPopup.Icon = MessageDialogIcon.Information;
                    dialogPopup.Show("Car Returned Successfully!");
                    Close();
                } else
                {
                    dialogPopup.Icon = MessageDialogIcon.Error;
                    dialogPopup.Show("Something went wrong with car return operation!", "Error");
                }
            }
        }

        private void dtpReturnDate_ValueChanged(object sender, EventArgs e)
        {
            if (CarRentalInfo == null)
            {
                return;
            }

            _InitLateInfo();
        }

        private void _InitLateInfo()
        {
            int totalRentDays = (CarRentalInfo.ReturnDate - CarRentalInfo.PickupDate).Days;
            int totalDaysUsed = (dtpReturnDate.Value - CarRentalInfo.PickupDate).Days;
            int lateDays = totalDaysUsed - totalRentDays;

            lblTotalDaysUsed.Text = totalDaysUsed.ToString();
            lblExtraDaysLate.Text = lateDays.ToString();

            if (lateDays > 0)
            {
                lblExtraDaysLate.Text = lateDays.ToString();
                lnlExtraAmount.Text = (lateDays * CarRentalInfo.PricePerDaySnapshot).ToString();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
