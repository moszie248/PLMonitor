using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pallet.Models;

namespace Pallet.Controllers
{
    [Filters.AutorizeSession]
    public class SettingManageController : Controller
    {
        private readonly ILogger<SettingManageController> _logger;

        public SettingManageController(ILogger<SettingManageController> logger)
        {
            _logger = logger;
        }

        public IActionResult Company()
        {
            return View();
        }

        public IActionResult Branch()
        {
            return View();
        }

        public IActionResult Position()
        {
            return View();
        }

        public IActionResult Equipment()
        {
            return View();
        }

        public IActionResult Damage()
        {
            return View();
        }

        public IActionResult StatusEquipment()
        {
            return View();
        }

        public IActionResult StatusPallet()
        {
            return View();
        }

        public IActionResult StatusRFID()
        {
            return View();
        }

        [HttpPost]
        public IActionResult reciveAddDamage(DmgListModel value)
        {   
            //add model to db.
            return Json(value);
        }
        public IActionResult reciveEditDamage(DmgListModel value)
        {   
            //add model to db.
            return Json(value);
        }
        
        public IActionResult reciveAddBranch(BranchListModel value)
        {   
            //add model to db.
            return Json(value);
        }
        public IActionResult reciveEditBranch(BranchListModel value)
        {   
            //add model to db.
            return Json(value);
        }

        public IActionResult reciveAddCompany(CompanyListModel value)
        {   
            //add model to db.
            return Json(value);
        }
        public IActionResult reciveEditCompany(CompanyListModel value)
        {   
            //add model to db.
            return Json(value);
        }

        public IActionResult reciveAddEquipment(EquipmentListModel value)
        {   
            //add model to db.
            return Json(value);
        }
        public IActionResult reciveEditEquipment(EquipmentListModel value)
        {   
            //add model to db.
            return Json(value);
        }

        public IActionResult reciveAddStatusPallet(StatusPalletListModel value)
        {   
            //add model to db.
            return Json(value);
        }
        public IActionResult reciveEditStatusPallet(StatusPalletListModel value)
        {   
            //add model to db.
            return Json(value);
        }

        public IActionResult reciveAddStatusRFID(StatusRFIDListModel value)
        {   
            //add model to db.
            return Json(value);
        }
        public IActionResult reciveEditStatusRFID(StatusRFIDListModel value)
        {   
            //add model to db.
            return Json(value);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
