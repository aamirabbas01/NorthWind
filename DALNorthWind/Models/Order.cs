using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DALNorthWind.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderItem = new HashSet<OrderItem>();
        }

        [Key]
        public int Id { get; set; }
        [DisplayName("Order Date")]
        [Required]
        public DateTime OrderDate { get; set; }
        [DisplayName("Order Number")]
        [Required]
        public string OrderNumber { get; set; }
        [DisplayName("Customer Name")]
        [Required]
        public int CustomerId { get; set; }
        [DisplayName("Total Amount")]
        public decimal? TotalAmount { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}
