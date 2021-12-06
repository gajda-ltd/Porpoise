namespace Porpoise.WebApi.Interfaces;

using Porpoise.WebApi.Models;

public interface IPersonRepository
{
    Person? Load(Guid id);
    void Save(Person person);
}
