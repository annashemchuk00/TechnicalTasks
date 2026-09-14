using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalTasks.Domain.Exceptions
{
    public class NonWorkingHoursException : Exception
    {
        public NonWorkingHoursException() : base("Оренда залу можлива з 6:00 до 23:00") { }
    }
}
