namespace DiApi.DataServices;

public class HttpDataService : IDataService
{
    public string GetProductData(string url)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Getting product data from {url}");
        Console.ResetColor();
        return ("Some product data.");
    }
}