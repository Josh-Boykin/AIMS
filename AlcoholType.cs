using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.ComponentModel;
namespace AIMS
{
    class AlcoholType
    {
        [DefaultValue("DefaultName")]
        public string TypeName { get; set; }
        //{
        //    get
        //    {
        //        return TypeName;
        //    }
        //    set
        //    {
        //        try
        //        {
        //            TypeName = value;
        //        }
        //        catch (StackOverflowException e)
        //        {
        //            Console.WriteLine("The user input overflowed");
        //            Console.WriteLine("value =" + value);
        //            Console.WriteLine("TypeName =" + TypeName);
        //            Console.WriteLine(e.Message);
        //        }
        //    }
        //}
        List<Product> products = new List<Product>();
        public void setTypeName(string TypeName)
        {
            this.TypeName = TypeName;
        }
        
        public static void ListOfTypes(SortedSet<string> typeNames)
        {
            foreach (string typeName in typeNames)
            {
                Console.WriteLine(typeName);
            }
            Console.ReadLine();
        }

        public void AddProduct(string addName, decimal addPrice)
        {
            Product product = new Product();
            product.Name = addName;
            product.Price = addPrice;
            products.Add(product);
        }
        public void RemoveProduct(string removeName) 
        {
            foreach (Product product in products)
            {
                if (product.Name == removeName)
                {
                    products.Remove(product);
                }
            }
        }
        public void EditProduct( string previousName, string editName, decimal editPrice)
        {
            foreach (Product product in products)
            {
                if (product.Name == previousName)
                {
                    product.Name = editName;
                    product.Price = editPrice;
                }
            }
        }
    }
}