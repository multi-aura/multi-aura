using BLL.Network;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BLL.Repositories.IRepositories
{
    public interface IPostRepository
    {
        Task<APIResponse<string>> GetRecentsAsync(int page, int limit);
    }
}
