using System;
using System.Collections.Generic;
using System.Text;

namespace ExoExceptions.Exceptions
{
    internal class InvalidAgeException : Exception
    {
        public InvalidAgeException(string message) : base(message) { }
    }
}
