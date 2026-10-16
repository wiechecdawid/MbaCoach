using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace MbaCoach.Clients;

 public abstract class BaseMbaClient(HttpClient httpClient, string baseUri)
 {
     protected HttpClient HttpClient = httpClient;
     protected string BaseUri = baseUri;

     protected async Task<string> GetStringAsync(string url)
     {
         var uriString = Path.Combine(BaseUri, url);
         Uri uri = new Uri(uriString);
         return await HttpClient.GetStringAsync(uri);
     }
}