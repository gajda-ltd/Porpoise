namespace Porpoise.WebApi.Models;

using System.Diagnostics;

[DebuggerDisplay("Id = {Id}, {FirstName} {LastName}")]
public sealed class Person
{
  private const int DEFAULT_YEAR_OF_BIRTH = 1900;
  private const int DEFAULT_MONTH_OF_BIRTH = 01;
  private const int DEFAULT_DAY_OF_BIRTH = 01;

  private DateTime dateOfBirth = new DateTime(DEFAULT_YEAR_OF_BIRTH, DEFAULT_MONTH_OF_BIRTH, DEFAULT_DAY_OF_BIRTH);
  public Guid Id { get; set; } = Guid.NewGuid();
  public string? FirstName { get; set; }
  public string? LastName { get; set; }
  public string? Email { get; set; }
  public string? Phone { get; set; }
  public string? Address { get; set; }
  public string? City { get; set; }
  [System.Text.Json.Serialization.JsonIgnore]
  public Nullable<int> Age
  {
    get { return DateTime.Now.Year - this.DateOfBirth.Year; }
  }
  public string? PostCode { get; set; }
  public DateTime DateOfBirth
  {
    get { return this.dateOfBirth; }
    set
    {
      if (value.Year < DEFAULT_YEAR_OF_BIRTH)
      {
        throw new DateOutOfRangeException(value);
      }

      if (value > DateTime.Now)
      {
        throw new DateOutOfRangeException(value);
      }

      this.dateOfBirth = value;
    }
  }
}