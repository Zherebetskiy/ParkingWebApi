using System;
using System.Runtime.Serialization;

namespace ParkingLibrary.Exceptions
{
    public class FinePresentException :Exception
    {
        public FinePresentException() { }
        public FinePresentException(string message) : base(message) { }
        public FinePresentException(string message, Exception inner) : base(message, inner) { }
    }
}
