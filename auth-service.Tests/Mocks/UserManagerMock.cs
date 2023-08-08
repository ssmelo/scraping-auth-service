using auth_service.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;

namespace auth_service.Tests.Mocks
{
    public class UserManagerMock : UserManager<User>
    {
        public UserManagerMock()
           : base(new Mock<IUserStore<User>>().Object,
             new Mock<IOptions<IdentityOptions>>().Object,
             new Mock<IPasswordHasher<User>>().Object,
             new IUserValidator<User>[0],
             new IPasswordValidator<User>[0],
             new Mock<ILookupNormalizer>().Object,
             new Mock<IdentityErrorDescriber>().Object,
             new Mock<IServiceProvider>().Object,
             new Mock<ILogger<UserManager<User>>>().Object)
        { }
    }
}
