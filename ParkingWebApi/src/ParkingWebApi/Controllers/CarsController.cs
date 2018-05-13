using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ParkingLibrary;

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
        public Car GetById(string id)
        {
            return parking.FindCarById(id);
        }

        [HttpPost]
        public void Post([FromBody]Car car)
        {
            parking.AddCar(car);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            parking.RemoveCar(id);
        }
    }
}
