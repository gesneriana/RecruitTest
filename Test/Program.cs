using System;
using System.Threading;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now.ToBinary().ToString("X2") + "-" + Guid.NewGuid().ToString("D"));
            Console.WriteLine("Hello World!");
        }
    }
}
