using Kursach3.Filters;
using Kursach3.Models;
using Kursach3.Services;
using Kursach3.ViewModels;
using MvcLuceneSampleApp.Search;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kursach3.Controllers
{
    [Culture]
    public class HomeController : DefaultController
    {
        public ActionResult Index()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                LuceneSearch.ClearLuceneIndex();
                LuceneSearch.AddUpdateLuceneIndex(db.Creatives);
            }
            return View();
        }

        [HttpGet]
        public string GetPopularCreatives()
        {
            return HomePageService.GetPopularCreatives();
        }

        [HttpGet]
        public string GetNewCreatives()
        {
            return HomePageService.GetNewCreatives();
        }

        [HttpGet]
        [Authorize]
        public ActionResult AdminPage()
        {
            using (var db = new ApplicationDbContext())
            {
                var users = db.Users.ToList();
                return View(users);
            }
        }

        public void DeleteUserById(string id) {

        }

        public ActionResult SearchPage()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult BanUser(string id)
        {
            using (var db = new ApplicationDbContext())
            {
                var user = db.Users.Find(id);
                user.Ban = !user.Ban;
                db.SaveChanges();
            }
            return RedirectToAction("AdminPage");
        }

        [HttpPost]
        public string SearchResult(Search search)
        {
            IEnumerable<Creative> creatives  = LuceneSearch.Search(search.Row);

            if (creatives.Count() == 0) return null;

            return HomePageService.SearchResult(creatives);
        }

        [HttpGet]
        public string GetTags()
        {
            using (var db = new ApplicationDbContext())
            {
                return JsonConvert.SerializeObject(db.Tags.Take(10).ToArray());
            }
        }


    }
}