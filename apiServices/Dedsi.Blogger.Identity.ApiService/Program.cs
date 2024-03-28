using Dedsi.Blogger.ApiService;

namespace Dedsi.Blogger.Identity.ApiService;

public class Program : DedsiBloggerProgram
{
    public static Task<int> Main(string[] args)
    {
        return RunMain<DedsiBloggerIdentityApiServiceModule>(typeof(Program).Namespace, args);
    }
}