using System.ComponentModel.DataAnnotations;

namespace Course_Project.Models
{
    public class SuppliersEntity
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name {  get; set; }
        [Required]
        [StringLength(50)]
        public string CompanyName {  get; set; }
        [Required]
        public DateTime Date {  get; set; }
        [Required]
        [StringLength(50)]
        public string ProductSupplied { get; set; }
        [StringLength(50)]
        public string? TransportUsed { get; set; }

        //FK
        public int SellerId { get; set; }
        public SellersEntity Sellers { get; set; }
    }
}
