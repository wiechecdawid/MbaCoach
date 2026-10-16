using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MbaCoach.Models.SeasonsClient;

public class SeasonsResponseModel : List<SeasonsResponseItem>
{
}

public class SeasonsResponseItem
{
    public required string Id { get; set; }
    public string? LeagueId { get; set; }
    public string? Name { get; set; }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public string? Status { get; set; }
    public required string SeasonStatus { get; set; }
    public List<ReopenHistory> ReopenHistory { get; set; } = [];
    public string LeagueType { get; set; } = "men";
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}

public class ReopenHistory
{
    public required string Reason { get; set; }
    public DateTimeOffset ReopenedAt { get; set; }
    public string? ReopenedBy { get; set; }
}

[JsonSerializable(typeof(SeasonsResponseModel))]
[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
internal partial class SeasonsResponseModelContext : JsonSerializerContext{}