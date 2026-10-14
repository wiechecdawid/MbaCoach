using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MbaCoach.Models.SearchClient;

public class SearchAllResponse
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

[JsonSerializable(typeof(SearchAllResponse))]
[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
internal partial class SearchSerializationContext : JsonSerializerContext
{
}