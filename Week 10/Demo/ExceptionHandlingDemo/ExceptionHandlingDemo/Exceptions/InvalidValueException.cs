using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExceptionHandlingDemo.Exceptions
{
    public class InvalidValueException : Exception
    {
        public InvalidValueException(string message): base(message) { }
    }
}