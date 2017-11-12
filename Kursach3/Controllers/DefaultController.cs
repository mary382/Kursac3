using Kursach3.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kursach3.Controllers
{
    public class DefaultController : Controller
    {
        [Culture] 
        public ActionResult ChangeCulture(string lang)
        {
            string returnUrl = Request.UrlReferrer.AbsolutePath;
            List<string> cultures = new List<string>() { "ru", "en" };
            if (!cultures.Contains(lang)) { lang = "en"; }
            HttpCookie cookie = Request.Cookies["lang"];
            if (cookie != null) cookie.Value = lang;   
            else
            {
                cookie = new HttpCookie("lang");
                cookie.HttpOnly = false;
                cookie.Value = lang;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
            return Redirect(returnUrl);
        }

        public ActionResult ChangeStyle(string style)
        {
            string returnUrl = Request.UrlReferrer.AbsolutePath;
            List<string> styles = new List<string>() { "night", "day" };
            if (!styles.Contains(style)) { style = "day"; }
            HttpCookie cookie = Request.Cookies["style"];
            if (cookie != null) cookie.Value = style;
            else
            {
                cookie = new HttpCookie("style");
                cookie.HttpOnly = false;
                cookie.Value = style;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
            return Redirect(returnUrl);
        }
    }
}