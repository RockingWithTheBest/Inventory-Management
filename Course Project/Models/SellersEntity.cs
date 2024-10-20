using System.ComponentModel.DataAnnotations;

namespace Course_Project.Models
{
    public class SellersEntity
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string? Address { get; set; }
        public int? PhoneNumber { get; set; }
        public List<CarEntity> Cars { get;  } = new List<CarEntity>();
        //FK
        public int? ReturnsId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int Quantity { get; set; }
        public virtual ReturnsEntity Return { get; set; }
        public virtual CustomersEntity Customer { get; set; }
    }
}
