using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pallet.Database;
using Pallet.Models;

namespace Pallet.Services
{
    public class LogService
    {
        
        private readonly UtilService _utilService;
        private const string folderPathError = @"C:\App\PMS\Log\Error\";
        private const string appName = "PMS";

        public LogService(UtilService utilService)
        {
            this._utilService = utilService;
        }

        public void Error(HttpContext httpContext, string methodBase, string errorProcess, string errorDetail, string stackTrace = ""){
            try
            {
                string date = DateTime.Now.ToString("yyyyMMdd", CultureInfo.CreateSpecificCulture("en-US"));
                string time = DateTime.Now.ToString("HH:mm:ss", CultureInfo.CreateSpecificCulture("en-US"));
                string methodRq = httpContext.Request.Method;
                string pathRq = httpContext.Request.Path;
                string line = "";
                if(stackTrace.Contains("line")){
                    string[] lineArr = stackTrace.Split("line");
                    line = lineArr[lineArr.Length-1].Trim();
                }
                line = line == "" ? "" : $"line: {line}";
                string text = $"{date} {time} |{appName}|{methodRq}|{pathRq}|{methodBase}| {errorProcess} | {errorDetail} | {line}";
                _utilService.ImportText(folderPathError, date, text);
            }
            catch (Exception){}
        }

        public void Error(HttpContext httpContext, string methodBase, string errorProcess, string errorDetail, int errorLine){
            try
            {
                string date = DateTime.Now.ToString("yyyyMMdd", CultureInfo.CreateSpecificCulture("en-US"));
                string time = DateTime.Now.ToString("HH:mm:ss", CultureInfo.CreateSpecificCulture("en-US"));
                string methodRq = httpContext.Request.Method;
                string pathRq = httpContext.Request.Path;
                string text = $"{date} {time} |{appName}|{methodRq}|{pathRq}|{methodBase}| {errorProcess} | {errorDetail} | line: {errorLine}";
                _utilService.ImportText(folderPathError, date, text);
            }
            catch (Exception){}
        }

    }
}