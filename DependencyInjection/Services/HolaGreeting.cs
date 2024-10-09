using DependencyInjection.Services.Contracts;

namespace DependencyInjection.Services;

public class HolaGreeting : IGreeting
{
    public string Greeting(string name)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"HolaGreeting");
        Console.ResetColor();

        return $"Hola {name}.";
    }
}