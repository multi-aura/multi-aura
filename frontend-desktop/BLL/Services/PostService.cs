using BLL.Network;
using BLL.Repositories.IRepositories;
using DTO;
using DTO.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

        public async Task<(List<Post>, string)> GetPostsByUserAsync(string userId)
        {
            var response = await _postRepository.GetPostsByUserAsync(userId);

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

        public async Task<(List<Comment>, string)> GetCommentsByPostIDAsync(string postId)
        {
            try
            {
                var response = await _postRepository.GetCommentsByPostIDAsync(postId);

                if (response is SuccessResponse<string> successResponse)
                {
                    var jsonObject = JsonConvert.DeserializeObject<dynamic>(successResponse.Data);
                    var commentsData = jsonObject.ToObject<Dictionary<string, object>>();
                    var list = DictionaryConverter.ParseCommentList(commentsData, "data");
                    //var list = new List<Comment>();

                    //if (jsonObject.data != null)
                    //{
                    //    // Loop through each post item and create Post object
                    //    foreach (var item in jsonObject.data)
                    //    {
                    //        var postData = item.ToObject<Dictionary<string, object>>();
                    //        var post = Post.FromDictionary(postData);
                    //        list.Add(post);
                    //    }
                    //}

                    return (list, string.Empty);
                }

                if (response is ErrorResponse<string> errorResponse)
                {
                    return (null, errorResponse.Message);
                }

                return (null, "Unknown error");
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }

    }
}
