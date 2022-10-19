using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DALNorthWind.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Product = new HashSet<Product>();
        }

        [Key]
        public int Id { get; set; }
        [DisplayName("Company Name")]
        [Required]
        public string CompanyName { get; set; }
        [DisplayName("Contact Name")]
        [Required]
        public string ContactName { get; set; }
        [DisplayName("Contact Title")]
        public string ContactTitle { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
