namespace DependencyInjection.Services.Contracts;

public interface ICalculator
{
    public int CalculateAge(DateOnly dateOfBirth);
}