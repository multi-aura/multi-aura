using BLL.DataProviders;
using CustomControl.Extensions;
using CustomControl.Modals;
using CustomControl.Properties;
using CustomControl.Utils;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;

namespace CustomControl.Commons
{
    public partial class PostCommon : UserControl
    {
        private AppDataProvider appDataProvider;

        private bool isLiked = false;
        private int likeCounter = 0;

        private int currentImageIndex;
        private List<Image> imageUrls;

        private Post currentPost = null;
        public Post CurrentPost
        {
            get => currentPost;
            set
            {
                if (currentPost != value)
                {
                    currentPost = value;
                    UpdateUI();
                }
            }
        }

        public PostCommon()
        {
            InitializeComponent();

            appDataProvider = AppDataProvider.Instance;

            this.labelComment.Click += ShowModalPostDetails;
            this.labelLike.Click += LabelLike_Click;

            this.panelImages.SizeChanged += PanelImages_SizeChanged;
        }

        private void LabelLike_Click(object sender, EventArgs e)
        {
            if (isLiked)
            {
                //TODO: handle unlike
                likeCounter--;
                this.labelTotalLikes.Text = likeCounter.ToShortNumber();
                this.labelLike.Image = Resources.heart;
            }
            else
            {
                //TODO: handle like
                likeCounter++;
                this.labelTotalLikes.Text = likeCounter.ToShortNumber();
                this.labelLike.Image = Resources.red_heart;
            }
            isLiked = !isLiked;
        }

        private async void UpdateUI()
        {
            if (currentPost != null)
            {
                SetUpPhotos();
                SetUpAuthorInfo();
                SetUpComments();

                if (currentPost.CreatedAt != null)
                {
                    this.labelCreateAt.Text = currentPost.CreatedAt.ToRelativeTime();
                }

                if (!string.IsNullOrEmpty(currentPost.Content))
                {
                    this.labelDescription.Text = currentPost.Content;
                }

                if (currentPost.LikedBy != null)
                {
                    if (currentPost.LikedBy != null && currentPost.LikedBy.Any(user => user.Username == appDataProvider.User.Username))
                    {
                        isLiked = true;
                        this.labelLike.Image = Resources.red_heart;
                    }
                    else
                    {
                        isLiked = false;
                        this.labelLike.Image = Resources.heart;
                    }

                    likeCounter = currentPost.LikedBy?.Count ?? 0;
                    this.labelTotalLikes.Text = likeCounter.ToShortNumber();
                }
                else
                {
                    isLiked = false;
                    this.labelLike.Image = Resources.heart;
                }
            }
        }

        private async void SetUpAuthorInfo()
        {
            if (currentPost.Author != null)
            {
                if (!string.IsNullOrEmpty(currentPost.Author.Avatar))
                {
                    try
                    {
                        var imageUrl = currentPost.Author.Avatar;
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

                if (!string.IsNullOrEmpty(currentPost.Author.FullName))
                {
                    this.labelFullName.Text = currentPost.Author.FullName;
                }
            }
        }

        private async void SetUpPhotos()
        {
            if (currentPost.Images != null)
            {
                int count = 0;
                imageUrls = new List<Image>();

                foreach (var item in currentPost.Images)
                {
                    var image = await NetworkLoader.LoadImageFromUrlAsync(item.Url);
                    if (image != null)
                    {
                        imageUrls.Add(image);
                        count++;
                    }
                }

                currentImageIndex = 0;
                LoadImage(currentImageIndex);
                if (count > 1)
                {
                    this.preImage.Visible = true;
                    this.nextImage.Visible = true;
                    this.preImage.MouseHover += PreImage_MouseHover;
                    this.preImage.MouseLeave += PreImage_MouseLeave;
                    this.nextImage.MouseHover += NextImage_MouseHover;
                    this.nextImage.MouseLeave += NextImage_MouseLeave;
                    this.preImage.Click += PreImage_Click;
                    this.nextImage.Click += NextImage_Click;
                }
                else
                {
                    this.preImage.Visible = false;
                    this.nextImage.Visible = false;
                }
            }
            else
            {
                this.panelImages.Visible = false;
                this.preImage.Visible = false;
                this.nextImage.Visible = false;
            }
        }
        private async void SetUpComments()
        {
            if (currentPost.Comments != null)
            {
                foreach (var item in currentPost.Comments)
                {
                    CommentCommon commentCommon = new CommentCommon
                    {
                        CurrentComment = item,
                        Dock = DockStyle.Top,
                        Margin = new Padding(0, 0, 0, 0),
                    };

                    commentCommon.ShowModalRequested += (sender, args) =>
                    {
                        ShowModalPostDetails(sender, args);
                    };

                    if (panelComments.InvokeRequired)
                    {
                        panelComments.Invoke(new Action(() =>
                        {
                            panelComments.Controls.Add(commentCommon);
                        }));
                    }
                    else
                    {
                        panelComments.Controls.Add(commentCommon);
                    }
                }                
            }
        }

        private void ShowModalPostDetails(object sender, EventArgs e)
        {
            Form modal = new PostDetails
            {
                CurrentPost = currentPost,
                Width = appDataProvider.ScreenWidth - 400,
                Height = appDataProvider.ScreenHeight - 100,
                StartPosition = FormStartPosition.CenterScreen,
                ShowInTaskbar = false,
                TopMost = true
            };

            appDataProvider.ShowModal(this, modal);
        }

        private void PreImage_Click(object sender, EventArgs e)
        {
            if (currentImageIndex > 0)
            {
                currentImageIndex--;
                LoadImage(currentImageIndex);
            }
            else if (currentImageIndex == 0)
            {
                currentImageIndex = currentPost.Images.Count - 1;
                LoadImage(currentImageIndex);
            }
        }

        private void NextImage_Click(object sender, EventArgs e)
        {
            // Chuyển đến ảnh tiếp theo
            if (currentImageIndex < currentPost.Images.Count - 1)
            {
                currentImageIndex++;
                LoadImage(currentImageIndex);
            }
            else if (currentImageIndex == currentPost.Images.Count - 1)
            {
                currentImageIndex = 0;
                LoadImage(currentImageIndex);
            }            
        }

        private async void LoadImage(int index)
        {
            if (index < 0 || index >= currentPost.Images.Count) return;

            var image = imageUrls[index];
            if (image != null)
            {
                this.currentPhotoBox.Image = image;
            }
        }        

        private void NextImage_MouseLeave(object sender, EventArgs e)
        {
            this.nextImage.BackColor = Color.FromArgb(48, 48, 48);
        }

        private void NextImage_MouseHover(object sender, EventArgs e)
        {
            this.nextImage.BackColor = Color.FromArgb(144, 144, 144);
        }

        private void PreImage_MouseLeave(object sender, EventArgs e)
        {
            this.preImage.BackColor = Color.FromArgb(48, 48, 48);
        }

        private void PreImage_MouseHover(object sender, EventArgs e)
        {
            this.preImage.BackColor = Color.FromArgb(144, 144, 144);
        }

        private void PanelImages_SizeChanged(object sender, EventArgs e)
        {
            // Tính toán vị trí theo chiều dọc (giữa panelImages)
            int centerY = panelImages.Height / 2;

            // Cập nhật vị trí cho preImage
            preImage.Location = new Point(preImage.Location.X, centerY - preImage.Height / 2);

            // Cập nhật vị trí cho nextImage
            nextImage.Location = new Point(nextImage.Location.X, centerY - nextImage.Height / 2);
        }
    }
}
