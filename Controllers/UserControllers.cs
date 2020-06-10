using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pallet.Models;
using Pallet.Services;

namespace Pallet.Controllers
{
    [Filters.AutorizeSession]
    public class UserController : Controller
    {
        private readonly LoginService _loginService;
        private readonly UserinfoService _userinfoService;

        public UserController(LoginService loginService, UserinfoService userinfoService)
        {
            this._loginService = loginService;
            this._userinfoService = userinfoService;
        }

        public IActionResult AddInformation()
        {
            return View();
        }

        public IActionResult Permision()
        {
            return View();
        }

        public IActionResult AddPermission()
        {
            return View();
        }

        public IActionResult EditPermission(int id)
        {
            return View();
        }
        
        public IActionResult ViewInformation()
        {
            return View();
        }

        public IActionResult Manage()
        {
            return View();
        }

        public async Task<JsonResult> GetUserinfo()
        {
            var obj = await _userinfoService.ReadAll(HttpContext);
            return Json(obj);
        }

        public IActionResult editInformation()
        {
            return View();
        }

        public IActionResult ReciveAdd(UserInfoModel value)
        {   
            //add model to db.
            return Json(value);
        }

        public IActionResult ReciveEdit(UserInfoModel value)
        {   
            //add model to db.
            return Json(value);
        }

        [HttpPost]
        public JsonResult GetUserName(){
            return Json(HttpContext.Session.GetString("firstname"));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
