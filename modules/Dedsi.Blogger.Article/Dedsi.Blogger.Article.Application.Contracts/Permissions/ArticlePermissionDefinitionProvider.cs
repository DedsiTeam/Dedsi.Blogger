using Dedsi.Blogger.Article.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Dedsi.Blogger.Article.Permissions;

public class ArticlePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ArticlePermissions.GroupName, L("Permission:Article"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ArticleResource>(name);
    }
}
