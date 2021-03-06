using LawOffice.Core.Models;
using LawOffice.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice.Core.Contracts
{
    public interface IOrderService
    {       
        Task<IEnumerable<OrderListViewModel>> GetOrders();

        Task<OrderFeedbackViewModel> GetOrderForFeedback(Guid Id);

        Task<bool> UpdateOrderFeedback(OrderFeedbackViewModel model);               
                 
    }
}
