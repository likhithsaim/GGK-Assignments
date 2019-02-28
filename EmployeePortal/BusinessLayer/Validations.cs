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
            if (Regex.IsMatch(email, @".+@gmail.com"))
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
            if (Regex.IsMatch(password, @"(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*()_+-=])[a-zA-Z0-9!@#$%^&*()_+-=]{8,}"))
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
            if (Regex.IsMatch(name, @"^[a-zA-Z ]+$"))
            {
                return true;
            }
            return false;
        }
    }
}