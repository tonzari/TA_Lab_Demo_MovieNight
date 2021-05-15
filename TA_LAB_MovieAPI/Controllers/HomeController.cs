using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TA_LAB_MovieAPI.Models;

namespace TA_LAB_MovieAPI.Controllers
{
    public class HomeController : Controller
    {

        private readonly MovieDAL _movieDAL = new MovieDAL();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<string> searchTerms = new List<string>()
            {
                "doom",
                "beverly hills",
                "princess mononoke",
                "pants"
            };

            List<MovieModel> movies = _movieDAL.GetMovieList(searchTerms);

            return View(movies);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
