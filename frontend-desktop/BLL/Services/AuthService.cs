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
                    var userData = JsonConvert.DeserializeObject<dynamic>(successResponse.Data);
                    Console.WriteLine($"[INFO] SuccessResponse Received - Data: {successResponse.Data}");

                    if (userData?.data?.data == null)
                    {
                        return (null, "API response data is empty or invalid.");
                    }

                    var userDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(userData.data.data.ToString());
                    var token = userData.data.token?.ToString();

                    var userProfile = User.FromDictionary(userDict);

                    if (userProfile != null)
                    {
                        userProfile.Token = token;
                        return (userProfile, string.Empty);
                    }

                    return (null, "Failed to parse user profile.");
                }
                catch (JsonException ex)
                {
                    return (null, $"Error parsing response: {ex.Message}");
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

            return (null, "Unknown error.");
        }
    }
}
