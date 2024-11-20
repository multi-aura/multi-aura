using BLL.DataProviders;
using CustomControl.Commons;
using GUI.Extensions;
using System;
using System.Drawing;
using System.Net.Http;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;

namespace GUI.Forms
{
    public partial class ProfileForm : Form
    {
        private AppDataProvider appDataProvider;
        private RelationshipDataProvider relationshipDataProvider;

        private Label selectedLabel;

        public ProfileForm()
        {
            InitializeComponent();
            appDataProvider = AppDataProvider.Instance;
            appDataProvider.DataLoaded += LoadProfile;

            relationshipDataProvider = RelationshipDataProvider.Instance;
            relationshipDataProvider.FollowerDataLoaded += LoadFollowerCounter;
            relationshipDataProvider.FollowingDataLoaded += LoadFollowingCounter;
            relationshipDataProvider.FriendDataLoaded += LoadFriendCounter;
            RegisterHoverAndClickEventsForLabels();
            LoadData();
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

        private async void LoadProfilePhoto()
        {
            if (!string.IsNullOrEmpty(appDataProvider.User.Avatar))
            {
                try
                {
                    var imageUrl = appDataProvider.User.Avatar;
                    using (HttpClient httpClient = new HttpClient())
                    {
                        var imageBytes = await httpClient.GetByteArrayAsync(imageUrl);

                        using (var ms = new System.IO.MemoryStream(imageBytes))
                        {
                            userAvatar.Image = Image.FromStream(ms);
                        }
                    }
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

        private void LoadFriendCounter()
        {
            if (relationshipDataProvider.Friends != null)
            {
                this.labelFriendCounter.Text = relationshipDataProvider.Friends.Count.ToShortNumber() + " Friends";
            }
        }

        private void LoadData()
        {
            for (int i = 0; i < 50; i++)
            {
                BriefPost briefPost = new BriefPost();
                panelResults.Controls.Add(briefPost);
            }
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

            SetSelectedLabel(labelPosts);
        }

        private void Label_MouseHover(object sender, EventArgs e)
        {
            if (sender is Label label && label != selectedLabel)
            {
                SetFocusedLabel(label, true);
            }
        }

        private void Label_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Label label && label != selectedLabel)
            {
                SetFocusedLabel(label, false);
            }
        }

        private void Label_Click(object sender, EventArgs e)
        {
            if (sender is Label clickedLabel)
            {
                SetSelectedLabel(clickedLabel);

                //TODO: make changes in panelResults

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
            selectedLabel = clickedLabel;
        }
    }
}
