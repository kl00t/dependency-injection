using DependencyInjection.Models;

namespace DependencyInjection.Services.Contracts;

public interface IPersonService
{
    Result<Person> GetPerson(string name, DateOnly dateofBirth);
}
