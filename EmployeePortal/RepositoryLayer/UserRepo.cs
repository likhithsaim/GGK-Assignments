using DomainLayer.Enums;
using DomainLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryLayer
{
    /// <summary>
    /// returns user details from database
    /// </summary>
    public class UserRepo
    {
        public List<UserModel> GetUserDetails(UserRoleChoiceEnum role)
        {
            if (role == (UserRoleChoiceEnum)1)
            {
                return DataSource._userList.Where(m => m.IsStudent).ToList();
            }
            else if (role == (UserRoleChoiceEnum)2)
            {
                return DataSource._userList.Where(m => !m.IsStudent).ToList();
            }
            return DataSource._userList.ToList();
        }
    }
}
