using Kursach3.Filters;
using Kursach3.Models;
using Kursach3.Services;
using Kursach3.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kursach3.Controllers
{
    [Culture]
    public class UserPageController : DefaultController
    {

        public ActionResult Index()
        {
            ViewBag.UserId = User.Identity.GetUserId();
            return View();
        }

        [HttpGet]
        public string GetMe()
        {
            return UserPageService.GetUser(User.Identity.GetUserId());
        }

        [HttpPost]
        public string GetUser(string userId)
        {
            return UserPageService.GetUser(userId);
        }

        [HttpGet]
        public string GetMyCreatives()
        {
            return UserPageService.GetUserCreatives(User.Identity.GetUserId());
        }

        [HttpPost]
        public string GetUserCreatives(string userId)
        {
            return UserPageService.GetUserCreatives(userId);
        }

        [HttpPost]
        public void Create(CreativeView creative)
        {
            UserPageService.CreateCreative(creative, User.Identity.GetUserId());
        }

        [HttpPost]
        public void ChangeAvatar(string src)
        {
            UserPageService.ChangeAvatar(UserPageService.UploadAvatar(src), User.Identity.GetUserId());
        }

        [HttpPost]
        public void ChangeRank(float rank, int creativeId)
        {
            UserPageService.ChangeRank(rank, creativeId);
        }
    }
}