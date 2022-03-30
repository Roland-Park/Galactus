
using ReactionsServiceApi.Entities;
using ReactionsServiceApi.Infrastructure.Services.SynchronousData.Interfaces;
using System.Text.Json;

namespace ReactionsServiceApi.Infrastructure.Services.SynchronousData;

public class ServicesHttpClient : IServicesHttpClient //This could be broken into MoodService, ConsequenceService, etc but I'm not gonna do that
{
    private readonly HttpClient httpClient;
    private readonly IConfiguration config;

    public ServicesHttpClient(HttpClient httpClient, IConfiguration config)
    {
        this.httpClient = httpClient;
        this.config = config;
    }

    public async Task<List<Mood>> GetMoods()
    {
        var serviceEndpoint = config["MoodService"];
        try
        {
            var response = await httpClient.GetAsync(serviceEndpoint);
            
            if (response.IsSuccessStatusCode)
            {
                var contents = await response.Content.ReadAsStringAsync();
                var moods = JsonSerializer.Deserialize<List<Mood>>(contents);
                Console.WriteLine("SUCCESS AWWWWW YEA");
                Console.WriteLine($"{moods.Count} moods returned");
                return moods;
            }
            else
            {
                var error = "response status does not indicate success.";
                Console.WriteLine(error);
                throw new Exception(error);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error with httpClient: {ex.Message}");
            return null;
        }
        
    }
}
