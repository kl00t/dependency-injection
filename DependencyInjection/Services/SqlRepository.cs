using DependencyInjection.Services.Contracts;

namespace DependencyInjection.Services;

public class SqlRepository : IRepository
{
    public bool SaveData(string data)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Saving data to SQL database");
        Console.ResetColor();
        return true;
    }
}
