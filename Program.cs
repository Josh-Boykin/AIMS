using System;
using System.Threading;

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

            /*
            Console.WriteLine("Enter name of new product.");
            Product P1 = new Product();
            P1.Name = Console.Readline();
            Console.ReadLine(ProductName.Name);
            Console.WriteLine("Enter value of price per unit.");
            */ 
        }    
    }
}






