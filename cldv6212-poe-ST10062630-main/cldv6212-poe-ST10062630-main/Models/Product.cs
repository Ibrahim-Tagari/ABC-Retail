namespace ST10062630_CLDV6212_POE.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        // Navigation property to list all orders associated with this product
        public ICollection<Order> Orders { get; set; }
    }
}
