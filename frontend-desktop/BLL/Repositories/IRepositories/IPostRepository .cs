using BLL.Network;
using System.Threading.Tasks;

namespace BLL.Repositories.IRepositories
{
    public interface IPostRepository
    {
        Task<APIResponse<string>> GetRecentsAsync(int page, int limit);
        Task<APIResponse<string>> GetPostsByUserAsync(string userId);
        Task<APIResponse<string>> GetCommentsByPostIDAsync(string postId);
    }
}
