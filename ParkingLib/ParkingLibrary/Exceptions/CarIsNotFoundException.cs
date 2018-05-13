using System;

namespace ParkingLibrary.Exceptions
{
    public class CarIsNotFoundException: Exception
    {
        public CarIsNotFoundException() { }
        public CarIsNotFoundException(string message) : base(message) { }
        public CarIsNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}
