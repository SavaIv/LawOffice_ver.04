using LawOffice.Core.Contracts;
using LawOffice.Core.Models;
using LawOffice.Infrastructure.Data;
using LawOffice.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IApplicationDbRepository repo;

        public OrderService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public async Task<OrderFeedbackViewModel> GetOrderForFeedback(Guid Id)
        {
            var theOrder = await repo.GetByIdAsync<Order>(Id);

            var theOrderDTO = new OrderFeedbackViewModel()
            {
                OrderId = theOrder.Id.ToString(),
                FeedBack = theOrder.FeedBack
            };

            return theOrderDTO;
        }

        public async Task<IEnumerable<OrderListViewModel>> GetOrders()
        {
            var orders = await repo.All<Order>().
                Select(u => new OrderListViewModel()
                {
                    Id = u.Id.ToString(),
                    ProblemType = u.ProblemType,
                    UrgencyType = u.UrgencyType,
                    TypeOfAnswer = u.TypeOfAnswer,
                    ProblemDescription = u.ProblemDescription,
                    StatusOfTheOrder = u.StatusOfTheOrder,
                    UserId = u.UserId,
                    UserName = u.User.FirstName + " " + u.User.LastName,
                    FeedBack = u.FeedBack
                })
                .ToListAsync();

            return orders;
        }

        public async Task<bool> UpdateOrderFeedback(OrderFeedbackViewModel model)
        {
            bool result = false;
            Guid orderId = Guid.Parse(model.OrderId);
            var theOrder = await repo.GetByIdAsync<Order>(orderId);
                        
            if (theOrder != null)
            {
                theOrder.FeedBack = model.FeedBack;
                
                await repo.SaveChangesAsync();
               
                result = true;
            }

            return result;
        }
    }
}
