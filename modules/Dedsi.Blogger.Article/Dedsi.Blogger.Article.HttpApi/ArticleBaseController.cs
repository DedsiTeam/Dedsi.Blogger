using Dedsi.Blogger.Article.Localization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Dedsi.Blogger.Article;

[ApiExplorerSettings(GroupName = ArticleRemoteServiceConsts.ModuleName)]
[RemoteService(Name = ArticleRemoteServiceConsts.ModuleName)]
[Area(ArticleRemoteServiceConsts.ModuleName)]
[Route("api/dedsi-blogger-article/[controller]/[action]")]
public abstract class ArticleBaseController : AbpControllerBase
{
    protected ArticleBaseController()
    {
        LocalizationResource = typeof(ArticleResource);
    }
}