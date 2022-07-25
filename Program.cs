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
            string newline = System.Environment.NewLine;
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
                        Console.WriteLine("What is the name of your product?");// add way to test 
                        var name = Console.ReadLine(); 
                        Console.WriteLine();
                        Console.WriteLine("What is the cost of the product?");                        
                        decimal price = Convert.ToDecimal(Console.ReadLine());
                        category.AddProduct(name,price);

                    };
                    
                }
                Menu categorySelectMenu = new Menu("Choose from an existing list of categories.", optionList);
                categorySelectMenu.Start();
                
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
                        new Option("Add Product", () => addProduct()), //TODO: add dynamic menu for categories to add new product to
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
                        new Option("Remove Product", () => {}),//TODO: Select category menu for add/remove product, add warnings
                        new Option("Remove Category", () => {}),//TODO: Remove existing category, add warnings( deletes all inside category)
                        returnToMainMenuOption
                    }
                ).Start();
            }
            void startInventoryMenu() //TODO: add dynamic menu for alcohol types. look at addproduct menu but deeper
            {
                 new Menu
                (
                    "Inventory: Please select an option.",
                    new List<Option>()
                    {
                        new Option("Select Category",() => {}), 
                        returnToMainMenuOption
                    }
                ).Start();
            }
            void startEditMenu()
            {
                new Menu
                (
                    "Edit: What would you like to change?",
                    new List<Option>()
                    {
                        new Option("Category", () => {}),//TODO: create dynamic list of categories
                        new Option("Product", () => {}),//TODO: create dynamic list of products. select product -> change name or price?
                        new Option("Product Price", () => {}),
                        returnToMainMenuOption
                    }
                ).Start();
            }
            void startReportMenu()
            {
                new Menu
                (
                    "Report: What would you like to see?",
                    new List<Option>()
                    {
                        new Option("Sample", () => {}),//TODO: add options for report list
                        new Option("Sample 2", () => {}),
                        returnToMainMenuOption
                    }

                ).Start();
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

        }// show list of products. similar to option list


    }
}












