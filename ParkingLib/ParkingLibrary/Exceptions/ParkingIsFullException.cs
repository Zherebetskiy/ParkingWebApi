using System;
using System.Runtime.Serialization;

namespace ParkingLibrary.Exceptions
{
    public class ParkingIsFullException :Exception
    {
        public ParkingIsFullException() { }
        public ParkingIsFullException(string message) : base(message) { }
        public ParkingIsFullException(string message, Exception inner) : base(message, inner) { }
    }
}
