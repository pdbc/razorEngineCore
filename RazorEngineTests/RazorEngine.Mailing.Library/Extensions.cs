using System;
using System.Collections.Generic;
using System.Text;

namespace RazorEngine.Mailing.Library
{
    public static class Extensions
    {
        public static String ToIdentityStoreDateFormat(this DateTime dateTime)
        {
            return dateTime.ToShortDateString();
        }
    }
}
