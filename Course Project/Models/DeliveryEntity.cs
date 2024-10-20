using System.ComponentModel.DataAnnotations;

namespace Course_Project.Models
{
    public class DeliveryEntity
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Company { get; set; }
        [Required]
        [StringLength(50)]
        public DateTime Date { get; set; }

        //FK
        [Required]
        public int SellerId {  get; set; }
        public virtual SellersEntity Seller { get; set; }
    }
}
