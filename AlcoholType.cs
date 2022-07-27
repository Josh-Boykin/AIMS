﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using CsvHelper;
using System.IO;
using System.Globalization;
using System.ComponentModel;
namespace AIMS
{
    class AlcoholType
    {
        private string typeName;
        public string TypeName { get; set; }

        List<Product> products = new List<Product>();
  
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