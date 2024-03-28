namespace Dedsi.Blogger.Article;

public static class ArticleDbProperties
{
    public static string DbTablePrefix { get; set; } = "Article";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "ArticleDB";
}
