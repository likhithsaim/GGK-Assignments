using DomainLayer.Models;

namespace RepositoryLayer
{
    public interface IAuthenticationRepo
    {
        bool ValidateLogin(LoginModel loginModel);
        string Register(IUserModel iuserModel);
    }
}
