using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Kursach3.Models;
using Kursach3.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kursach3.Services
{
    public class UserPageService
    {

        public static string GetUser(string userId)
        {
            using (var db = new ApplicationDbContext())
            {
                return JsonConvert.SerializeObject(db.Users.Find(userId));
            }
        }

        public static string UploadAvatar(string avatar)
        {
            var account = new Account(
                "dqxuyyhh2d",
                "494215851576957",
                "kByBGvzNRvujzAwNt70UfkbQq5k");
            var cloudinary = new Cloudinary(account);
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(avatar)
            };
            return cloudinary.Upload(uploadParams).SecureUri.ToString();
        }

        public static void ChangeAvatar(string avatarUrl, string id)
        {
            using(var db = new ApplicationDbContext())
            {
                var user = db.Users.Find(id);
                user.AvatarUrl = avatarUrl;
                db.SaveChanges();
            }
        }

        public static void ChangeRank(float rank, int creativeId)
        {
            using (var db = new ApplicationDbContext())
            {
                Creative creative = db.Creatives.Find(creativeId);
                creative.Rank = rank;
                db.SaveChanges();
            }
        }

        public static string GetUserCreatives(string userId)
        {
            using (var db = new ApplicationDbContext())
            {
                var creatives = from c in db.Creatives.Where(x => x.UserId == userId).ToList()
                                orderby c.CreateData descending
                                select c;
                return JsonConvert.SerializeObject(creatives);
            }
        }

        public static void CreateCreative(CreativeView creative, string userId)
        {
            Creative newCreative = new Creative(creative, userId);

            using (var db = new ApplicationDbContext())
            {
                db.Creatives.Add(newCreative);
                db.Users.Find(userId).CountCreatives++;
                db.SaveChanges();
            }

            if (creative.Chapters != null)
            foreach (ChapterView chapter in creative.Chapters)
            {
                Chapter newChapter = new Chapter(chapter, newCreative.Id);

                using (var db = new ApplicationDbContext())
                {
                    db.Chapters.Add(newChapter);
                    db.SaveChanges();
                }

                if(chapter.Tags != null)
                foreach (Tag tag in chapter.Tags)
                {
                    Tag newTag = new Tag(tag, newChapter.Id);

                    using (var db = new ApplicationDbContext())
                    {
                        db.Tags.Add(newTag);
                        db.SaveChanges();
                    }
                }
            }
        }
    }
}