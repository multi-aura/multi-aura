using BLL;
using CustomControl.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControl.Modals
{
    public partial class PostDetails : Form
    {
        private AppDataProvider _appDataProvider;

        private List<string> imageUrls;
        private int currentImageIndex;

        public PostDetails()
        {
            InitializeComponent();
            this.CloseWindowControlButton.Click += CloseWindowControlButton_Click;

            _appDataProvider = AppDataProvider.Instance;

            // Danh sách các URL ảnh
            imageUrls = new List<string>
            {
                "https://firebasestorage.googleapis.com/v0/b/multi-aura.appspot.com/o/Hihon%2F1728534046_9ea1c9841cadbef3e7bc.jpg?alt=media&token=3d221a08-d064-4ece-881a-32e2c5d273e1",
                "https://firebasestorage.googleapis.com/v0/b/multi-aura-8eb80.appspot.com/o/profile-photos%2F1729077318_2773d8b41134ee880c2f2ba46fe02303.jpg?alt=media&token=14759029-2076-4233-a726-4f903d843340",
                "https://i.pinimg.com/564x/ba/cc/a2/bacca2f413feec96e248866fe3078556.jpg"
            };

            currentImageIndex = 0;
            LoadImage(currentImageIndex);

            this.preImage.MouseHover += PreImage_MouseHover;
            this.preImage.MouseLeave += PreImage_MouseLeave;
            this.nextImage.MouseHover += NextImage_MouseHover;
            this.nextImage.MouseLeave += NextImage_MouseLeave;
            this.preImage.Click += PreImage_Click; // Thêm sự kiện cho nút trước
            this.nextImage.Click += NextImage_Click; // Thêm sự kiện cho nút tiếp theo

            LoadData();

        }

        private void LoadData()
        {
            for (int i = 0; i < 3; i++)
            {
                CommentCommon commentCommon = new CommentCommon();
                commentCommon.Dock = DockStyle.Top;

                panelComments.Controls.Add(commentCommon);
            }
        }

        private void CloseWindowControlButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PreImage_Click(object sender, EventArgs e)
        {
            // Chuyển đến ảnh trước đó
            if (currentImageIndex > 0)
            {
                currentImageIndex--;
                LoadImage(currentImageIndex);
            }
        }

        private void NextImage_Click(object sender, EventArgs e)
        {
            // Chuyển đến ảnh tiếp theo
            if (currentImageIndex < imageUrls.Count - 1)
            {
                currentImageIndex++;
                LoadImage(currentImageIndex);
            }
        }

        private async void LoadImage(int index)
        {
            if (index < 0 || index >= imageUrls.Count) return;

            string url = imageUrls[index];
            Image image = await LoadImageFromUrlAsync(url);
            if (image != null)
            {
                this.currentPhotoBox.Image = image;
            }
        }

        private async Task<Image> LoadImageFromUrlAsync(string url)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    var stream = await httpClient.GetStreamAsync(url);
                    return Image.FromStream(stream);
                }
                catch
                {
                    // Xử lý lỗi nếu cần
                    return null;
                }
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
    }
}
