using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Colorful;
//using Console = Colorful.Console;

namespace AIMS
{
    class MenuLoop
    {
        //public static void Menu()
        //{
        //    for (; ; )
        //    {
        //        Console.Clear();
        //        WriteLogo();
        //        Console.WriteLine("Please choose one of the following options.");\
        //        Console.WriteLine();
        //    }
        //}
        //public static void Say(string prefix, string message)
        //{
        //    Console.Write("[");
        //    Console.Write(prefix, Color.White);
        //    Console.Write("] " + message);
        //    Console.WriteLine();
        //}

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
            Console.WriteLine(logo, Color.Red);
        }
    }
}
