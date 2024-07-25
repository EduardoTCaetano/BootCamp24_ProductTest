using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp24_ProductTestXunit
{
    public class ProductContext
    {
        private readonly List<Product> _products = new();

        public Product AddProduct(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name))
                throw new ArgumentException("Name is required.");
            if (product.Price <= 0)
                throw new ArgumentException("Price must be greater than zero.");
            if (!new[] { "Electronics", "Books", "Pets" }.Contains(product.Category))
                throw new ArgumentException("Invalid category.");
            _products.Add(product);
            return product;
        }
    }
}
