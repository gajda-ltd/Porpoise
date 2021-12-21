namespace Porpoise.WebApi.Models;

public sealed class DateOutOfRangeException : Exception
{
  public DateOutOfRangeException(DateTime dateTime) : base($"'{dateTime:yyyy-MM-DD}' out of range")
  {

  }
}