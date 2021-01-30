using System;
using System.Collections.Generic;
using System.Text;

namespace NB.Core.Entites
{
    public class Author
    {
        public int AuthorId { get; set; }
       
        public string AuthorName { get; set; }
      
        public string SurName { get; set; }
       
        public string UserName { get; set; }

       
        public string PassWord { get; set; }
       
        public string Email { get; set; }

        public List<News> News { get; set; }

    }
}
