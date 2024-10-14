using DependencyInjection.Services.Contracts;

namespace DependencyInjection.Middleware;

public class CustomMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    private readonly IOperationSingleton _singletonOperation;

    public CustomMiddleware(
        RequestDelegate next, 
        ILogger<CustomMiddleware> logger,
        IOperationSingleton singletonOperation)
    {
        _logger = logger;
        _singletonOperation = singletonOperation;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context,
        IOperationTransient transientOperation, IOperationScoped scopedOperation)
    {
        _logger.LogInformation("Middleware started");

        var transient = $"Transient: {transientOperation.OperationId}";
        _logger.LogInformation(transient);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(transient);
        Console.ResetColor();

        var scoped = $"Scoped: {scopedOperation.OperationId}";
        _logger.LogInformation(scoped);
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(scoped);
        Console.ResetColor();

        var singleton = $"Singleton: {_singletonOperation.OperationId}";
        _logger.LogInformation(singleton);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(singleton);
        Console.ResetColor();

        _logger.LogInformation("Middleware ended");

        await _next(context);
    }
}
