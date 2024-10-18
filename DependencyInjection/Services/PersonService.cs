using DependencyInjection.Models;
using DependencyInjection.Services.Contracts;
using System.Text;

namespace DependencyInjection.Services;

public class PersonService : IPersonService
{
    private readonly ILogger<PersonService> _logger;
    private readonly ICalculator _calculator;
    private readonly IExternalApi _externalApi;
    private readonly IRepository _sqlRepository;
    private readonly IRepository _mongoRepostory;
    private readonly IGreeting _helloGreeting;
    private readonly IGreeting _holaGreeting;

    public PersonService(
        ILogger<PersonService> logger,
        ICalculator calculator,
        IExternalApi externalApi,
        [FromKeyedServices("sql")] IRepository sqlRepository,
        [FromKeyedServices("mongo")] IRepository mongoRepostory,
        [FromKeyedServices("hello")] IGreeting helloGreeting,
        [FromKeyedServices("hola")] IGreeting holaGreeting)
    {
        _logger = logger;
        _calculator = calculator;
        _externalApi = externalApi;
        _sqlRepository = sqlRepository;
        _mongoRepostory = mongoRepostory;
        _helloGreeting = helloGreeting;
        _holaGreeting = holaGreeting;
    }

    public Result<Person> GetPerson(string name, DateOnly dateOfBirth)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"GetPerson");
        Console.ResetColor();

        _logger.LogInformation("GetPerson called for {name}", name);

        var greeting = _helloGreeting.Greeting(name);
        var hola = _holaGreeting.Greeting(name);

        var age = _calculator.CalculateAge(dateOfBirth);

        var starSign = _externalApi.GetStarSign(dateOfBirth);

        var data = CreateData(name, greeting, age, starSign, dateOfBirth);

        var isSuccess = _sqlRepository.SaveData(data);
        var isSuccess2 = _mongoRepostory.SaveData(data);

        if (isSuccess)
        {
            return new Result<Person>
            {
                IsSuccess = true,
                Data = new Person
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Age = age,
                    Greeting = greeting,
                    StarSign = starSign,
                    DateOfBirth = dateOfBirth,
                    Data = data
                }
            };
        }

        return new Result<Person>
        {
            IsSuccess = false
        };
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