using System;
using System.Threading.Tasks;
using MbaCoach.Services;
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
GeminiService gService = new();

client.MessageCreate += async m =>
{
    if (m.Author.IsBot) return;
    
    var response = await gService.GetResponse(m.Content);
    await m.ReplyAsync(response);
  
};
await client.StartAsync();
await Task.Delay(-1);