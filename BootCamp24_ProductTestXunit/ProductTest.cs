using System;
using Xunit;
using BootCamp24_ProductTestXunit;

namespace BootCamp24_ProductTestXunit
{
    public class ProductRepositoryTests
    {
        private readonly ProductRepository _productRepository;

        public ProductRepositoryTests()
        {
            _productRepository = new ProductRepository();
        }

        // Electronics category tests
        [Fact]
        public void AddElectronicsProduct_ValidProduct_ReturnsAddedProduct()
        {
            var product = new Product { Name = "Laptop", Price = 1000m, Category = "Electronics" };
            var addedProduct = _productRepository.Add(product);

            Assert.NotNull(addedProduct);
            Assert.Equal("Laptop", addedProduct.Name);
            Assert.Equal(1000m, addedProduct.Price);
            Assert.Equal("Electronics", addedProduct.Category);
        }

        [Fact]
        public void AddElectronicsProduct_ZeroPrice_ThrowsArgumentException()
        {
            var product = new Product { Name = "Laptop", Price = 0m, Category = "Electronics" };
            Assert.Throws<ArgumentException>(() => _productRepository.Add(product));
        }

        [Fact]
        public void AddElectronicsProduct_NegativePrice_ThrowsArgumentException()
        {
            var product = new Product { Name = "Laptop", Price = -1000m, Category = "Electronics" };
            Assert.Throws<ArgumentException>(() => _productRepository.Add(product));
        }

        [Fact]
        public void AddElectronicsProduct_InvalidCategory_ThrowsArgumentException()
        {
            var product = new Product { Name = "Laptop", Price = 1000m, Category = "InvalidCategory" };
            Assert.Throws<ArgumentException>(() => _productRepository.Add(product));
        }

        [Fact]
        public void AddElectronicsProduct_NullName_ThrowsArgumentException()
        {
            var product = new Product { Name = "", Price = 1000m, Category = "Electronics" };
            Assert.Throws<ArgumentException>(() => _productRepository.Add(product));
        }

        [Fact]
        public void UpdateElectronicsProduct_ValidProduct_ReturnsUpdatedProduct()
        {
            var product = new Product { Name = "Laptop", Price = 1000m, Category = "Electronics" };
            var addedProduct = _productRepository.Add(product);

            addedProduct.Price = 1200m;
            var updatedProduct = _productRepository.Update(addedProduct);

            Assert.NotNull(updatedProduct);
            Assert.Equal(1200m, updatedProduct.Price);
        }

        [Fact]
        public void GetElectronicsProductById_ValidId_ReturnsProduct()
        {
            var product = new Product { Name = "Laptop", Price = 1000m, Category = "Electronics" };
            var addedProduct = _productRepository.Add(product);
            var retrievedProduct = _productRepository.GetById(addedProduct.Id);

            Assert.NotNull(retrievedProduct);
            Assert.Equal(addedProduct.Id, retrievedProduct.Id);
            Assert.Equal("Laptop", retrievedProduct.Name);
            Assert.Equal(1000m, retrievedProduct.Price);
            Assert.Equal("Electronics", retrievedProduct.Category);
        }

        [Fact]
        public void DeleteElectronicsProduct_ValidId_RemovesProduct()
        {
            var product = new Product { Name = "Laptop", Price = 1000m, Category = "Electronics" };
            var addedProduct = _productRepository.Add(product);
            _productRepository.Remove(addedProduct.Id);
            var retrievedProduct = _productRepository.GetById(addedProduct.Id);

            Assert.Null(retrievedProduct);
        }

        // Books category tests
        [Fact]
        public void AddBooksProduct_ValidProduct_ReturnsAddedProduct()
        {
            var product = new Product { Name = "Novel", Price = 30m, Category = "Books" };
            var addedProduct = _productRepository.Add(product);

            Assert.NotNull(addedProduct);
            Assert.Equal("Novel", addedProduct.Name);
            Assert.Equal(30m, addedProduct.Price);
            Assert.Equal("Books", addedProduct.Category);
        }

        [Fact]
        public void AddBooksProduct_ZeroPrice_ThrowsArgumentException()
        {
            var product = new Product { Name = "Novel", Price = 0m, Category = "Books" };
            Assert.Throws<ArgumentException>(() => _productRepository.Add(product));
        }

        [Fact]
        public void AddBooksProduct_NegativePrice_ThrowsArgumentException()
        {
            var product = new Product { Name = "Novel", Price = -30m, Category = "Books" };
            Assert.Throws<ArgumentException>(() => _productRepository.Add(product));
        }

        [Fact]
        public void AddBooksProduct_InvalidCategory_ThrowsArgumentException()
        {
            var product = new Product { Name = "Novel", Price = 30m, Category = "InvalidCategory" };
            Assert.Throws<ArgumentException>(() => _productRepository.Add(product));
        }

        [Fact]
        public void AddBooksProduct_NullName_ThrowsArgumentException()
        {
            var product = new Product { Name = "", Price = 30m, Category = "Books" };
            Assert.Throws<ArgumentException>(() => _productRepository.Add(product));
        }

        [Fact]
        public void UpdateBooksProduct_ValidProduct_ReturnsUpdatedProduct()
        {
            var product = new Product { Name = "Novel", Price = 30m, Category = "Books" };
            var addedProduct = _productRepository.Add(product);

            addedProduct.Price = 40m;
            var updatedProduct = _productRepository.Update(addedProduct);

            Assert.NotNull(updatedProduct);
            Assert.Equal(40m, updatedProduct.Price);
        }

        [Fact]
        public void GetBooksProductById_ValidId_ReturnsProduct()
        {
            var product = new Product { Name = "Novel", Price = 30m, Category = "Books" };
            var addedProduct = _productRepository.Add(product);
            var retrievedProduct = _productRepository.GetById(addedProduct.Id);

            Assert.NotNull(retrievedProduct);
            Assert.Equal(addedProduct.Id, retrievedProduct.Id);
            Assert.Equal("Novel", retrievedProduct.Name);
            Assert.Equal(30m, retrievedProduct.Price);
            Assert.Equal("Books", retrievedProduct.Category);
        }

        [Fact]
        public void DeleteBooksProduct_ValidId_RemovesProduct()
        {
            var product = new Product { Name = "Novel", Price = 30m, Category = "Books" };
            var addedProduct = _productRepository.Add(product);
            _productRepository.Remove(addedProduct.Id);
            var retrievedProduct = _productRepository.GetById(addedProduct.Id);

            Assert.Null(retrievedProduct);
        }

        // Pets category tests
        [Fact]
        public void AddPetsProduct_ValidProduct_ReturnsAddedProduct()
        {
            var product = new Product { Name = "Dog Food", Price = 50m, Category = "Pets" };
            var addedProduct = _productRepository.Add(product);

            Assert.NotNull(addedProduct);
            Assert.Equal("Dog Food", addedProduct.Name);
            Assert.Equal(50m, addedProduct.Price);
            Assert.Equal("Pets", addedProduct.Category);
        }

        [Fact]
        public void AddPetsProduct_ZeroPrice_ThrowsArgumentException()
        {
            var product = new Product { Name = "Dog Food", Price = 0m, Category = "Pets" };
            Assert.Throws<ArgumentException>(() => _productRepository.Add(product));
        }

        [Fact]
        public void AddPetsProduct_NegativePrice_ThrowsArgumentException()
        {
            var product = new Product { Name = "Dog Food", Price = -50m, Category = "Pets" };
            Assert.Throws<ArgumentException>(() => _productRepository.Add(product));
        }

        [Fact]
        public void AddPetsProduct_InvalidCategory_ThrowsArgumentException()
        {
            var product = new Product { Name = "Dog Food", Price = 50m, Category = "InvalidCategory" };
            Assert.Throws<ArgumentException>(() => _productRepository.Add(product));
        }

        [Fact]
        public void AddPetsProduct_NullName_ThrowsArgumentException()
        {
            var product = new Product { Name = "", Price = 50m, Category = "Pets" };
            Assert.Throws<ArgumentException>(() => _productRepository.Add(product));
        }

        [Fact]
        public void UpdatePetsProduct_ValidProduct_ReturnsUpdatedProduct()
        {
            var product = new Product { Name = "Dog Food", Price = 50m, Category = "Pets" };
            var addedProduct = _productRepository.Add(product);

            addedProduct.Price = 60m;
            var updatedProduct = _productRepository.Update(addedProduct);

            Assert.NotNull(updatedProduct);
            Assert.Equal(60m, updatedProduct.Price);
        }

        [Fact]
        public void GetPetsProductById_ValidId_ReturnsProduct()
        {
            var product = new Product { Name = "Dog Food", Price = 50m, Category = "Pets" };
            var addedProduct = _productRepository.Add(product);
            var retrievedProduct = _productRepository.GetById(addedProduct.Id);

            Assert.NotNull(retrievedProduct);
            Assert.Equal(addedProduct.Id, retrievedProduct.Id);
            Assert.Equal("Dog Food", retrievedProduct.Name);
            Assert.Equal(50m, retrievedProduct.Price);
            Assert.Equal("Pets", retrievedProduct.Category);
        }

        [Fact]
        public void DeletePetsProduct_ValidId_RemovesProduct()
        {
            var product = new Product { Name = "Dog Food", Price = 50m, Category = "Pets" };
            var addedProduct = _productRepository.Add(product);
            _productRepository.Remove(addedProduct.Id);
            var retrievedProduct = _productRepository.GetById(addedProduct.Id);

            Assert.Null(retrievedProduct);

        }
    }
}
