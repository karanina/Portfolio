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

        private readonly ISaleIdGenerator _idGenerator;

        // Assuming a GST rate of 15% This will be later configurable in a real application, but hardcoded here for simplicity.
        private int GSTRate = 15;

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
            ISaleCalculator calculator,
            ISaleIdGenerator idGenerator
        )
        {
            _inventory = inventory ?? throw new ArgumentNullException(nameof(inventory));
            _catalogue = catalogue ?? throw new ArgumentNullException(nameof(catalogue));
            _calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
            _idGenerator = idGenerator ?? throw new ArgumentNullException(nameof(idGenerator));
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
            int saleId = _idGenerator.NextId();
            _sale = new Sale(saleId, customer, _inventory, _catalogue);
        }

        public CurrentSaleSummaryDto AddItemAndGetCurrentSummary(string productId, int quantity)
        {
            AddItem(productId, quantity);
            return GetCurrentSaleSummary();
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

        public ReceiptDto CompleteSale()
        {
            IReadOnlyList<ReceiptItemDto> items = GetCurrentSaleItems();

            // calculate the totals
            decimal subTotal = _calculator.CalculateTotal(CurrentSale);
            decimal gst = _calculator.CalculateGST(CurrentSale, GSTRate);
            decimal total = subTotal;

            // complete the sale
            CurrentSale.CompleteSale(total);

            // build the receipt DTO to return to the presentation layer
            ReceiptDto receipt = new ReceiptDto(
                CurrentSale.Id,
                new DateTime(),
                CurrentSale.Customer.Name,
                subTotal,
                gst,
                total,
                subTotal,
                items
            );

            // reset the sale for the next transaction
            _sale = null;

            return receipt;
        }

        // build receipt items from the current sale items, calculating line totals for each item using the calculator
        public IReadOnlyList<ReceiptItemDto> GetCurrentSaleItems()
        {
            return CurrentSale
                .GetItems()
                .Select(item =>
                {
                    decimal lineTotal = _calculator.CalculateLineTotal(CurrentSale, item);
                    return new ReceiptItemDto(
                        item.ProductId,
                        item.Description,
                        item.Quantity,
                        item.UnitPrice,
                        lineTotal
                    );
                })
                .ToList()
                .AsReadOnly();
        }

        // For use by presentation layer to display the current sale record, while the sale is open
        public CurrentSaleSummaryDto GetCurrentSaleSummary()
        {
            // to avoid repeated guard checks that are brought on by using CurrentSale - will only check once
            Sale sale = CurrentSale;

            decimal subtotal = _calculator.CalculateTotal(sale);
            decimal gst = _calculator.CalculateGST(sale, GSTRate);
            decimal total = subtotal;

            IReadOnlyList<ReceiptItemDto> items = GetCurrentSaleItems();

            return new CurrentSaleSummaryDto(sale.Customer.Name, subtotal, total, gst, items);
        }


    }
}
