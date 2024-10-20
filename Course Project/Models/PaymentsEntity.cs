using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Course_Project.Models
{
    public class PaymentsEntity
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "decimal(10,2)" )]
        public decimal Amount { get; set; }
        [StringLength(50)]
        public string? FormOfPayment { get; set; }
        //FK
        [Required]
        public int CustomerId { get; set; }
        public virtual CustomersEntity Customer { get; set; }      
    }
}
