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
                Console.WriteLine($"[INFO] SuccessResponse Received - Data: {successResponse.Data}");

                try
                {
                    if (string.IsNullOrEmpty(successResponse.Data))
                    {
                        return (null, "API response data is empty.");
                    }

                    // Deserialize the data into a dictionary
                    var dataDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(successResponse.Data);
                    Console.WriteLine($"dataDict: {dataDict}");

                    if (dataDict != null)
                    {
                        // Parse thông tin user
                        var userProfile = User.FromDictionary(dataDict);
                        Console.WriteLine($"Data: {userProfile.FullName}");

                        if (userProfile != null)
                        {
                            return (userProfile, string.Empty);
                        }
                        return (null, "Failed to parse user profile");
                    }

                    return (null, "Failed to parse response data into dictionary");
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

            return (null, "Unknown error");
        }



    }
}
