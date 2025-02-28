using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using zeynerp.Application.Interfaces;
using zeynerp.Core.Domain.Entities;

namespace zeynerp.Web.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IInvitationService _invitationService;

        public UserController(UserManager<ApplicationUser> userManager, IInvitationService invitationService)
        {
            _userManager = userManager;
            _invitationService = invitationService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> SendInvitation(Guid companyId, string email)
        {
            await _invitationService.SendInvitationAsync(companyId, email);
            return RedirectToAction("Index");
        }
    }
}