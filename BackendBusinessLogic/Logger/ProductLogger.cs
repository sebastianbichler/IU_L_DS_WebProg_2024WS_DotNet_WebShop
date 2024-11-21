using Serilog;

public static class ProductLogger
{
    static ProductLogger()
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Hour)
            .CreateLogger();
    }

    public static void LogInformation(string message)
    {
        Log.Information(message);
    }

    public static void LogWarning(string message)
    {
        Log.Warning(message);
    }

    public static void LogError(string message)
    {
        Log.Error(message);
    }

    public static void LogDebug(string message)
    {
        Log.Debug(message);
    }

    public static void LogFatal(string message)
    {
        Log.Fatal(message);
    }
}
