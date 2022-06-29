using System;

namespace AIMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            MenuLoop.WriteLogo();
            Thread.Sleep(2000);
            Console.WriteLine("Welcome to the Alcohol Inventory Managment System.");
            Thread.Sleep(2000);
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
        }    
    }
}






