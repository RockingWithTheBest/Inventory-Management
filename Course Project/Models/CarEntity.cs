using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Course_Project.Models
{
    public class CarEntity
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Brand { get; set; }
        public DateOnly? Year { get; set; }
        [Required]
        [StringLength(50)]
        public string Mileage {  get; set; }
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Cost { get; set; }
        //Foreign Keys
        public int? SellerId { get; set; }

        //Navigation Properties
        public virtual SellersEntity Seller { get; set; }
   

    }
}
