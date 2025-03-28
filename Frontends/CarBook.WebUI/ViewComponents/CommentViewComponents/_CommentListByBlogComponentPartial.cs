﻿using CarBook.Dto.CommentDtos;
using CarBook.Dto.TagCloudDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.CommentViewComponents
{
    public class _CommentListByBlogComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CommentListByBlogComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.blogid = id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7062/api/Comments/CommnetListByBlog?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCommnetDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
