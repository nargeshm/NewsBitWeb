using NB.Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace NB.Core.Contracts.Service
{
    public interface INewsService
    {
        News Get(string little);
        List<News> NewsSearch(string q, int pageNumber, int PageSize);

        List<News> GetPopularNews();
        List<News> GetRecentNews();
    }
}
