using LawOffice.Core.Contracts;
using LawOffice.Core.Models;
using LawOffice.Infrastructure.Data.Identity;
using LawOffice.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IApplicationDbRepository? repo;

        public UserService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public async Task<IEnumerable<UserListViewModel>> GetUsers()
        {
            var users = repo.All<ApplicationUser>().
                Select(u => new UserListViewModel()
                {
                    Email = u.Email,
                    Id = u.Id,
                    Name = $"{u.FirstName} {u.LastName}"
                })
                .ToListAsync();

            return await users;

            //return await repo.All<ApplicationUser>()
            //    .Select(u => new UserListViewModel()
            //    {
            //        Email = u.Email,
            //        Id = u.Id,
            //        Name = $"{u.FirstName} {u.LastName}"
            //    })
            //    .ToListAsync();

        }
    }
}
