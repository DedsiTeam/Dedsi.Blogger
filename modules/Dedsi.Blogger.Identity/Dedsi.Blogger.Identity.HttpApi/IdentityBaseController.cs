using Dedsi.Blogger.Identity.Localization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Dedsi.Blogger.Identity;

[ApiExplorerSettings(GroupName = IdentityRemoteServiceConsts.ModuleName)]
[RemoteService(Name = IdentityRemoteServiceConsts.ModuleName)]
[Area(IdentityRemoteServiceConsts.ModuleName)]
[Route("api/dedsi-blogger-identity/[controller]/[action]")]
public abstract class IdentityBaseController : AbpControllerBase
{
    protected IdentityBaseController()
    {
        LocalizationResource = typeof(IdentityResource);
    }
}