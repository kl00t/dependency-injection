using DependencyInjection.Services.Contracts;

namespace DependencyInjection.Services;

public class MongoRepository : IRepository
{
    public bool SaveData(string data)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Saving data to Mongo database");
        Console.ResetColor();
        return true;
    }
}