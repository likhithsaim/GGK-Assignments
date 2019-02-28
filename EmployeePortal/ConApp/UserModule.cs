using BusinessLayer;
using DomainLayer.Enums;
using DomainLayer.Models;
using System.Collections.Generic;

namespace ConApp
{
    class UserModule
    {
        /// <summary>
        /// Sends the user choice to BusinessLayer and get user details
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        internal List<UserModel> GetUserDetails(UserRoleChoiceEnum role)
        {
            UserBusiness userBusiness = new UserBusiness();
            return userBusiness.GetUserDetails(role);
        }
    }
}
