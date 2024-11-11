using Course_Project.DatabaseContext;
using Course_Project.Models;
using Course_Project.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Course_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController:ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ICustomer icustomer;
        public CustomerController(ApplicationDbContext dbContext, ICustomer icustomer)
        {
            this.dbContext = dbContext;
            this.icustomer = icustomer;
        }
        [HttpGet]
        [Route("GetAllCustomers")]
        public IActionResult Index()
        {
            var customer = icustomer.GetAllCustomer();
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        [HttpGet]
        [Route("GetByCustomerByLastName")]
        public IActionResult GetByLastName(string lastname)
        {
            var customer = icustomer.GetByLastName(lastname);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }


        [HttpPost]
        [Route("AddCustomer" +
            "")]
        public IActionResult AddCustomer(CustomersEntity cust)
        {
            int customer = icustomer.AddCustomer(cust);
            if (customer <= 0)
            {
                return BadRequest("Customer Not Added");
            }
            else
                return Ok("Added Customer" + customer);
        }

        [HttpPut]
        [Route("EditCustomerDetails")]
        public IActionResult EditCustomer(CustomersEntity customer)
        {
            int carEntity = icustomer.EditCustomerDetails(customer);
            if (carEntity <= 0)
            {
                return BadRequest("Customer Not Updated");
            }
            else
                return Ok("Edited Customer" + carEntity);
        }

        [HttpDelete]
        [Route("DeleteCustomer")]
        public IActionResult DeleteCustomer(int id)
        {
            int customer = icustomer.DeleteCustomer(id);
            if (customer <= 0)
            {
                return BadRequest("Customer Not Deleted");
            }
            else
                return Ok("Delete Customer" + customer);
        }

    }
}
