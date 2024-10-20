using System.ComponentModel.DataAnnotations;

namespace Course_Project.Models
{
    public class CustomersEntity
    {
        [Required]
        public string Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string? Position {  get; set; }

        //FK
        [Required]
        public int SellerId { get; set; }
        //Navigation Property
        public virtual SellersEntity Seller { get; set; } 
    }
}
