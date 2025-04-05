using CarBook.Dto.RegisterDtos;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using CarBook.Dto.LoginDtos;

namespace CarBook.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateLoginDto createRegisterDto)
        {
            var client = _httpClientFactory.CreateClient();
            
            return View();
        }
    }
}
