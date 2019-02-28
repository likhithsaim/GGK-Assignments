namespace DomainLayer
{
    public static class StringLiterals
    {
        public static string _success = "Success";
        public static string _failed = "Failed";
        public static string _accountCreatedMessage = "User account created";
        public static string _closingMessage = "Closing...";
        public static string _enterChoice = "Enter choice : ";
        public static string _invalidChoice = "Invalid choice";
        public static string _signInScreenMessage = "...Sign-In Screen...";
        public static string _signUpScreenMessage = "...Sign-Up Screen...";
        public static string _homeScreenMessage = "...Home Screen...";
        public static string _afterSignedInScreenMessage = "...Signed In...";
        public static string _afterSignedInScreenMenu = "1. Student Details\n2. Others\n3.All\n4.Sign-out";
        public static string _signingOutMessage = "Signing out...";
        public static string _displayNameAndMailMessage = "Name\t\tMail-ID";
        public static string _homeScreenMenu = "1. Sign-In\n2. Sign-Up\n3. Exit";
        public static string _firstName = "Enter First Name : ";
        public static string _lastName = "Enter Last Name : ";
        public static string _mailIDRequirements = "Mail-ID must contain '@gmail.com'.";
        public static string _mailID = "Enter valid Mail_ID : ";
        public static string _idNotAvailable = "ID not available.\nEnter another id.\n";
        public static string _invalidEmail = "Invalid Email";
        public static string _enterPassword = "Enter Password : ";
        public static string _confirmPassword = "Confirm Password : ";
        public static string _areYouStudent = "Are you a Student (y/n) : ";
        public static string _passwordRequiremnts = "password must contain a Lowercase letter, an Uppercase letter, a number, one of these special symbols (!@#$%^&*())";
        public static string _validateName = "Name should only contain alphabets and white spaces";
        public static string _validateEmail = "Email should look like example@gmail.com";
        public static string _validatePassword = "Password does not meet the requirements";
        public static string _comparePasswordWithConfirmPassword = "Password  and confirmpassword does not match";
        public static string _regexPassword = @"(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*()_+-=])[a-zA-Z0-9!@#$%^&*()_+-=]{8,}";
        public static string _regexName = @"^[a-zA-Z ]+$";
        public static string _regexEmailID = @".+@gmail.com";
    }
}