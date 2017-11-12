using Kursach3.Models;
using Kursach3.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kursach3.Services
{
    public class CreativeService
    {
        public static string GetCreative(int creativeId)
        {
            using (var db = new ApplicationDbContext())
            {
                List<ChapterView> chapters = new List<ChapterView>();
                foreach (Chapter chapter in db.Chapters.Where(n => n.CreativeId == creativeId).ToList())
                {
                    chapters.Add(new ChapterView(chapter, db.Tags.Where(n => n.ChapterId == chapter.Id).ToArray()));                    
                }

                return JsonConvert.SerializeObject(new CreativeView(db.Creatives.Find(creativeId), chapters.ToArray()));
            }
        }

        public static void RedactChapter(Chapter chapter)
        {
            using (var db = new ApplicationDbContext())
            {
                Chapter UpdataChapter = db.Chapters.Find(chapter.Id);
                UpdataChapter.Name = chapter.Name;
                UpdataChapter.Text = chapter.Text;
                db.SaveChanges();
            }
        }
    }
}