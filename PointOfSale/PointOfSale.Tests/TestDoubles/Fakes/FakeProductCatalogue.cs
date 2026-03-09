using PointOfSale.Domain.Inventory.Products;

namespace PointOfSale.Tests.TestDoubles.Fakes
{
    public class FakeProductCatalogue : IProductCatalogue
    {
        private readonly Dictionary<string, ProductSpecification> _products = new();

        public void AddProduct(ProductSpecification product)
        {
            _products[product.ProductId] = product;
        }

        public ProductSpecification GetByProductId(string productId)
        {
            if (_products.TryGetValue(productId, out var product))
            {
                return product;
            }
            throw new KeyNotFoundException($"Product with ID {productId} not found in catalogue.");
        }

        public IReadOnlyDictionary<string, ProductSpecification> GetAllProducts()
        {
            return _products;
        }

        public int GetCatalogueSize()
        {
            return _products.Count;
        }
    }
}
