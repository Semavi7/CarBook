using CarBook.Dto.AuthorDtos;
using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Packaging.Signing;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminStatistics")]
    public class AdminStatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminStatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            Random random = new Random();
            var client = _httpClientFactory.CreateClient();

            #region İstatistik1
            var responseMessage = await client.GetAsync("https://localhost:7062/api/Statistics/GetCarCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                int v1 = random.Next(0, 101);
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject <ResultStatisticDto>(jsonData);
                ViewBag.v = values.carCount;
                ViewBag.v1 = v1;
            }
            #endregion

            #region İstatistik2
            var responseMessage2 = await client.GetAsync("https://localhost:7062/api/Statistics/GetLocationCount");
            if (responseMessage2.IsSuccessStatusCode)
            {
                int locationCountRandom = random.Next(0, 101);
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData2);
                ViewBag.locationCount = values2.locationCount;
                ViewBag.locationCountRandom = locationCountRandom;
            }
            #endregion

            #region İstatistik3
            var responseMessage3 = await client.GetAsync("https://localhost:7062/api/Statistics/GetAuthorCount");
            if (responseMessage2.IsSuccessStatusCode)
            {
                int authorCountRandom = random.Next(0, 101);
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                var values3 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData3);
                ViewBag.authorCount = values3.authorCount;
                ViewBag.authorCountRandom = authorCountRandom;
            }
            #endregion

            #region İstatistik4
            var responseMessage4 = await client.GetAsync("https://localhost:7062/api/Statistics/GetBlogCount");
            if (responseMessage4.IsSuccessStatusCode)
            {
                int blogCountRandom = random.Next(0, 101);
                var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
                var values4 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData4);
                ViewBag.blogCount = values4.blogCount;
                ViewBag.blogCountRandom = blogCountRandom;
            }
            #endregion

            #region İstatistik5
            var responseMessage5 = await client.GetAsync("https://localhost:7062/api/Statistics/GetBrandCount");
            if (responseMessage5.IsSuccessStatusCode)
            {
                int brandCountRandom = random.Next(0, 101);
                var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
                var values5 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData5);
                ViewBag.brandCount = values5.brandCount;
                ViewBag.brandCountRandom = brandCountRandom;
            }
            #endregion

            #region İstatistik6
            var responseMessage6 = await client.GetAsync("https://localhost:7062/api/Statistics/GetAvgRentPriceForDaily");
            if (responseMessage6.IsSuccessStatusCode)
            {
                int avgPriceDailyRandom = random.Next(0, 101);
                var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
                var values6 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData6);
                ViewBag.avgPriceDaily = values6.avgPriceDaily.ToString("0.00");
                ViewBag.avgPriceDailyRandom = avgPriceDailyRandom;
            }
            #endregion

            #region İstatistik7
            var responseMessage7 = await client.GetAsync("https://localhost:7062/api/Statistics/GetAvgRentPriceForWeekly");
            if (responseMessage7.IsSuccessStatusCode)
            {
                int avgRentPriceForWeeklyRandom = random.Next(0, 101);
                var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
                var values7 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData7);
                ViewBag.avgRentPriceForWeekly = values7.avgRentPriceForWeekly.ToString("0.00");
                ViewBag.avgRentPriceForWeeklyRandom = avgRentPriceForWeeklyRandom;
            }
            #endregion

            #region İstatistik8
            var responseMessage8 = await client.GetAsync("https://localhost:7062/api/Statistics/GetAvgRentPriceForMontly");
            if (responseMessage8.IsSuccessStatusCode)
            {
                int avgRentPriceForMonthlyRandom = random.Next(0, 101);
                var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
                var values8 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData8);
                ViewBag.avgRentPriceForMonthly = values8.avgRentPriceForMonthly.ToString("0.00");
                ViewBag.avgRentPriceForMonthlyRandom = avgRentPriceForMonthlyRandom;
            }
            #endregion

            return View();
        }
    }
}
