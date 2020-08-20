using System;

namespace CodeingPractise
{
    class Program
    {
        static void Main(string[] args)
        {
            IProduct product = new Product();
            string name = product.PrintText("Vivek");

            Console.WriteLine(name);


        }
    }
}
