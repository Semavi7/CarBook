﻿using System.Text;
using System.Threading.Tasks;
using CarBook.Dto.BlogDtos;
using CarBook.Dto.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Boglar";
            ViewBag.v2 = "Yazarlarımızın Blogları";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7062/api/Blogs/GetAllBlogsWithAuthorList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAllBlogsWithAuthorDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> BlogDetail(int id)
        {
            ViewBag.v1 = "Boglar";
            ViewBag.v2 = "Blog Detayı ve Yorumlar";
            ViewBag.blogid = id;

            var client = _httpClientFactory.CreateClient();
            var responseMessage2 = await client.GetAsync($"https://localhost:7062/api/Comments/CommentCountByBlog?id=" + id);
            var JsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.Id = JsonData2;
            return View();
        }

        [HttpGet]
        public PartialViewResult AddComment(int id)
        {
            ViewBag.blogid = id;
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentDto createCommentDto)
        {
            var client = _httpClientFactory.CreateClient();
            var JsonData = JsonConvert.SerializeObject(createCommentDto);
            StringContent stringContent = new StringContent(JsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7062/api/Comments/CreateCommentWithMediator", stringContent);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}
