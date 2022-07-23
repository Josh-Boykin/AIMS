using System;

namespace AIMS
{
    public class Option
    {

        public Option(string Description, Action Action)
        {
            this.Action = Action;
            this.Description = Description;
        }
        
        public Option() { }

        public string Description { get; set; }
        public Action Action { get; set; }
        public void Display()
        {
            Console.Write(Description);
        }
    }
}