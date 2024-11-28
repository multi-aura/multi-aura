using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Network;
using BLL.Repositories.IRepositories;
using BLL.Repositories.Repositories;
using DTO;
namespace BLL.Repository
{
    public class AuthRepository:BaseRepository,IAuthRepository
    {
        private static AuthRepository instance;
        private static readonly object padlock = new object();
        public static AuthRepository Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new AuthRepository();
                    }
                    return instance;
                }
            }
        }
        private AuthRepository() : base()
        {
            
        }

        public async Task<APIResponse<string>> LoginAsync(LoginRequest loginRequest)
        {
            if (string.IsNullOrEmpty(NetworkUrls.Auth.Login))
            {
                throw new Exception("Auth login URL is not configured or is empty.");
            }

            if (loginRequest == null)
            {
                throw new ArgumentNullException(nameof(loginRequest), "LoginRequest is null.");
            }
            if (string.IsNullOrEmpty(loginRequest.Username) || string.IsNullOrEmpty(loginRequest.Password))
            {
                throw new ArgumentException("Username or Password in LoginRequest is empty.");
            }

            try
            {
                var response = await PostAsync(NetworkUrls.Auth.Login, loginRequest);

                if (response == null)
                {
                    throw new Exception("API response is null.");
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error during login API call: {ex.Message}", ex);
            }
        }



    }
}
