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
    public class LanguageController : Controller
    {
        private readonly LogService _log;

        public LanguageController(LogService logService)
        {
            this._log = logService;
        }

        public string Language()
        {
            return HttpContext.Session.GetString("language");
        }
    }
}
