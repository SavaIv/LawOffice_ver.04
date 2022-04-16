using LawOffice.Core.Constants;
using LawOffice.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LawOffice.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData[MessageConstants.SuccessMessage] = "Добре Дошли на страницата на G6!";
            //ViewData[MessageConstants.ErrorMessage] = "Лошо! Нещо се счупи!";
            //ViewData[MessageConstants.WarningMessage] = "Внимавай! Възможни са проблеми!";

            return View();
        }

        public IActionResult WelcomOnWork()
        {            
            return View();
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