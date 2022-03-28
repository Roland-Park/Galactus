namespace GalactusBlazorUI.Data;

public interface IWeatherForecastService
{
    Task GetMoods();
}

public class WeatherForecastService : IWeatherForecastService
{
    HttpClient httpClient;
    public WeatherForecastService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public async Task GetMoods()
    {
        var serviceEndpoint = "http://mood-clusterip-srv:80/mood";
        //var serviceEndpoint = "http://localhost:31994/mood";
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
                Console.WriteLine("response status does not indicate success.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error with httpClient: {ex.Message}");
        }
    }

    public class Mood
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
