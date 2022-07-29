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
    class Program // add comments to explain what you are doing on diff parts, clear excess README add > dotnet add package CsvHelper 
    {
        static void Main(string[] args)
        {                       
                List<AlcoholType> categories = new List<AlcoholType>();
                string newline = System.Environment.NewLine;

            void read()
            {
                categories = new List<AlcoholType>();
                foreach (string file in Directory.EnumerateFiles(@"csv_files\", "*.csv"))
                {
                    
                    using (var reader = new StreamReader( file ))
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        List<Product> records = csv.GetRecords<Product>().ToList();                       
                        AlcoholType category = new AlcoholType();                       
                        category.TypeName = file.Substring(10,file.Length - 14 ); // removing csv_files\ & .csv from string (csv_files\Bourbon.csv)                      
                        category.Products = records;// overrides list of products with .csv Product List                   
                        categories.Add(category);
                    }
                }
            }
            
            void save()
            {
                foreach (AlcoholType category in categories)
                {
                    using (var writer = new StreamWriter(@"csv_files\" + category.TypeName + ".csv"))
                    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        csv.WriteRecords(category.Products);
                    }
                }

            }

            Option returnToMainMenuOption = new Option();
            returnToMainMenuOption = new Option("Return to main menu", () => startMainMenu());
            read();
            
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
                    save();
                }
                catch
                {
                    Console.WriteLine("There was an error with your input. Press any key to continue.");
                    Console.ReadKey();
                    startAddMenu();

                }
                startAddMenu();
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
                        save();
                        startAddMenu();
                    };
                    
                }
                new Menu("Add: Choose from an existing list of categories.", optionList).Start();
   
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
                            productOptionList.Add(returnToMainMenuOption);
                            new Menu("Remove: Choose from an existing list of products.", productOptionList).Start();
                        };
                    }
                    optionList.Add(returnToMainMenuOption);
                    new Menu("Remove: Choose from an existing list of categories.", optionList).Start();
                }
                finally 
                { 
                    save(); 
                    removeProduct(); 
                }
            }

            void removeCategory()
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
                    optionList.Add(returnToMainMenuOption);
                    new Menu("Remove: Choose from an existing list of Categories.", optionList).Start();                    
                }
                finally
                {
                    save();
                    removeCategory();
                }
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
                    "Add: Would you like to add a Product or Category?",
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
                    "Remove: Would you like to remove a Product or Category?",
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

                                    Console.WriteLine("Inventory: Enter the quantity of the product by tenths.");
                                    product.Quantity = Convert.ToDecimal(Console.ReadLine());
                                    addQuantity();
                                    
                                };

                            }
                            productOptionList.Add(returnToMainMenuOption);
                            new Menu("Inventory: Choose from an existing list of products.", productOptionList).Start();                                                        
                        };

                    }
                    optionList.Add(returnToMainMenuOption);
                    new Menu("Inventory: Choose from an existing list of categories.", optionList).Start();
                }
                finally
                {
                    save();
                    addQuantity();
                }
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
                            Console.WriteLine("Edit: What would you like to change the name to?");
                            category.TypeName = Console.ReadLine();

                        };
                    }
                    optionList.Add(returnToMainMenuOption);
                    new Menu("Edit: Choose from an existing list of categories.", optionList).Start();                    
                }
                finally
                {
                    save();
                    categoryEdit();
                }
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
                                    Console.WriteLine("Edit: What would you like to change the name to?");
                                    product.Name = Console.ReadLine();
                                };

                            }
                            productOptionList.Add(returnToMainMenuOption);
                            new Menu("Edit: Choose from an existing list of products.", productOptionList).Start();                            
                        };
                    }
                    optionList.Add(returnToMainMenuOption);
                    new Menu("Edit: Choose from an existing list of categories.", optionList).Start();                    
                }
                finally
                {
                    save();
                    productEdit();
                }
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
                                    Console.WriteLine("Edit: What would you like to change the price to?");
                                    product.Price = Convert.ToDecimal(Console.ReadLine());
                                };

                            }
                            productOptionList.Add(returnToMainMenuOption);
                            Menu productSelectMenu = new Menu("Edit: Choose from an existing list of products.", productOptionList);
                            productSelectMenu.Start();

                        };

                    }
                    optionList.Add(returnToMainMenuOption);
                    new Menu("Edit: Choose from an existing list of categories.", optionList).Start();                    
                }
                finally
                {
                    save();
                    priceEdit();
                }
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
                        Console.Clear();
                        Menu.WriteLogo();
                        foreach (Product product in category.Products)
                        {
                            Console.WriteLine(product.Name + ", " + product.Price);
                        }
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        startReportMenu();
                    };
                }                
                optionList.Add(returnToMainMenuOption);
                new Menu("Report: Choose from an existing list of categories.", optionList).Start();
                
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
                        Console.Clear();
                        Menu.WriteLogo();                        
                        foreach (Product product in category.Products)
                        {
                            Console.WriteLine( "Name: " + product.Name + ", Inventory: " + product.Quantity + " units, Value: " + "$" + Math.Round((product.QuantityPrice), 2));
                        }
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        startReportMenu();
                    };
                }
                optionList.Add(returnToMainMenuOption);
                new Menu("Report: Choose from an existing list of categories.", optionList).Start();                
            }
            void startExitMenu()
            {
                save();
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












