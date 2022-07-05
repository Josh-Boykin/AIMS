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
        public string ProductName   // property
            {
                get { return productname; }
                set { productname = value; }
            }
        //Public string ProductName { get; set; }
        private decimal productprice; // field
        public decimal ProductPrice  // property
        {
            get { return productprice; }
            set { productprice = value; }
        }
        //public decimal ProductPrice { get; set; }   need to have rounded to tenths

    //string ProductName;
    //decimal ProductPrice
    }
}
