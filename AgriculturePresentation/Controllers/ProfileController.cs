using AgriculturePresentation.Models;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    public class ProfileController : AdminBaseController
    {
        private readonly UserManager<IdentityUser> _userManager;

        public ProfileController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userName = User.Identity?.Name;

            if (string.IsNullOrEmpty(userName))
            {
                return RedirectToAction("Index", "Login");
            }

            var values = await _userManager.FindByNameAsync(userName);

            if (values == null)
            {
                return RedirectToAction("Index", "Login");
            }

            UserEditViewModel userEditViewModel = new UserEditViewModel()
            {
                Mail = values.Email ?? string.Empty,
                Phone = values.PhoneNumber ?? string.Empty,
                CurrentPassword = "",
                Password = "",
                ConfirmPassword = ""
            };

            return View(userEditViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel p)
        {
            var userName = User.Identity?.Name;

            if (string.IsNullOrEmpty(userName))
            {
                return RedirectToAction("Index", "Login");
            }

            var values = await _userManager.FindByNameAsync(userName);

            if (values == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if (p.Password == p.ConfirmPassword)
            {
                var passwordChangeResult = await _userManager.ChangePasswordAsync(values, p.CurrentPassword, p.Password);

                if (passwordChangeResult.Succeeded)
                {
                    values.Email = p.Mail;
                    values.PhoneNumber = p.Phone;

                    await _userManager.UpdateAsync(values);

                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var item in passwordChangeResult.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Şifreler birbiriyle uyuşmuyor.");
            }

            return View(p);
        }
    }
}
