using Volo.Abp.Reflection;

namespace Dedsi.Blogger.Article.Permissions;

public class ArticlePermissions
{
    public const string GroupName = "Article";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(ArticlePermissions));
    }
}
