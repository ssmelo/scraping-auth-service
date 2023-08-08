using auth_service.Application.DTOs.User.Login;
using auth_service.Application.DTOs.User.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auth_service.Tests.Mocks
{
    public static class RequestsMocks
    {
        public static RegisterUserRequestDTO GetRegisterUserRequestDTO()
        {
            return new RegisterUserRequestDTO();
        }

        public static LoginRequestDTO GetLoginUserRequestDTO()
        {
            return new LoginRequestDTO();
        }
    }
}
