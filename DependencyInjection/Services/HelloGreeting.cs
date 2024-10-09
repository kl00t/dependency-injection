using DependencyInjection.Services.Contracts;

namespace DependencyInjection.Services;

public class HelloGreeting : IGreeting
{
    public string Greeting(string name)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"HelloGreeting");
        Console.ResetColor();

        return $"Hello {name}.";
    }
}
