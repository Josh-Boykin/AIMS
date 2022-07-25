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
            /*List<Product> products = new List<Product>();*///TODO: Read products from save file
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
                    inventoryMenu.Start();
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
                            new Option("Add Product", () => addProduct()), //TODO: add dynamic menu for categories to add new product to
                            new Option("Add Category", () => addCategory()),
                            returnToMainMenuOption
                        }
                    );
                    addMenu.Start();
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
                    removeMenu.Start();
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
                    editMenu.Start();
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

            void addCategory() 
            {
                Console.WriteLine("Input a name for your category");
                string userInput = string.Empty;                
                try
                {

                    userInput = Console.ReadLine();
                    AlcoholType category = new AlcoholType(); 
                    category.setTypeName(userInput);                    
                    categories.Add(category);
                }
                catch
                {
                    Console.WriteLine("There was an error with your input. Press any key to continue.");
                    Console.ReadKey();
                    mainMenu.Start();

                }
                mainMenu.Start();
            }
            void addProduct()
            {
                List<Option> optionList = new List<Option>();
                foreach (AlcoholType category in categories)
                {
                    Option option = new Option();                    
                    option.Description = category.TypeName;
                    optionList.Add(option);
                }                
                Menu categorySelectMenu = new Menu("Choose from an existing list of categories.", optionList );
                categorySelectMenu.Start();
            } 

        }

        
    }
}












