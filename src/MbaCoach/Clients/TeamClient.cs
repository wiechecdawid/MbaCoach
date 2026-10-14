using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using MbaCoach.Models.TeamsClient;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace MbaCoach.Clients;

public class TeamClient(HttpClient client, string baseUri)
{
    public async Task<IEnumerable<TeamsResultItem>> GetTeamsAsync(int limit = 500)
    {
        var response = await GetStringAsync($"teams?limit ={limit}");
        return JsonSerializer.Deserialize(response, TeamsResultContext.Default.TeamsResult);
    }

    private async Task<string> GetStringAsync(string url)
    {
        var uriString = Path.Combine(baseUri, url);
        Uri uri = new Uri(uriString);
        return await client.GetStringAsync(uri);
    }
}