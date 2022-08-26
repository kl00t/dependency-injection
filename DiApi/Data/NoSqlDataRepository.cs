using DiApi.DataServices;

namespace DiApi.Data;

public class NoSqlDataRepository : IDataRepository
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public NoSqlDataRepository(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public string ReturnData()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Getting data from NoSQL Database.");

        using var scope = _serviceScopeFactory.CreateScope();
        var dataService = scope.ServiceProvider.GetRequiredService<IDataService>();
        dataService.GetProductData("https://something.com/api/");
        Console.ResetColor();

        return ("NoSQL data from the database.");

    }
}