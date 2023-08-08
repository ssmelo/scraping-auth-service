using auth_service.Application.DTOs.User.Register;
using auth_service.Application.Interfaces.Services;
using auth_service.Domain.Errors;
using auth_service.Domain.Models;
using auth_service.Infrastructure;
using auth_service.Tests.Mocks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Writers;
using Moq;

namespace auth_service.Tests.Infrastructure.Services
{
    public class IdentityServiceTests
    {
        private readonly IdentityService _identityService;

        private readonly Mock<UserManagerMock> _userManager;
        private readonly Mock<SignInManagerMock> _signInManager;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<IConfiguration> _config;

        public IdentityServiceTests()
        {
            _userManager = new Mock<UserManagerMock>();
            _signInManager = new Mock<SignInManagerMock>();
            _mapper = new Mock<IMapper>();
            _config = new Mock<IConfiguration>();

            _identityService = new IdentityService(_signInManager.Object, _userManager.Object, _mapper.Object, _config.Object);
        }

        [Fact]
        public async void RegisterUser_SuccessfulRegistration_ReturnsUser()
        {
            var userRequestDTO = RequestsMocks.GetRegisterUserRequestDTO();

            _userManager
                .Setup(manager => manager.CreateAsync(It.IsAny<User>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);

            _userManager
                .Setup(manager => manager.SetLockoutEnabledAsync(It.IsAny<User>(), false))
                .ReturnsAsync(IdentityResult.Success);

            var exception = await Record.ExceptionAsync(() => _identityService.RegisterUser(userRequestDTO));

            Assert.Null(exception);
        }

        [Theory]
        [MemberData(nameof(GetIdentityErrorsList))]
        public async void RegisterUser_FailureRegistration_ReturnsUser(List<IdentityError> identityErrors)
        {
            var userRequestDTO = RequestsMocks.GetRegisterUserRequestDTO();

            _userManager
                .Setup(manager => manager.CreateAsync(It.IsAny<User>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Failed(identityErrors.ToArray()));

            var exception = await Assert.ThrowsAsync<DefaultException>(() => _identityService.RegisterUser(userRequestDTO));
           
            var identityErrorsMessages = identityErrors.Select(err => err.Description).ToList();
            Assert.Equal(identityErrorsMessages, exception.Errors);
        }

        public static IEnumerable<object[]> GetIdentityErrorsList()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new List<IdentityError>() 
                    {
                        new IdentityError() { Code = "code", Description = "description" },
                        new IdentityError() { Code = "code", Description = "description2" }
                    }
                },
                new object[]
                {
                    new List<IdentityError>() { }
                }
            };
        }
    }
}
