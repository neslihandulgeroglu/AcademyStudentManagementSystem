using ASMSBusinessLayer.EmailService;
using ASMSDataAccessLayer.ContractsDAL;
using ASMSEntityLayer.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASMSBusinessLayer.ContractsBLL;
using ASMSPresentationLayer.Models;
using ASMSEntityLayer.Enums;
using ASMSEntityLayer.ViewModels;
using ASMSEntityLayer.ResultModels;
using ASMSBusinessLayer.ViewModels;

namespace ASMSPresentationLayer.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppUser> _roleManager;
        private readonly IEmailSender _emailSender;
        private readonly IStudentBusinessEngine _studentBusinessEngine;

        public AccountController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager, RoleManager<AppUser> roleManager, 
            IEmailSender emailSender, IStudentBusinessEngine studentBusinessEngine)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            _roleManager = roleManager;
            this._emailSender = emailSender;
            this._studentBusinessEngine = studentBusinessEngine;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel  model)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var checkUserForEmail = await _userManager.FindByEmailAsync(model.Email);
                if (checkUserForEmail !=null)
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
                    BirthDate = model.BirthDate.HasValue ?
                    model.BirthDate.Value : null,
                    Gender = model.Gender,
                    EmailConfirmed = true,
                    UserName = model.Email
                };
                var result = await _userManager.CreateAsync(newUser, model.Password);
                if (result.Succeeded)//eklendi
                {
                   // rol ataması
                    var roleResult = await _userManager.AddToRoleAsync(newUser,ASMSRoles.Student.ToString());
                    //Student eklensin
                    StudentVM newStudent = new StudentVM()
                    {
                        UserId = newUser.Id,
                        TCNumber = model.TCNumber
                    };
                    IResult resultStudent = _studentBusinessEngine.Add(newStudent);
                    if (resultStudent.IsSuccess==false)
                    {


                    }
                    var emailToStudent = new EmailMessage()
                    {
                        Subject="ASMS Sistemine HOŞ GELDİNİZ!"+
                        newUser.Name+" "+newUser.Surname,
                        Body="Merhaba,Sisteme kaydınız gerçekleşmiştir...",
                        Contacts=new string[] {model.Email}
                    };
                    return RedirectToAction("Login", "Account", new { email = model.Email });
                }
                else
                {
                    ModelState.AddModelError("", "Beklenmedik bir sorun oldu.Üye kaydı başarısız tekrar deneyiniz!");
                    return View(model);
                }
            }
            catch (Exception) 
            {
                //loglanacak
                return RedirectToAction("Error","Home");
            }
        }


    }
}
