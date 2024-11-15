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
    public partial class UserSummaryCommon : UserControl
    {
        private bool isFollowing;
        public UserSummaryCommon()
        {
            InitializeComponent();
            isFollowing = true;
            this.actionButton.MouseHover += ActionButton_MouseHover;
            this.actionButton.MouseLeave += ActionButton_MouseLeave;
            this.actionButton.Click += ActionButton_Click;

            this.Click += UserSummaryCommon_Click;
            this.userAvatar.Click += UserSummaryCommon_Click;
            this.labelFullName.Click += UserSummaryCommon_Click;
            this.labelUsername.Click += UserSummaryCommon_Click;
        }

        private void UserSummaryCommon_Click(object sender, EventArgs e)
        {
            //TODO: handle open user profile
        }

        private void ActionButton_Click(object sender, EventArgs e)
        {
            isFollowing = !isFollowing;
            this.actionButton.Text = isFollowing ? "Following" : "Follow";
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

