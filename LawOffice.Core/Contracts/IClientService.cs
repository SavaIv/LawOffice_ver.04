using LawOffice.Core.Models;

namespace LawOffice.Core.Contracts
{
    public interface IClientService
    {
        Task<ClienLawInfoViewModel> GetInfoById(Guid id);

        Task<bool> AddOrderToUser(ClientOrderViewModel model);

        Task<ClientOrderViewModel> PutTheUserIdInOrderModel(string id);
    }
}
