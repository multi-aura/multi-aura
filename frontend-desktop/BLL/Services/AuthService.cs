using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Repositories.IRepositories;
using BLL.Network;
using DTO;
using DTO.Utils;
using Newtonsoft.Json;
namespace BLL.Services
{
    public class AuthService
    {
        private readonly IAuthRepository _authRepository;
        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        public async Task<(User, string)> LoginAsync(LoginRequest loginRequest)
        {
            var response = await _authRepository.LoginAsync(loginRequest);

            if (response is SuccessResponse<string> successResponse)
            {
                try
                {
                    var userData = JsonConvert.DeserializeObject<User>(successResponse.Data);
                    return (userData, string.Empty);
                }
                catch (Exception ex)
                {
                    return (null, $"Error parsing user data: {ex.Message}");
                }
            }

            if (response is ErrorResponse<string> errorResponse)
            {
                return (null, errorResponse.Message);
            }

            return (null, "Unknown error occurred.");
        }

    }
}
