using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.IO;
using System.Globalization;


namespace AIMS
{
    class AlcoholType
    {        
        public string TypeName
        {
            get
            {
                return TypeName;
            }
            set
            {
                TypeName = value;
            }
        }          

        public void ListOfTypes(SortedSet<string> typeNames)
        {
            foreach (string typeName in typeNames)
            {
                Console.WriteLine(typeName);
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