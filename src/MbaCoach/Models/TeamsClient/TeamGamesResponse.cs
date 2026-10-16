using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MbaCoach.Models.TeamsClient;

public class TeamGamesResponse
{
    public required string TeamId { get; set; }
    public IList<TeamGame> Games { get; set; } = [];
    public int Total { get; set; }
}

public class TeamGame
{
    public required string GameId { get; set; }
    public required string SeasonId { get; set; }
    public required string OpponentId { get; set; }
    public string? OpponentName { get; set; }
    public byte Pts { get; set; }
    public byte OppPts { get; set; }
    public byte Reb { get; set; }
    public byte Ast { get; set; }
    public byte Stl { get; set; }
    public byte Blk { get; set; }
    public byte To { get; set; }
    public double FgPct { get; set; }
    public double ThreePct { get; set; }
    public required string Result { get; set; }
    public DateTimeOffset GameDate { get; set; }
}

[JsonSerializable(typeof(TeamGamesResponse))]
[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
internal partial class TeamGamesResponseContext : JsonSerializerContext{}