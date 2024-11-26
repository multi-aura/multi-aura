using BLL.Network;
using BLL.Repositories.IRepositories;
using BLL.Repositories.Repositories;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using DTO;

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
        //CRUD
        public async Task<APIResponse<string>> CreatePostAsync(string description)
        {
            var requestBody = new
            {
                description = description
            };

            return await PostAsync(NetworkUrls.Post.CreatePost, requestBody);
        }

        public async Task<APIResponse<string>> DeletePostAsync(string postId)
        {
            string url = $"{NetworkUrls.Post.DeletePost}/{postId}";
            return await DeleteAsync(url);
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

        //Interactions
        public async Task<APIResponse<string>> LikePostAsync(string postId)
        {
            string url = $"{NetworkUrls.Post.LikePost}/{postId}";
            return await PostAsync(url);
        }

        public async Task<APIResponse<string>> UnlikePostAsync(string postId)
        {
            string url = $"{NetworkUrls.Post.UnlikePost}/{postId}";
            return await DeleteAsync(url);
        }

        public async Task<APIResponse<string>> LikeCommentAsync(string commentId)
        {
            string url = $"{NetworkUrls.Post.LikeComment}/{commentId}";
            return await PostAsync(url);
        }

        public async Task<APIResponse<string>> UnlikeCommentAsync(string commentId)
        {
            string url = $"{NetworkUrls.Post.UnlikeComment}/{commentId}";
            return await DeleteAsync(url);
        }

        public async Task<APIResponse<string>> LikeReplyCommentAsync(string commentId, string replyId)
        {
            string url = $"{NetworkUrls.Post.LikeReplyComment}/{commentId}/{replyId}";
            return await PostAsync(url);
        }

        public async Task<APIResponse<string>> UnlikeReplyCommentAsync(string commentId, string replyId)
        {
            string url = $"{NetworkUrls.Post.UnlikeReplyComment}/{commentId}/{replyId}";
            return await DeleteAsync(url);
        }

        //Upload medias
        public async Task<APIResponse<string>> UploadPostPhotosAsync(string postId, IEnumerable<string> photoPaths)
        {
            string url = $"{NetworkUrls.Upload.UploadPostPhotos}/{postId}";

            using (var formData = new MultipartFormDataContent())
            {
                foreach (var photoPath in photoPaths)
                {
                    var fileContent = new ByteArrayContent(File.ReadAllBytes(photoPath));
                    fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");
                    formData.Add(fileContent, "photos", Path.GetFileName(photoPath));
                }

                return await PostAsync(url, formData, isFormData: true);
            }
        }

    }
}
