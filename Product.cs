using CsvHelper.Configuration.Attributes;

namespace AIMS
{
    class Product
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
    
        
        