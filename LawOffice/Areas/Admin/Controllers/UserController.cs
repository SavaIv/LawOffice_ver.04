using LawOffice.Core.Constants;
using LawOffice.Core.Contracts;
using LawOffice.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LawOffice.Areas.Admin.Controllers
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

        [Authorize(Roles = UserConstants.Roles.Administrator)]
        public async Task<IActionResult> ManageUsers()
        {
            var users = await service.GetUsers();

            //return Ok(users);
            return View(users);
        }

        public async Task<IActionResult> CreateRole()
        {
            //await roleManager.CreateAsync(new IdentityRole()
            //{
            //    Name = "Administrator"
            //});

            return Ok();
        }

        public async Task<IActionResult> Edit(string Id)
        {
            var model = await service.GetUserForEdit(Id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await service.UpdateUser(model))
            {
                ViewData[MessageConstants.SuccessMessage] = "Успешен запис!";
            }
            else
            {
                ViewData[MessageConstants.ErrorMessage] = "Възникна грешка!";
            }

            return View(model);
        }

        public async Task<IActionResult> Roles(string id)
        {
            var user = await service.GetUserById(id);
            var model = new UserRolesViewModel()
            {
                UserId = user.Id,
                Name = $"{user.FirstName} {user.LastName}"
            };


            ViewBag.RoleItems = roleManager.Roles
                .ToList()
                .Select(r => new SelectListItem()
                {
                    Text = r.Name,
                    Value = r.Name,
                    Selected = userManager.IsInRoleAsync(user, r.Name).Result
                }).ToList();

            return View(model);
        }
    } 
}
