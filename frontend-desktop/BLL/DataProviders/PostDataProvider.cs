using BLL.Repository;
using BLL.Services;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL.DataProviders
{
    public class PostDataProvider
    {
        private static PostDataProvider instance;
        private static readonly object padlock = new object();
        public static PostDataProvider Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new PostDataProvider();
                    }
                    return instance;
                }
            }
        }


        private AppDataProvider appDataProvider = AppDataProvider.Instance;

        private PostRepository postRepository;
        private PostService postService;

        private List<Post> recentPosts = null;
        public List<Post> RecentPosts
        {
            get => recentPosts;
        }

        public event Action RecentPostsDataLoaded;

        private PostDataProvider()
        {
            postRepository = PostRepository.Instance;
            postService = new PostService(postRepository);

            Initialize();
        }

        public void Initialize()
        {
            FetchRecentPosts();
        }
        
        private async void FetchRecentPosts()
        {
            if (appDataProvider.User != null && !string.IsNullOrEmpty(appDataProvider.User.Token))
            {
                var (list, errorMessage) = await postService.GetRecentsAsync(1, 10);

                if (string.IsNullOrEmpty(errorMessage))
                {
                    this.recentPosts = list;
                    RecentPostsDataLoaded?.Invoke();
                }
                else
                {
                    MessageBox.Show("Error fetching recent posts: " + errorMessage);
                }
            }
        }
    }
}
