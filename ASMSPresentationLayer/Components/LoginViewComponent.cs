using ASMSPresentationLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASMSPresentationLayer.Components
{
    public class LoginViewComponent:ViewComponent
    {
       public IViewComponentResult Invoke(string email)
        {
            LoginViewModel model = new LoginViewModel()
            {
                Email = email
            };
           return View(model);
            
        }
    }
}
