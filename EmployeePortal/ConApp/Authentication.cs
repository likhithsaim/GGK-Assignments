using BusinessLayer;

namespace ConApp
{
    class Authentication
    {
        AuthencatioBusiness _authBusiness;
        public Authentication()
        {
            _authBusiness = new AuthencatioBusiness();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailID"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        internal bool Login(string emailID, string password)
        {
            return _authBusiness.ValidateLogin(emailID, password) ;
        }
        internal string  Register(string password, string emailID,string firstName, string lastName, bool isStudent)
        {
            return _authBusiness.Register(password, emailID, firstName, lastName, isStudent);
        }
    }
}
