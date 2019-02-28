﻿using DomainLayer.Enums;
using DomainLayer.Models;
using System.Collections.Generic;

namespace RepositoryLayer
{
    public interface IUserRepo
    {
        List<IUserModel> GetUserDetails(UserRoleChoiceEnum role);

    }
}
