using DomainLayer.Models;
using System.Linq;

namespace RepositoryLayer
{
    public class AuthencatioRepo
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
        public string Register(RegistrationModel registrationModel)
        {
            if (DataSource._userList == null || !DataSource._userList.Any(m => m.Email == registrationModel.Email))
            {
                UserModel userModel = new UserModel();
                userModel.Email = registrationModel.Email;
                userModel.FirstName = registrationModel.FirstName;
                userModel.LastName = registrationModel.LastName;
                userModel.Password = registrationModel.Password;
                userModel.IsStudent = registrationModel.IsStudent;
                DataSource._userList.Add(userModel);
                return "Success";
            }
            return "Failed";
        }
    }
}