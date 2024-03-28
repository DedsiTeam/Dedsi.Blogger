using Dedsi.Blogger.Identity.Users;

namespace Dedsi.Blogger.Identity.Authorizations;

public record LoginInputDto(string Account,string PassWord);

public record LoginResultDto(string Token,UserDto User);