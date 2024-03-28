using Dedsi.Blogger.Identity.Localization;
using Volo.Abp.Application.Services;

namespace Dedsi.Blogger.Identity;

public abstract class IdentityAppService : ApplicationService
{
    protected IdentityAppService()
    {
        LocalizationResource = typeof(IdentityResource);
        ObjectMapperContext = typeof(IdentityApplicationModule);
    }
}
