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
            if (loginRequest == null)
            {
                throw new ArgumentNullException(nameof(loginRequest), "LoginRequest is null.");
            }

            var response = await _authRepository.LoginAsync(loginRequest);

            if (response == null)
            {
                return (null, "API response is null.");
            }
            if (response is SuccessResponse<string> successResponse)
            {
                try
                {

                    if (string.IsNullOrEmpty(successResponse.Data))
                    {
                        return (null, "API response data is empty.");
                    }

                    var userData = JsonConvert.DeserializeObject<User>(successResponse.Data);

                    if (userData == null)
                    {
                        return (null, "Failed to deserialize user data.");
                    }

                    return (userData, string.Empty);
                }
                catch (JsonException ex)
                {
                    return (null, $"Error parsing user data: {ex.Message}");
                }
                catch (Exception ex)
                {
                    return (null, $"Unexpected error: {ex.Message}");
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
