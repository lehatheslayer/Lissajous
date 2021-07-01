using System;

namespace test
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            byte a = 32;
            byte[] b = BitConverter.GetBytes((short) 1024);
            foreach(var variable in b)
            {
                Console.WriteLine(variable);
            }
        }
    }
}