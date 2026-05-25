using BusinessLayer;
using Cars_Rental.Global_Classes;
using Cars_Rental.Payment.Forms;
using FontAwesome.Sharp;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cars_Rental.Rental.Forms
{
    public partial class frmViewRental : Form
    {
        public clsCarRental CarRentalInfo { get; set; }
        private int? _CarRentalID = null;

        public frmViewRental(int? carRentalID)
        {
            InitializeComponent();

            _CarRentalID = carRentalID;
        }

        private void frmViewRental_Load(object sender, EventArgs e)
        {
            _InitIcons();
            _LoadData();
        }

        private void _InitIcons()
        {
            btnCancel.Image = Utility.GetFontAwesomeImage(IconChar.Xmark, Color.White);
        }

        private void _LoadData()
        {
            CarRentalInfo = clsCarRental.Find(_CarRentalID);

            if (CarRentalInfo == null)
            {
                return;
            }

            DataTable initialPaymentData = clsCarRental.GetInitialPaymentData(_CarRentalID);

            int totalRentDays = Math.Abs((CarRentalInfo.PickupDate - CarRentalInfo.ReturnDate).Days);

            lblRentalID.Text = CarRentalInfo.CarRentalID.ToString();
            lblCustomerName.Text = CarRentalInfo.CustomerInfo.Fullname;
            lblLicenseNumber.Text = CarRentalInfo.CustomerInfo.LicenseNumber;

            lblCarName.Text = CarRentalInfo.CarInfo.CarName;
            lblTransmission.Text = CarRentalInfo.CarInfo.TransmissionInfo.TransmissionName;
            lblFuelType.Text = CarRentalInfo.CarInfo.FuelTypeInfo.FuelTypeName;
            lblPricePerDay.Text = CarRentalInfo.CarInfo.PricePerDay.ToString();
            lblPickupDate.Text = CarRentalInfo.PickupDate.ToString();
            lblReturnDate.Text = CarRentalInfo.ReturnDate.ToString();
            lblPickupLocation.Text = CarRentalInfo.PickupLocation;
            lblRentalDuration.Text = totalRentDays.ToString() + " Days";
            lblTotalPrice.Text = (totalRentDays * CarRentalInfo.CarInfo.PricePerDay).ToString();
            lblDeposit.Text = CarRentalInfo.Deposit.ToString();
            
            if (initialPaymentData.Rows.Count > 0)
            {
                lblInitialPayment.Text = initialPaymentData.Rows[0]["Amount"].ToString();
                lblPaymentMethod.Text = initialPaymentData.Rows[0]["PaymentMethod"].ToString();
            }

            if (CarRentalInfo.HasCarReturned())
            {
                _LoadReturnData();
            } else
            {
                pnlReturnDetails.Visible = false;
            }

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

        private void _LoadReturnData()
        {
            pnlReturnDetails.Visible = true;

            clsRentalReturn carReturnInfo = clsRentalReturn.FindByCarRentalID(CarRentalInfo.CarRentalID);

            int totalRentDays = (int)Math.Ceiling((carReturnInfo.ReturnDate - CarRentalInfo.PickupDate).TotalDays);
            int scheduledRentDays = (CarRentalInfo.ReturnDate - CarRentalInfo.PickupDate).Days;

            lblActualReturnDate.Text = carReturnInfo.ReturnDate.ToString();
            lblTotalDaysUsed.Text = totalRentDays.ToString();

            if (totalRentDays > scheduledRentDays)
            {
                int extraDaysLate = totalRentDays - scheduledRentDays;

                lblExtraDaysLate.Text = extraDaysLate.ToString();
                lblExtraAmontFees.Text = (extraDaysLate * CarRentalInfo.PricePerDaySnapshot).ToString();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPaymentHistory_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmPaymentHistory frm = new frmPaymentHistory(_CarRentalID);
            frm.ShowDialog();
            this.Show();
        }
    }
}
