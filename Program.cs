using CsvHelper;
using System.Globalization;

namespace AIMS
{
    class Program // add comments to explain what you are doing on diff parts, clear excess README add > dotnet add package CsvHelper   !!!
    {
        static void Main(string[] args)
        {                       
                List<AlcoholType> categories = new List<AlcoholType>();
                string newline = System.Environment.NewLine;

            void read() // Loads saved variables from .csv files
            {
                
                if (!Directory.Exists(@"aims_csv_files")) // creates a folder for .csv files if one does not exist.
                {
                    Directory.CreateDirectory(@"aims_csv_files");
                }
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                categories = new List<AlcoholType>();
                foreach (string file in Directory.EnumerateFiles(@"aims_csv_files\", "*.csv")) // list only filename of .csv files 
                {
                    
                    using (var reader = new StreamReader( file ))
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        csv.Context.RegisterClassMap<ProductMap>(); // registers mapping in the context
                        List<Product> records = csv.GetRecords<Product>().ToList();                       
                        AlcoholType category = new AlcoholType();                       
                        category.TypeName = file.Substring(15,file.Length - 19 ); // removing aims_csv_files\ & .csv from string (aims_csv_files\Bourbon.csv)                      
                        category.Products = records;// overrides list of products with .csv Product List                   
                        categories.Add(category);
                    }
                }
            }
            
            void save() // saves the users input to the .csv file
            {
                foreach (AlcoholType category in categories)
                {
                    using (var writer = new StreamWriter(@"aims_csv_files\" + category.TypeName + ".csv"))
                    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        csv.Context.RegisterClassMap<ProductMap>();// registers mapping in the context
                        csv.WriteRecords(category.Products);
                    }
                }

            }

            Option returnToMainMenuOption = new Option();  // added to option menus to make master loop more user friendly
            returnToMainMenuOption = new Option("Return to main menu", () => startMainMenu());
            read(); // reads previously stored data from .csv
            
            startMainMenu(); // Menu Start Function

            void addCategory() // function to add categories to store products data
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
                catch // error handling
                {
                    Console.WriteLine("There was an error with your input. Press any key to continue.");
                    Console.ReadKey();
                    startAddMenu();

                }
                startAddMenu();
            }

            void addProduct() // function to store product names and prices
            {
                List<Option> optionList = new List<Option>();
                foreach (AlcoholType category in categories)
                {
                    Option option = new Option();
                    option.Description = category.TypeName;
                    optionList.Add(option);
                    option.Action = () => // once the TypeName has been selected everything in the llamda runs 
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
            void removeProduct()// Function to delete products 
            {
                try
                {
                    List<Option> optionList = new List<Option>(); // choose the category you want to delete a product from
                    foreach (AlcoholType category in categories)
                    {
                        Option option = new Option();
                        option.Description = category.TypeName;
                        optionList.Add(option);
                        option.Action = () =>
                        {

                            List<Option> productOptionList = new List<Option>(); // Choose a product from a list of products
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
                                        new Option("Delete Product", () => category.Products.Remove(product)), // warning message to make sure you have selectied the right product
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
                    removeProduct(); // loop to the to of remove product incase you need to do another action
                }
            }

            void removeCategory() // removes category and all products assoiated
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
                                    new Option("Delete Category and all products connected.", () => 
                                    {
                                        categories.Remove(category);
                                        File.Delete(@"aims_csv_files\" + category.TypeName + ".csv");
                                    }),
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
            
            void startMainMenu() // main menu list of options that use llamda to perform a function 
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
            void startAddMenu() // menu select screen for adding products and categories
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
            void startRemoveMenu() // menu select screen for removing products and categories

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
            
            void startInventoryMenu() // menu option for adding inventory quantity
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
            
            void addQuantity() // function to take in inventory product quantities
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
                                    product.Quantity = Convert.ToDecimal(Console.ReadLine()); // had to convert string to decimal since readline can only take in a string 
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
            void startEditMenu() // Menu select screen for options that exist to be changed
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
            void categoryEdit() // function to update category name
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
                            string oldName = category.TypeName;

                            try
                            {
                                category.TypeName = Console.ReadLine();
                            }
                            finally
                            {
                                File.Delete(@"aims_csv_files\" + oldName + ".csv");
                                save();
                            }
                            
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
            void productEdit() // function to update product name
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
            void priceEdit() // function to update product prices
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
            void startReportMenu() // menu select for different report options
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
            void productPriceReport() // function that displays product name and price of 1 unit
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
            void valueReport() // function that displays product name, inventory quantity as well as the value of the inventory 
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
                            Console.WriteLine( "Name: " + product.Name + ", Inventory: " + product.Quantity + " units, Value: " + "$" + Math.Round((product.QuantityPrice), 2));// last part of line multiplies product price and quantity & displays rounding to 2 decimal points.
                        }
                        Console.WriteLine("Press any key to continue..."); //requires any key stroke to advance back to report menu
                        Console.ReadKey();
                        startReportMenu();
                    };
                }
                optionList.Add(returnToMainMenuOption);
                new Menu("Report: Choose from an existing list of categories.", optionList).Start();                
            }
            void startExitMenu() // menu select for whether or not to exit console.
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












