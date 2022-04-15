using LawOffice.Core.Constants;
using LawOffice.Core.Contracts;
using LawOffice.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LawOffice.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService service;

        public ClientController(IClientService _service)
        {
            service = _service;
        }

        public IActionResult IndexClient()
        {
            return View();
        }

        public IActionResult ConfirmOrderSent()
        {
            return View();
        }

        public async Task<IActionResult> Info(Guid Id)
        {
            var model = await service.GetInfoById(Id);

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> ClientOrder()
        {
            //var theUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            //ViewData["UserId"] = theUserId;
            
            //var model = await service.PutTheUserIdInOrderModel(theUserId);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ClientOrder(ClientOrderViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewData[MessageConstants.ErrorMessage] = "Error appear. Pleasy try again.";
                return View(model);
            }

            var orderOK = service.AddOrderToUser(model);

            if (await orderOK == false)
            {
                ViewData[MessageConstants.ErrorMessage] = "Error appear. Pleasy try again.";
                return View(model);
            }

            ViewData[MessageConstants.SuccessMessage] = "Your order is accepted!";

            return RedirectToAction(nameof(ConfirmOrderSent));
        }
    }
}
