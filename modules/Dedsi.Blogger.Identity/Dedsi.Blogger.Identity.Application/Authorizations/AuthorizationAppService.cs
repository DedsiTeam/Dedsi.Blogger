using System.Threading.Tasks;
using Dedsi.Blogger.Identity.Users;

namespace Dedsi.Blogger.Identity.Authorizations;

public class AuthorizationAppService : IdentityAppService, IAuthorizationAppService
{
    public async Task<LoginResultDto> LoginAsync(LoginInputDto input)
    {
        return new LoginResultDto(GuidGenerator.Create().ToString(),new UserDto());
    }
}