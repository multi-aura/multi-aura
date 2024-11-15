using BLL;
using CustomControl.Modals;
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
    public partial class CommentCommon : UserControl
    {
        public event EventHandler<Form> ShowModalRequested;
        private AppDataProvider _appDataProvider;
        public CommentCommon()
        {
            InitializeComponent();

            _appDataProvider = AppDataProvider.Instance;

            this.labelReply.MouseHover += LabelReply_MouseHover;
            this.labelReply.MouseLeave += LabelReply_MouseLeave;
            this.labelReply.Click += LabelReply_Click;
        }

        private void LabelReply_Click(object sender, EventArgs e)
        {
            Form modal = new PostDetails
            {
                Width = _appDataProvider.ScreenWidth - 400,
                Height = _appDataProvider.ScreenHeight - 100,
                StartPosition = FormStartPosition.CenterScreen,
                ShowInTaskbar = false,
                TopMost = true
            };

            ShowModalRequested?.Invoke(this, modal);
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
