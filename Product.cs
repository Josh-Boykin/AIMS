﻿using System;
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
                return Name;
            }
            set
            {
                string myString = value;
                if (value == string.Empty)// WIP need to reject null answers
                {
                    throw new ArgumentNullException ("You must enter a name");
                }
                else if (myString.Length > 20)
                {
                    throw new ArgumentOutOfRangeException(" over 20 characters not allowed for product name.");
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
                if (value <= 0)
                {
                    throw new ArgumentException();
                }                
                //decimal d = Math.Round(value, 2); alternative method
                //price = d;
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
                quantity = Math.Round(value, 1);
            } 
        }
        //public decimal Price { get; set; }       
    }
}
