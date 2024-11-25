using BLL.Network;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Repositories.IRepositories
{
    public interface IPostRepository
    {
        //CRUD
        Task<APIResponse<string>> CreatePostAsync(string description);
        Task<APIResponse<string>> DeletePostAsync(string postId);

        //GET
        Task<APIResponse<string>> GetRecentsAsync(int page, int limit);
        Task<APIResponse<string>> GetPostsByUserAsync(string userId);
        Task<APIResponse<string>> GetCommentsByPostIDAsync(string postId);

        //Interactions
        Task<APIResponse<string>> LikePostAsync(string postId);
        Task<APIResponse<string>> UnlikePostAsync(string postId);
        Task<APIResponse<string>> LikeCommentAsync(string commentId);
        Task<APIResponse<string>> UnlikeCommentAsync(string commentId);
        Task<APIResponse<string>> LikeReplyCommentAsync(string commentId, string replyId);
        Task<APIResponse<string>> UnlikeReplyCommentAsync(string commentId, string replyId);

        //Upload medias
        Task<APIResponse<string>> UploadPostPhotosAsync(string postId, IEnumerable<string> photoPaths);
    }
}
