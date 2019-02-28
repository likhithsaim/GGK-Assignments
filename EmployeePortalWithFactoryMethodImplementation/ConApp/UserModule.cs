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
        internal List<IUserModel> GetUserDetails(UserRoleChoiceEnum role)
        {
            IUserBusiness userBusiness = BusinessFactory.GetUserBusiness();
            return userBusiness.GetUserDetails(role);
        }
    }
}