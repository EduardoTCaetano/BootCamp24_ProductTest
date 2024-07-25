using System;
using Xunit;

namespace BootCamp24_ProductTestXunit
{
    public class ProductContextTests
    {
        private readonly ProductContext _productContext;

        public ProductContextTests()
        {
            _productContext = new ProductContext();
        }

        [Fact]
        public void When_AddProductIsValid_ShouldAddProduct()
        {
            var product = new Product { Name = "Product", Price = 100, Category = "Electronics" };
            _productContext.AddProduct(product);

            Assert.Contains(_productContext.Products, p =>
                p.Name == "Product" &&
                p.Price == 100m &&
                p.Category == "Electronics");
        }

        [Fact]
        public void When_AddProductPriceIsZero_ShouldThrowArgumentException()
        {
            var product = new Product { Name = "Product", Price = 0, Category = "Electronics" };
            var exception = Assert.Throws<ArgumentException>(() => _productContext.AddProduct(product));
        }

        [Fact]
        public void When_AddProductPriceIsNegative_ShouldThrowArgumentException()
        {
            var product = new Product { Name = "Product", Price = -100, Category = "Electronics" };
            var exception = Assert.Throws<ArgumentException>(() => _productContext.AddProduct(product));
        }

        [Theory (DisplayName ="Teste-Categoria")]
        [InlineData("Electronics", true)]
        [InlineData("Books", true)]
        [InlineData("Pets", true)]
        [InlineData("InvalidCategory", false)]

        public void When_AddProductCategoryIsChecked_ShouldHandleAccordingly(string category, bool isValid)
        {
            var product = new Product { Name = "Product", Price = 100, Category = category };

            if (isValid)
            {
                _productContext.AddProduct(product);
                Assert.Contains(_productContext.Products, p =>
                    p.Name == "Product" &&
                    p.Price == 100 &&
                    p.Category == category);
            }
            else
            {
                var exception = Assert.Throws<ArgumentException>(() => _productContext.AddProduct(product));
            }
        }
    
    [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void When_NameIsEmptyOrNull_ShouldThrowArgumentException(string invalidName)
        {
            var product = new Product
            {
                Name = invalidName,
                Price = 100,
                Category = "Electronics"
            };

            var exception = Assert.Throws<ArgumentException>(() => _productContext.AddProduct(product));
        }
    }
}
