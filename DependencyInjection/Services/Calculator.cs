using DependencyInjection.Services.Contracts;

namespace DependencyInjection.Services;

public class Calculator : ICalculator
{
    public int CalculateAge(DateOnly dateOfBirth)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"CalculateAge");
        Console.ResetColor();

        DateOnly today = DateOnly.FromDateTime(DateTime.Today);
        int age = today.Year - dateOfBirth.Year;

        // If the birthday hasn't occurred yet this year, subtract one year from the age
        if (dateOfBirth > today.AddYears(-age))
        {
            age--;
        }

        return age;
    }
}