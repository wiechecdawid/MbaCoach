using System;
using System.Threading.Tasks;
using Google.GenAI;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;

namespace MbaCoach.Services;

public class GeminiService
{
    private const string Instructions = """
                                        You are a basketball coach. You pass random basketball tips to any request.
                                        """;
    private static readonly string ApiKey = Environment.GetEnvironmentVariable("GEMINI_API_KEY") ??
                             throw new Exception("Gemini_API_KEY is missing");
    private static readonly string Model = Environment.GetEnvironmentVariable("GEMINI_MODEL") ?? "gemini-3.8-flash";
    private IChatClient _client = new Client(vertexAI: false, apiKey: ApiKey).AsIChatClient(Model);
        

    public async Task<string> GetResponse(string message)
    {
        try
        {
            ChatOptions options = new() { Instructions = Instructions };
            var response = await _client.GetResponseAsync(message, options);
            return response.Text;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Gemini ERROR] Wystąpił błąd podczas odpytywania Gemini: {ex.Message}");
            Console.WriteLine(ex.StackTrace);
            return "Przepraszam, mam problem z połączeniem z bazą wiedzy.";
        }
    }
}