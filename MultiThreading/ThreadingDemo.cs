using System.Threading;
class ThreadingDemo
{
    public int number;
    //  For determining the out value when a method call happens
    public void MethodForOut(out int number)
    {
        Thread.Sleep(80);
        number = 100;
    }
}