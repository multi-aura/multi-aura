using BLL.Network;
using BLL.Repositories.IRepositories;
using BLL.Repositories.Repositories;
using System.Threading.Tasks;

namespace BLL.Repository
{
    public class PostRepository : BaseRepository, IPostRepository
    {
        private static PostRepository instance;
        private static readonly object padlock = new object();
        public static PostRepository Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new PostRepository();
                    }
                    return instance;
                }
            }
        }

        private PostRepository() : base()
        {
        }

        public async Task<APIResponse<string>> GetRecentsAsync(int page, int limit)
        {
            var requestBody = new
            {
                limit = limit,
                page = page
            };

            return await PostAsync(NetworkUrls.Post.GetRecentPosts, requestBody);
        }

        public async Task<APIResponse<string>> GetPostsByUserAsync(string userId)
        {
            string url = $"{NetworkUrls.Post.GetPostsByUser}/{userId}";
            return await PostAsync(url);
        }

        public async Task<APIResponse<string>> GetCommentsByPostIDAsync(string postId)
        {
            string url = $"{NetworkUrls.Post.GetCommentsByPostID}/{postId}";
            return await PostAsync(url);
        }
    }
}
