using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using BCryptNet = BCrypt.Net.BCrypt;
using Sanctuary.Domain;
using Sanctuary.Presentation.Models;
using Sanctuary.Domain.Entities;

namespace Sanctuary.Presentation.Controllers
{
    [Route("{controller}")]
    public class AuthenticationController : BaseController
    {
        public AuthenticationController(BaseContext context) : base(context) { }

        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectPermanent("/");
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            try
            {
                var volunteer = _context.Volunteers.Where(x => x.Email == model.Email).FirstOrDefault();
                if (volunteer == null || !BCryptNet.Verify(model.Password, volunteer.PasswordHash))
                {
                    throw new Exception("E-mail ou senha ínválido");
                }

                var claims = new List<Claim>
                {
                    new Claim("user", volunteer.Id.ToString()),
                    new Claim("role", volunteer.Role)
                };

                await HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(claims, "Cookies", "user", "role")));
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }

            return Json(new { success = true });
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            try
            {
                var volunteer = new Volunteer
                {
                    Name = model.Name,
                    Email = model.Email,
                    Birthdate = model.Birthdate,
                    PasswordHash = BCryptNet.HashPassword(model.Password),
                    Phone = model.Phone,
                    Role = "Default",
                    Status = "Analysis"
                };
                _context.Volunteers.Add(volunteer);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.ToString() });
            }

            return await Login(new LoginViewModel {
                Email = model.Email,
                Password = model.Password
            });
        }

        [HttpGet("Denied")]
        public IActionResult Denied()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
