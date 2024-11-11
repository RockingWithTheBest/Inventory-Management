using Course_Project.DatabaseContext;
using Course_Project.DTOs;
using Course_Project.Models;
using Course_Project.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Course_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController:ControllerBase
    {
        private readonly ICar _carRepository;

        public CarController(ICar car)
        {
            _carRepository = car;
        }
        [HttpGet]
        [Route("GetAll")]
        public ActionResult<IEnumerable<CarDto>> Index() 
        {
            var cardto = _carRepository.GetAllCars();
            if (cardto == null)
            {
                return NotFound();
            }
            return Ok(cardto);
        }
        [HttpGet]
        [Route("GetByBrand")]
        public IActionResult GetBrand(string brand)
        {
            var carBrand = _carRepository.GetByBrand(brand);
            if (carBrand == null)
            {
                return NotFound();
            }
            return Ok(carBrand);
        }


        [HttpPost]
        [Route("AddCar")]
        public IActionResult AddCar(CarDto car)
        {
            int carCreate = _carRepository.CreateCarDto(car);
            if (carCreate <= 0)
            {
                return BadRequest("Car Not Designed");
            }
            else
                return Ok("Added Car" + carCreate);
        }
        [HttpPost]
        [Route("Add Car List")]
        public ActionResult PostCarList(List<CarDto> cars)
        {
            var carList = _carRepository.CreateCarList(cars);
            if(carList == null)
            {
                return BadRequest("No cars where added");
            }
            else
            {
                return Ok("The number of added cars is :"+carList);
            }
        }
        [HttpPut]
        [Route("EditCarDetails")]
        public IActionResult EditCar(CarEntity car)
        {
            int carEntity = _carRepository.UpdateCarDetails(car);
            if (carEntity <= 0)
            {
                return BadRequest("Car Not Updated");
            }
            else
                return Ok("Added Car" + carEntity);
        }

        [HttpDelete]
        [Route("DeleteCar")]
        public IActionResult DeleteCustomer(int id)
        {
            int carEntity = _carRepository.DeleteCar(id);
            if (carEntity <= 0)
            {
                return BadRequest("Car Not Deleted");
            }
            else
                return Ok("Delete Car" + carEntity);
        }
    }
}
