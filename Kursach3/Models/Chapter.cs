using Kursach3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kursach3.Models
{
    public class Chapter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int Position { get; set; }
        public int CreativeId { get; set; }

        public Chapter() { }

        public Chapter(ChapterView chapter, int creativeId)
        {
            Name = chapter.Name;
            Text = chapter.Text;
            Position = chapter.Position;
            CreativeId = creativeId;
        }
    }
}