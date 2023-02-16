using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sksoft.Entity;
using System.Security.Claims;

namespace Sksoft.UI.Controllers
{
    public class LoginController : BaseController
    {

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Index(Kullanici model)
        {
            var kullaniciVarmi = db.Kullanici.FirstOrDefault(x => x.ad == model.ad && x.sifre == model.sifre);

            if (kullaniciVarmi != null)
            {
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim(ClaimTypes.Name, model.ad));
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
                return RedirectToAction("Index", "Yonetim");
            }
            else
            {
                return RedirectToAction("Login", "Yonetim");
                ViewBag.Durum = "Kullanıcı adı veya şifre hatalı!!!";
            }
        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");

        }
    }
}
