using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using zeynerp.Application.DTOs.Company;
using zeynerp.Application.DTOs.User;
using zeynerp.Application.Interfaces;
using zeynerp.Core.Domain.Entities;
using zeynerp.Web.Extensions;

namespace zeynerp.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ICompanyService _companyService;
        private readonly IUserService _userService;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IEmailSender emailSender, ICompanyService companyService, IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _companyService = companyService;
            _userService = userService;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if(ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = registerDto.Email,
                    Email = registerDto.Email,
                    FullName = registerDto.FullName
                };

                var result = await _userManager.CreateAsync(user, registerDto.Password);
                
                if(result.Succeeded)
                {                   
                    var companyDto = await _companyService.CreateCompanyAsync(new CompanyDto { Name = registerDto.CompanyName });

                    user.CompanyId = companyDto.Id;
                    await _userService.UpdateUserAsync(user);

                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token = token }, protocol: Request.Scheme);

                    if (callbackUrl != null)
                        await _emailSender.SendEmailConfirmationAsync(registerDto.Email, callbackUrl);

                    return RedirectToAction("Login");
                }

                foreach (var error in result.Errors)
                {
                    if (error.Code == "DuplicateUserName")
                    {
                        ModelState.AddModelError("", "Bu e-posta adresi zaten kullanılmakta.");
                    }
                    else
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View(registerDto);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginDto loginDto)
        {
            return View();
        }
    }
}