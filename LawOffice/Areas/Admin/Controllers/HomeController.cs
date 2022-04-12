using Microsoft.AspNetCore.Mvc;

namespace LawOffice.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
