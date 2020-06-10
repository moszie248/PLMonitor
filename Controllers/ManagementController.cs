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
    public class ManagementController : Controller
    {
        private readonly ILogger<ManagementController> _logger;

        public ManagementController(ILogger<ManagementController> logger)
        {
            _logger = logger;
        }

        public IActionResult ManageRFID()
        {
            return View();
        }

        public IActionResult ManagePallet()
        {
            return View();
        }

        
        public IActionResult ManagePurchase()
        {
            return View();
        }


        public IActionResult ReciveAddPallet(PalletModel value)
        {   
            //add model to db.
            return Json(value);
        }

        public IActionResult ReciveEditPallet(PalletModel value)
        {   
            //add model to db.
            return Json(value);
        }

        public IActionResult ReciveAddPruchase(PruchaseModel value)
        {   
            //add model to db.
            return Json(value);
        }

        public IActionResult ReciveEditPruchase(PruchaseModel value)
        {   
            //add model to db.
            return Json(value);
        }

        public IActionResult ReciveAddRFID(RFIDModel value)
        {   
            //add model to db.
            return Json(value);
        }

        public IActionResult ReciveEditRFID(RFIDModel value)
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
