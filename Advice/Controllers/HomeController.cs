using Advice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Advice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> MessageAdvice()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://api.adviceslip.com/");
            HttpResponseMessage response = await httpClient.GetAsync("advice");

            response.EnsureSuccessStatusCode();

            var advice = response.Content.ReadAsStringAsync().Result;

            ListAdvice listAdvice = JsonConvert.DeserializeObject<ListAdvice>(advice);

            return View(listAdvice);
        }

    }
}
