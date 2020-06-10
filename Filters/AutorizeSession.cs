using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace Pallet.Filters
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class AutorizeSession : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            try
            {
                if (filterContext.HttpContext.Session.GetString("username") == null || 
                filterContext.HttpContext.Session.GetString("username") == "")
                {
                    filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary {
                            {"Controller","Login"},
                            {"Action","Index"}
                        });
                }
            }
            catch (Exception) { }

        }
    }
}