using MbaCoach.Clients;
namespace MbaCoach.Tests.E2E;

public class SearchClientTests
{
    [Fact]
    public async Task Should_ReturnItemsList_WhenSearchAllRequestCalled()
    {
        // Arrange
        
        SearchClient searchClient = new (new ());
        const string Query = "king";
        // Act
        var result = await searchClient.SearchAll(Query);

        //Assert
        Assert.NotNull(result);
    }
}
