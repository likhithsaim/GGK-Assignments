using System;
class PrivateConstructorClass
{
    public static int count = 0;
    //  private constructor
    private PrivateConstructorClass()
    {
    }
    //  static constructor
    public static PrivateConstructorClass GetInstance()
    {
        if(count<5)
        {
            count++;
            return new PrivateConstructorClass();
        }
        return null;
    }
    //  Destructor
    ~PrivateConstructorClass()
    {
        Console.WriteLine("Object deleted");
        count--;
    }
}