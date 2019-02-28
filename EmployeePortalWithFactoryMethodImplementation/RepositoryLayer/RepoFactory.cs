using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class RepoFactory
    {
        public static IUserRepo GetUserRepo()
        {
            return new UserRepo();
        }
        public static IAuthenticationRepo GetAuthenticationRepo()
        {
            return new AuthencatioRepo();
        }
    }
}
