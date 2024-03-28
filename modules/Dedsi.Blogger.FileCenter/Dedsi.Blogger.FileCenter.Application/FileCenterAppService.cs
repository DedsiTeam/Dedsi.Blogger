using Dedsi.Blogger.FileCenter.Localization;
using Volo.Abp.Application.Services;

namespace Dedsi.Blogger.FileCenter;

public abstract class FileCenterAppService : ApplicationService
{
    protected FileCenterAppService()
    {
        LocalizationResource = typeof(FileCenterResource);
        ObjectMapperContext = typeof(FileCenterApplicationModule);
    }
}
