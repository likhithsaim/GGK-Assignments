using BusinessLayer;
using DomainLayer;
using DomainLayer.Enums;
using DomainLayer.Models;
using System;
using System.Collections.Generic;

namespace ConApp
{
    public class Display
    {
        AuthencatioBusiness _authBusiness;
        public Display()
        {
            _authBusiness = new AuthencatioBusiness();
        }
        //  Displays Home Page 
        public void HomePage()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("...Home Page...");
                Console.WriteLine("1. Sign-In\n2. Sign-Up\n3. Exit");
                Console.Write("Enter your choice : ");
                int choice;
                try
                {
                   choice = Int32.Parse(Console.ReadLine());
                }
                catch
                {
                    choice = 4;
                }
                    switch ((HomePageOptionsEnum)choice)
                {
                    case HomePageOptionsEnum.SignIn:
                        SignIn();
                        break;
                    case HomePageOptionsEnum.SignUp:
                        SignUp();
                        break;
                    case HomePageOptionsEnum.Exit:
                        Console.WriteLine("Closing...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        Console.ReadLine();
                        break;
                }
            }
        }
        //  For user sign-in
        void SignIn()
        {
            Console.Clear();
            Console.WriteLine("...Sign-in Page...");
            Console.Write("Enter valid ID : ");
            string id = Console.ReadLine();
            Console.Write("Enter Password : ");
            string password = Console.ReadLine();
            if (_authBusiness.ValidateLogin(id, password))
            {
                AfterSignIn();
            }
            else
            {
                Console.WriteLine(StringLiterals._invalidEmail);
                Console.ReadLine();
            }
        }
        //  For user Sign-Up
        void SignUp()
        {
            Console.Clear();
            Console.WriteLine("...Sign-Up Page...");
            Console.Write("Enter First Name : ");
            string firstName = Console.ReadLine();
            Console.Write("Enter Last Name  : ");
            string lastName = Console.ReadLine();
            string emailID, password;
            Console.WriteLine("Mail-ID must contain '@gmail.com'.");
            Console.Write("Enter valid Mail_ID : ");
            emailID = Console.ReadLine();
            Console.WriteLine("password must contain a Lowercase letter, an Uppercase letter, a number, one of these special symbols (!@#$%^&*())");
            Console.Write("Enter Password : ");
            password = Console.ReadLine();
            bool isStudent = false;
            Console.Write("Are you a Student (y/n) : ");
            if (Console.ReadLine().Equals("y"))
            {
                isStudent = true;
            }
            string errorMessage = _authBusiness.Register(emailID, password, firstName, lastName, isStudent);
            if(errorMessage.Equals("Success"))
            {
                Console.WriteLine("User account created");
            }
            else if(errorMessage.Equals("Failed"))
            { 
                Console.WriteLine("ID not available.\nEnter another id.\n");
            }
            else
            {
                Console.WriteLine(errorMessage);
            }
            Console.ReadLine();
        }
        //  operations to be performed after user sign-in
        void AfterSignIn()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("...Signed In...");
                Console.Clear();
                Console.WriteLine("1. Student Details\n2. Others\n3.All\n4.Sign-out");
                Console.Write("Enter your Choice : ");
                int choice;
                try
                {
                    choice = Int32.Parse(Console.ReadLine());
                }
                catch
                {
                    choice = 5;
                }
                switch ((UserRoleChoiceEnum)choice)
                {
                    case UserRoleChoiceEnum.Student:
                    case UserRoleChoiceEnum.Other:
                    case UserRoleChoiceEnum.All:
                        UserModule userModule = new UserModule();
                        displayDetails(userModule.GetUserDetails((UserRoleChoiceEnum)choice));
                        break;
                    case UserRoleChoiceEnum.SignOut:
                        Console.WriteLine("Signing out...");
                        Console.ReadLine();
                        HomePage();
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        Console.ReadLine();
                        break;
                }
            }
        }
        //  Displays details all users in database according to user choice
        public void displayDetails(List<UserModel> dummyDataBase)
        {
            Console.WriteLine("Name\t\tMail-Id");
            foreach (var name in dummyDataBase)
            {
                Console.WriteLine(name.FirstName + " " + name.LastName + "\t\t" + name.Email);
            }
            Console.ReadLine();
        }
    }
}