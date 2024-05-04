using Microsoft.Extensions.Hosting;
using ModuleBot.Core.Settings;
using Bot = ModuleBot.Core.ModuleBot;

var host = Host.CreateApplicationBuilder(args);
var app = host.Build();

var bot = new Bot();
if (BotSettings.TryGetBotApiKey(out var apiKey))
    bot.Init(apiKey);

app.StartAsync();

while (true) Thread.Sleep(BotSettings.ThreadSleepTime);