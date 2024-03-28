using Dedsi.Blogger.ApiService;

namespace Dedsi.Blogger.Article.ApiService;

public class Program : DedsiBloggerProgram
{
    public static Task<int> Main(string[] args)
    {
        return RunMain<DedsiBloggerArticleApiServiceModule>(typeof(Program).Namespace, args);
    }
}