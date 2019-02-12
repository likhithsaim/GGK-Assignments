using System;
using System.Threading;
namespace MultiThreading
{
    class Program
    {
        static void Main(string[] args)
        {
            int number;
            ThreadingDemo threading = new ThreadingDemo();
            for (int i = 10; i <= 50; i += 10)
            {
                number = i;
                Thread newThread = new Thread(() => threading.MethodForOut(out number));
                newThread.Start();
                Console.WriteLine("In main method                     : " + number);
                Thread.Sleep(40);
                Console.WriteLine("In called method before assignment : " + number);
                newThread.Join();
                Console.WriteLine("In main  method after assignment   : " + number + "\n");
            }
            Console.ReadLine();
        }
    }
}
