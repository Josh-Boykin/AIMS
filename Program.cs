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
            Thread.Sleep(1000);
            Console.WriteLine("Welcome to the Alcohol Inventory Managment System.");
            Thread.Sleep(1000);
            Console.WriteLine();
            Console.WriteLine("Please enter a product name.");


            Product bottle = new Product();
            bottle.Name = Console.ReadLine();
            
            bool isError = false;
            do
            {
                Console.WriteLine("Please enter a valid price.");
                try
                {
                    isError = false;
                    bottle.Price = Convert.ToDecimal(Console.ReadLine());
                }
                catch (System.OverflowException)
                {
                    isError = true;
                    System.Console.WriteLine(
                        "The conversion from string to decimal overflowed.");
                }
                catch (System.FormatException)
                {
                    isError = true;
                    System.Console.WriteLine(
                        "The string is not formatted as a decimal.");
                }
                catch (System.ArgumentNullException)
                {
                    isError = true;
                    System.Console.WriteLine(
                        "The string is null.");
                }
                catch (System.ArgumentException)
                {
                    isError = true;
                    Console.WriteLine("Not a valid value.");
                }
            } while (isError); // do while checks at end

                Console.WriteLine("The Price of the bottle called " + bottle.Name + " will be " + bottle.Price.ToString("N2"));
            Console.ReadLine();
            

            
        }
        /*
        Console.WriteLine("Enter name of new product.");
        Product P1 = new Product();
        P1.Name = Console.Readline();
        Console.ReadLine(ProductName.Name);
        Console.WriteLine("Enter value of price per unit.");
        */
        
    }
}






