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

            product.Id = Guid.NewGuid();
            _products.Add(product);
            return product;
        }

        public Product GetProductById(Guid id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public List<Product> GetAllProducts()
        {
            return _products;
        }

        public Product UpdateProduct(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name))
                throw new ArgumentException("Name is required.");
            if (product.Price <= 0)
                throw new ArgumentException("Price must be greater than zero.");
            if (!new[] { "Electronics", "Books", "Pets" }.Contains(product.Category))
                throw new ArgumentException("Invalid category.");

            var existingProduct = GetProductById(product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.Category = product.Category;
            }
            return existingProduct;
        }

        public bool RemoveProduct(Guid id)
        {
            var product = GetProductById(id);
            if (product != null)
            {
                _products.Remove(product);
                return true;
            }
            return false;
        }
    }
}