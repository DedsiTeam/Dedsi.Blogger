using Dedsi.Blogger.Article;
using Dedsi.Blogger.Consul;
using Dedsi.Blogger.FileCenter;
using Dedsi.Blogger.Identity;
using Dedsi.Blogger.Ocelot;
using Volo.Abp.Modularity;

namespace Dedsi.Blogger.Public.Gateway;

[DependsOn(
    typeof(ArticleHttpApiModule),
    typeof(FileCenterHttpApiModule),
    typeof(IdentityHttpApiModule),
    
    typeof(DedsiBloggerConsulModule)
)]
public class DedsiBloggerPublicGatewayModule : DedsiBloggerOcelotModule
{
    protected override string[] ApiServiceNames { get; set; } = 
    [
        typeof(DedsiBloggerPublicGatewayModule).Namespace,
        ArticleRemoteServiceConsts.ModuleName,
        FileCenterRemoteServiceConsts.ModuleName,
        IdentityRemoteServiceConsts.ModuleName
    ];

    protected override string ApiServiceVersion { get; set; } = "V1";

}