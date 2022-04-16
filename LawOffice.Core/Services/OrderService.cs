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
        private readonly IApplicationDbRepository? repo;

        public OrderService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public async Task<IEnumerable<OrderListViewModel>> GetOrders()
        {
            var orders = await repo.All<Order>().
                Select(u => new OrderListViewModel()
                {
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
    }
}
