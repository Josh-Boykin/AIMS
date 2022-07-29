using System;
using CsvHelper.Configuration;

namespace AIMS
{
    class ProductMap : ClassMap<Product> //inheritance
    {
        public ProductMap()
        {
            Map(m => m.Name).Name("Name");
            Map(m => m.Price).Name("Price");
            Map(m => m.Quantity).Name("Quantity");
            Map(m => m.QuantityPrice).Name("QuantityPrice");
        }
    }
}