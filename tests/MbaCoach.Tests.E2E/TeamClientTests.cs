using MbaCoach.Clients;

namespace MbaCoach.Tests.E2E;

public class TeamClientTests
{
    [Fact]
    public async Task Should_GetListOfTeams()
    {
        // Arrange
        TeamClient client = new(new(), Constants.HttpConstants.BaseUri);
        
        // Act
        var result = await client.GetTeamsAsync();
        
        // Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }
    
    [Fact]
    public async Task Should_GetTeamById()
    {
        // Arrange
        TeamClient teamClient = new(new(), Constants.HttpConstants.BaseUri);
        SeasonsClient seasonsClient = new(new (),  Constants.HttpConstants.BaseUri);
        var items = await teamClient.GetTeamsAsync();
        var season = (await seasonsClient.GetSeasons())
            .FirstOrDefault(season => season.SeasonStatus.Equals("active",
                StringComparison.InvariantCultureIgnoreCase));
        Assert.NotNull(season);
        var team = items.First();
        
        // Act
        var result = await teamClient.GetTeam(team.Id, season?.Id);
        
        // Assert
        Assert.NotNull(result);
        Assert.Equal(team.Id, result.TeamId);
    }
}