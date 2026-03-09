using PointOfSale.Domain.Inventory.Products;
using PointOfSale.Domain.Inventory.StockLevel;
using PointOfSale.Domain.Sales;

namespace PointOfSale.Application.Sales
{
    public class SaleService
    // Application Service layer to coordinate interactions between the Sale aggregate root and other parts of the system,
    // (product catalogue, inventory, sale calculator etc) for a single active sale.
    {
        // We don't want to allow a reassignment of catalogue, inventory or calculator as they are dependencies that
        // should be injected when the service is created and not changed.
        private readonly IProductCatalogue _catalogue;
        private readonly IInventoryManagement _inventory;
        private readonly ISaleCalculator _calculator;

        // _sale and CurrentSale are a guarded backing field pattern.
        private Sale? _sale; // backing field / storage of the sale

        // CurrentSale is a guard clause protecting _sale, and controlling access to _sale and performing null checks to ensure there IS a _sale
        // before allowing any operations to be performed on it. This way we can centralise the null check logic and avoid
        // repeating it in every method that needs to access _sale.
        private Sale CurrentSale =>
            _sale
            ?? throw new InvalidOperationException(
                "No active sale. Please create a sale to perform this action."
            );

        public SaleService(
            IProductCatalogue catalogue,
            IInventoryManagement inventory,
            ISaleCalculator calculator
        )
        {
            _inventory = inventory ?? throw new ArgumentNullException(nameof(inventory));
            _catalogue = catalogue ?? throw new ArgumentNullException(nameof(catalogue));
            _calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
        }

        public void CreateSale(Customer customer)
        {
            if (_sale != null)
            {
                throw new InvalidOperationException("A sale is already in progress.");
            }
            if (customer == null)
            {
                throw new ArgumentNullException(
                    nameof(customer),
                    "A valid customer must be provided to create a sale."
                );
            }
            _sale = new Sale(customer, _inventory, _catalogue);
        }

        public void AddItem(string productId, int quantity)
        {
            CurrentSale.AddItem(productId, quantity);
        }

        public decimal GetTotal()
        {
            return _calculator.CalculateTotal(CurrentSale);
        }

        public void MakePayment(decimal amount)
        {
            CurrentSale.MakePayment(amount);
        }

        public SaleStatus CompleteSale()
        {
            decimal totalDue = _calculator.CalculateTotal(CurrentSale);
            CurrentSale.CompleteSale(totalDue);

            SaleStatus status = CurrentSale.Status;
            _sale = null; // reset sale for next transaction
            return status;
        }
    }
}
