using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIsAndJSON
{
    public class OpenWeatherMapAPI
    {
        public static void getWeather()
        {
            var client = new HttpClient();

            var key = "0bde42fe4305c6a2ee40be06ba23cdda";
            //var city = "Santa Rosa";
            Console.WriteLine("Enter a city name to get the weather: ");
            var city = Console.ReadLine();

            var weatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={key}&units=imperial";
            var response = client.GetStringAsync(weatherUrl).Result;

            JObject formattedResponse = JObject.Parse(response);
            //Console.WriteLine(formattedResponse.ToString());
            var temp = formattedResponse["main"]["temp"];
            Console.WriteLine($"The current temperature is: {temp} F");
        }
        
    }
}
