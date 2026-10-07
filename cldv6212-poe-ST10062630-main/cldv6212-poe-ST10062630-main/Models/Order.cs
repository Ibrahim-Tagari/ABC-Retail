
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ST10062630_CLDV6212_POE.Models
{

    public class Order
    {
        public int OrderID { get; set; }

        [Required]
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }

        [Required]
        [ForeignKey("Product")]
        public int ProductID { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        // Navigation properties
        public Customer Customer { get; set; }
        public Product Product { get; set; }
    }

}
