namespace Porpoise.WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using Porpoise.WebApi.Interfaces;
using Porpoise.WebApi.Models;

[ApiController]
[Route("[controller]")]
public sealed class PersonController : ControllerBase
{
    private readonly ILogger<PersonController> logger;
    private readonly IPersonRepository repository;

    public PersonController(ILogger<PersonController> logger, IPersonRepository repository) => (this.logger, this.repository) = (logger, repository);

    [HttpGet(Name = "Load")]
    public IActionResult Load(Guid id)
    {
        try
        {
            var person = this.repository.Load(id);

            if (person is null)
            {
                return this.NotFound();
            }

            return this.Ok(person);
        }
        catch (Exception exception)
        {
            this.logger.LogError(exception, exception.Message);
        }

        return this.NotFound();
    }

    [HttpPost(Name = "Save")]
    public IActionResult Save(Person person)
    {
        try
        {
            this.repository.Save(person);
            return this.Ok();

        }
        catch (Exception exception)
        {
            this.logger.LogError(exception, exception.Message);
        }

        return this.BadRequest();
    }
}
