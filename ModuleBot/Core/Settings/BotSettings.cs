using Microsoft.Extensions.Configuration;

namespace ModuleBot.Core.Settings;

internal static class BotSettings
{
    private static IConfigurationRoot? _configurationRoot = null;
    
    static BotSettings()
    {
        Init();
    }

    internal static int ThreadSleepTime => 3000000;

    private static void Init()
    {
        var configurationBuilder = new ConfigurationBuilder();
        var baseDirPath = AppDomain.CurrentDomain.BaseDirectory;
        var environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");
        configurationBuilder.SetBasePath(baseDirPath).AddJsonFile($"appsettings.{environment}.json");
        _configurationRoot = configurationBuilder.Build();
    }

    internal static bool TryGetBotApiKey(out string apiKey)
    {
        apiKey = "";
        if (_configurationRoot is null) return false;
        var keyLocal = _configurationRoot.GetConnectionString("BOT_API_KEY");
        if (string.IsNullOrEmpty(keyLocal)) return false;
        apiKey = keyLocal;
        return true;

    }
}