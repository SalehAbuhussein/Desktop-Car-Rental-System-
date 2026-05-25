using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars_Rental.Global_Classes
{
    public static class CurrentUser
    {
        public static clsUser UserInfo { get; set; }

        public static void Logout()
        {
            UserInfo = null;
        }
    }
}
