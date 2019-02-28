using DomainLayer;
using System.Text.RegularExpressions;

namespace BusinessLayer
{
    public static class Validations
    {
        /// <summary>
        /// For Email validation
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool ValidateEmail(string email)
        {
            if (Regex.IsMatch(email, StringLiterals._regexEmailID))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// For password validation
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool ValidatePassword(string password)
        {
            if (Regex.IsMatch(password, StringLiterals._regexPassword))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// For name validation
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool ValidateName(string name)
        {
            if (Regex.IsMatch(name, StringLiterals._regexName))
            {
                return true;
            }
            return false;
        }
    }
}