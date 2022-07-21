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
    class Product
    {        
        public string Name
        {
            get
            {
                return Name;
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
                Name = value;
            }
        }
        public decimal Price  // property
        {
            get
            {
                return Price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                Price = Math.Round(value, 2);
            }
        }


        public decimal Quantity
        {
            get
            {
                return Quantity;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                Quantity = Convert.ToDecimal(value);
                Math.Round(value, 2); //check to see if this is working
            }
        }
        public decimal QuantityPrice
        {
            get
            {
                return QuantityPrice;
            }
            set
            {
                Decimal QuantityPrice = Decimal.Multiply(Price, Quantity);
            }
            
        }
        public void SetName()
        {
            return; //is this right?
        }
        public void SetPrice() 
        {
            return;
        }
        public override string ToString() => $"Product Name:{Name}\n Product Price:{Price}\nAmount of Inventory:{Quantity}\nValue of Inventory{QuantityPrice}";
    }
}
    
        
        