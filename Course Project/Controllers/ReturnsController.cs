using Course_Project.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Course_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReturnsController:ControllerBase
    {
        private readonly IReturns ireturns;
        public ReturnsController(IReturns ireturns)
        {
            this.ireturns = ireturns;
        }

        [HttpDelete]
        [Route("DeleteById")]
        public IActionResult DeleteReturns(int id)
        {
            var returns = ireturns.DeleteReturns(id);
            if(returns == 0)
            {
                return NotFound("No such Id was found");
            }
            else
            {
                return Ok($"Record with id : {returns} is deleted");
            }
        }
    }
}
