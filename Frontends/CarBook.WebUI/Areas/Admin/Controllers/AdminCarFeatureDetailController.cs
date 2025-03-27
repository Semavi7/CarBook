using CarBook.Dto.AboutDtos;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using CarBook.Dto.CarFeatureDtos;
using CarBook.Dto.CategoryDtos;
using System.Text;
using CarBook.Dto.FeatureDtos;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminCarFeatureDetail")]
    public class AdminCarFeatureDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarFeatureDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index/{id}")]
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7062/api/CarFeaatures?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarFeatureByCarIdDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(List<ResultCarFeatureByCarIdDto> resultCarFeatureByCarIdDtos)
        {
            foreach (var item in resultCarFeatureByCarIdDtos)
            {
                if (item.Availabe)
                {
                    var client = _httpClientFactory.CreateClient();
                    await client.GetAsync("https://localhost:7062/api/CarFeaatures/CarFeatureChangeAvailableToTrue?id=" + item.CarFeatureID);
                }
                else
                {
                    var client = _httpClientFactory.CreateClient();
                    await client.GetAsync("https://localhost:7062/api/CarFeaatures/CarFeatureChangeAvailableToFalse?id=" + item.CarFeatureID);
                }
            }
            return RedirectToAction("Index", "AdminCar");
        }

        [Route("CreateFeatureByCarId/{id}")]
        [HttpGet]
        public async Task<IActionResult> CreateFeatureByCarId(int id)
        {
            ViewBag.carId = id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7062/api/Features");
            if (responseMessage.IsSuccessStatusCode)
            {
                var JsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureWithStatusDto>>(JsonData);
                CreateCarFeatureDto model = new CreateCarFeatureDto();
                model.Features = values;
                model.CarID = id;
                return View(model);
            }
            return View();
        }

        [Route("CreateFeatureByCarId/{id}")]
        [HttpPost]
        public async Task<IActionResult> CreateFeatureByCarId(CreateCarFeatureDto createCarFeatureDto)
        {
            CreateCarFeatureDetailDto model = new CreateCarFeatureDetailDto();
            model.CarID = createCarFeatureDto.CarID;
            var client = _httpClientFactory.CreateClient();
            foreach (var item in createCarFeatureDto.Features)
            {
                if (item.Status)
                {
                    model.FeatureID = item.FeatureID;
                    var JsonData = JsonConvert.SerializeObject(model);
                    StringContent stringContent = new StringContent(JsonData, Encoding.UTF8, "application/json");
                    var responseMessage = await client.PostAsync("https://localhost:7062/api/CarFeaatures", stringContent);
                }
            }
            return RedirectToAction("Index", "AdminCar", new { area = "Admin" });
        }
    }
}
