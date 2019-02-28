using DomainLayer.Enums;
using DomainLayer.Models;
using RepositoryLayer;
using System.Collections.Generic;

namespace BusinessLayer
{
    internal class UserBusiness : IUserBusiness
    {
        IUserRepo _userRepo;

        public UserBusiness()
        {
            _userRepo = RepoFactory.GetUserRepo();
        }
        /// <summary>
        /// Returns users details according to the choice
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public List<IUserModel> GetUserDetails(UserRoleChoiceEnum role)
        {
            return _userRepo.GetUserDetails(role);
        }
    }
}