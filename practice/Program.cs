using System;
using System.Text.RegularExpressions;
namespace JustForFun
{
    class Program
    {
        static void Main()
        {
            string s = "hello world";
            Console.WriteLine(s);
            string v = "aeiou";
            int length = s.Length;
            if (!v.Contains(s[length - 1].ToString()))
            {
                char ch = s[length - 1];
                ch--;
                s = s.Substring(0, length - 1) + ch + "a";
            }
            string[] a = Regex.Split(s, "[a,e,i,o,u]");
            s = "";
            for (int i = 0; i < a.Length; i++)
            {
                length = a[i].Length;
                if (length > 0)
                {
                    char ch = a[i][length - 1];
                    ch++;
                    s = s + a[i].Substring(0, a[i].Length - 1) + ch + " ";
                }
            }
            Console.WriteLine(s);
            Console.Read();
        }
    }
}