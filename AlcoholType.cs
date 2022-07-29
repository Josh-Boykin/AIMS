namespace AIMS
{
    class AlcoholType
    {
        
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
    }
}