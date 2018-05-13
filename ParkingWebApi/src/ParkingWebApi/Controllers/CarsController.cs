using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ParkingLibrary;
using ParkingLibrary.Exceptions;

namespace ParkingWebApi.Controllers
{
    [Route("api/[controller]")]
    public class CarsController : Controller
    {
        Parking parking = Parking.Instance;

        [HttpGet]
        public List<Car> GetAll()
        {
            return parking.cars.Keys.ToList();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var car = parking.FindCarById(id);
            if (car == null)
            {
                return NotFound($"Car with id:{id} is not found!");
            }
            return new ObjectResult(car);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Car car)
        {
            if (car == null)
            {
                return BadRequest();
            }

            try
            {
                parking.AddCar(car);
            }
            catch (ParkingIsFullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DuplicateCarIdException ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                parking.RemoveCar(id);
            }
            catch (CarIsNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (FinePresentException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}
