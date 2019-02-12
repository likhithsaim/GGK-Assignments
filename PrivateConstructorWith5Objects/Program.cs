using System;

namespace PrivateConstructorWith5Objects
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i <7; i++)
            {
                if(PrivateConstructorClass.GetInstance()!=null)
                {
                    Console.WriteLine("new object created");
                }
                else
                {
                    Console.WriteLine("Cannot Create a new object");
                    GC.Collect();
                    GC.GetTotalMemory(true);
                }
            }
            Console.ReadLine();
        }
    }
}
