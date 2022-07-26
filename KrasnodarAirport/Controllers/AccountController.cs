using KrasnodarAirport.Entities.Identity;
using KrasnodarAirport.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace KrasnodarAirport.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly string CommonRoleName = "CommonUser";
        
        public AccountController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Register()
        {
            return View();

        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var existingUser = await _userManager.FindByEmailAsync(model.Email);

            if (existingUser != null)
            {
                ModelState.AddModelError("", "Пользователь с таким email(ом) уже существует");
                return View(model);
            }
               

            var newUser = new User
            {
                Email = model.Email,
                UserName = model.Email,
                EmailConfirmed = true, //TODO: build fuctionallity to send email
            };

            var isCreated = await _userManager.CreateAsync(newUser, model.Password);

            if (!isCreated.Succeeded)
            {
                ModelState.AddModelError("", "Ошибка регистрации");
                return View(model);
            }
                

            await _userManager.AddToRoleAsync(newUser, CommonRoleName);

            var createdUser = await _userManager.FindByEmailAsync(newUser.Email);
            if (createdUser == null)
            {
                ModelState.AddModelError("", "Ошибка регистрации");
                return View(model);
            }

            return Ok();
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
                return View(model);
            }
            var validPassword = await _userManager.CheckPasswordAsync(user, model.Password);

            if (!validPassword)
            {
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
                return View(model);
            }
            var role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
            await AuthenticateAsync(model.Email, role);

            return RedirectToAction("index", "home");
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Home", "Index");
        }

        [HttpGet]
        public async Task<IActionResult> AccessDenied()
        {
            return View();
        }
        private async Task AuthenticateAsync(string email, string role)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, role )
            };
            ClaimsIdentity id = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme,
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType
                );
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
