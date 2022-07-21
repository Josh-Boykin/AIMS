using System;

namespace AIMS
{
    public class Option
    {
        public string Description { get; set; }
        public Action Action { get; set; }
        public void Display()
        {
            Console.Write(Description);
        }
    }
}