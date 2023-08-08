using auth_service.Application.DTOs.User.Login;
using auth_service.Application.DTOs.User.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auth_service.Tests.Mocks
{
    public static class ResponsesMocks
    {
        public static RegisterUserResponseDTO GetRegisterUserResponseDTO()
        {
            return new RegisterUserResponseDTO(201, new RegisterUserResponseBody("email", "password"));
        }
        public static LoginResponseBody GetLoginResponseBody()
        {
            return new LoginResponseBody("token", DateTime.Now);
        }
    }
}
