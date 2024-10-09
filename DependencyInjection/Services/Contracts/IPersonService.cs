namespace DependencyInjection.Services.Contracts;

public interface IPersonService
{
    string? GetPerson(string name, DateOnly dateofBirth);
}
