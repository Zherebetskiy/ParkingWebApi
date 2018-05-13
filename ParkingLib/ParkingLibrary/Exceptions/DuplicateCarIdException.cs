using System;

namespace ParkingLibrary.Exceptions
{
    public class DuplicateCarIdException : Exception
    {
        public DuplicateCarIdException() { }
        public DuplicateCarIdException(string message) : base(message) { }
        public DuplicateCarIdException(string message, Exception inner) : base(message, inner) { }
    }
}
