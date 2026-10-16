using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MbaCoach.Models.TeamsClient;

public class TeamResponse
{
    public required string TeamId { get; set; }
    public string? SeasonId { get; set; }
    public IList<RosterItem> Roster { get; set; }
    public string? LeagueName { get; set; }
    public byte LeagueLevel { get; set; }
    public TeamStats? TeamStats { get; set; }
    public FarmRelation? FarmRelation { get; set; }
}

public class FarmRelation
{
    public string? MainTeamId { get; set; }
    public string? MainTeamName { get; set; }
    public List<FarmTeam> FarmTeams { get; set; } = [];
}

public class FarmTeam
{
    public required string TeamId { get; set; }
    public string? TeamName { get; set; }
}

public class TeamStats
{
    public required string TeamId { get; set; }
    public int GamesPlayed { get; set; }
    public int Wins { get; set; }
    public int Losses { get; set; }
    public double Ppg { get; set; }
    public double OppPpg { get; set; }
    public double Rpg { get; set; }
    public double Apg { get; set; }
    public double Spg { get; set; }
    public double Bpg { get; set; }
    public double Topg { get; set; }
    public double FgPct { get; set; }
    public double FtPct { get; set; }
    public double PointDifferential { get; set; }
}

public class RosterItem
{
    public required string PlayerId { get; set; }
    public required string PlayerName { get; set; }
    public int? JerseyNumber { get; set; }
    public required string JerseyLabel { get; set; }
    public string? Position { get; set; }
    public int Age { get; set; }
    public int HeightCm { get; set; }
    public int WeightKg { get; set; }
    public int GamesPlayed { get; set; }
    public double Ppg { get; set; }
    public double Rpg { get; set; }
    public double Apg { get; set; }
    public bool IsSuspended { get; set; }
    public string? FarmTeamId { get; set; }
    public string? FarmTeamName { get; set; }
}

[JsonSerializable(typeof(TeamResponse))]
[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
internal partial class TeamsResponseContext : JsonSerializerContext
{
}