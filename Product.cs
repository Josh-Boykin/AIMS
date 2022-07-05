using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIMS
{
    internal class Product
    {
        private string productname; // field
        //public string ProductName   // property
        //    {
        //        get { return productname; }
        //        set { productname = value; }
        //    }
        public string ProductName { get; set; }

        private decimal productprice; // field
        public decimal ProductPrice  // property
        {
            get 
            {
                return productprice;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                //decimal d = Math.Round(value, 2); alternative method
                //productprice = d;
                productprice = Math.Round(value, 2);

            }
        }
        //public decimal ProductPrice { get; set; }

        //string ProductName;
        //decimal ProductPrice
    }
}
