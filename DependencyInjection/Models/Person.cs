
namespace DependencyInjection.Models;

public class Person
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public int Age { get; set; }

    public string StarSign { get; set; }

    public string Greeting { get; set; }
    
    public DateOnly DateOfBirth { get; set; }
    public string Data { get; set; }
}

public class Result<T>
{
    public bool IsSuccess { get; set; }

    public T? Data { get; set; }
}