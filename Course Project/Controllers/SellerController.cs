using Course_Project.Repository.Implementation;
using Course_Project.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Course_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController:ControllerBase
    {
        private readonly ISeller seller_repo;
        public SellerController(ISeller seller_repo)
        {
            this.seller_repo = seller_repo;
        }

        [HttpDelete]
        [Route("DeleteById")]
        public IActionResult DeleteSeller(int id) 
        {
            var seller = seller_repo.DeleteInstance(id);
            if (seller == null)
            {
                return BadRequest("No instance was deleted");
            }
            else
            {
                return Ok($"Seller with id :{seller} is now deleted");
            }
        }
    }
}
