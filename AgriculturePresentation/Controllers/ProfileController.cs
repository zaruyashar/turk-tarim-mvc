using AgriculturePresentation.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    public class ProfileController : AdminBaseController
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public ProfileController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
                Mail = values.Email ?? "",
                Phone = values.PhoneNumber ?? "",
                Password = "",
                CurrentPassword = "",
                ConfirmPassword = ""
            };

            return View(userEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel p)
        {
            var userName = User.Identity?.Name ?? "";
            var values = await _userManager.FindByNameAsync(userName);

            if (values == null) return NotFound();

            bool isPasswordChanged = false;

            values.Email = p.Mail;
            values.PhoneNumber = p.Phone;

            if (!string.IsNullOrEmpty(p.Password))
            {
                if (string.IsNullOrEmpty(p.CurrentPassword))
                {
                    ModelState.AddModelError("CurrentPassword", "Şifre değişimi için mevcut şifre şarttır.");
                    return View(p);
                }

                var passwordChangeResult = await _userManager.ChangePasswordAsync(values, p.CurrentPassword, p.Password);

                if (passwordChangeResult.Succeeded)
                {
                    isPasswordChanged = true; 
                }
                else
                {
                    foreach (var item in passwordChangeResult.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View(p);
                }
            }

            var result = await _userManager.UpdateAsync(values);
            if (result.Succeeded)
            {
                if (isPasswordChanged)
                {
                    await _signInManager.SignOutAsync();
                    TempData["SuccessMessage"] = "PasswordChanged";
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    TempData["SuccessMessage"] = "ProfileUpdated";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View(p);
            }
        }
    }
}