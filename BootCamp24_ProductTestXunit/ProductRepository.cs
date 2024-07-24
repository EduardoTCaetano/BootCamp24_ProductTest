using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp24_ProductTestXunit
{
    public class ProductRepository
    {
        private ProductContext context;

        public ProductRepository()
        {
            context = new ProductContext();
        }

        public Product Add(Product product)
        {
            return context.AddProduct(product);
        }

        public Product GetById(Guid id)
        {
            return context.GetProductById(id);
        }

        public List<Product> GetAll()
        {
            return context.GetAllProducts();
        }

        public Product Update(Product product)
        {
            return context.UpdateProduct(product);
        }

        public bool Remove(Guid id)
        {
            return context.RemoveProduct(id);
        }
    }
}
