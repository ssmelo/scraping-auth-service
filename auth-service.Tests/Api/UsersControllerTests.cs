using auth_service.Api;
using auth_service.Application.DTOs.User.Login;
using auth_service.Application.DTOs.User.Register;
using auth_service.Application.Interfaces.Services;
using auth_service.Domain.Models;
using auth_service.Infrastructure;
using auth_service.Tests.Mocks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auth_service.Tests.Api
{
    public class UsersControllerTests
    {
        private readonly UsersController _usersController;

        private readonly Mock<IIdentityService> _identityServiceMock;

        public UsersControllerTests()
        {
            _identityServiceMock = new Mock<IIdentityService>();
            _usersController = new UsersController(_identityServiceMock.Object);
        }

        [Fact]
        public async void RegisterUser_SuccessfulRegistration_Returns201()
        {
            var registerUserRequestMock = RequestsMocks.GetRegisterUserRequestDTO();
            var userResponseMock = new Mock<User>().Object;

            _identityServiceMock
                .Setup(service => service.RegisterUser(registerUserRequestMock))
                .ReturnsAsync(userResponseMock);

            var result = await _usersController.RegisterUser(registerUserRequestMock);

            var actionResult = Assert.IsType<CreatedAtActionResult>(result);
            var returnValue = Assert.IsType<RegisterUserResponseDTO>(actionResult.Value);
            Assert.Equal(201, returnValue.StatusCode);
            Assert.Equal(registerUserRequestMock.FirstName, returnValue.Data.FirstName);
            Assert.Equal(registerUserRequestMock.Email, returnValue.Data.Email);
        }

        [Fact]
        public async void Login_SuccessfulLogin_Returns200()
        {
            var loginRequestMock = RequestsMocks.GetLoginUserRequestDTO();
            var loginResponseBodyMock = ResponsesMocks.GetLoginResponseBody();

            _identityServiceMock
                .Setup(service => service.Login(loginRequestMock))
                .ReturnsAsync(loginResponseBodyMock);

            var result = await _usersController.Login(loginRequestMock);

            var actionResult = Assert.IsType<CreatedAtActionResult>(result);
            var returnValue = Assert.IsType<LoginResponseDTO>(actionResult.Value);
            Assert.Equal(200, returnValue.StatusCode);
            Assert.Equal(loginResponseBodyMock, returnValue.Data);
        }
    }
}
