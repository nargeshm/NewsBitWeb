using NB.Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace NB.Core.Contracts.Repository
{
    public interface INewsRepository
    {
        News Get(string Little);
        //for Search by category
        List<News> GetFilterNews(string search, int pageNumber, int PageSize);

        List<News> GetPopularNews();
        List<News> GetRecentNews();
        List<News> GetTopNews();
        List<News> GetbreakingNews();

    }
}
