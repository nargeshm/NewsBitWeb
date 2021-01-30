using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NB.Core.Contracts.Service;
using NB.Core.Entites;
using NB.Infrastruture.Sql;
using PresentationHost.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationHost.Controllers
{
    public class HomeController : Controller
    {
        private readonly INewsService newsService;
        private readonly NewsContext ctx;

        public HomeController(INewsService newsService, NewsContext ctx)
        {
            this.newsService = newsService;
            this.ctx = ctx;
        }
        //dont foget get the pic & title from db
        public IActionResult Index()
        {
            List<News> News = newsService.GetRecentNews();
            ViewBag.News = News;

            return View();
        }
        //for email:
        public ContentResult NewsLetter(string Email)
        {


            if (ctx.Users.Any(a => a.Email == Email))
            {

                return Content("your Email has already been registered in the NewsLetter!");

            }
            User Users = new User()
            {
                Email = Email,
            };
            ctx.Users.Add(Users);
            ctx.SaveChanges();

            return Content("your name was recorded in the NewsLetter!  thank you.");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        //show detail of news:
        public IActionResult Detail(string little)
        {
            News news = newsService.Get(little);
            return View(news);
        }
        /* return  news by category */
        public IActionResult News(string Category)
        {
            ViewBag.name = Category;

            var CategoryN = ctx.Categories.Single(a => a.CategoryName == Category);
            var NewsContext = ctx.Entry(CategoryN).Collection(b => b.News)
                .Query().Include(b => b.Author).Include(b => b.Medias);

            return View(NewsContext.ToList());
        }
        //for search news:
        public IActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Search(string q, int page = 1)
        {
            
            string format = "";
            
            
            var data = newsService.NewsSearch(q, page, 4);
            foreach (var item in data)
            {
                string images = $"/images/{ item.Medias[0].Path as string}";
                string src =$"/Home/Detail/?little={item.LitleTitle}";

                format += $"<hr /><ul class={"row - popular"}> <section class={"popular - text"}><p><a href={src}>{item.NewsTitle}</a></p><li><img src={images}  style = {"border:1px;height:100px;width:120px"} /><p style = {"height:50px;width:830px"}><a href={src}>{item.NewsReleasetime} ... {item.NewsSummary}</a></p></li></section></ul><hr />";


            }
            return Content(format);
        }
        public IActionResult SearchByTitle(string q, int page = 1)
        {
            var data = newsService.NewsSearch(q, page, 4);

            return View(data);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
