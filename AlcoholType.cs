using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AIMS
{
    internal class AlcoholType
    {
        private string type;
        public string Type
        {
            get
            {
                return type;
            }
            set
            {

            }
        }  

        List<Product> productList = new List<Product>();
          
        
        public void AddProduct(string addName, float addPrice)
        {
            return;
            // create a new product based off my parameters
            // add product to  list
        }
        public void RemoveProduct(string removeName, float removePrice) 
        {

        }
    }
}