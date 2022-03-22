using ReactionsServiceApi.Infrastructure.Services.Interfaces;

namespace ReactionsServiceApi.Infrastructure.Services;

public class ServicesHttpClient : IServicesHttpClient //This could be broken into MoodService, ConsequenceService, etc but I'm not gonna do that
{
    private readonly HttpClient httpClient;
    private readonly IConfiguration config;

    public ServicesHttpClient(HttpClient httpClient, IConfiguration config)
    {
        this.httpClient = httpClient;
        this.config = config;
    }

    public async Task GetMoods()
    {
        var serviceEndpoint = config["MoodService"];
        try
        {
            var response = await httpClient.GetAsync(serviceEndpoint);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("SUCCESS AWWWWW YEA");
                Console.WriteLine(response.Content);
            }
            else
            {
                Console.WriteLine("bad things have happened");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }
}
