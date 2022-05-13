using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASMSBusinessLayer.ContractsBLL;

namespace ASMSPresentationLayer.Controllers
{
    public class DistrictController : Controller
    {
        private readonly IDistrictBusinessEngine _districtEngine;

        public DistrictController(IDistrictBusinessEngine districtEngine)
        {
            _districtEngine = districtEngine;
        }

        public JsonResult GetCityDistricts(byte id)
        {
            try
            {
                var data = _districtEngine.GetDistrictsOfCity(id).Data;
                return Json(new { isSuccess = true, data });
            }
            catch (Exception ex)
            {
                //ex loglanabilir
                return Json(new { isSuccess = false });
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
