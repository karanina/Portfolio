namespace PointOfSale.Domain.Inventory.Products
{
    public class DuplicateProductException : Exception
    {
        public DuplicateProductException(string message)
            : base(message) { }
    }

    public class ProductCatalogue : IProductCatalogue
    {
        private readonly Dictionary<string, ProductSpecification> _catalogue;

        public ProductCatalogue()
        {
            _catalogue = new Dictionary<string, ProductSpecification>();
        }

        public void AddProduct(ProductSpecification productSpecification)
        {
            if (_catalogue.ContainsKey(productSpecification.ProductId))
            {
                throw new DuplicateProductException(
                    $"A product with ID {productSpecification.ProductId} already exists in the catalogue."
                );
            }
            _catalogue[productSpecification.ProductId] = productSpecification;
        }

        public IReadOnlyDictionary<string, ProductSpecification> GetAllProducts()
        {
            return _catalogue;
        }

        public int GetCatalogueSize()
        {
            return _catalogue.Count;
        }

        public ProductSpecification GetByProductId(string productId)
        {
            return _catalogue[productId];
        }
    }
}
