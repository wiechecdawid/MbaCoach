using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using MbaCoach.Models.TeamsClient;
using NetCord;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace MbaCoach.Clients;

public class TeamClient(HttpClient client, string baseUri) : BaseMbaClient(client, baseUri)
{
    public async Task<IEnumerable<TeamsResultItem>> GetTeamsAsync(int limit = 500)
    {
        var response = await GetStringAsync($"teams?limit ={limit}");
        return JsonSerializer.Deserialize(response, TeamsResultContext.Default.TeamsResult);
    }

    public async Task<TeamResponse> GetTeamAsync(string teamId, string seasonId)
    {
        var response = await GetStringAsync($"teams/{teamId}?seasonId={seasonId}");
        return JsonSerializer.Deserialize(response, TeamsResponseContext.Default.TeamResponse);
    }

    public async Task<TeamGamesResponse> GetTamGamesAsync(string teamId)
    {
        var response = await GetStringAsync($"teams/{teamId}/games");
        return JsonSerializer.Deserialize(response, TeamGamesResponseContext.Default.TeamGamesResponse);
    }
}