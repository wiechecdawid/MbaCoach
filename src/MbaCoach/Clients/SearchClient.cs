using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MbaCoach.Models.SearchClient;
using NetCord.JsonConverters;

namespace MbaCoach.Clients;

public class SearchClient(HttpClient client)
{
    public async Task<SearchAllResponse> SearchAll(string query, int limit = 50)
    {
        var uri = new Uri($"https://hoopengine.liga.mba/api/v1/search?q={query}&limit={limit}");
        HttpRequestMessage request = new(HttpMethod.Get, uri);
        var response = await client.GetStringAsync(uri);
        JsonSerializerOptions opt = new()
        {
            TypeInfoResolver = SearchSerializationContext.Default
        };
        return JsonSerializer.Deserialize(response, SearchSerializationContext.Default.SearchAllResponse);
    }
}
