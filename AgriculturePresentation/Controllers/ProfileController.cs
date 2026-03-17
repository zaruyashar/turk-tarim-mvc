using AgriculturePresentation.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace AgriculturePresentation.Controllers
{
    public class ProfileController : AdminBaseController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public ProfileController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
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
                ImageUrl = values.ImageUrl,
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

            if (userName == "fieldMaster" || userName == "superUser")
            {
                TempData["ProtectedData"] = "Bu ana yönetici hesabı portföy sunumu için koruma altındadır. Profil bilgileri veya şifresi değiştirilemez. Anlayışınız için teşekkürler!";
                return RedirectToAction("Index");
            }

            var values = await _userManager.FindByNameAsync(userName);

            if (values == null) return NotFound();

            bool isPasswordChanged = false;

            values.Email = p.Mail;
            values.PhoneNumber = p.Phone;


            if (p.ImageFile != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.ImageFile.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savepath = resource + "/wwwroot/userimages/" + imagename;

                using (var stream = new FileStream(savepath, FileMode.Create))
                {
                    await p.ImageFile.CopyToAsync(stream);
                }

                values.ImageUrl = imagename;
            }


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