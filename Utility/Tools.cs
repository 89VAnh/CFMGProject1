using System.Text.RegularExpressions;

namespace Utility
{
    public class Tools
    {
        public static bool CheckPhone(string phone)
        {
            return Regex.Match(phone, @"^\d{10}$").Success;
        }

        public static bool CheckEmail(string email)
        {
            return Regex.Match(email, @"^([\w\.-]+)@([\w-]+)((\.(\w){2,3})+)$").Success;
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
            return value;
        }
    }
}