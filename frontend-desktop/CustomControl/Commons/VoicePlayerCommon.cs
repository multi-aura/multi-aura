using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControl.Commons
{
    public partial class VoicePlayerCommon : UserControl
    {
        private Image gifImage;        // Ảnh GIF động
        private Image staticImage;     // Ảnh tĩnh từ GIF (Frame đầu tiên)
        private Timer gifTimer;        // Timer để điều khiển việc bật lại GIF
        private int timeLeft;          // Thời gian còn lại
        private int totalTime = 3;     // Tổng thời gian (3 giây)

        public VoicePlayerCommon()
        {
            InitializeComponent();

            // Load ảnh GIF ban đầu
            gifImage = buttonVoicePlayer.Image;

            // Tạo ảnh tĩnh (lấy frame đầu tiên của GIF)
            staticImage = ExtractFirstFrame((Bitmap)gifImage);

            // Khởi tạo Timer để quản lý thời gian bật lại GIF
            gifTimer = new Timer();
            gifTimer.Interval = 1000; // Mỗi giây (1000ms)
            gifTimer.Tick += GifTimer_Tick;

            this.labelTimer.Text = $"00:{totalTime:00}";
            this.progressBarVoice.Minimum = 0;
            this.progressBarVoice.Maximum = totalTime;

            // Gán sự kiện click cho PictureBox để bật tắt GIF
            buttonVoicePlayer.Click += ButtonVoicePlayer_Click;

            // Bắt đầu với ảnh tĩnh (dừng chuyển động của GIF)
            buttonVoicePlayer.Image = staticImage;
        }

        // Sự kiện click để bật lại chuyển động của GIF
        private void ButtonVoicePlayer_Click(object sender, EventArgs e)
        {
            // Đặt lại ảnh động GIF
            buttonVoicePlayer.Image = gifImage;

            // Đặt lại thời gian còn lại và thanh progress
            timeLeft = totalTime;
            progressBarVoice.Value = 0;
            labelTimer.Text = $"00:{timeLeft:00}";

            // Bắt đầu timer để cập nhật mỗi giây
            gifTimer.Start();
        }

        // Mỗi khi Timer tick (mỗi giây), giảm thời gian và cập nhật thanh progress
        private void GifTimer_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft--; // Giảm thời gian còn lại
                progressBarVoice.Value = totalTime - timeLeft; // Cập nhật progressBar
                labelTimer.Text = $"00:{timeLeft:00}"; // Cập nhật label hiển thị thời gian
            }
            else
            {
                // Khi hết thời gian, dừng timer và đặt lại trạng thái
                gifTimer.Stop();
                buttonVoicePlayer.Image = staticImage; // Đổi lại ảnh tĩnh
                progressBarVoice.Value = 0; // Reset progressBar
                labelTimer.Text = $"00:{totalTime:00}"; // Reset label thời gian
            }
        }

        // Hàm để lấy frame đầu tiên của GIF (tạo ảnh tĩnh)
        private Image ExtractFirstFrame(Bitmap gif)
        {
            // Tạo một ảnh mới với kích thước của GIF
            Bitmap firstFrame = new Bitmap(gif.Width, gif.Height);

            // Vẽ frame đầu tiên của GIF vào ảnh tĩnh
            using (Graphics g = Graphics.FromImage(firstFrame))
            {
                g.DrawImage(gif, new Point(0, 0));
            }

            return firstFrame;
        }
    }
}
