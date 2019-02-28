using DomainLayer;
using DomainLayer.Models;
using RepositoryLayer;

namespace BusinessLayer
{
    internal class AuthencatioBusiness : IAuthenticationBusiness
    {
        IAuthenticationRepo _authRepo;

        public AuthencatioBusiness()
        {
            _authRepo = RepoFactory.GetAuthenticationRepo();
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
        public string Register(RegistrationModel registrationModel)
        {
            if (!Validations.ValidateName(registrationModel.FirstName + "  " + registrationModel.LastName))
                return StringLiterals._validateName;
            if (!Validations.ValidateEmail(registrationModel.Email))
                return StringLiterals._validateEmail;
            if (!registrationModel.Password.Equals(registrationModel.ConfirmPassword))
                return StringLiterals._comparePasswordWithConfirmPassword;
            if (!Validations.ValidatePassword(registrationModel.Password))
                return StringLiterals._validatePassword;
            ObjectCreator objectCreator = new ObjectCreator();
            IUserModel iuserModel = objectCreator.FactoryMethod(registrationModel.IsStudent);
            iuserModel.Email = registrationModel.Email;
            iuserModel.FirstName = registrationModel.FirstName;
            iuserModel.LastName = registrationModel.LastName;
            iuserModel.Password = registrationModel.Password;
            return _authRepo.Register(iuserModel);
        }
    }
}