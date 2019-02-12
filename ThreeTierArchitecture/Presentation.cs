using System;
using System.Collections.Generic;
class Presentation
{
    BusinessLogic m_businessLogic = new BusinessLogic();
    //  Displays Home Page
    public void HomePage()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("...Home Page...");
            Console.WriteLine("1. Sign-In\n2. Sign-Up\n3. Exit");
            Console.Write("Enter your choice : ");
            switch (Console.ReadLine())
            {
                case "1":
                    SignIn();
                    break;
                case "2":
                    SignUp();
                    break;
                case "3":
                    Console.WriteLine("Closing...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.ForegroundColor=ConsoleColor.Red;
                    Console.WriteLine("Invalid choice.");
                    Console.ResetColor();
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
        string message = m_businessLogic.IsAuthorized(id, password);
        if (message.Equals("Authorized"))
        {
            AfterSignIn();
        }
        else
        {
            Console.ForegroundColor=ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
            Console.ReadLine();
        }
    }
    //  For user Sign-Up
    void SignUp()
    {
        Console.Clear();
        Console.WriteLine("...Sign-Up Page...");
        string fullName = "";
        Console.Write("Enter First Name : ");
        fullName = Console.ReadLine();
        Console.Write("Enter Last Name  : ");
        fullName += " " + Console.ReadLine();
        string MailId, password;
        Console.ForegroundColor=ConsoleColor.Green;
        Console.WriteLine("Mail-ID must contain '@gmail.com'.");
        Console.ResetColor();
        do
        {
            Console.Write("Enter valid Mail-ID : ");
            MailId = Console.ReadLine();
            if (m_businessLogic.IsIdExist(MailId))
            {
                Console.ForegroundColor=ConsoleColor.Red;
                Console.WriteLine("ID not available.\nEnter another id.\n");
                Console.ResetColor();
                MailId = "a";
            }
        } while (!m_businessLogic.isIdValid(MailId));
        Console.ForegroundColor=ConsoleColor.Green;
        Console.WriteLine("password must contain a Lowercase letter, an Uppercase letter, a number, one of these special symbols (!@#$%^&*())");
        Console.ResetColor();
        do
        {
            Console.Write("Enter Password : ");
            password = Console.ReadLine();
        } while (!m_businessLogic.isPasswordValid(password));
        bool isStudent = false;
        Console.Write("Are you a Student (y/n) : ");
        if (Console.ReadLine().Equals("y"))
        {
            isStudent = true;
        }
        m_businessLogic.Create(MailId, fullName, password, isStudent);
        Console.WriteLine("User account created");
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
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                case "2":
                case "3":
                    displayDetails(m_businessLogic.GetUserDetails(choice));
                    break;
                case "4":
                    Console.WriteLine("Signing out...");
                    Console.ReadLine();
                    HomePage();
                    break;
                default:
                    Console.ForegroundColor=ConsoleColor.Red;
                    Console.WriteLine("Invalid choice.");
                    Console.ResetColor();
                    Console.ReadLine();
                    break;
            }
        }
    }
    //  Displays details all users in database according to user choice
    public void displayDetails(Dictionary<string, string> dummyDataBase)
    {
        Console.WriteLine("Name\t\tMail-Id");
        foreach (KeyValuePair<string, string> name in dummyDataBase)
        {
            Console.WriteLine(name.Key + "\t\t" + name.Value);
        }
        Console.ReadLine();
    }
}