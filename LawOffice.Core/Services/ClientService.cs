using LawOffice.Core.Contracts;
using LawOffice.Core.Models;
using LawOffice.Infrastructure.Data;
using LawOffice.Infrastructure.Data.Repositories;

namespace LawOffice.Core.Services
{
    public class ClientService : IClientService
    {
        private readonly IApplicationDbRepository repo;

        public ClientService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public async Task<bool> AddOrderToUser(ClientOrderViewModel model)
        {
            bool result = false;

            var theOrder = new Order()
            {
                ProblemType = model.ProblemType,
                UrgencyType = model.UrgencyType,
                TypeOfAnswer = model.TypeOfAnswer,
                ProblemDescription = model.ProblemDescription,
                StatusOfTheOrder = "Pending",
                UserId = model.UserId
            };

            repo.AddAsync<Order>(theOrder);
            repo.SaveChangesAsync();

            result = true;      

            return result;
        }

        public async Task<ClienLawInfoViewModel> GetInfoById(Guid id)
        {
            var theCompanyInfo = await repo.GetByIdAsync<CompanyInfo>(id);

            var theInfo = new ClienLawInfoViewModel()
            {
                TypeOfLaw = theCompanyInfo.TypeOfLaw,
                InfoAboutLaw = theCompanyInfo.InfoAboutLaw
            };

            return theInfo;
        }

        public async Task<ClientOrderViewModel> PutTheUserIdInOrderModel(string id)
        {
            var theModel = new ClientOrderViewModel()
            {
                ProblemType = "default valie was not changed",
                UrgencyType = "default valie was not changed",
                TypeOfAnswer = "default valie was not changed",
                ProblemDescription = "default valie was not changed",
                StatusOfTheOrder = "default valie was not changed",
                UserId = id
            };

            return theModel;
        }
    }
}
