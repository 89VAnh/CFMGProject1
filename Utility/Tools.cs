using System.Globalization;
using System.Text.RegularExpressions;

namespace Utility
{
    public class Tools
    {
        public static bool CheckEmail(string email)
        {
            return Regex.Match(email, @"^([\w\.-]+)@([\w-]+)((\.(\w){2,3})+)$").Success;
        }

        public static bool CheckPhone(string phone)
        {
            return Regex.Match(phone, @"^\d{10}$").Success;
        }

        public static string ConvertToCurrency(int c)
        {
            var nfi = new NumberFormatInfo()
            {
                NumberDecimalDigits = 0,
                NumberGroupSeparator = "."
            };
            return c.ToString("N", nfi) + " đ";
        }

        public static int Discount(int totalPrice, int discountValue, int discountType)
        {
            int value = totalPrice;
            try
            {
                int discount = discountValue;

                switch (discountType)
                {
                    case 0: value -= discount * 1000; break;
                    case 1: value -= value * discount / 100; break;
                    default: break;
                }
            }
            catch { }
            return value >= 0 ? value : 0;
        }
    }
}