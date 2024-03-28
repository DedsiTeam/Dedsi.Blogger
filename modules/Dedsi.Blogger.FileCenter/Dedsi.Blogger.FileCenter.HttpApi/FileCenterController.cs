using Dedsi.Blogger.FileCenter.Localization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Dedsi.Blogger.FileCenter;

[ApiExplorerSettings(GroupName = FileCenterRemoteServiceConsts.ModuleName)]
[RemoteService(Name = FileCenterRemoteServiceConsts.ModuleName)]
[Area(FileCenterRemoteServiceConsts.ModuleName)]
[Route("api/dedsi-blogger-file-center/[controller]/[action]")]
public abstract class FileCenterController : AbpControllerBase
{
    protected FileCenterController()
    {
        LocalizationResource = typeof(FileCenterResource);
    }
}

public class IdentityController : FileCenterController
{
    [HttpPost]
    public string Get() => "21323";
}