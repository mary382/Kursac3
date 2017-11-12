using Kursach3.Models;
using Kursach3.Filters;
using Kursach3.Services;
using Kursach3.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Kursach3.Controllers
{
    [Culture]
    public class CreativeController : DefaultController
    {
        public ActionResult CreativeReader()
        {
            ViewBag.UserId = User.Identity.GetUserId();
            return View();
        }

        public ActionResult CreativeRedact()
        {
            return View();
        }

        [HttpPost]
        public string GetCreative(CreativeView creative)
        {
            return CreativeService.GetCreative(creative.Id);
        }

        [HttpPost]
        public void RedactChapter(Chapter redactChapter)
        {
            CreativeService.RedactChapter(redactChapter);
        }

    }
}