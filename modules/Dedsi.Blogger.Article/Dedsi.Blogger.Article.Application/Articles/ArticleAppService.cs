using System;
using System.Threading.Tasks;

namespace Dedsi.Blogger.Article.Articles;

public class ArticleAppService : ArticleBaseAppService, IArticleAppService
{
    public Task<ArticleDto> GetAsync(Guid id)
    {
        return Task.FromResult(new ArticleDto()
        {
            Title = "di"
        });
    }
}