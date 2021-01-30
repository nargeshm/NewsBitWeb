using NB.Core.Contracts.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using NB.Core.Contracts.Service;
using NB.Core.Entites;

public class NewsService : INewsService
{
    private readonly INewsRepository newsRepository;

    public NewsService(INewsRepository newsRepository)
    {
        this.newsRepository = newsRepository;
    }

    public List<News> GetPopularNews()
    {
        return newsRepository.GetPopularNews()
             .Take(4).ToList();
    }

    public List<News> GetRecentNews()
    {
        return newsRepository.GetRecentNews();
    }

    public List<News> NewsSearch(string q, int pageNumber, int PageSize)
    {
        return newsRepository.GetFilterNews(q, pageNumber, PageSize);
    }


    public News Get(String Little)
    {
        return newsRepository.Get(Little);
    }
}