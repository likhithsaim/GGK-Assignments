using System;
namespace secAssign
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter two float values:");
            string value1 = Console.ReadLine();
            string value2 = Console.ReadLine();
            Methods methods = new Methods();
            string result = methods.CategorizeInputs(value1, value2);
            Console.WriteLine("sum is : " + result);
            Console.ReadLine();
        }
    }
}