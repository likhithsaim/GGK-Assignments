using System;
using System.Collections.Generic;
class DataAccessLayer
{
    private Dictionary<string, PersonDetails> m_dataBase = new Dictionary<string, PersonDetails>();
    //  Checks for the authorization using password
    public bool IsIdExist(string mailId)
    {
        if(m_dataBase.ContainsKey(mailId))
        {
            return true;
        }
        return false; 
    }
    public string IsAuthorized(string mailId, string password)
    {
        if (!m_dataBase.ContainsKey(mailId))
        {
            return "Mail-ID does not exist";
        }
        else
        {
            m_dataBase.TryGetValue(mailId, out PersonDetails details);
            if (!details.password.Equals(password))
            {
                return "Entered password does not match.";
            }
        }
        return "Authorized";
    }
    //  For user sign-up
    public void Create(string mailId, string name, string password, bool isStudent)
    {
        PersonDetails details = new PersonDetails(name, password, isStudent);
        m_dataBase.Add(mailId, details);
    }
    //  Returns Student details
    public Dictionary<string, string> GetUserDetails(string choice)
    {
        Dictionary<string, string> dummyDataBase = new Dictionary<string, string>();
        if (choice.Equals("1"))
        {
            foreach (KeyValuePair<string, PersonDetails> i in m_dataBase)
            {
                if (i.Value.isStudent)
                {
                    dummyDataBase.Add(i.Value.name, i.Key);
                }
            }
        }
        else if (choice.Equals("2"))
        {
            foreach (KeyValuePair<string, PersonDetails> i in m_dataBase)
            {
                if (!i.Value.isStudent)
                {
                    dummyDataBase.Add(i.Value.name, i.Key);
                }
            }
        }
        else
        {
            foreach (KeyValuePair<string, PersonDetails> i in m_dataBase)
            {
                dummyDataBase.Add(i.Value.name, i.Key);
            }
        }
        return dummyDataBase;
    }
}