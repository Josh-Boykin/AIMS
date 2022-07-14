using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIMS
{
    internal class Product
    {
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
        private decimal price; // field
        public decimal Price  // property
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
            }
        }

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
                quantity = Convert.ToDecimal(value);

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
    
        
        