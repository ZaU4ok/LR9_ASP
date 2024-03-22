using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace LR9_ASP
{
    public class WeatherComponent : ViewComponent
    {
        private readonly string _apiKey = "не знайшов api";

        public async Task<IViewComponentResult> InvokeAsync(string region)
        {
            var weatherData = await GetWeatherAsync(region);
            return View(weatherData);
        }

        private async Task<WeatherData> GetWeatherAsync(string region)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync($"http://api.openweathermap.org/data/2.5/weather?q={region}&appid={_apiKey}&units=metric");
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var weatherData = JsonSerializer.Deserialize<WeatherData>(json);
                return weatherData;
            }
        }
    }

    public class WeatherData
    {
        public MainData Main { get; set; }
        public string Name { get; set; }
    }

    public class MainData
    {
        public double Temp { get; set; }
    }
}
