using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.IO;
using System.Globalization;
using CsvHelper.Configuration.Attributes;

namespace AIMS
{
    class Product
    {        
        [Index(0)]
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {

                string myString = value;
                if (value == string.Empty)
                {
                    throw new ArgumentNullException("You must enter a name");
                }
                else if (myString.Length > 20)
                {
                    throw new ArgumentOutOfRangeException(" over 20 characters is not allowed for product name.");
                }                
                name = value;
            }
        }
        [Index(1)]
        private decimal price;
        public decimal Price  
        {
            
            get
            {
                return price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                price = Math.Round(value, 2);
                QuantityPrice = decimal.Multiply(price, quantity);
            }
        }
        [Index(2)]
        private decimal quantity;
        public decimal Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                quantity = Math.Round((value), 2);   
                QuantityPrice = decimal.Multiply(price, quantity);
            }
        }
        [Index(3)]
        private decimal quantityPrice;
        public decimal QuantityPrice
        {
            get
            {
                return decimal.Multiply(price, quantity);                
            }
            set
            {
                quantityPrice = value;
            }
        }                
    }
}
    
        
        