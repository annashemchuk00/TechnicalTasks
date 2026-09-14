namespace TechnicalTasks.Domain.Exceptions
{
    public class InvalidDateException : Exception
    {
        public InvalidDateException() : base("Дата початку не може бути більшою за дату завершення.") { }
    }
}
