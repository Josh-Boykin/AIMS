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
        
        private string description;
        public string Description { get; set; }
        
        private Action action;
        public Action Action { get; set; }

        public void Display()
        {
            Console.Write(Description);
        }
    }
}