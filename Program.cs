using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherApp.Models; // Import the models
using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherApp.Models; // Import the models

class Program
{
    static async Task Main()
    {
        int lat = 59;
        int lon = 10;

        string url = $"https://api.met.no/weatherapi/locationforecast/2.0/compact?lat={lat}&lon={lon}";

        using HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Add("User-Agent", "YourAppName/1.0 (your@email.com)"); // Required for Met.no API

        HttpResponseMessage response = await client.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            string json = await response.Content.ReadAsStringAsync();

            // Save JSON (Pretty)
            string directory = "_tmp";
            string filePath = Path.Combine(directory, "met_no_weatherapi.json");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            await File.WriteAllTextAsync(filePath, JsonSerializer.Serialize(
                JsonSerializer.Deserialize<JsonElement>(json), new JsonSerializerOptions { WriteIndented = true }));

            Console.WriteLine($"Program·Main()·Pretty JSON saved to {filePath}");

            // Deserialize JSON
            WeatherResponse? weather = JsonSerializer.Deserialize<WeatherResponse>(json);

            if (weather?.Properties?.TimeSeries != null && weather.Properties.TimeSeries.Count > 0)
            {
                var latestData = weather.Properties.TimeSeries[0]; // Get the first time series entry
                Console.WriteLine($"Program·Main()·Temperature: {latestData.Data.Instant.Details.Temperature}°C");
                Console.WriteLine($"Program·Main()·Wind Speed: {latestData.Data.Instant.Details.WindSpeed} m/s");
                Console.WriteLine($"Program·Main()·Humidity: {latestData.Data.Instant.Details.Humidity}%");
                Console.WriteLine($"Program·Main()·Weather Symbol: {latestData.Data.Next1Hours.Summary.SymbolCode}");
            }
            else
            {
                Console.WriteLine("Program·Main()·Error: Weather data is missing or incomplete.");
            }
        }
        else
        {
            Console.WriteLine($"Program·Main()·Error: HTTP {response.StatusCode} - {response.ReasonPhrase}");
        }
    }
}
