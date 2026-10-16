using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using MbaCoach.Models.SeasonsClient;

namespace MbaCoach.Clients;

public class SeasonsClient(HttpClient httpClient, string baseUri) : BaseMbaClient(httpClient, baseUri)
{
    public async Task<SeasonsResponseModel> GetSeasons(string leagueType = "men")
    {
        var response = await GetStringAsync($"seasons?leagueType={leagueType}");
        return JsonSerializer.Deserialize(response, SeasonsResponseModelContext.Default.SeasonsResponseModel);
    }
}