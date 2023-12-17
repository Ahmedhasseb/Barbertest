using DAL.Moduls;
using DemoMvc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DemoMvc.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(AccountViewModel account)
        {
            if (ModelState.IsValid)
            {
                var model = new AppUser()
                {
                    FName = account.FName,
                    LName=account.LNname,
                    UserName = account.Email.Split("@")[0],
                    Email = account.Email,
                    IsAgree = account.IsAgree,

                };

            }
            return View();
        }
    }
}
