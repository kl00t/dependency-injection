namespace DiApi.Data;

public class SqlDataRepository : IDataRepository
{
    public string ReturnData()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Getting data from SQL Database.");
        Console.ResetColor();
        return ("SQL data from the database.");
    }
}