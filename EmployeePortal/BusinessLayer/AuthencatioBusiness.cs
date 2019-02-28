using DomainLayer;
using DomainLayer.Models;
using RepositoryLayer;

namespace BusinessLayer
{
    public class AuthencatioBusiness
    {
        AuthencatioRepo _authRepo;

        public AuthencatioBusiness()
        {
            _authRepo = new AuthencatioRepo();
        }
        /// <summary>
        /// For login authentication
        /// </summary>
        /// <param name="emailID"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool ValidateLogin(string emailID, string password)
        {
            LoginModel loginModel = new LoginModel();
            loginModel.Email = emailID;
            loginModel.Password = password;
            return _authRepo.ValidateLogin(loginModel);
        }
        /// <summary>
        /// To check for successfull registration
        /// </summary>
        /// <param name="emailID"></param>
        /// <param name="password"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="isStudent"></param>
        /// <returns></returns>
        public string Register(string emailID, string password, string firstName, string lastName, bool isStudent)
        {
            RegistrationModel registrationModel = new RegistrationModel();
            registrationModel.Email = emailID;
            registrationModel.Password = password;
            registrationModel.FirstName = firstName;
            registrationModel.LastName = lastName;
            registrationModel.IsStudent = isStudent;
            if (!Validations.ValidateName(firstName + "  " + lastName))
                return StringLiterals._validateName;
            if (!Validations.ValidateEmail(emailID))
                return StringLiterals._invalidEmail;
            if (!Validations.ValidatePassword(password))
                return StringLiterals._validatePassword;
            return _authRepo.Register(registrationModel);
        }
    }
}