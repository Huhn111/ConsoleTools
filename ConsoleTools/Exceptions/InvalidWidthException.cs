using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTools.Exceptions
{
    public class InvalidWidthException : Exception
    {
        public InvalidWidthException() : base("The Width is Invalid") { }

        public InvalidWidthException(string? message) : base(message) { }

        public InvalidWidthException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
