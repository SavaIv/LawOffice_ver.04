using LawOffice.Core.Contracts;
using LawOffice.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace LawOffice.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IOrderService service;

        public OrderController(IOrderService _service)
        {
            service = _service;
        }

        public IActionResult ConfirmOrderFeedbackChanged()
        {
            return View();
        }
       

        public async Task<IActionResult> ManageOrders()
        {
            var orders = await service.GetOrders();
            
            return View(orders);
        }

        public async Task<IActionResult> FeedBack(Guid Id)
        {
            var model = await service.GetOrderForFeedback(Id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> FeedBack(OrderFeedbackViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            service.UpdateOrderFeedback(model);


            return RedirectToAction(nameof(ConfirmOrderFeedbackChanged));
        }        
    }
}
