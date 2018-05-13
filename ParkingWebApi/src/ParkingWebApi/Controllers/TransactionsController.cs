using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ParkingLibrary;
using ParkingLibrary.Exceptions;

namespace ParkingWebApi.Controllers
{
    [Route("api/[controller]")]
    public class TransactionsController : Controller
    {
        Parking parking = Parking.Instance;
        [Route("transactionlog"), HttpGet]
        public string GetTransactionLog()
        {
            return TransactionManager.GetTransactoinLog();
        }

        [Route("transactionperminute"), HttpGet]
        public List<Transaction> GetTransactionByLastMinute()
        {
            return parking.GetTransactionByLastMinute();
        }

        [HttpGet("{id}")]
        public IActionResult GetTransactionByLastMinuteByCar(string id)
        {
            List<Transaction> transactions;
            try
            {
                transactions = parking.GetTransactionByLastMinute(id);
            }
            catch (CarIsNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            return new ObjectResult(transactions);
        }

        [HttpPut("{id}")]
        public IActionResult RefillBalance(string id, [FromBody]double value)
        {
            Car car = parking.FindCarById(id);

            if (car == null)
            {
                return NotFound($"Car with id:{id} is not found!");
            }

            if (value <= 0)
            {
                return BadRequest($"Invalid input data!");
            }
            return new ObjectResult(car.Refill(value));
        }
    }
}

