using BusinessLayer;
using DomainLayer.Models;

namespace ConApp
{
    class Authentication
    {
        IAuthenticationBusiness _authBusiness;
        public Authentication()
        {
            _authBusiness = BusinessFactory.GetAuthenticationBusiness();
        }
        /// <summary>
        /// Retuens true if the credentials are correct
        /// </summary>
        /// <param name="emailID"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        internal bool Login(string emailID, string password)
        {
            return _authBusiness.ValidateLogin(emailID, password);
        }
        /// <summary>
        /// Returns success message or error message if any
        /// </summary>
        /// <param name="password"></param>
        /// <param name="emailID"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="isStudent"></param>
        /// <returns></returns>
        internal string Register(RegistrationModel registrationModel)
        {
            return _authBusiness.Register(registrationModel);
        }
    }
}