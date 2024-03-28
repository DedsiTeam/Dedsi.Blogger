using System;
using System.Threading.Tasks;

namespace Dedsi.Blogger.Article.Articles;

public interface IArticleAppService
{
    Task<ArticleDto> GetAsync(Guid id);
}