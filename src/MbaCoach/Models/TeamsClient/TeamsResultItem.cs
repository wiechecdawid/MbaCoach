using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using MbaCoach.Models.SearchClient;

namespace MbaCoach.Models.TeamsClient;

public class TeamsResult : List<TeamsResultItem>
{
}

public class TeamsResultItem
{
    public required string Id { get; set; }
    public string? LeagueId { get; set; }
    public required string Name { get; set; }
    public required string Abbreviation { get; set; }
    public string? LogoUrl { get; set; }
    public string? ContactPerson { get; set; }
    public string? ContactEmail { get; set; }
    public string? ContactPhone { get; set; }
    public string? Status { get; set; }
    public string? PrimaryColour { get; set; }
    public string? SecondaryColour { get; set; }
    public string? MainTeamId { get; set; }
    public string[]? FarmTeamIds { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}

[JsonSerializable(typeof(TeamsResult))]
[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
internal partial class TeamsResultContext : JsonSerializerContext
{
}