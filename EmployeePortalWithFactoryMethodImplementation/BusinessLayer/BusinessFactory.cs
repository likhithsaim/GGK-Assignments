namespace BusinessLayer
{
    public class BusinessFactory
    {
        public static IUserBusiness GetUserBusiness()
        {
            return new UserBusiness();
        }
        public static IAuthenticationBusiness GetAuthenticationBusiness()
        {
            return new AuthencatioBusiness();
        }
    }
}
