using Microsoft.AspNetCore.Mvc;
using ParkingLibrary;

namespace ParkingWebApi.Controllers
{
    [Route("api/[controller]")]
    public class ParkingsController : Controller
    {
        Parking parking = Parking.Instance;

        [Route("freeplaces"), HttpGet]
        public int GetFreePlaces()
        {
            return parking.FreePlaces;
        }

        [Route("busyplaces"), HttpGet]
        public int GetBusyPlaces()
        {
            return parking.ParkingSpace - parking.FreePlaces;
        }

        [Route("balance"), HttpGet]
        public float GetBalance()
        {
            return parking.Balance;
        }
    }
}
