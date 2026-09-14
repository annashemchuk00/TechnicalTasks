using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalTasks.Domain.Exceptions
{
    public class RoomOccupiedException : Exception
    {
        public RoomOccupiedException() : base("На цей час зал вже зайнятий") { }
    }
}
