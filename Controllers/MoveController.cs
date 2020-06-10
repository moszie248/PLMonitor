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
    public class MoveController : Controller
    {
        private readonly ILogger<MoveController> _logger;

        public MoveController(ILogger<MoveController> logger)
        {
            _logger = logger;
        }

        public IActionResult MovePalletRFID()
        {
            return View();
        }

        public IActionResult History()
        {
            return View();
        }

        public IActionResult AddInvoice()
        {
            return View();
        }

        public IActionResult AddBill()
        {
            return View();
        }

        public IActionResult AddDamage()
        {
            return View();
        }

        public IActionResult ReciveAddDamage(DamageModel value)
        {   
            //add model to db.
            return Json(value);
        }

        public IActionResult ReciveAddInvoice(InvoiceModel value)
        {   
            //add model to db.
            return Json(value);
        }

        public IActionResult ReciveAddBill(BillModel value)
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
