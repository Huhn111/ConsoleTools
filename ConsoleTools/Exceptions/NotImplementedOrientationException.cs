using ConsoleTools.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTools.Exceptions
{
    public class NotImplementedOrientationException : Exception
    {

        public Orientations InvalidOrientation { get; private set; }

        public NotImplementedOrientationException(Orientations orientation) : base($"The Orientation is not yet implemented (Orientation: {orientation})")
        {
            InvalidOrientation = orientation;
        }

        public NotImplementedOrientationException(Orientations orientation, string? message) : base(message) => InvalidOrientation = orientation;

        public NotImplementedOrientationException(Orientations orientation, string? message, Exception? innerException) : base(message, innerException) => InvalidOrientation = orientation;
    }
}
