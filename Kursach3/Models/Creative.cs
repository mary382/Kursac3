using Kursach3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kursach3.Models
{
    public class Creative
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Rank { get; set; }
        public int Count { get; set; }
        public DateTime CreateData { get; set; }
        public DateTime RedactData { get; set; }
        public string UserId { get; set; }

        public Creative() { }

        public Creative(CreativeView creative, string userId)
        {
            Name = creative.Name;
            Rank = 0;
            Count = 0;
            CreateData = DateTime.Now;
            RedactData = DateTime.Now;
            UserId = userId;
        }
    }

}