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
            
            AlcoholType vodka = new AlcoholType();
            vodka.AddProduct("Titos", 24.95F);
            vodka.AddProduct("Grey Goose", 35.99F);
            vodka.AddProduct("Stoli", 14.50F);

            AlcoholType rum = new AlcoholType();
            rum.AddProduct("Bacardi", 13.00F);
            rum.AddProduct("Malibu", 8.79F);

            AlcoholType bourbon = new AlcoholType();
            bourbon.AddProduct("Makers Mark", 28.89F);
            bourbon.AddProduct("Angels Envy", 41.19F);
            bourbon.AddProduct("Woodford Reserve", 35.99F);

            AlcoholType tequila = new AlcoholType();
            tequila.AddProduct("Patron", 19.10F);
            tequila.AddProduct("Don Julio 1942", 74.95F);

            AlcoholType gin = new AlcoholType();
            gin.AddProduct("Bombay Sapphire", 17.00F);
            gin.AddProduct("Hendrick's", 27.15F);

            Product bottle = new Product();
            //bottle.Name = Console.ReadLine();            
            
            bool isErrorN = false;
            do
            {
                Console.WriteLine("Please enter a product name.");
                try
                {
                    isErrorN = false;
                    bottle.Name = Console.ReadLine();// make all literals become lower case
                }
                catch (ArgumentOutOfRangeException)
                {
                    isErrorN = true;
                    Console.WriteLine(
                        "Oops. You used too many characters.");
                }                
                catch (ArgumentNullException)
                {
                    isErrorN = true;
                    Console.WriteLine(
                        "Product name cannot be blank.");
                }                
            } while (isErrorN);
            
            bool isErrorP = false;
            do
            {
                Console.WriteLine("Please enter the price for the product.");
                try
                {
                    isErrorP = false;
                    bottle.Price = Convert.ToDecimal(Console.ReadLine());
                }
                catch (OverflowException)
                {
                    isErrorP = true;
                    System.Console.WriteLine(
                        "The conversion from string to decimal overflowed.");
                }
                catch (FormatException)
                {
                    isErrorP = true;
                    System.Console.WriteLine(
                        "The string is not formatted as a decimal.");
                }
                catch (ArgumentNullException)
                {
                    isErrorP = true;
                    System.Console.WriteLine(
                        "The string is null.");
                }
                catch (ArgumentException)
                {
                    isErrorP = true;
                    Console.WriteLine("Not a valid value.");
                }
            } while (isErrorP); // do while checks at end

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






