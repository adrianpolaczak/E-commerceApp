using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApp.Domain.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2")]
        public decimal Price { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string ShipFirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string ShipLastName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string ShipCity { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 5)]
        public string ShipPostalCode { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string ShipAddress { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(256)]
        public string ContactEmail { get; set; }

        [Required]
        [Phone]
        public string ContactPhoneNumber { get; set; }
    }
}
