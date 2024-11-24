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
        private AuthRepository() : base() { }

        public async Task<APIResponse<string>> LoginAsync(LoginRequest loginRequest)
        {
            return await PostAsync(NetworkUrls.Auth.Login, loginRequest);
        }

    }
}
