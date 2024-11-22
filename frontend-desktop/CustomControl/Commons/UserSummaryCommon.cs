using DTO;
using System;
using System.Drawing;
using System.Net.Http;
using System.Windows.Forms;

namespace CustomControl.Commons
{
    public partial class UserSummaryCommon : UserControl
    {
        public UserSummary CurrentUserSummary = null;
        public bool IsFollowing = false;
        public UserSummaryCommon()
        {
            InitializeComponent();

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

        private void UserSummaryCommon_Click(object sender, EventArgs e)
        {
            //TODO: handle open user profile
        }

        private void ActionButton_Click(object sender, EventArgs e)
        {
            IsFollowing = !IsFollowing;
            this.actionButton.Text = IsFollowing ? "Following" : "Follow";
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

