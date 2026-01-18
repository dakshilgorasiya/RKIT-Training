using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExceptionHandlingDemo.Exceptions
{
    /// <summary>
    /// A custom exception to represent invalid values.
    /// </summary>
    public class InvalidValueException : Exception
    {
        /// <summary>
        /// A constructor that takes a message.
        /// </summary>
        /// <param name="message">Exception message</param>
        public InvalidValueException(string message): base(message) { }
    }
}