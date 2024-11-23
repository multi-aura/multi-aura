using BLL.DataProviders;
using CustomControl.Modals;
using DTO;
using System;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControl.Commons
{
    public partial class UserSummaryCommon : UserControl
    {
        public AppDataProvider appDataProvider;
        public RelationshipDataProvider relationshipDataProvider;
        public UserSummary CurrentUserSummary = null;
        public bool IsFollowing = false;
        public UserSummaryCommon()
        {
            InitializeComponent();
            appDataProvider = AppDataProvider.Instance;
            relationshipDataProvider = RelationshipDataProvider.Instance;

            this.Load += UserSummaryCommon_Load;

            this.actionButton.MouseHover += ActionButton_MouseHover;
            this.actionButton.MouseLeave += ActionButton_MouseLeave;
            this.actionButton.Click += ActionButton_Click;

            this.Click += UserSummaryCommon_Click;
            this.userAvatar.Click += UserSummaryCommon_Click;
            this.labelFullName.Click += UserSummaryCommon_Click;
            this.labelUsername.Click += UserSummaryCommon_Click;
        }

        private async void UserSummaryCommon_Load(object sender, EventArgs e)
        {
            if(CurrentUserSummary != null)
            {
                if (!string.IsNullOrEmpty(CurrentUserSummary.Avatar))
                {
                    try
                    {
                        // Tải ảnh từ URL
                        var imageUrl = CurrentUserSummary.Avatar;
                        using (HttpClient httpClient = new HttpClient())
                        {
                            var imageBytes = await httpClient.GetByteArrayAsync(imageUrl);

                            using (var ms = new System.IO.MemoryStream(imageBytes))
                            {
                                // Gán ảnh vào PictureBox
                                userAvatar.Image = Image.FromStream(ms);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        userAvatar.Image = Properties.Resources.person; // ảnh mặc định trong Resources
                    }
                }
                else
                {
                    userAvatar.Image = Properties.Resources.person;
                }

                if (!string.IsNullOrEmpty(CurrentUserSummary.FullName))
                {
                    this.labelFullName.Text = CurrentUserSummary.FullName;
                }

                if (!string.IsNullOrEmpty(CurrentUserSummary.Username))
                {
                    this.labelUsername.Text = CurrentUserSummary.Username;
                }
            }

            this.actionButton.Text = IsFollowing ? "Following" : "Follow";
        }

        private async void UserSummaryCommon_Click(object sender, EventArgs e)
        {
            try
            {
                string username = CurrentUserSummary.Username;
                if (!string.IsNullOrEmpty(username))
                {
                    var (profile, errorMessage) = await relationshipDataProvider.GetProfileAsync(username);

                    if (string.IsNullOrEmpty(errorMessage))
                    {
                        RequestOpenModal(profile);
                    }
                    else
                    {
                        MessageBox.Show("Can not go to this profile \nError fetching other profile: " + errorMessage);
                    }

                }
                else
                {
                    MessageBox.Show("Can not go to this profile");
                }
            }
            catch
            {
                MessageBox.Show("Something went wrong \nCan not go to this profile!");
            }
        }

        private void RequestOpenModal(UserProfile profile)
        {
            Form modal = new ProfileDetails
            {
                CurrentUserProfile = profile,
                Width = appDataProvider.ScreenWidth - 100,
                Height = appDataProvider.ScreenHeight - 100,
                StartPosition = FormStartPosition.CenterScreen,
                ShowInTaskbar = false,
                TopMost = true
            };

            appDataProvider.ShowModal(this, modal);
        }

        private void ActionButton_Click(object sender, EventArgs e)
        {
            if(CurrentUserSummary != null && CurrentUserSummary.UserID != null)
            {
                this.actionButton.Text = "Processing..";

                Task.Run(async () =>
                {
                    try
                    {
                        if (IsFollowing)
                        {
                            var (result,  _) = await relationshipDataProvider.Unfollow(CurrentUserSummary);

                            this.Invoke(new Action(() =>
                            {
                                if (result)
                                {
                                    IsFollowing = false;
                                }

                                this.actionButton.Text = IsFollowing ? "Following" : "Follow";
                            }));
                        }
                        else
                        {
                            var (result, _) = await relationshipDataProvider.Follow(CurrentUserSummary);

                            this.Invoke(new Action(() =>
                            {
                                if (result)
                                {
                                    IsFollowing = true;
                                }

                                this.actionButton.Text = IsFollowing ? "Following" : "Follow";
                            }));
                        }
                    }
                    catch (Exception ex)
                    {
                        this.Invoke(new Action(() =>
                        {
                            MessageBox.Show($"Operation failed: {ex.Message}");
                            this.actionButton.Text = IsFollowing ? "Following" : "Follow";
                        }));
                    }
                });

            }
        }

        private void ActionButton_MouseHover(object sender, EventArgs e)
        {
            this.actionButton.ForeColor = Color.FromArgb(144, 144, 144);
        }
        private void ActionButton_MouseLeave(object sender, EventArgs e)
        {
            this.actionButton.ForeColor = Color.White;
        }
    }
}

