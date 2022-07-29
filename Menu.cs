namespace AIMS
{
    internal class Menu
    {

        public Menu(string Text, List<Option> Options) 
        {
            this.Text = Text;
            this.Options = Options;
        }        

        private string text;
        public string Text { get; set; }

        private List<Option> options;
        public List<Option> Options { get; set; }

        public void DisplayText()
        {
            Console.WriteLine(Text);
        }
        public void DisplayOptions()
        {
            int i = 1;
            foreach (var option in Options) //numbers a dynamic list that can change in size
            {
                Console.Write(i++ + ".) ");
                option.Display();
                Console.Write("\r\n");
            }
        }
        public void Start()
        {
            Console.Clear();
            WriteLogo();
            DisplayText();
            Console.WriteLine();
            DisplayOptions();
            Console.WriteLine();
            RequestInput();
        }
        public void RequestInput()
        {
            Console.WriteLine();
            Console.WriteLine("Please type an option using the number keys.");

            try
            {
                string numberString = Console.ReadLine();
                int number = int.Parse(numberString);
                Options.ElementAt(number - 1).Action();
            }
            catch
            {
                Console.WriteLine("There was an error with your input. Press any key to continue.");
                Console.ReadKey();
                this.Start();

            }

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
