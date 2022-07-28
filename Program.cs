using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using CsvHelper;
using System.IO;
using System.Globalization;

namespace AIMS
{
    class Program
    {
        static void Main(string[] args)
        {
            List<AlcoholType> categories = new List<AlcoholType>(); // TODO: Read categories from save file
            string newline = System.Environment.NewLine;
            //List<Product> products = new List<Product>();
            //var reader = new StreamReader(@"C:\Users\Boomb\source\repos\AIMS\AIMS_Repository.csv"); //can put inside a using case
            //var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture); // can put inside a using case
            //var records = csvReader.GetRecords<dynamic>().ToList();

            //var writer = new StreamWriter(@"C:\Users\Boomb\source\repos\AIMS\AIMS_Repository.csv"); //can put inside a using case
            //var csvwriter = new CsvWriter(writer, CultureInfo.InvariantCulture); // can put inside a using case
            //csvwriter.WriteRecords(records);

            Option returnToMainMenuOption = new Option();
            returnToMainMenuOption = new Option("Return to main menu", () => startMainMenu());

            startMainMenu();

            void addCategory()
            {
                Console.WriteLine("Input a name for your category");
                string userInputC = string.Empty;
                try
                {

                    userInputC = Console.ReadLine();
                    AlcoholType category = new AlcoholType();
                    category.TypeName = userInputC;
                    categories.Add(category);
                }
                catch
                {
                    Console.WriteLine("There was an error with your input. Press any key to continue.");
                    Console.ReadKey();
                    startMainMenu();

                }
                startMainMenu();
            }

            void addProduct()
            {
                List<Option> optionList = new List<Option>();
                foreach (AlcoholType category in categories)
                {
                    Option option = new Option();
                    option.Description = category.TypeName;
                    optionList.Add(option);
                    option.Action = () =>
                    {
                        Console.WriteLine("What is the name of your product?");
                        string Name = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine("What is the cost of the product?");
                        decimal Price = Convert.ToDecimal(Console.ReadLine());
                        category.AddProduct(Name, Price);
                        startMainMenu();
                    };
                    
                }
                Menu categorySelectMenu = new Menu("Choose from an existing list of categories.", optionList);
                categorySelectMenu.Start();

            }
            void removeProduct()
            {
                try
                {
                    List<Option> optionList = new List<Option>();
                    foreach (AlcoholType category in categories)
                    {
                        Option option = new Option();
                        option.Description = category.TypeName;
                        optionList.Add(option);
                        option.Action = () =>
                        {

                            List<Option> productOptionList = new List<Option>();
                            foreach (Product product in category.Products)
                            {
                                Option option = new Option();
                                option.Description = product.Name;
                                productOptionList.Add(option);
                                option.Action = () =>
                                {
                                    new Menu
                                    (
                                        "Are you sure? This will permanently delete the product.",
                                        new List<Option>()
                                        {
                                        new Option("Delete Product", () => category.Products.Remove(product)),
                                        returnToMainMenuOption

                                        }
                                    ).Start();
                                };

                            }
                            Menu productSelectMenu = new Menu("Choose from an existing list of products.", productOptionList);
                            productSelectMenu.Start();

                        };

                    }
                    Menu categorySelectMenu = new Menu("Choose from an existing list of categories.", optionList);
                    categorySelectMenu.Start();
                }
                finally { startMainMenu(); }
            }

            void removeCategory()
            {
                try { 
                List<Option> optionList = new List<Option>();
                foreach (AlcoholType category in categories)
                {
                    Option option = new Option();
                    option.Description = category.TypeName;
                    optionList.Add(option);
                    option.Action = () =>
                    {
                        new Menu
                        (
                            "Are you sure? This will permanently delete all products added inside this\r\n" +
                            "category as well as the category.",
                            new List<Option>()
                            {
                                new Option("Delete Category and all products connected.", () => categories.Remove(category)),
                                returnToMainMenuOption
                            }
                        ).Start();                        
                    };
                    
                }
                Menu productSelectMenu = new Menu("Choose from an existing list of Categories.", optionList);
                productSelectMenu.Start();}
                finally { startMainMenu(); }
            }
            
            void startMainMenu()
            {
                new Menu
                (
                    " Welcome to the Alcohol Inventory Managment System.",
                    new List<Option>()
                    {
                        new Option("Inventory", () => startInventoryMenu()),
                        new Option("Add", () => startAddMenu()),
                        new Option("Remove", () => startRemoveMenu()),
                        new Option("Edit", () => startEditMenu()),
                        new Option("Report", () => startReportMenu()),
                        new Option("Exit", () => startExitMenu())
                    }
                ).Start();
            }
            void startAddMenu()
            {
                 new Menu
                (
                    "Would you like to add a Product or Category?",
                    new List<Option>()
                    {
                        new Option("Add Product", () => addProduct()), 
                        new Option("Add Category", () => addCategory()),
                        returnToMainMenuOption
                    }
                ).Start();
            }
            void startRemoveMenu() 
            {
                new Menu
                (
                    "Would you like to remove a Product or Category?",
                    new List<Option>()
                    {
                        new Option("Remove Product", () => removeProduct()),
                        new Option("Remove Category", () => removeCategory()),
                        returnToMainMenuOption
                    }
                ).Start();
            }
            
            void startInventoryMenu() 
            {
                 new Menu
                (
                    "Inventory: Please select an option.",
                    new List<Option>()
                    {
                        new Option("Select Category",() => addQuantity()),
                        returnToMainMenuOption
                    }
                ).Start();
            }startMainMenu();
            
            void addQuantity()
            {
                try
                {
                    List<Option> optionList = new List<Option>();
                    foreach (AlcoholType category in categories)
                    {
                        Option option = new Option();
                        option.Description = category.TypeName;
                        optionList.Add(option);                        
                        option.Action = () =>
                        {

                            List<Option> productOptionList = new List<Option>();
                            foreach (Product product in category.Products)
                            {
                                Option option = new Option();
                                option.Description = product.Name;
                                productOptionList.Add(option);
                                option.Action = () =>
                                {

                                    Console.WriteLine("Enter the quantity of the product by tenths.");
                                    product.Quantity = Convert.ToDecimal(Console.ReadLine());
                                    addQuantity();
                                    
                                };

                            }
                            productOptionList.Add(returnToMainMenuOption);
                            Menu productSelectMenu = new Menu("Inventory: Choose from an existing list of products.", productOptionList);
                            productSelectMenu.Start();
                            
                        };

                    }
                    optionList.Add(returnToMainMenuOption);
                    Menu categorySelectMenu = new Menu("Choose from an existing list of categories.", optionList);
                    categorySelectMenu.Start();
                }
                finally { startMainMenu(); }
            }
            void startEditMenu() 
            {
                new Menu
                (
                    "Edit: What would you like to change?",
                    new List<Option>()
                    {
                        new Option("Category", () => categoryEdit()),
                        new Option("Product", () => productEdit()),
                        new Option("Product Price", () => priceEdit()),
                        returnToMainMenuOption
                    }
                ).Start();
            }
            void categoryEdit()
            {
                try
                {
                    List<Option> optionList = new List<Option>();
                    foreach (AlcoholType category in categories)
                    {
                        Option option = new Option();
                        option.Description = category.TypeName;
                        optionList.Add(option);
                        option.Action = () =>
                        {
                            Console.WriteLine("What would you like to change the name to?");
                            category.TypeName = Console.ReadLine();

                        };
                    }
                    Menu categorySelectMenu = new Menu("Choose from an existing list of categories.", optionList);
                    categorySelectMenu.Start();
                } finally { startEditMenu(); }
            }
            void productEdit()
            {
                try
                {
                    List<Option> optionList = new List<Option>();
                    foreach (AlcoholType category in categories)
                    {
                        Option option = new Option();
                        option.Description = category.TypeName;
                        optionList.Add(option);
                        option.Action = () =>
                        {

                            List<Option> productOptionList = new List<Option>();
                            foreach (Product product in category.Products)
                            {
                                Option option = new Option();
                                option.Description = product.Name;
                                productOptionList.Add(option);
                                option.Action = () =>
                                {
                                    Console.WriteLine("What would you like to change the name to?");
                                    product.Name = Console.ReadLine();
                                };

                            }
                            Menu productSelectMenu = new Menu("Choose from an existing list of products.", productOptionList);
                            productSelectMenu.Start();

                        };

                    }
                    Menu categorySelectMenu = new Menu("Choose from an existing list of categories.", optionList);
                    categorySelectMenu.Start();
                }
                finally { startEditMenu(); }
            }
            void priceEdit()
            {
                try
                {
                    List<Option> optionList = new List<Option>();
                    foreach (AlcoholType category in categories)
                    {
                        Option option = new Option();
                        option.Description = category.TypeName;
                        optionList.Add(option);
                        option.Action = () =>
                        {

                            List<Option> productOptionList = new List<Option>();
                            foreach (Product product in category.Products)
                            {
                                Option option = new Option();
                                option.Description = product.Name;
                                productOptionList.Add(option);
                                option.Action = () =>
                                {
                                    Console.WriteLine("What would you like to change the price to?");
                                    product.Price = Convert.ToDecimal(Console.ReadLine());
                                };

                            }
                            Menu productSelectMenu = new Menu("Choose from an existing list of products.", productOptionList);
                            productSelectMenu.Start();

                        };

                    }
                    Menu categorySelectMenu = new Menu("Choose from an existing list of categories.", optionList);
                    categorySelectMenu.Start();
                }
                finally { startEditMenu(); }
            }
            void startReportMenu()
            {
                new Menu
                (
                    "Report: What would you like to see?",
                    new List<Option>()
                    {
                        new Option("Product and Price by Category", () => productPriceReport()),
                        new Option("Total Inventory Value by Category ", () => valueReport()),
                        returnToMainMenuOption
                    }

                ).Start();
            }
            void productPriceReport()
            {
                List<Option> optionList = new List<Option>();
                foreach (AlcoholType category in categories)
                {
                    Option option = new Option();
                    option.Description = category.TypeName;
                    optionList.Add(option);
                    option.Action = () =>
                    {

                        List<Option> productOptionList = new List<Option>();
                        foreach (Product product in category.Products)
                        {
                            Option option = new Option();
                            option.Description = product.Name + ", " + product.Price;
                            productOptionList.Add(option);

                        }
                        productOptionList.Add(returnToMainMenuOption);
                        Menu productSelectMenu = new Menu("Product names and cost per unit by category.", productOptionList);
                        productSelectMenu.Start();

                    };

                }
                Menu categorySelectMenu = new Menu("Choose from an existing list of categories.", optionList);
                categorySelectMenu.Start();
            }
            void valueReport()
            {
                List<Option> optionList = new List<Option>();
                foreach (AlcoholType category in categories)
                {
                    Option option = new Option();
                    option.Description = category.TypeName;
                    optionList.Add(option);
                    option.Action = () =>
                    {

                        List<Option> productOptionList = new List<Option>();
                        foreach (Product product in category.Products)
                        {
                            try
                            {
                                Option option = new Option();
                                option.Description = "Name: " + product.Name + ", Inventory: " + product.Quantity + " units, Value: " + "$" + Math.Round((product.QuantityPrice), 2);
                                productOptionList.Add(option);
                            }
                            catch (ArgumentException)
                            {
                                valueReport();
                            }

                        }
                        productOptionList.Add(returnToMainMenuOption);
                        Menu productSelectMenu = new Menu("Product name, Inventory and total value of Inventory.", productOptionList);
                        productSelectMenu.Start();

                    };

                }
                Menu categorySelectMenu = new Menu("Choose from an existing list of categories.", optionList);
                categorySelectMenu.Start();
            }
            void startExitMenu()
            {
                new Menu
                (
                    "Are you sure you want to exit?",
                    new List<Option>()
                    {
                        new Option("Yes",() => Environment.Exit(0)),
                        new Option("No",() => startMainMenu())
                    }
                ).Start();
            }
            

        }


    }
}












