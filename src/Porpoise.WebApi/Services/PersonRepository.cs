namespace Porpoise.WebApi.Services;

using System;
using Marten;
using Porpoise.WebApi.Interfaces;
using Porpoise.WebApi.Models;

public sealed class PersonRepository : IPersonRepository
{
    private readonly IDocumentStore store;

    public PersonRepository(IDocumentStore store) => this.store = store;

    public Person? Load(Guid id)
    {
        using var session = this.store.LightweightSession();
        return session.Query<Person>().SingleOrDefault(p => p.Id == id);
    }

    public void Save(Person person)
    {
        using var session = this.store.LightweightSession();
        session.Store(person);
        session.SaveChanges();
    }
}
