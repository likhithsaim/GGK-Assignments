using System;

namespace ImplementingISandAS
{
    class Implementation
    {
        public void Method<T>(dynamic input)
        {
            if (ImplementingAS<T>(input) != null)
            {
                Console.WriteLine("{0} to {1} is possible", input, typeof(T));
            }
            else
            {
                Console.WriteLine("{0} to {1} is not possible", input, typeof(T));
            }
        }
        T ImplementingAS<T>(dynamic input)
        {
            if (ImplementingIS<T>(input))
            {
                return (T)input;
            }
            return default(T);
        }
        bool ImplementingIS<T>(dynamic input)
        {
            Type x = input.GetType();
            while (x != null)
            {
                if (x == typeof(T))
                {
                    return true;
                }
                x = x.BaseType;
            }
            return false;
        }
    }
}