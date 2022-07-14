using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AIMS
{
    internal class AlcoholType
    {
        private string typeName;
        public string TypeName
        {
            get
            {
                return typeName;
            }
            set
            {
                TypeName = value;
            }
        }   
        //public static void ListOfTypes(SortedSet<string> set)
        //{

        //    string set1 = string.Join(",", set);
        //    Console.WriteLine(set1);
        //    Console.ReadLine();
        //}

        public void ListOfTypes(SortedSet<string> typeNames)
        {
            foreach (string typeName in typeNames)
            {
                return; Console.WriteLine(typeName);
            }
            Console.ReadLine();
        }

        public void AddProduct(string addName, float addPrice)
        {
            addName = addName.ToLower();

            // create a new product based off my parameters
            // add product to list
        }
        public void RemoveProduct(string removeName, float removePrice) 
        {

        }
        public void EditProduct(string editName, float editPrice)
        {

        }
    }
}