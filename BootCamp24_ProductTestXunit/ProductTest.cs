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
        public void When_AddProductIsValid_ShouldReturnAddedProduct()
        {
            var product = new Product { Name = "Product", Price = 100, Category = "Electronics" };
            var addedProduct = _productContext.AddProduct(product);

            Assert.NotNull(addedProduct);
            Assert.Equal("Product", addedProduct.Name);
            Assert.Equal(100m, addedProduct.Price);
            Assert.Equal("Electronics", addedProduct.Category);
        }

        [Fact]
        public void When_AddProductPriceIsZero_ShouldThrowArgumentException()
        {
            var product = new Product { Name = "Product", Price = 0, Category = "Electronics" };
            Assert.Throws<ArgumentException>(() => _productContext.AddProduct(product));
        }

        [Fact]
        public void When_AddProductPriceIsNegative_ShouldThrowArgumentException()
        {
            var product = new Product { Name = "Product", Price = -100, Category = "Electronics" };
            Assert.Throws<ArgumentException>(() => _productContext.AddProduct(product));
        }

        [Fact]
        public void When_AddProductCategoryIsInvalid_ShouldThrowArgumentException()
        {
            var product = new Product { Name = "Product", Price = 100, Category = "InvalidCategory" };
            Assert.Throws<ArgumentException>(() => _productContext.AddProduct(product));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void When_NameIsEmptyOrNull_ShouldThrowArgumentException(string invalidName)
        {
            var product = new Product
            {
                Name = invalidName,
                Price = 10,
                Category = "Electronics"
            };

            Assert.Throws<ArgumentException>(() => _productContext.AddProduct(product));
        }
    }
}
