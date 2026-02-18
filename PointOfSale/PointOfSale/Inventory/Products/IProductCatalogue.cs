namespace PointOfSale.Inventory.Products
{
    // This interface is for future proofing of the product catalogue, as eventually there will be a database connection.
    public interface IProductCatalogue
    {
        void AddProduct(ProductSpecification productSpecification);
        ProductSpecification GetByProductId(string productId);
        IReadOnlyDictionary<string, ProductSpecification> GetAllProducts();
        int GetCatalogueSize();
    }
}
