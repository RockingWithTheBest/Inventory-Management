using Course_Project.DatabaseContext;
using Course_Project.Models;
using Course_Project.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Course_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController:ControllerBase
    {
        private readonly ApplicationDbContext db;
        private readonly IPayment ipayment;

        public PaymentController(ApplicationDbContext db, IPayment ipayment)
        {
            this.db = db;
            this.ipayment = ipayment;
        }
        [HttpGet]
        [Route("GetAll")]
        public IActionResult Index()
        {
            var payment = ipayment.GetAllPayments();
            if (payment == null)
            {
                return NotFound();
            }
            return Ok(payment);
        }
        [HttpGet]
        [Route("GetByFormOfPayment")]
        public IActionResult GetByFormOfPayment(string paymentType)
        {
            var payment = ipayment.GetByPaymentForm(paymentType);
            if (payment == null)
            {
                return NotFound();
            }
            return Ok(payment);
        }


        [HttpPost]
        [Route("AddPayment")]
        public IActionResult AddPayment(PaymentsEntity paymentaddin)
        {
            int payment = ipayment.AddPayment(paymentaddin);
            if (payment <= 0)
            {
                return BadRequest("Payment Not Added");
            }
            else
                return Ok("Added Payment" + payment);
        }

        [HttpPut]
        [Route("UpdatePaymentData")]
        public IActionResult EditPaymentData(PaymentsEntity payment)
        {
            int paymentEntity = ipayment.EditPayment(payment);
            if (paymentEntity <= 0)
            {
                return BadRequest("Payment Not Updated");
            }
            else
                return Ok("Added Payment" + paymentEntity);
        }

        [HttpDelete]
        [Route("DeletePayment")]
        public IActionResult DeletePayment(int id)
        {
            int paymentEntity = ipayment.DeletePayment(id);
            if (paymentEntity <= 0)
            {
                return BadRequest("Payment Not Deleted");
            }
            else
                return Ok("Delete Payment" + paymentEntity);
        }

    }
}
