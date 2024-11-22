using BLL.DataProviders;
using CustomControl.Commons;
using CustomControl.Extensions;
using CustomControl.Utils;
using DTO;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CustomControl.Modals
{
    public partial class UserProfile : Form
    {
        private AppDataProvider appDataProvider;
        private RelationshipDataProvider relationshipDataProvider;
        private PostDataProvider postDataProvider;

        private Label currentTaskBar;
        private Panel currentPanelResults;

        private bool hasPostsData = false;
        private bool hasMediasData = false;
        private bool hasFriendsData = false;
        private bool hasMoreData = true;

        public UserProfile()
        {
            InitializeComponent();

            appDataProvider = AppDataProvider.Instance;
            appDataProvider.DataLoaded += LoadProfile;

            relationshipDataProvider = RelationshipDataProvider.Instance;
            relationshipDataProvider.FollowerDataLoaded += LoadFollowerCounter;
            relationshipDataProvider.FollowingDataLoaded += LoadFollowingCounter;
            relationshipDataProvider.FriendDataLoaded += OnFriendDataLoaded;

            postDataProvider = PostDataProvider.Instance;
            postDataProvider.CurrentUserPostsDataLoaded += LoadPanelUserPosts;

            RegisterHoverAndClickEventsForLabels();

            currentPanelResults = panelPosts;
            LoadPanel(currentPanelResults, hasPostsData);
        }

        private void LoadPanelUserPosts()
        {
            if (panelPosts.InvokeRequired)
            {
                panelPosts.Invoke(new Action(LoadPanelUserPosts));
                return;
            }

            //panelForYouNoQueryPosts.Controls.Clear();
            if (postDataProvider.CurrentUserPosts != null)
            {
                hasPostsData = false;
                foreach (var item in postDataProvider.CurrentUserPosts)
                {
                    PostCommon postCommon = new PostCommon
                    {
                        CurrentPost = item,
                        Dock = DockStyle.Top,
                        Margin = new Padding(0, 0, 0, 0),
                    };

                    if (panelPosts.InvokeRequired)
                    {
                        panelPosts.Invoke(new Action(() =>
                        {
                            panelPosts.Controls.Add(postCommon);
                            panelPosts.Controls.SetChildIndex(postCommon, 0);
                        }));
                    }
                    else
                    {
                        panelPosts.Controls.Add(postCommon);
                        panelPosts.Controls.SetChildIndex(postCommon, 0);
                    }
                    if (!hasPostsData)
                    {
                        hasPostsData = true;
                    }

                    if (item.Images != null && item.Images.Count != 0)
                    {
                        AddMediasDataItem(item);
                    }
                }

            }
            else
            {
                hasPostsData = false;
            }

            hasPostsData = true;
            if (currentTaskBar == labelPosts)
            {
                HideLoading();
                LoadPanel(this.panelPosts, hasPostsData);
            }
        }

        private void AddMediasDataItem(Post post)
        {
            if (panelMedias.InvokeRequired)
            {
                panelMedias.Invoke(new Action(LoadPanelFriends));
                return;
            }

            BriefPost briefPost = new BriefPost
            {
                CurrentPost = post,
            };

            if (panelMedias.InvokeRequired)
            {
                panelMedias.Invoke(new Action(() =>
                {
                    panelMedias.Controls.Add(briefPost);
                }));
            }
            else
            {
                panelMedias.Controls.Add(briefPost);
            }


            if (!hasMediasData)
            {
                hasMediasData = true;
            }

            if (currentTaskBar == labelMedias)
            {
                HideLoading();
                LoadPanel(this.panelMedias, hasMediasData);
            }
        }

        private void LoadPanelFriends()
        {
            if (panelFriends.InvokeRequired)
            {
                panelFriends.Invoke(new Action(LoadPanelFriends));
                return;
            }

            if (currentTaskBar == labelFriends)
            {
                ShowLoading();
            }
            panelFriends.Controls.Clear();
            if (relationshipDataProvider.Friends != null)
            {
                hasFriendsData = false;
                foreach (var item in relationshipDataProvider.Friends)
                {
                    UserSummaryCommon userSummary = new UserSummaryCommon
                    {
                        CurrentUserSummary = item,
                        IsFollowing = true,
                        Dock = DockStyle.Top,
                        Margin = new Padding(0, 0, 0, 0),
                        Padding = new Padding(10, 4, 10, 4),
                    };

                    if (panelFriends.InvokeRequired)
                    {
                        panelFriends.Invoke(new Action(() =>
                        {
                            panelFriends.Controls.Add(userSummary);
                        }));
                    }
                    else
                    {
                        panelFriends.Controls.Add(userSummary);
                    }
                    if (!hasFriendsData)
                    {
                        hasFriendsData = true;
                    }
                }
            }
            else
            {
                hasFriendsData = false;
            }

            if (currentTaskBar == labelFriends)
            {
                HideLoading();
                LoadPanel(this.panelFriends, hasFriendsData);
            }
        }

        private async void LoadProfile()
        {
            if (appDataProvider.User != null)
            {
                LoadProfilePhoto();

                if (!string.IsNullOrEmpty(appDataProvider.User.FullName))
                {
                    this.labelFullName.Text = appDataProvider.User.FullName;
                }
                if (!string.IsNullOrEmpty(appDataProvider.User.Username))
                {
                    this.labelUsername.Text = appDataProvider.User.Username;
                }

            }
        }

        private void ShowLoading()
        {
            this.NotFoundContainer.Visible = false;
            this.currentPanelResults.Visible = false;
            this.LoadingContainer.Visible = true;
        }

        private void HideLoading()
        {
            this.currentPanelResults.Visible = true;
            this.LoadingContainer.Visible = false;
        }

        private async void LoadProfilePhoto()
        {
            if (!string.IsNullOrEmpty(appDataProvider.User.Avatar))
            {
                try
                {
                    var imageUrl = appDataProvider.User.Avatar;

                    userAvatar.Image = await NetworkLoader.LoadImageFromUrlAsync(imageUrl);
                }
                catch (Exception ex)
                {
                    userAvatar.Image = Properties.Resources.profile;
                }
            }
            else
            {
                userAvatar.Image = Properties.Resources.profile;
            }
        }

        private void LoadFollowerCounter()
        {
            if (relationshipDataProvider.Followers != null)
            {
                this.labelFollowerCounter.Text = relationshipDataProvider.Followers.Count.ToShortNumber() + " Followers";
            }
        }

        private void LoadFollowingCounter()
        {
            if (relationshipDataProvider.Followings != null)
            {
                this.labelFollowingCounter.Text = relationshipDataProvider.Followings.Count.ToShortNumber() + " Followings";
            }
        }

        private void OnFriendDataLoaded()
        {
            LoadFriendCounter();
            LoadPanelFriends();
        }

        private void LoadFriendCounter()
        {
            if (relationshipDataProvider.Friends != null)
            {
                this.labelFriendCounter.Text = relationshipDataProvider.Friends.Count.ToShortNumber() + " Friends";
            }
        }

        private void Label_Click(object sender, EventArgs e)
        {
            if (sender is Label clickedLabel)
            {
                SetSelectedLabel(clickedLabel);

                if (clickedLabel == labelMedias)
                {
                    LoadPanel(this.panelMedias, hasMediasData);
                }
                else if (clickedLabel == labelFriends)
                {
                    LoadPanel(this.panelFriends, hasFriendsData);
                }
                else if (clickedLabel == labelMore)
                {
                    LoadPanel(this.panelMore, hasMoreData);
                }
                else
                {
                    LoadPanel(this.panelPosts, hasPostsData);
                }
            }
        }

        private void LoadPanel(object panelSender, bool hasData)
        {
            this.LoadingContainer.Visible = false;
            if (hasData)
            {
                this.NotFoundContainer.Visible = false;
            }
            else
            {
                this.NotFoundContainer.Visible = true;
            }

            ActivatePanel(panelSender);
        }

        private void ActivatePanel(object sender)
        {
            if (sender != null)
            {
                if (currentPanelResults != (Panel)sender)
                {
                    currentPanelResults.Visible = false;
                    currentPanelResults = (Panel)sender;
                    currentPanelResults.Visible = true;
                }
            }
        }

        private void SetFocusedLabel(Label label, bool isFocused)
        {
            label.Font = new Font(label.Font, isFocused ? FontStyle.Bold : FontStyle.Regular);
            label.BackColor = isFocused ? Color.FromArgb(148, 148, 148) : Color.Transparent;
        }

        private void UnsetSelectedLabel(Label label)
        {
            label.Font = new Font(label.Font, FontStyle.Regular);
            label.BackColor = Color.Transparent;
        }

        private void SetSelectedLabel(Label clickedLabel)
        {
            foreach (Control control in tableLayoutPanelProfileTaskBar.Controls)
            {
                if (control is Label label)
                {
                    UnsetSelectedLabel(label);
                }
            }

            clickedLabel.Font = new Font(clickedLabel.Font, FontStyle.Bold);
            clickedLabel.BackColor = Color.Transparent;
            currentTaskBar = clickedLabel;
        }

        private void RegisterHoverAndClickEventsForLabels()
        {
            foreach (Control control in tableLayoutPanelProfileTaskBar.Controls)
            {
                if (control is Label label)
                {
                    label.MouseHover += Label_MouseHover;
                    label.MouseLeave += Label_MouseLeave;

                    label.Click += Label_Click;
                }
            }
            this.panelFriends.Visible = false;
            this.panelMedias.Visible = false;
            this.panelMore.Visible = false;
            this.NotFoundContainer.Visible = false;
            this.LoadingContainer.Visible = true;

            SetSelectedLabel(labelPosts);
        }

        private void Label_MouseHover(object sender, EventArgs e)
        {
            if (sender is Label label && label != currentTaskBar)
            {
                SetFocusedLabel(label, true);
            }
        }

        private void Label_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Label label && label != currentTaskBar)
            {
                SetFocusedLabel(label, false);
            }
        }
    }
}
