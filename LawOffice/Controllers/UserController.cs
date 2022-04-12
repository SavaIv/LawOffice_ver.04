using LawOffice.Core.Constants;
using LawOffice.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LawOffice.Controllers
{
    public class UserController : BaseController
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IUserService service;

        public UserController(RoleManager<IdentityRole> _roleManager, IUserService _service)
        {
            roleManager = _roleManager;
            service = _service;
        }

        public IActionResult Index()
        {
            return View();
        }

        // тези двата метода са в Areas/Admin/Controllers/UserController.cs

        [Authorize(Roles = UserConstants.Roles.Administrator)]
        public async Task<IActionResult> ManageUsers()
        {
            var users = await service.GetUsers();

            return Ok(users);
        }

        public async Task<IActionResult> CreateRole()
        {
            await roleManager.CreateAsync(new IdentityRole()
            {
                Name = "Administrator"
            });

            return Ok();
        }        
    }
}
