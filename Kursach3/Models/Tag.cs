using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kursach3.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ChapterId { get; set; }

        public Tag() { }

        public Tag(Tag tag, int chapterId)
        {
            Name = tag.Name;
            ChapterId = chapterId;
        }
    }
}