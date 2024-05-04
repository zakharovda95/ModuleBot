using ModuleBot.Core.Interfaces;
using ModuleBot.Core.Settings;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ModuleBot.Core;

internal class ModuleBot : IModuleBot
{
    private async Task OnUpdate(ITelegramBotClient client, Update update, CancellationToken ctoken)
    {
        Console.WriteLine("Хех");
    }

    private async Task OnError(ITelegramBotClient client, Exception update, CancellationToken ctoken)
    {
        Console.WriteLine("Хех");
    }

    public void Init(string key)
    {
        if (string.IsNullOrEmpty(key)) return;

        var client = new TelegramBotClient(key);
        var options = new ReceiverOptions() { AllowedUpdates = Array.Empty<UpdateType>() };
        using var ctx = new CancellationTokenSource();

        client.StartReceiving(OnUpdate, OnError, options, ctx.Token);
        ShowReadyInfo(client);
    }

    private async void ShowReadyInfo(ITelegramBotClient client)
    {
        var info = await client.GetMeAsync();
        Console.WriteLine($"Бот {info.Username} c ID {info.Id} готов к работе!");
    }
}