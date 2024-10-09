namespace DependencyInjection.Services.Contracts;

public interface IExternalApi
{
    string GetStarSign(DateOnly dateOfBirth);
}