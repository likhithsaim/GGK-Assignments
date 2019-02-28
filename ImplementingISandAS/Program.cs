using System;
using System.Text.RegularExpressions;

namespace ImplementingISandAS
{
    class Program
    {
        static void Main(string[] args)
        {
            Implementation implementation = new Implementation();
            Console.WriteLine("Enter a string : ");
            dynamic input = Console.ReadLine();
            if (Regex.IsMatch(input, "[0-9]+"))
            {
                long? x = Int64.Parse(input);
                input = x;
            }
            implementation.Method<string>(input);
            implementation.Method<long?>(input);
            Console.Read();
        }
    }
}