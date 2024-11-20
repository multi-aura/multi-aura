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
    public class SearchDataProvider
    {
        private static SearchDataProvider instance;
        private static readonly object padlock = new object();
        public static SearchDataProvider Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new SearchDataProvider();
                    }
                    return instance;
                }
            }
        }


        private AppDataProvider appDataProvider = AppDataProvider.Instance;

        private RelationshipRepository relationshipRepository;
        private RelationshipService relationshipService;
        private SearchRepository searchRepository;
        private SearchService searchService;

        private List<Post> forYouPosts = null;
        public List<Post> ForYouPosts
        {
            get => forYouPosts;
        }

        private List<UserSummary> followers = null;
        public List<UserSummary> Followers
        {
            get => followers;
        }

        private List<UserSummary> followings = null;
        public List<UserSummary> Followings
        {
            get => followings;
        }

        private List<UserSummary> friends = null;
        public List<UserSummary> Friends
        {
            get => friends;
        }

        public event Action FriendDataLoaded;
        public event Action ForYouNoQueryDataLoaded;
        public event Action FollowerDataLoaded;
        public event Action FollowingDataLoaded;

        private SearchDataProvider()
        {
            relationshipRepository = RelationshipRepository.Instance;
            relationshipService = new RelationshipService(relationshipRepository);

            searchRepository = SearchRepository.Instance;
            searchService = new SearchService(searchRepository);

            Initialize();
        }

        public void Initialize()
        {
            //FetchUserFriends();
            FetchForYouNoQuery();
            //FetchFollowers();
            //FetchFollowings();
        }
        
        private async void FetchForYouNoQuery()
        {
            if (appDataProvider.User != null && !string.IsNullOrEmpty(appDataProvider.User.Token))
            {
                var (list, errorMessage) = await searchService.SearchForYouAsync("", 1, 10);

                if (string.IsNullOrEmpty(errorMessage))
                {
                    this.forYouPosts = list;
                    ForYouNoQueryDataLoaded?.Invoke();
                }
                else
                {
                    MessageBox.Show("Error fetching for you posts: " + errorMessage);
                }
            }
        }

        private async void FetchUserFriends()
        {
            if (appDataProvider.User != null && !string.IsNullOrEmpty(appDataProvider.User.Token))
            {
                var (friends, errorMessage) = await relationshipService.GetFriendsAsync();

                if (string.IsNullOrEmpty(errorMessage))
                {
                    this.friends = friends;
                    FriendDataLoaded?.Invoke(); // Gọi sự kiện khi dữ liệu đã tải xong
                }
                else
                {
                    MessageBox.Show("Error fetching friends: " + errorMessage);
                }
            }
        }

        private async void FetchFollowers()
        {
            if (appDataProvider.User != null && !string.IsNullOrEmpty(appDataProvider.User.Token))
            {
                var (suggests, errorMessage) = await relationshipService.GetFollowersAsync();

                if (string.IsNullOrEmpty(errorMessage))
                {
                    this.followers = suggests;
                    FollowerDataLoaded?.Invoke();
                }
                else
                {
                    MessageBox.Show("Error fetching followers: " + errorMessage);
                }
            }
        }

        private async void FetchFollowings()
        {
            if (appDataProvider.User != null && !string.IsNullOrEmpty(appDataProvider.User.Token))
            {
                var (list, errorMessage) = await relationshipService.GetFollowingsAsync();

                if (string.IsNullOrEmpty(errorMessage))
                {
                    this.followings = list;
                    FollowingDataLoaded?.Invoke();
                }
                else
                {
                    MessageBox.Show("Error fetching followings: " + errorMessage);
                }
            }
        }
    }
}
