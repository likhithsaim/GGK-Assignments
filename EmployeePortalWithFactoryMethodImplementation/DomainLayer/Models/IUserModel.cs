namespace DomainLayer.Models
{
    public interface IUserModel
    {
        string Email { get; set; }
        string Password { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}
