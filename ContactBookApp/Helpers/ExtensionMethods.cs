using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ContactBookApp.Helpers
{
    public static class ExtensionMethods
    {
        public static bool IsValidPhoneNumberFormat(this string phoneNumber)
        {
            return Regex.Match(phoneNumber, @"^(09|\+639)\d{9}$").Success;
        }

        public static bool IsValidEmail(this string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
