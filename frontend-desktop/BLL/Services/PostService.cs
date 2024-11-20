using BLL.DataProviders;
using BLL.Network;
using BLL.Repositories.IRepositories;
using BLL.Repository;
using DTO;
using DTO.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<(List<Post>, string)> GetRecentsAsync(int page = 1, int limit = 10)
        {
            var response = await _postRepository.GetRecentsAsync(page, limit);

            if (response is SuccessResponse<string> successResponse)
            {
                var posts = await Post.ParsePostListAsync(successResponse.Data);
                return (posts, string.Empty);
            }

            if (response is ErrorResponse<string> errorResponse)
            {
                return (null, errorResponse.Message);
            }

            return (null, "Unknown error");
        }
    }
}
