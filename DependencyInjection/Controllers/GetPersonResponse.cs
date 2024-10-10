namespace DependencyInjection.Controllers;

public class GetPersonResponse
{
    public Guid Id { get; set; }
    public string Message { get; set; }
    public string Name { get; set; }
    public string Greeting { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string StarSign { get; set; }
}