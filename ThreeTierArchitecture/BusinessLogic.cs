using System.Text.RegularExpressions;
using System.Collections.Generic;
using System;
class BusinessLogic
{
    DataAccessLayer m_dataAccessLayer = new DataAccessLayer();
    //  Checks if the mail id is valid or not
    public bool isIdValid(string id)
    {
        if (Regex.IsMatch(id, @".+(@gmail.com)"))
        {
            return true;
        } 
        return false;
    }
    //  Checks if the password meets the requirements
    public bool isPasswordValid(string password)
    {
        if (Regex.IsMatch(password, @"(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*()])[a-zA-Z0-9!@#$%^&*()]{8,}"))
        {
            return true;
        }
        return false;
    }
    //  Creates an account for the new User
    public void Create(string mailId, string fullName, string password, bool isStudent)
    {
        m_dataAccessLayer.Create(mailId, fullName, password, isStudent);
    }
    //  Checks if the Mail_ID exists 
    public bool IsIdExist(string MailId)
    {
        if (m_dataAccessLayer.IsIdExist(MailId))
        {
            return true;
        }
        return false;
    }
    //  Checks if the User_id and Password matches
    public string IsAuthorized(string MailId, string password)
    {
        return m_dataAccessLayer.IsAuthorized(MailId, password);
    }
    //  Returns users details from database
    public Dictionary<string, string> GetUserDetails(string choice)
    {
        return m_dataAccessLayer.GetUserDetails(choice);
    }
}