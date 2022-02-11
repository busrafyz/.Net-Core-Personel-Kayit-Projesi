using CorePersonel.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace CorePersonel.Controllers
{
    public class LoginController : Controller
    {
        Context context = new Context();
       
        [HttpGet]
        public IActionResult GirisYap()
        {
            return View();
        }

        public async Task<IActionResult> GirisYap(Admin admin)
        {
            var values = context.Admins.FirstOrDefault(x => x.Username == admin.Username && x.Password == admin.Password);
            if (values != null)
             {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,admin.Username)
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Birim");
            }
            return View();
        }
    }
}
