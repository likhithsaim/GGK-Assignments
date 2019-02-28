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
        IAuthenticationBusiness _authBusiness;
        public Display()
        {
            _authBusiness = BusinessFactory.GetAuthenticationBusiness();
        }
        //  Displays Home Page 
        public void HomeScreen()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(StringLiterals._homeScreenMessage);
                Console.WriteLine(StringLiterals._homeScreenMenu);
                Console.Write(StringLiterals._enterChoice);
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
                        Console.WriteLine(StringLiterals._closingMessage);
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine(StringLiterals._invalidChoice);
                        Console.ReadLine();
                        break;
                }
            }
        }
        //  For user sign-in
        void SignIn()
        {
            Console.Clear();
            Console.WriteLine(StringLiterals._signInScreenMessage);
            Console.Write(StringLiterals._mailID);
            string mailID = Console.ReadLine().ToLower();
            Console.Write(StringLiterals._enterPassword);
            string password = Console.ReadLine();
            if (_authBusiness.ValidateLogin(mailID, password))
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
            RegistrationModel registrationModel = new RegistrationModel();
            Console.Clear();
            Console.WriteLine(StringLiterals._signUpScreenMessage);

            Console.Write(StringLiterals._firstName);
            registrationModel.FirstName = Console.ReadLine();

            Console.Write(StringLiterals._lastName);
            registrationModel.LastName = Console.ReadLine();

            Console.WriteLine(StringLiterals._mailIDRequirements);
            Console.Write(StringLiterals._mailID);
            registrationModel.Email = Console.ReadLine().ToLower();

            Console.WriteLine(StringLiterals._passwordRequiremnts);
            Console.Write(StringLiterals._enterPassword);
            registrationModel.Password = Console.ReadLine();

            Console.Write(StringLiterals._confirmPassword);
            registrationModel.ConfirmPassword = Console.ReadLine();

            registrationModel.IsStudent = false;
            Console.Write(StringLiterals._areYouStudent);
            if (Console.ReadLine().Equals("y"))
            {
                registrationModel.IsStudent = true;
            }

            string errorMessage = _authBusiness.Register(registrationModel);
            if (errorMessage.Equals(StringLiterals._success))
            {
                Console.WriteLine(StringLiterals._accountCreatedMessage);
            }
            else if (errorMessage.Equals(StringLiterals._failed))
            {
                Console.WriteLine(StringLiterals._idNotAvailable);
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
                Console.WriteLine(StringLiterals._afterSignedInScreenMessage);
                Console.WriteLine(StringLiterals._afterSignedInScreenMenu);
                Console.Write(StringLiterals._enterChoice);
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
                        Console.WriteLine(StringLiterals._signingOutMessage);
                        Console.ReadLine();
                        HomeScreen();
                        break;
                    default:
                        Console.WriteLine(StringLiterals._invalidChoice);
                        Console.ReadLine();
                        break;
                }
            }
        }
        //  Displays details all users in database according to user choice
        public void displayDetails(List<IUserModel> dummyDataBase)
        {
            Console.WriteLine(StringLiterals._displayNameAndMailMessage);
            foreach (var name in dummyDataBase)
            {
                Console.WriteLine("{0,-20}{1}", name.FirstName + " " + name.LastName, name.Email);
            }
            Console.ReadLine();
        }
    }
}