using ASMSBusinessLayer.EmailService;
using ASMSBusinessLayer.ViewModels;
using ASMSEntityLayer.Enums;
using ASMSEntityLayer.IdentityModels;
using ASMSPresentationLayer.Areas.Management.Models;
using ASMSPresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASMSPresentationLayer.Areas.Management.Controllers
{

    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger<AdminController> _logger;

        public AdminController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, 
            IEmailSender emailSender, ILogger<AdminController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _emailSender = emailSender;
            _logger = logger;
        }

        public IActionResult Dashboard()
        {

            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterAdminViewModel model)
        {

            try
            {
                if (!ModelState.IsValid)
                {

                    return View(model);
                   
                    
                }
                var checkUserForEmail = await _userManager.FindByEmailAsync(model.Email);
                if (checkUserForEmail != null)
                {
                    ModelState.AddModelError("", "Bu email ile zaten sisteme kayıt yapılmıştır.");
                    return View(model);
                  
                }

                AppUser newUser = new AppUser()
                {
                    
                    Email = model.Email,
                    Name = model.Name,
                    Surname = model.Surname,
                    CreatedDate = DateTime.Now,
                    IsDeleted = false,
                    EmailConfirmed = true,
                    UserName = model.Email
                };
                var result = await _userManager.CreateAsync(newUser, model.Password);
                if (result.Succeeded)//eklendi
                {
                    // rol ataması
                    var roleResult = await _userManager.AddToRoleAsync(newUser, ASMSRoles.StudentAdministration.ToString());
                    //Student eklensin
                    
                    
                    if (roleResult.Succeeded == false)
                    {


                    }
                    var emailToStudent = new EmailMessage()
                    {
                        Subject = "ASMS Sistemine HOŞ GELDİNİZ!" +
                        newUser.Name + " " + newUser.Surname,
                        Body = "Merhaba,Yönetim Sistemine kaydınız gerçekleşmiştir...",
                        Contacts = new string[] { model.Email }
                    };
                    await _emailSender.SendMessage(emailToStudent);
                    TempData["RegisterSuccessMessage"] = "Sisteme kaydınız başarıyla gerçekleşti!";
                    _logger.LogInformation("Sisteme yeni  bir öğrenci işleri personeli kayıt olduı.userid=" + newUser.Id);
                    return RedirectToAction("Login", "Mangement//Admin", new {area="Management", email = model.Email });
                }
                else
                {
                    
                    ModelState.AddModelError("", "Beklenmedik bir sorun oldu.Üye kaydı başarısız tekrar deneyiniz!");
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Management/Admin Register Hata oldu" + ex.ToString());
                ModelState.AddModelError("", "Beklenmedik bir sorun oldu.Üye kaydı başarısız tekrar deneyiniz!");
                return View(model);
            }
        }
        public IActionResult Login(string email)
        {
            LoginViewModel model = new LoginViewModel()
            {
                Email = email
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var user = await _userManager.FindByNameAsync(model.Email);
                //var user = _userManager.FindByEmailAsync(model.Email);  //Name yerine email de yazılabilir.
                if (user == null)
                {
                    ModelState.AddModelError("", "Epostanız ya da şifreniz hatalıdır! Tekrar deneyiniz!");
                    return View(model);
                }
                //TO DO: Son parametre bool lockoutOnFailure ile ilgili örnek yapılacak.
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);

                ////TO DO: 
                //if (result.IsLockedOut)
                //{
                //    DateTimeOffset d = user.LockoutEnd.Value;
                //}

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Epostanız ya da şifreniz hatalıdır! Tekrar deneyiniz!");
                    return View(model);
                }
                //Artık giriş yapıldı.
                if (_userManager.IsInRoleAsync(user, ASMSRoles.StudentAdministration.ToString()).Result)
                {
                    return RedirectToAction("Index", "Home");
                }
                if (_userManager.IsInRoleAsync(user, ASMSRoles.Coordinator.ToString()).Result)
                {
                    return RedirectToAction("Dashboard", "Admin", new { areas = "Management" });
                };



                if (_userManager.IsInRoleAsync(user, ASMSRoles.StudentAdministration.ToString()).Result)
                {
                    return RedirectToAction("Dashboard", "Admin");
                }
                return RedirectToAction("Index", "Home");


            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Beklenmedik bir hata oluştu! Tekrar deneyiniz!");
                //ex loglansın.
                return View(model);
            }
        }

    }
}
