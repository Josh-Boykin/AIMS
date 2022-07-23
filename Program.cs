using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsvHelper;
using System.IO;
using System.Globalization;

namespace AIMS
{
    class Program
    {
        static void Main(string[] args)
        {
            List<AlcoholType> categories = new List<AlcoholType>(); // TODO: Read categories from save file
            List<Product> products = new List<Product>();//TODO: Read products from save file
            Menu mainMenu = new Menu();
            mainMenu.Text = " Welcome to the Alcohol Inventory Managment System.";

            Option returnToMainMenuOption = new Option("Return to main menu",() => mainMenu.Start());

            Option inventoryOption = new Option
            (
                "Inventory",
                () => 
                {
                    Menu inventoryMenu = new Menu
                    (
                        "Inventory: Please select an option.",
                        new List<Option>()
                        {
                            new Option("Select Category",() => {}), //TODO: add dynamic menu for alcohol types
                            returnToMainMenuOption
                        }
                    );                
                }
            
            );
            Option addOption = new Option
            (
                "Add",
                () =>
                {
                    Menu addMenu = new Menu
                    (
                        "Would you like to add a Product or Category?",
                        new List<Option>()
                        {
                            new Option("Add Product", () => {}), //TODO: add dynamic menu for categories to add new product to
                            new Option("Add Category", () => addCategory()),//TODO: create new category
                            returnToMainMenuOption
                        }
                    );
                }
            );
            Option removeOption = new Option
            (
                "Remove",
                () =>
                {
                    Menu removeMenu = new Menu
                    (
                        "Would you like to remove a Product or Category?",
                        new List<Option>()
                        {
                            new Option("Remove Product", () => {}),//TODO: Select category menu for add/remove product, add warnings
                            new Option("Remove Category", () => {}),//TODO: Remove existing category, add warnings( deletes all inside category)
                            returnToMainMenuOption
                        }
                    );
                }
            );
            Option editOption = new Option
            (
                "Edit",
                () =>
                {
                    Menu editMenu = new Menu
                    (
                        "Edit: What would you like to change?",
                        new List<Option>()
                        {
                            new Option("Category", () => {}),//TODO: create dynamic list of categories
                            new Option("Product", () => {}),//TODO: create dynamic list of products. select product -> change name or price?
                            new Option("Product Price", () => {}),
                            returnToMainMenuOption
                        }
                    );
                }                
            );
            Option reportOption = new Option("Report", () => { });//TODO: Show total values of each categories
            Option exitOption = new Option
            (
                "Exit",
                () =>
                {
                    Menu exitMenu = new Menu
                    (
                        "Are you sure you want to exit?",
                        new List<Option>()
                        {
                            new Option("Yes",() => Environment.Exit(0)),
                            new Option("No",() => mainMenu.Start())
                        }
                    );
                    exitMenu.Start();
                }
            );
            List<Option> options = new List<Option>();
            options.Add(inventoryOption);
            options.Add(addOption);
            options.Add(removeOption);
            options.Add(editOption);
            options.Add(reportOption);
            options.Add(exitOption);


            mainMenu.Options = options;
            mainMenu.Start();

            //var reader = new StreamReader(@"C:\Users\Boomb\source\repos\AIMS\AIMS_Repository.csv"); //can put inside a using case
            //var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture); // can put inside a using case
            //var records = csvReader.GetRecords<dynamic>().ToList();

            //var writer = new StreamWriter(@"C:\Users\Boomb\source\repos\AIMS\AIMS_Repository.csv"); //can put inside a using case
            //var csvwriter = new CsvWriter(writer, CultureInfo.InvariantCulture); // can put inside a using case
            //csvwriter.WriteRecords(records);

            string newline = System.Environment.NewLine;

            AlcoholType addName = new AlcoholType();
            SortedSet<string> typeName = new SortedSet<string>()
            {
                "Vodka",
                "Gin",
                "Bourbon"
            };

            //bool isErrorT = false;
            //do
            //{
            //    Console.WriteLine("Enter a Product Category name.(ex. Vodka, Rum..)");
            //    try
            //    {
            //        isErrorT = false;
            //        typeName.AddProduct(addName = Console.ReadLine());
            //    }
            //    catch (InvalidOperationException)
            //    {
            //        Console.WriteLine("Cannot modify a set you are also iterating over");
            //    }
            //} while (isErrorT);

            //foreach (string typeName in ListOfType)
            //{
            //    typeNames.Add(type);
            //    Console.WriteLine(type);
            //}           

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
            //int isErrorM = true;
            //while 
            //Console.WriteLine("1.) Inventory\r\n2.) Add\r\n3.) Remove\r\n4.) Edit\r\n5.) Report\r\n6.) Exit");
            //string option = Console.ReadLine();
            //while (option != null)
            //{
            //    if (option == "1") // INVENTORY
            //    {
            //        Console.WriteLine("1!");
            //    }
            //    else if (option == "2") // ADD
            //    {
            //        Console.WriteLine("2!");
            //    }
            //    else if (option == "3") // REMOVE
            //    {
            //        Console.WriteLine("3!");
            //    }
            //    else if (option == "4") // EDIT
            //    {
            //        Console.WriteLine("4!");
            //    }
            //    else if (option == "5") // REPORT
            //    {
            //        Console.WriteLine("5!");
            //    }
            //    else if (option == "6") // EXIT
            //    {
            //        Console.Clear();
            //        Console.WriteLine("Are you sure you want to exit?\r\n1.) Yes\r\n2.) No");
            //        string optionExit = Console.ReadLine();
            //        if (optionExit == "1")
            //        {
            //            Environment.Exit(0);
            //        }
            //        else if (optionExit == "2")
            //        {
            //            null;
            //        }
            //    }
            //    else Console.WriteLine("Please enter a valid option");
            //}
            /*
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
            bool isErrorQ = false;
            do
            {
                Console.WriteLine("How much of the product do you have? \nYou must enter a number value by tenths (.1,2.4,etc.)");
                try
                {
                    isErrorQ = false;
                    bottle.Quantity = Convert.ToDecimal(Console.ReadLine());
                }
                catch (OverflowException)
                {
                    isErrorQ = true;
                    System.Console.WriteLine(
                        "The conversion from string to decimal overflowed.");
                }
                catch (FormatException)
                {
                    isErrorQ = true;
                    System.Console.WriteLine(
                        "The string is not formatted as a decimal.");
                }
                catch (ArgumentException)
                {
                    isErrorQ = true;
                    Console.WriteLine("Not a valid value. Please try again.");
                }
            } while (isErrorQ);

            Decimal Price = bottle.Price;
            Decimal Quantity = bottle.Quantity;
            Decimal QuantityPrice = Decimal.Multiply(Price, Quantity);

            Console.WriteLine($"Product Name: {bottle.Name}\nProduct Price: ${bottle.Price}\nAmount of Inventory: {Quantity}\nValue of Inventory: ${QuantityPrice}");
            Console.ReadLine();*/
            void addCategory() 
            {
                Console.WriteLine("Input a name for your category");
                string userInput;
                try
                {

                    userInput = Console.ReadLine();
                    AlcoholType category = new AlcoholType();
                    category.TypeName = userInput;
                    categories.Add(category);
                }
                catch
                {
                    Console.WriteLine("There was an error with your input. Press any key to continue.");
                    Console.ReadKey();
                    mainMenu.Start();

                }                
            }
        }

        
    }
}

/*
Console.WriteLine("Enter name of new product.");
Product P1 = new Product();
P1.Name = Console.Readline();
Console.ReadLine(ProductName.Name);
Console.WriteLine("Enter value of price per unit.");
*/












