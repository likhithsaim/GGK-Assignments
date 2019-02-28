using DomainLayer.Models;

namespace BusinessLayer
{
    public interface IAuthenticationBusiness
    {
        bool ValidateLogin(string emailID, string password);
        string Register(RegistrationModel registrationModel);
    }
}
