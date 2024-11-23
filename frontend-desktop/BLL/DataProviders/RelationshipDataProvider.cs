using BLL.Repository;
using BLL.Services;
using DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL.DataProviders
{
    public class RelationshipDataProvider
    {
        private static RelationshipDataProvider instance;
        private static readonly object padlock = new object();
        public static RelationshipDataProvider Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new RelationshipDataProvider();
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

        private List<UserSummary> suggestedFriends = null;
        public List<UserSummary> SuggestedFriends
        {
            get => suggestedFriends;
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

        private UserProfile otherProfile = null;
        public UserProfile OtherProfile
        {
            get => otherProfile;
        }

        public event Action FriendDataLoaded;
        public event Action SuggestDataLoaded;
        public event Action FollowerDataLoaded;
        public event Action FollowingDataLoaded;

        public event Action OnFollowEvent;
        public event Action OnUnfollowEvent;

        public event Action OnGetOtherProfileSuccess;

        private RelationshipDataProvider()
        {
            relationshipRepository = RelationshipRepository.Instance;
            relationshipService = new RelationshipService(relationshipRepository);

            searchRepository = SearchRepository.Instance;
            searchService = new SearchService(searchRepository);

            appDataProvider.DataLoaded += Initialize;
        }

        public void Initialize()
        {
            FetchUserFriends();
            FetchSuggestedFriends();
            FetchFollowers();
            FetchFollowings();
        }

        public async void GetProfileDetails(string username)
        {
            if (!string.IsNullOrEmpty(username))
            {
                var (profile, errorMessage) = await GetProfileAsync(username);

                if (string.IsNullOrEmpty(errorMessage))
                {
                    otherProfile = profile;
                    OnGetOtherProfileSuccess?.Invoke();
                }
                else
                {
                    MessageBox.Show("Error fetching other profile: " + errorMessage);
                }
            }

        }

        public async void FetchUserFriends()
        {
            if (appDataProvider.User != null && !string.IsNullOrEmpty(appDataProvider.User.Token))
            {
                var (list, errorMessage) = await relationshipService.GetFriendsAsync();

                if (string.IsNullOrEmpty(errorMessage))
                {
                    this.friends = list;
                    FriendDataLoaded?.Invoke(); // Gọi sự kiện khi dữ liệu đã tải xong
                }
                else
                {
                    MessageBox.Show("Error fetching friends: " + errorMessage);
                }
            }
        }
        public async void FetchSuggestedFriends()
        {
            if (appDataProvider.User != null && !string.IsNullOrEmpty(appDataProvider.User.Token))
            {
                var (list, errorMessage) = await searchService.SearchPeopleAsync();

                if (string.IsNullOrEmpty(errorMessage))
                {
                    this.suggestedFriends = list;
                    SuggestDataLoaded?.Invoke();
                }
                else
                {
                    MessageBox.Show("Error fetching suggested friends: " + errorMessage);
                }
            }
        }

        private async void FetchFollowers()
        {
            if (appDataProvider.User != null && !string.IsNullOrEmpty(appDataProvider.User.Token))
            {
                var (list, errorMessage) = await relationshipService.GetFollowersAsync();

                if (string.IsNullOrEmpty(errorMessage))
                {
                    this.followers = list;
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

        public async Task<(UserProfile, string)> GetProfileAsync(string username = "")
        {
            try
            {
                var result = await relationshipService.GetProfileAsync(username);
                if (!string.IsNullOrEmpty(result.Item2))
                {
                    throw new Exception(result.Item2);  // Lỗi khi lấy profile
                }
                return result;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                Console.WriteLine($"Error fetching profile: {ex.Message}");
                return (null, ex.Message);
            }
        }

        public async Task<(User, string)> GetAuthProfileAsync()
        {
            try
            {
                var result = await relationshipService.GetAuthProfileAsync();
                if (!string.IsNullOrEmpty(result.Item2))
                {
                    throw new Exception(result.Item2);  // Lỗi khi lấy profile
                }
                return result;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                Console.WriteLine($"Error fetching profile: {ex.Message}");
                return (null, ex.Message);
            }
        }

        public async Task<(bool, RelationshipStatus)> Follow(UserSummary user, RelationshipStatus relationshipStatus = null)
        {
            if (user == null && string.IsNullOrEmpty(user.UserID))
            {
                return (false, relationshipStatus);
            }
            if (appDataProvider.User != null && !string.IsNullOrEmpty(appDataProvider.User.Token))
            {
                var (result, errorMessage) = await relationshipService.FollowUserAsync(user.UserID);

                if (!result)
                {
                    MessageBox.Show($"Follow failed: {errorMessage}");
                }
                else
                {
                    this.followings.Add(user);

                    (relationshipStatus, _) = await relationshipService.GetRelationshipStatusAsync(user.UserID);

                    if (relationshipStatus.Status != null && relationshipStatus.Status == RelationshipStatusType.Follower)
                    {
                        this.friends.Add(user);
                    }

                    OnFollowEvent?.Invoke();
                }
                
                return (result, relationshipStatus);
            }
            return (false, relationshipStatus);
        }

        public async Task<(bool, RelationshipStatus)> Unfollow(UserSummary user, RelationshipStatus relationshipStatus = null)
        {
            if (user == null && string.IsNullOrEmpty(user.UserID))
            {
                return (false, relationshipStatus);
            }
            if (appDataProvider.User != null && !string.IsNullOrEmpty(appDataProvider.User.Token))
            {
                var (result, errorMessage) = await relationshipService.UnfollowUserAsync(user.UserID);
                
                if (!result)
                {
                    MessageBox.Show($"Unfollow failed: {errorMessage}");
                }
                else
                {
                    this.followings.Remove(user);

                    (relationshipStatus, _) = await relationshipService.GetRelationshipStatusAsync(user.UserID);

                    if (relationshipStatus.Status != null && relationshipStatus.Status == RelationshipStatusType.Friend)
                    {
                        this.friends.Remove(user);
                    }

                    OnUnfollowEvent?.Invoke();
                }

                return (result, relationshipStatus);
            }
            return (false, relationshipStatus);
        }

    }
}
