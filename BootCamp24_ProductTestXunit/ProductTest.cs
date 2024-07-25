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
            Assert.Equal("Price must be greater than zero.", exception.Message);
        }

        [Fact]
        public void When_AddProductPriceIsNegative_ShouldThrowArgumentException()
        {
            var product = new Product { Name = "Product", Price = -100, Category = "Electronics" };
            var exception = Assert.Throws<ArgumentException>(() => _productContext.AddProduct(product));
            Assert.Equal("Price must be greater than zero.", exception.Message);
        }

        [Fact]
        public void When_AddProductCategoryIsInvalid_ShouldThrowArgumentException()
        {
            var product = new Product { Name = "Product", Price = 100, Category = "InvalidCategory" };
            var exception = Assert.Throws<ArgumentException>(() => _productContext.AddProduct(product));
            Assert.Equal("Invalid category.", exception.Message);
        }

        [Theory]
        [InlineData("Electronics")]
        [InlineData("Books")]
        [InlineData("Pets")]
        public void When_AddProductCategoryIsValid_ShouldAddProduct(string validCategory)
        {
            var product = new Product { Name = "Product", Price = 100, Category = validCategory };
            _productContext.AddProduct(product);

            Assert.Contains(_productContext.Products, p =>
                p.Name == "Product" &&
                p.Price == 100m &&
                p.Category == validCategory);
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
            Assert.Equal("Name is required.", exception.Message);
        }
    }
}
