using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Network;
using DTO;
namespace BLL.Repositories.IRepositories
{
    public interface IAuthRepository
    {
        Task<APIResponse<string>> LoginAsync(LoginRequest loginRequest);
    }
}
