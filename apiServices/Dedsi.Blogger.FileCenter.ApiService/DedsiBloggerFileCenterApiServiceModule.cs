using Dedsi.Blogger.ApiService;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace Dedsi.Blogger.FileCenter.ApiService;

[DependsOn(
    typeof(FileCenterApplicationModule),
    typeof(DedsiBloggerFileCenterSqlSugarModule),
    typeof(FileCenterHttpApiModule)
)]
public class DedsiBloggerFileCenterApiServiceModule  : DedsiBloggerApiServiceModule
{
    protected override string ApiServiceName => FileCenterRemoteServiceConsts.ModuleName;
    protected override string ApiServiceVersion => "V1";
    protected override string RedisKeyPrefix => ApiServiceName;
    
    protected override void ConfigureApiServices(ServiceConfigurationContext context)
    {

    }

    protected override void OnApiServiceInitialization(ApplicationInitializationContext context)
    {

    }
}