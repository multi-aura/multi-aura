using BLL.DataProviders;
using CustomControl.Commons;
using CustomControl.Modals;
using System;
using System.Drawing;
using System.Net.Http;
using System.Windows.Forms;

namespace GUI.Forms
{
    public partial class HomeForm : Form
    {
        private AppDataProvider appDataProvider;
        private RelationshipDataProvider relationshipDataProvider;
        private PostDataProvider postDataProvider;

        public HomeForm()
        {
            InitializeComponent();
            this.NotFoundContainer.Visible = false;
            appDataProvider = AppDataProvider.Instance;

            relationshipDataProvider = RelationshipDataProvider.Instance;
            relationshipDataProvider.FriendDataLoaded += LoadFriends;
            relationshipDataProvider.SuggestDataLoaded += LoadSuggestFriends;

            postDataProvider = PostDataProvider.Instance;
            postDataProvider.RecentPostsDataLoaded += LoadPanelRecentPosts;
        }

        private void LoadPanelRecentPosts()
        {
            if (panelPosts.InvokeRequired)
            {
                panelPosts.Invoke(new Action(LoadPanelRecentPosts));
                return;
            }
            //panelForYouNoQueryPosts.Controls.Clear();
            if (postDataProvider.RecentPosts != null)
            {
                bool hasData = false;
                foreach (var item in postDataProvider.RecentPosts)
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
                        }));
                    }
                    else
                    {
                        panelPosts.Controls.Add(postCommon);
                    }
                    if (!hasData)
                    {
                        hasData = true;
                    }
                }
                if (!hasData)
                {
                    this.NotFoundContainer.Visible = true;
                }
            }
            else
            {
                this.NotFoundContainer.Visible = true;
            }
        }

        private async void LoadFriends()
        {
            if (relationshipDataProvider.Friends == null || relationshipDataProvider.Friends.Count == 0)
            {
                MessageBox.Show("No friends found.");
                return;
            }

            foreach (var friend in relationshipDataProvider.Friends)
            {
                AvatarCommon avatarCommon = new AvatarCommon
                {
                    Dock = DockStyle.None,
                    Cursor = Cursors.Hand,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Margin = new Padding(10, 0, 0, 0),
                    Size = new Size(50, 50),
                    MinimumSize = new Size(50, 50),
                    MaximumSize = new Size(50, 50),
                    CurrentUser = friend,
                };
                avatarCommon.Click += FriendAvatar_Click;

                if (!string.IsNullOrEmpty(friend.Avatar))
                {
                    try
                    {
                        var imageUrl = friend.Avatar;
                        using (HttpClient httpClient = new HttpClient())
                        {
                            var imageBytes = await httpClient.GetByteArrayAsync(imageUrl);

                            using (var ms = new System.IO.MemoryStream(imageBytes))
                            {
                                avatarCommon.Image = Image.FromStream(ms);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Can not load avatar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        avatarCommon.Image = Properties.Resources.person;
                    }
                }
                else
                {
                    avatarCommon.Image = Properties.Resources.person;
                }

                if (flowLayoutPanelFriends.InvokeRequired)
                {
                    flowLayoutPanelFriends.Invoke(new Action(() =>
                    {
                        flowLayoutPanelFriends.Controls.Add(avatarCommon);
                    }));
                }
                else
                {
                    flowLayoutPanelFriends.Controls.Add(avatarCommon);
                }
            }
        }

        private void LoadSuggestFriends()
        {
            if (relationshipDataProvider.SuggestedFriends == null || relationshipDataProvider.SuggestedFriends.Count == 0)
            {
                MessageBox.Show("No suggested friends found.");
                return;
            }

            if (panelSuggests.InvokeRequired)
            {
                panelSuggests.Invoke(new Action(LoadSuggestFriends));
                return;
            }

            panelSuggests.Controls.Clear();

            SuggestForYouCommon suggestForYouCommon = new SuggestForYouCommon
            {
                UserSummaries = relationshipDataProvider.SuggestedFriends,
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 0, 0, 0),
            };

            panelSuggests.Controls.Add(suggestForYouCommon);
        }

        private void FriendAvatar_Click(object sender, EventArgs e)
        {
            Form modal = new PostDetails
            {
                Width = appDataProvider.ScreenWidth - 400,
                Height = appDataProvider.ScreenHeight - 100,
                StartPosition = FormStartPosition.CenterScreen,
                ShowInTaskbar = false,
                TopMost = true
            };
            appDataProvider.ShowModal(this, modal);
        }
    }
}
