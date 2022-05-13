using ASMSPresentationLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASMSPresentationLayer.Components
{
    public class RegisterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(new RegisterViewModel());
        }
    }
}