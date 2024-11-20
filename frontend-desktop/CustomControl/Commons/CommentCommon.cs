using BLL.DataProviders;
using CustomControl.Extensions;
using CustomControl.Modals;
using CustomControl.Properties;
using CustomControl.Utils;
using DTO;
using System;
using System.Drawing;
using System.Net.Http;
using System.Windows.Forms;

namespace CustomControl.Commons
{
    public partial class CommentCommon : UserControl
    {
        public event EventHandler ShowModalRequested;

        private AppDataProvider appDataProvider;

        private bool isLiked = false;
        private int likeCounter = 0;

        private Comment currentComment = null;
        public Comment CurrentComment
        {
            get => currentComment;
            set
            {
                if (currentComment != value)
                {
                    currentComment = value;
                    UpdateUI();
                }
            }
        }
        public CommentCommon()
        {
            InitializeComponent();

            appDataProvider = AppDataProvider.Instance;

            this.labelReply.MouseHover += LabelReply_MouseHover;
            this.labelReply.MouseLeave += LabelReply_MouseLeave;
            this.labelReply.Click += ShowModalPostDetails;

            this.labelLike.Click += LabelLike_Click;
        }

        private void LabelLike_Click(object sender, EventArgs e)
        {
            if (isLiked)
            {
                //TODO: handle unlike
                likeCounter--;
                this.labelTotalLikes.Text = likeCounter.ToShortNumber();
                this.labelLike.Image = Resources.heart16;
            }
            else
            {
                //TODO: handle like
                likeCounter++;
                this.labelTotalLikes.Text = likeCounter.ToShortNumber();
                this.labelLike.Image = Resources.red_heart16;
            }
            isLiked = !isLiked;
        }

        private void UpdateUI()
        {
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            if (currentComment != null)
            {
                SetUpAuthorInfo();
                SetUpCommentDetails();
                SetUpReplyComments();
            }
        }

        private async void SetUpAuthorInfo()
        {
            if (currentComment.Author != null)
            {
                if (!string.IsNullOrEmpty(currentComment.Author.Avatar))
                {
                    try
                    {
                        var imageUrl = currentComment.Author.Avatar;
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
                        userAvatar.Image = Properties.Resources.person; // ảnh mặc định trong Resources
                    }
                }
                else
                {
                    userAvatar.Image = Properties.Resources.person;
                }

                if (!string.IsNullOrEmpty(currentComment.Author.FullName))
                {
                    this.labelFullName.Text = currentComment.Author.FullName;
                }
                else
                {

                }                
            }
        }

        private void SetUpCommentDetails()
        {
            if (currentComment != null)
            {
                SetUpPhotos();
                if (!string.IsNullOrEmpty(currentComment.Text))
                {
                    this.labelText.Visible = true;
                    this.labelText.Text = currentComment.Text;
                }
                else
                {
                    this.labelText.Visible = false;
                }

                if (currentComment.CreatedAt != null)
                {
                    this.labelTime.Text = currentComment.CreatedAt.ToRelativeTime();
                }

                if (currentComment.LikedBy != null)
                {
                    if (currentComment.LikedBy.Contains(appDataProvider.User.Username))
                    {
                        isLiked = true;
                        this.labelLike.Image = Resources.red_heart16;
                    }
                    else
                    {
                        isLiked = false;
                        this.labelLike.Image = Resources.heart16;
                    }
                    likeCounter = currentComment.LikedBy.Count;
                    this.labelTotalLikes.Text = likeCounter.ToShortNumber();
                }
                else
                {
                    isLiked = false;
                    this.labelLike.Image = Resources.heart16;
                }
                if (!string.IsNullOrEmpty(currentComment.Voice))
                {
                    this.voicePlayer.Visible = true;
                }
                else {
                    this.voicePlayer.Visible = false;
                }
            }
        }

        private async void SetUpPhotos()
        {
            if (currentComment.Images != null)
            {
                bool hasData = false;
                //imageUrls = new List<Image>();

                foreach (var item in currentComment.Images)
                {
                    var image = await NetworkLoader.LoadImageFromUrlAsync(item.Url);
                    if (image != null)
                    {
                        //imageUrls.Add(image);

                        PictureBox pictureBox = new PictureBox
                        {
                            Image = image,
                            Margin = new Padding(0, 0, 0, 0),
                            Padding = new Padding(0, 10, 0, 10),
                            Size = new Size(160, 160),
                            SizeMode = PictureBoxSizeMode.Zoom,
                        };

                        if (this.flowLayoutPanelImages.InvokeRequired)
                        {
                            this.flowLayoutPanelImages.Invoke(new Action(() =>
                            {
                                this.flowLayoutPanelImages.Controls.Add(pictureBox);
                            }));
                        }
                        else
                        {
                            this.flowLayoutPanelImages.Controls.Add(pictureBox);
                        }

                        if (!hasData)
                        {
                            hasData = true;
                        }
                    }
                }
                if (hasData)
                {
                    this.flowLayoutPanelImages.Visible = true;
                }
                else
                {
                    this.flowLayoutPanelImages.Visible = false;
                }
            }
            else
            {
                this.flowLayoutPanelImages.Visible = false;
            }
        }

        private void SetUpReplyComments()
        {
            if (currentComment.Replies != null)
            {
                foreach (var item in currentComment.Replies)
                {
                    ReplyComment replyComment = new ReplyComment
                    {
                        CurrentComment = item,
                        Margin = new Padding(0, 0, 0, 0),
                        Padding = new Padding(0, 0, 0, 0),
                        Dock = DockStyle.Top,
                    };

                    replyComment.ShowModalRequested += (sender, args) =>
                    {
                        ShowModalPostDetails(sender, args);
                    };

                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action(() =>
                        {
                            this.panelReplies.Controls.Add(replyComment);
                            replyComment.Dock = DockStyle.Top;
                        }));
                    }
                    else
                    {
                        this.panelReplies.Controls.Add(replyComment);
                        replyComment.Dock = DockStyle.Top;
                    }
                }
            }
        }

        private void ShowModalPostDetails(object sender, EventArgs e)
        {
            ShowModalRequested?.Invoke(this, EventArgs.Empty);
        }

        private void LabelReply_MouseLeave(object sender, EventArgs e)
        {
            labelReply.ForeColor = Color.FromArgb(222, 222, 222);
        }

        private void LabelReply_MouseHover(object sender, EventArgs e)
        {
            labelReply.ForeColor = Color.White;
        }
    }
}
