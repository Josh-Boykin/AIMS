using System;
using System.Threading;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.IO;
using System.Globalization;

namespace AIMS
{
    class MenuLoop
    {
        public static void Menu()
        {
            Console.Clear();
            MenuLoop.WriteLogo();
            Thread.Sleep(1000);
            Console.WriteLine(" Welcome to the Alcohol Inventory Managment System.\r\n Please Make a selection using the number keys.");
            Thread.Sleep(1000);
            Console.WriteLine();
            bool optionError = false;
            do
            {
                optionError = false;
                Console.Clear(); // make this not run on first pass
                WriteLogo();
                Console.WriteLine(" Welcome to the Alcohol Inventory Managment System.\r\n Please Make a selection using the number keys.");
                Console.WriteLine("\r\n1.) Inventory\r\n2.) Add\r\n3.) Remove\r\n4.) Edit\r\n5.) Report\r\n6.) Exit");
                string option = Console.ReadLine();

                if (option == "1") // INVENTORY
                {
                    Console.WriteLine("1!");
                }
                else if (option == "2") // ADD
                {
                    
                    
                    Console.WriteLine("Name?");
                    string Name = Console.ReadLine();
                    Console.WriteLine("Price?");
                    string Price = Console.ReadLine();
                    //sw.WriteLine(Name + "," + Price);
                    //Console.WriteLine();
                    
                    //sw.Close();
                }
                else if (option == "3") // REMOVE
                {
                    Console.WriteLine("3!");
                }
                else if (option == "4") // EDIT
                {
                    Console.WriteLine("4!");
                }
                else if (option == "5") // REPORT
                {
                    Console.WriteLine("5!");
                }
                else if (option == "6") // EXIT
                {
                    Console.Clear();
                    MenuLoop.WriteLogo();
                    Console.WriteLine("Are you sure you want to exit?\r\n1.) Yes\r\n2.) No");
                    string optionExit = Console.ReadLine();
                    if (optionExit == "1")
                    { 
                        Environment.Exit(0);
                    }
                    else if (optionExit == "2")
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Please select a valid option.");
                        Console.WriteLine();
                        continue;
                    }
                }
            }  while (true);
            
  

        }
        public static void WriteLogo()
        {
            string logo = @"
                                                                      ________
                  *         ******  **********  ******               /  ____  \
                 ***          **    **  **  **  **                  /  / __ \  \          
                ** **         **    **  **  **  **                 /  / /  \ \  \    
               **   **        **    **  **  **  ******            /  / / /\_\_\__\_____////
              *********       **    **      **  ******            \  \ \ \/ / /  /     \\\\       
             **       **      **    **      **      **             \  \ \__/ /  /      
            **         **     **    **      **      **              \  \____/  /
           **           **  ******  **      **  ******               \________/
";
            Console.WriteLine(logo); // inspiration from Michael Winter *

        }
    }
}
