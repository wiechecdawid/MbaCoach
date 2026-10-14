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
}