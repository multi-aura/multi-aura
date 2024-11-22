using BLL.DataProviders;
using CustomControl.Extensions;
using CustomControl.Modals;
using CustomControl.Properties;
using CustomControl.Utils;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace CustomControl.Commons
{
    public partial class BriefPost : UserControl
    {
        private AppDataProvider appDataProvider;
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

        public BriefPost()
        {
            InitializeComponent();
            appDataProvider = AppDataProvider.Instance;
            UpdateUI();

            this.Click += BriefPost_Click;
            this.postPhotoRepresent.Click += BriefPost_Click;
            this.labelHasMoreImages.Click += BriefPost_Click;
        }

        private void BriefPost_Click(object sender, EventArgs e)
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

        private async void UpdateUI()
        {
            this.labelHasMoreImages.Visible = false;
            if (currentPost != null)
            {
                bool hasData = false;
                foreach (var item in currentPost.Images)
                {
                    if (hasData)
                    {
                        this.labelHasMoreImages.Visible = true;
                        break;
                    }

                    var image = await NetworkLoader.LoadImageFromUrlAsync(item.Url);
                    if (image != null)
                    {
                        this.postPhotoRepresent.Image = image;
                        if (!hasData) {
                            hasData = true;
                        }                        
                    }
                }
                if (!hasData)
                {
                    this.postPhotoRepresent.Image = Resources.error_image;
                }
            }
            else
            {
                this.postPhotoRepresent.Image = Resources.error_image;
            }
        }
    }
}
