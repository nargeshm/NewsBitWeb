using System;
using System.Collections.Generic;

namespace NB.Core.Entites
{
    public class News
    {
        public int NewsId { get; set; }
        public string NewsTitle { get; set; }
        public string LitleTitle { get; set; }
        public string NewsSummary { get; set; }
        public string NewsText { get; set; }
        public string Source { get; set; }
        public int ReadCount { get; set; }

        public DateTime NewsReleasetime { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Media> Medias { get; set; }

    }
}
