using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using Pallet.Database;
using Pallet.Models;
using Pallet.Services;
using Pallet.ViewModels;

namespace Pallet.Controllers
{
    public class LoginController : Controller
    {
        private readonly LogService _log;
        private readonly LoginService _loginService;

        public LoginController(LogService logService, LoginService loginService)
        {
            this._log = logService;
            this._loginService = loginService;
        }

        public IActionResult Index()
        {
            // var user = _loginService.CallStoredProcedure(HttpContext);
            if (HttpContext.Session.GetString("username") == null || HttpContext.Session.GetString("username") == "")
            {
                if (GetCookie("ku") != null)
                {
                    return View(new LoginViewModel
                    {
                        username = Base64Decode(GetCookie("ku")),
                        ischecked = true
                    });
                }

                return View();
            }
            else
            {
                return RedirectToAction("index", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Index")]
        public async Task<IActionResult> Login(LoginViewModel obj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("index");
                }

                var user = await _loginService.Authentication(HttpContext, obj.username, obj.password);
                if (user != null)
                {
                    Type type = user.GetType();
                    string username = Convert.ToString(type.GetProperty("username").GetValue(user));
                    if (obj.ischecked)
                    {
                        //set the key value in Cookie
                        SetCookie("ku", Base64Encode(username), 365);
                    }
                    else
                    {
                        removeCookie("ku");
                    }

                    HttpContext.Session.SetString("username", username);
                    HttpContext.Session.SetString("firstname", Convert.ToString(type.GetProperty("firstname").GetValue(user)));
                    HttpContext.Session.SetString("language", Convert.ToString(type.GetProperty("language").GetValue(user))); // 0 th, 1 en
                    return RedirectToAction("index", "Home");
                }
                else
                {
                    ViewBag.Message = "Username or password is wrong , Please Try Again";
                }
            }
            catch (Exception error)
            {
                _log.Error(HttpContext, MethodBase.GetCurrentMethod().Name, "Error", error.Message, error.StackTrace);
            }

            return View("index");
        }

        [ActionName("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("index", "Login");
        }

        /// <summary>
        /// Get the cookie
        /// </summary>
        /// <param name="key">Key </param>
        /// <returns>string value</returns>
        private string GetCookie(string key)
        {
            return Request.Cookies[key];
        }

        /// <summary>
        /// set the cookie
        /// </summary>
        /// <param name="key">key (unique indentifier)</param>
        /// <param name="value">value to store in cookie object</param>
        /// <param name="expireTime">expiration time (number of days)</param>
        private void SetCookie(string key, string value, int? expireTime)
        {
            try
            {
                CookieOptions option = new CookieOptions();
                if (expireTime.HasValue)
                    option.Expires = DateTime.Now.AddDays(expireTime.Value);
                else
                    option.Expires = DateTime.Now.AddMilliseconds(10);
                Response.Cookies.Append(key, value, option);   
            }
            catch (Exception error)
            {
                _log.Error(HttpContext, MethodBase.GetCurrentMethod().Name, "Error", error.Message, error.StackTrace);
            }
        }

        /// <summary>
        /// Delete the key
        /// </summary>
        /// <param name="key">Key</param>
        private void removeCookie(string key)
        {
            Response.Cookies.Delete(key);
        }

        private string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        private string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

    }
}
