using Dedsi.Blogger.Consul;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Volo.Abp.AspNetCore.Mvc;

namespace Dedsi.Blogger.Public.Gateway;

[ApiExplorerSettings(GroupName = "Dedsi.Blogger.Public.Gateway")]
[Route("api/Health/[action]")]
public class HealthController(IOptions<ConsulConfigOptions> consulConfigOption) : AbpController
{
    /// <summary>
    /// 心跳检查接口
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public Task<string> CheckAsync() => Task.FromResult(consulConfigOption.Value.ServiceName + " is Ok!!!");
}