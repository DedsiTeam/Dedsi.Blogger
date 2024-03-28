using Dedsi.Blogger.Article.Localization;
using Volo.Abp.Application.Services;

namespace Dedsi.Blogger.Article;

public abstract class ArticleBaseAppService : ApplicationService
{
    protected ArticleBaseAppService()
    {
        LocalizationResource = typeof(ArticleResource);
        ObjectMapperContext = typeof(ArticleApplicationModule);
    }
}
