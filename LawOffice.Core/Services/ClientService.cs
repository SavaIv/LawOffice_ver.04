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
    }
}
