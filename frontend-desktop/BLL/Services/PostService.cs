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

        // CRUD
        public async Task<(bool, string)> CreatePostAsync(string description, IEnumerable<string> photoPaths)
        {
            var response = await _postRepository.CreatePostAsync(description);

            if (response is SuccessResponse<string> successResponse)
            {
                var postData = JsonConvert.DeserializeObject<dynamic>(successResponse.Data);
                string postId = postData.data._id;

                var (result, errorMessage) = await UploadPostPhotosAsync(postId, photoPaths);
                if (!result)
                {
                    return (false, errorMessage);
                }

                return (true, string.Empty);
            }

            return (false, "Error creating post");
        }

        public async Task<(bool, string)> DeletePostAsync(string postId)
        {
            var response = await _postRepository.DeletePostAsync(postId);
            if (response is SuccessResponse<string> successResponse)
            {
                return (true, successResponse.Message);
            }
            return (false, "Error deleting post");
        }

        public async Task<(List<Post>, string)> GetRecentsAsync(int page = 1, int limit = 10)
        {
            var response = await _postRepository.GetRecentsAsync(page, limit);

            if (response is SuccessResponse<string> successResponse)
            {
                if (string.IsNullOrEmpty(successResponse.Data))
                {
                    return (new List<Post>(), string.Empty);
                }

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
                if (string.IsNullOrEmpty(successResponse.Data))
                {
                    return (new List<Post>(), string.Empty);
                }

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

        //  Interactions
        public async Task<(bool, string)> LikePostAsync(string postId)
        {
            var response = await _postRepository.LikePostAsync(postId);
            if (response is SuccessResponse<string> successResponse)
            {
                return (true, successResponse.Message);
            }
            return (false, "Error liking post");
        }

        public async Task<(bool, string)> UnlikePostAsync(string postId)
        {
            var response = await _postRepository.UnlikePostAsync(postId);
            if (response is SuccessResponse<string> successResponse)
            {
                return (true, successResponse.Message);
            }
            return (false, "Error unliking post");
        }

        public async Task<(bool, string)> LikeCommentAsync(string commentId)
        {
            var response = await _postRepository.LikeCommentAsync(commentId);
            if (response is SuccessResponse<string> successResponse)
            {
                return (true, successResponse.Message);
            }
            return (false, "Error liking comment");
        }

        public async Task<(bool, string)> UnlikeCommentAsync(string commentId)
        {
            var response = await _postRepository.UnlikeCommentAsync(commentId);
            if (response is SuccessResponse<string> successResponse)
            {
                return (true, successResponse.Message);
            }
            return (false, "Error unliking comment");
        }

        public async Task<(bool, string)> LikeReplyCommentAsync(string commentId, string replyId)
        {
            var response = await _postRepository.LikeReplyCommentAsync(commentId, replyId);
            if (response is SuccessResponse<string> successResponse)
            {
                return (true, successResponse.Message);
            }
            return (false, "Error liking reply comment");
        }

        public async Task<(bool, string)> UnlikeReplyCommentAsync(string commentId, string replyId)
        {
            var response = await _postRepository.UnlikeReplyCommentAsync(commentId, replyId);
            if (response is SuccessResponse<string> successResponse)
            {
                return (true, successResponse.Message);
            }
            return (false, "Error unliking reply comment");
        }


        public async Task<(bool, string)> UploadPostPhotosAsync(string postId, IEnumerable<string> photoPaths)
        {
            var response = await _postRepository.UploadPostPhotosAsync(postId, photoPaths);
            if (response is SuccessResponse<string> successResponse)
            {
                return (true, successResponse.Message);
            }
            return (false, "Error uploading photos");
        }


    }
}
