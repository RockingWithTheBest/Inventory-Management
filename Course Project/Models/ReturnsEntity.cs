using System.ComponentModel.DataAnnotations;

namespace Course_Project.Models
{
    public class ReturnsEntity
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string ShippingAddress { get; set; }
        [StringLength(50)]
        public string? Email { get; set; }
        [Required]
        [StringLength(50)]
        public string Reason { get; set; }
        public DateTime? Date { get; set; }

        //Foreign Keys
        public int? SellerId { get; set; }
        //Navigation properties
        public virtual SellersEntity Seller { get; set; }
     }
}
