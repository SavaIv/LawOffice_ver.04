using LawOffice.Core.Contracts;
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

        public async Task<IActionResult> ManageOrders()
        {
            var orders = await service.GetOrders();
            ;
            return View(orders);
        }
    }
}
