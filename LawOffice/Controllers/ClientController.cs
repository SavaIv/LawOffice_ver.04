using LawOffice.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LawOffice.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService service;

        public ClientController(IClientService _service)
        {
            service = _service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Info(Guid Id)
        {
            var model = await service.GetInfoById(Id);

            return View(model);
        }

    }
}
