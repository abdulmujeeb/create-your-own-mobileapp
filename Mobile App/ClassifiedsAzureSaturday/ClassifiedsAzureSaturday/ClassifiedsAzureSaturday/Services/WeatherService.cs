using ClassifiedsAzureSaturday.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClassifiedsAzureSaturday.Services
{
    public class WeatherService
    {
        async public Task<List<WeatherForecast>> GetWeatherForecasts()
        {
            HttpClient httpClient = new HttpClient();
            var res = await httpClient.GetStringAsync("http://saturdaybackend.azurewebsites.net/weatherforecast");
            var result = JsonConvert.DeserializeObject<List<WeatherForecast>>(res);
            return result;            
        }
    }
}
