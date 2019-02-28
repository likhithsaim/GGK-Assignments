using DomainLayer;
using DomainLayer.Models;
using System.Linq;

namespace RepositoryLayer
{
    internal class AuthencatioRepo : IAuthenticationRepo
    {
        /// <summary>
        /// For login validation
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        public bool ValidateLogin(LoginModel loginModel)
        {
            if (DataSource._userList == null)
                return false;
            return DataSource._userList.Any(m => m.Email == loginModel.Email &&
             m.Password == loginModel.Password);
        }
        /// <summary>
        /// Registers a new user and also returns error messages if any
        /// </summary>
        /// <param name="registrationModel"></param>
        /// <returns></returns>
        public string Register(IUserModel iuserModel)
        {
            if (DataSource._userList == null || !DataSource._userList.Any(m => m.Email == iuserModel.Email))
            {
                DataSource._userList.Add(iuserModel);
                return StringLiterals._success;
            }
            return StringLiterals._failed;
        }
    }
}