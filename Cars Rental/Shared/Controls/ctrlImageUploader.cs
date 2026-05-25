using Cars_Rental.Global_Classes;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cars_Rental.Shared.Controls
{
    public partial class ctrlImageUploader : UserControl
    {
        public ctrlImageUploader()
        {
            InitializeComponent();
        }

        private void _InitIcons()
        {
            btnUploadImage.Image = Utility.GetFontAwesomeImage(IconChar.Upload, Color.White);
            btnRemoveImage.Image = Utility.GetFontAwesomeImage(IconChar.TrashAlt, Color.FromArgb(143, 150, 171));
        }

        private void ctrlImageUploader_Load(object sender, EventArgs e)
        {
            _InitIcons();
        }
    }
}
