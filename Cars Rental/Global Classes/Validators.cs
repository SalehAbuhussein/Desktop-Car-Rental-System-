using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cars_Rental.Global_Classes
{
    public static class Validators
    {
        public static bool ValidateControl<T>(
            T control, 
            ErrorProvider errorProvider,
            Func<T, bool> isInvalid,
            string message
        ) where T : Control
        {
            if (isInvalid(control))
            {
                errorProvider.SetError(control, message);
                return true;
            } else
            {
                errorProvider.SetError(control, null);
                return false;
            }
        }

        public static bool IsNumber(char character)
        {
            return char.IsDigit(character) || char.IsControl(character);
        }
    }
}
