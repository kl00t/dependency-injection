
using System.Globalization;
using System.Text;
using DependencyInjection.Services.Contracts;

namespace DependencyInjection.Services;

public class PersonService : IPersonService
{
    private readonly ILogger<PersonService> _logger;
    private readonly ICalculator _calculator;
    private readonly IRepository _repository;
    private readonly IExternalApi _externalApi;
    private readonly IGreeting _greeting;

    public PersonService(
        ILogger<PersonService> logger, 
        ICalculator calculator, 
        IRepository repository, 
        IExternalApi externalApi,
        IGreeting greeting)
    {
        _logger = logger;
        _calculator = calculator;
        _repository = repository;
        _externalApi = externalApi;
        _greeting = greeting;
    }

    public string? GetPerson(string name, DateOnly dateOfBirth)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"GetPerson");
        Console.ResetColor();

        _logger.LogInformation("GetPerson called for {name}", name);

        var greeting = _greeting.Greeting(name);

        var age = _calculator.CalculateAge(dateOfBirth);

        var starSign = _externalApi.GetStarSign(dateOfBirth);

        var data = CreateData(name, greeting, age, starSign, dateOfBirth);

        var isSuccess = _repository.SaveData(data);
        if (isSuccess)
        {
            return data;
        }

        return null;
    }

    private static string CreateData(string name, string greeting, int age, string starSign, DateOnly dateOfBirth)
    {
        var sb = new StringBuilder();
        sb.Append($"Name: {name}\n")
        .AppendLine($"Greeting: {greeting}\n")
        .AppendLine($"Age: {age}\n")
        .AppendLine($"Date Of Birth: {dateOfBirth}\n")
        .AppendLine($"Star Sign: {starSign}\n");
        return sb.ToString();
    }
}