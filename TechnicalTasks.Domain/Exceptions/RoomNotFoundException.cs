using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalTasks.Domain.Exceptions
{
    public class RoomNotFoundException : Exception
    {
        public RoomNotFoundException() : base("Зал не знайдено") { }
    }
}
