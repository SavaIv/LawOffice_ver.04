using LawOffice.Core.Models;

namespace LawOffice.Core.Contracts
{
    public interface IClientService
    {
        Task<ClienLawInfoViewModel> GetInfoById(Guid id);
    }
}
