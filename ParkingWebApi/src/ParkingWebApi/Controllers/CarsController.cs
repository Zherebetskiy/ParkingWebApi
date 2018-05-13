using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParkingLibrary;


// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ParkingWebApi.Controllers
{
    [Route("api/[controller]")]
    public class CarsController : Controller
    {
        Parking parking = Parking.Instance;

        [HttpGet]
        public List<Car> GetAll()
        {
            var cars = parking.cars;
            cars.Add(new Car("1", 123, CarType.Bus), new TransactionManager("1"));
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
