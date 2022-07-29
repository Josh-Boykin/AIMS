using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.ComponentModel;
using CsvHelper.Configuration.Attributes;

namespace AIMS
{
    class AlcoholType
    {
        [Index(0)]
        private string typeName;
        public string TypeName { get; set; }

        
        private List<Product> products = new List<Product>();
        public List<Product> Products { get { return products; } set {products = value; } }
  

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