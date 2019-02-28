using DomainLayer.Enums;
using DomainLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryLayer
{
    /// <summary>
    /// returns user details from database
    /// </summary>
    internal class UserRepo : IUserRepo
    {
        public List<IUserModel> GetUserDetails(UserRoleChoiceEnum role)
        {
            if (role == (UserRoleChoiceEnum)1)
            {
                return DataSource._userList.Where(m => m is StudentModel).ToList();
            }
            else if (role == (UserRoleChoiceEnum)2)
            {
                return DataSource._userList.Where(m => m is OthersModel).ToList();
            }
            return DataSource._userList.ToList();
        }
    }
}