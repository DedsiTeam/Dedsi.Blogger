using Dedsi.Blogger.ApiService;

namespace Dedsi.Blogger.FileCenter.ApiService;

public class Program : DedsiBloggerProgram
{
    public static Task<int> Main(string[] args)
    {
        return RunMain<DedsiBloggerFileCenterApiServiceModule>(typeof(Program).Namespace, args);
    }
}