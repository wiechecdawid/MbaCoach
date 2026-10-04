using System;
using System.Threading.Tasks;
using NetCord;
using NetCord.Gateway;

var token = Environment.GetEnvironmentVariable("DISCORD_TOKEN")
            ?? throw new InvalidOperationException("Missing environment variable 'DISCORD_TOKEN'");
var teamName = Environment.GetEnvironmentVariable("HOOPENGINE_TEAM_NAME")
               ?? throw new InvalidOperationException("Missing environment variable TEAM_NAME");

GatewayClient client = new(new BotToken(token), new GatewayClientConfiguration
{
    Intents = GatewayIntents.GuildMessages | GatewayIntents.MessageContent
});

client.MessageCreate += async m =>
{
    if (m.Content == "!ping")
    {
        await m.ReplyAsync($"Pong! {teamName}");
    }
};
await client.StartAsync();
await Task.Delay(-1);