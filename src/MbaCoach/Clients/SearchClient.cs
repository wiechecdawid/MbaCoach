using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using NetCord.JsonConverters;

namespace MbaCoach.Clients;

public class SearchClient(HttpClient client)
{
    public async Task<SearchTeamsAndPlayersResponse> SearchAll(string query, int limit = 50)
    {
        var uri = new Uri($"https://hoopengine.liga.mba/api/v1/search?q={query}&limit={limit}");
        HttpRequestMessage request = new(HttpMethod.Get, uri);
        var response = await client.GetStringAsync(uri);
        JsonSerializerOptions opt = new()
        {
            TypeInfoResolver = SearchSerializationContext.Default
        };
        return JsonSerializer.Deserialize(response, SearchSerializationContext.Default.SearchTeamsAndPlayersResponse);
    }
}


public class SearchTeamsAndPlayersResponse
{
    public string? Query { get; set; }
    public List<SearchedPlayerResultItem>? Players { get; set; }
    public List<SearchedTeamResultItem>? Teams { get; set; }
    public List<SearchedGameResultItem>? Games { get; set; }
}

public class SearchedPlayerResultItem
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public string? TeamId { get; set; }
    public string? TeamName { get; set; }
    public sbyte? JerseyNumber { get; set; }
    public double Score { get; set; }
    public string? JerseyLabel { get; set; }
}

public class SearchedTeamResultItem
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public string? LeagueId { get; set; }
    public string? LeagueName { get; set; }
    public double Score { get; set; }
}

public class SearchedGameResultItem
{
    public string Id { get; set; }
    public DateTimeOffset Date { get; set; }
    public required string HomeTeamId { get; set; }
    public string? HomeTeamName { get; set; }
    public required string AwayTeamId { get; set; }
    public string? AwayTeamName { get; set; }
    public string? Status { get; set; }
    public double Score { get; set; }
    public object? HomeScore { get; set; } = null;
    public object? AwayScore { get; set; } = null;
    public string? HomeTeamAbbreviation { get; set; }
    public string? AwayTeamAbbreviation { get; set; }
}

[JsonSerializable(typeof(SearchTeamsAndPlayersResponse))]
[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
internal partial class SearchSerializationContext : JsonSerializerContext
{
}