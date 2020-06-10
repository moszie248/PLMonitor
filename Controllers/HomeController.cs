using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pallet.Database;
using Pallet.Models;
using Pallet.Services;

namespace Pallet.Controllers
{
    [Filters.AutorizeSession]
    public class HomeController : Controller
    {
        private readonly LogService _log;
        private readonly DatabaseContext _context;

        public HomeController(LogService logService, DatabaseContext context)
        {
            this._log = logService;
            this._context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
