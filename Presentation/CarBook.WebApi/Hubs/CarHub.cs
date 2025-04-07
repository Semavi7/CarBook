using System.Text.Json.Serialization;
using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace CarBook.WebApi.Hubs
{
    public class CarHub : Hub
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarHub(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task SendCarCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7062/api/Statistics/GetCarCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData);
                await Clients.All.SendAsync("ReceiveCarCount", values.carCount);
            }
            else
            {
                await Clients.All.SendAsync("ReceiveCarCount", 0);
            }
        }
    }
}
