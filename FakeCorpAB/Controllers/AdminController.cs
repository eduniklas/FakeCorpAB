using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using FakeCorpAB.Models;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace FakeCorpAB.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> usermanager;
        public AdminController(UserManager<IdentityUser> _usermanager)
        {
            usermanager = _usermanager;
        }
        public async Task<IActionResult> Index()
        {
            var admins = (await usermanager
                .GetUsersInRoleAsync("Administrator"))
                .ToArray();

            var everyone = await usermanager.Users.ToArrayAsync();

            var model = new AdminViewModel
            {
                Administrators = admins,
                Everyone = everyone
            };

            return View(model);
        }
    }
}
