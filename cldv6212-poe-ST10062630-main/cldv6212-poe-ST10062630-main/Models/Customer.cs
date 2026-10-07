namespace ST10062630_CLDV6212_POE.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        // Navigation property to list all orders associated with this customer
        public ICollection<Order> Orders { get; set; }  
    }
}
