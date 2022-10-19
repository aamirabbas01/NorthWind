using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DALNorthWind.Models
{
    public partial class OrderItem
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Order Number")]
        public int OrderId { get; set; }
        [DisplayName("Product Name")]
        [Required]
        public int ProductId { get; set; }
        [DisplayName("Unit Price")]
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        public int Quantity { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
