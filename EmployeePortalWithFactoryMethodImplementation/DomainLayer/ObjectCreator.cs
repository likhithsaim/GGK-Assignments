using DomainLayer.Models;

namespace DomainLayer
{
    public class ObjectCreator
    {
        /// <summary>
        /// Returns object according to user input
        /// </summary>
        /// <param name="isStudent"></param>
        /// <returns></returns>
        public IUserModel FactoryMethod(bool isStudent)
        {
            if (isStudent)
            {
                return new StudentModel();
            }
            else
            {
                return new OthersModel();
            }
        }
    }
}