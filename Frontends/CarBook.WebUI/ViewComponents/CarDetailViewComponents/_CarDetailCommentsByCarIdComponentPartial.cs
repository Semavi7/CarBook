using CarBook.Dto.ReviewDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.CarDetailViewComponents
{
    public class _CarDetailCommentsByCarIdComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CarDetailCommentsByCarIdComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.carid = id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7062/api/Reviews?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultReviewByCarIdDto>>(jsonData);
                ViewBag.c = values.Count;
                ViewBag.five = values.Count(x => x.RaytingValue == 5);
                ViewBag.four = values.Count(x => x.RaytingValue == 4);
                ViewBag.three = values.Count(x => x.RaytingValue == 3);
                ViewBag.two = values.Count(x => x.RaytingValue == 2);
                ViewBag.one = values.Count(x => x.RaytingValue == 1);

                int star = values.Count;
                ViewBag.fivestar = star == 0 ? 0 : values.Count(x => x.RaytingValue == 5) * 100.0 / star;
                ViewBag.fourstar = star == 0 ? 0 : values.Count(x => x.RaytingValue == 4) * 100.0 / star;
                ViewBag.threestar = star == 0 ? 0 : values.Count(x => x.RaytingValue == 3) * 100.0 / star;
                ViewBag.twostar = star == 0 ? 0 : values.Count(x => x.RaytingValue == 2) * 100.0 / star;
                ViewBag.onestar = star == 0 ? 0 : values.Count(x => x.RaytingValue == 1) * 100.0 / star;
                return View(values);
            }
            return View();
        }
    }
}
