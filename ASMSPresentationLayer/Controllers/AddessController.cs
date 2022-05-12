using ASMSBusinessLayer.ContractsBLL;
using ASMSBusinessLayer.EmailService;
using ASMSEntityLayer.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASMSPresentationLayer.Controllers
{
    public class AddessController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailSender emailSender;
        private readonly IUsersAddressBusinessEngine _userAddress;
        private readonly ICityBusinessEngine _cityEngine;

        public AddessController(UserManager<AppUser> userManager, IEmailSender emailSender, IUsersAddressBusinessEngine userAddress)
        {
            _userManager = userManager;
            this.emailSender = emailSender;
            _userAddress = userAddress;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddAddress()
        {
            ViewBag.Cities = _cityEngine.GetAll().Data;

            return View();
        }

    }
}
