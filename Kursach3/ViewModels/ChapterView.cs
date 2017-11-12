using Kursach3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kursach3.ViewModels
{
    public class ChapterView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int Position { get; set; }
        public Tag[] Tags { get; set; }

        public ChapterView() { }

        public ChapterView(Chapter chapter, Tag[] tags)
        {
            Id = chapter.Id;
            Name = chapter.Name;
            Text = chapter.Text;
            Position = chapter.Position;
            Tags = tags;
        }
    }
}