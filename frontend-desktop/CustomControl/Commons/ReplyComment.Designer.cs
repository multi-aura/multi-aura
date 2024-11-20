namespace CustomControl.Commons
{
    partial class ReplyComment
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.voicePlayer = new CustomControl.Commons.VoicePlayerCommon();
            this.tableLayoutPanelComment = new System.Windows.Forms.TableLayoutPanel();
            this.userAvatar = new CustomControl.Commons.AvatarCommon();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.labelText = new System.Windows.Forms.Label();
            this.flowLayoutPanelImages = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.panelActionTaskBar = new System.Windows.Forms.Panel();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.labelTotalLikes = new System.Windows.Forms.Label();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.labelLike = new System.Windows.Forms.Label();
            this.labelReply = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelFullName = new System.Windows.Forms.Label();
            this.tableLayoutPanelComment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userAvatar)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.flowLayoutPanelImages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            this.panelActionTaskBar.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            this.tableLayoutPanel12.SuspendLayout();
            this.SuspendLayout();
            // 
            // voicePlayer
            // 
            this.voicePlayer.BackColor = System.Drawing.Color.Transparent;
            this.voicePlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.voicePlayer.Location = new System.Drawing.Point(10, 38);
            this.voicePlayer.Margin = new System.Windows.Forms.Padding(0);
            this.voicePlayer.MinimumSize = new System.Drawing.Size(457, 60);
            this.voicePlayer.Name = "voicePlayer";
            this.voicePlayer.Padding = new System.Windows.Forms.Padding(6, 10, 6, 10);
            this.voicePlayer.Size = new System.Drawing.Size(509, 60);
            this.voicePlayer.TabIndex = 14;
            // 
            // tableLayoutPanelComment
            // 
            this.tableLayoutPanelComment.AutoSize = true;
            this.tableLayoutPanelComment.ColumnCount = 2;
            this.tableLayoutPanelComment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelComment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelComment.Controls.Add(this.userAvatar, 0, 0);
            this.tableLayoutPanelComment.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanelComment.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanelComment.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelComment.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelComment.Name = "tableLayoutPanelComment";
            this.tableLayoutPanelComment.RowCount = 1;
            this.tableLayoutPanelComment.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelComment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 341F));
            this.tableLayoutPanelComment.Size = new System.Drawing.Size(569, 342);
            this.tableLayoutPanelComment.TabIndex = 17;
            // 
            // userAvatar
            // 
            this.userAvatar.CurrentUser = null;
            this.userAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.userAvatar.Image = global::CustomControl.Properties.Resources.person;
            this.userAvatar.Location = new System.Drawing.Point(0, 0);
            this.userAvatar.Margin = new System.Windows.Forms.Padding(0);
            this.userAvatar.MaximumSize = new System.Drawing.Size(40, 40);
            this.userAvatar.MinimumSize = new System.Drawing.Size(40, 40);
            this.userAvatar.Name = "userAvatar";
            this.userAvatar.Size = new System.Drawing.Size(40, 40);
            this.userAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userAvatar.TabIndex = 1;
            this.userAvatar.TabStop = false;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.labelText, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.flowLayoutPanelImages, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.panelActionTaskBar, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.labelFullName, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.voicePlayer, 0, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(40, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(529, 342);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // labelText
            // 
            this.labelText.AutoSize = true;
            this.labelText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelText.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelText.ForeColor = System.Drawing.Color.White;
            this.labelText.Location = new System.Drawing.Point(10, 22);
            this.labelText.Margin = new System.Windows.Forms.Padding(0);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(509, 16);
            this.labelText.TabIndex = 15;
            this.labelText.Text = "Text";
            // 
            // flowLayoutPanelImages
            // 
            this.flowLayoutPanelImages.AutoScroll = true;
            this.flowLayoutPanelImages.AutoSize = true;
            this.flowLayoutPanelImages.Controls.Add(this.pictureBox9);
            this.flowLayoutPanelImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelImages.Location = new System.Drawing.Point(10, 98);
            this.flowLayoutPanelImages.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanelImages.Name = "flowLayoutPanelImages";
            this.flowLayoutPanelImages.Padding = new System.Windows.Forms.Padding(0, 4, 0, 20);
            this.flowLayoutPanelImages.Size = new System.Drawing.Size(509, 204);
            this.flowLayoutPanelImages.TabIndex = 13;
            this.flowLayoutPanelImages.WrapContents = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = global::CustomControl.Properties.Resources._2773d8b41134ee880c2f2ba46fe02303;
            this.pictureBox9.Location = new System.Drawing.Point(10, 14);
            this.pictureBox9.Margin = new System.Windows.Forms.Padding(10, 10, 0, 10);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(160, 160);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox9.TabIndex = 43;
            this.pictureBox9.TabStop = false;
            // 
            // panelActionTaskBar
            // 
            this.panelActionTaskBar.Controls.Add(this.tableLayoutPanel11);
            this.panelActionTaskBar.Controls.Add(this.tableLayoutPanel12);
            this.panelActionTaskBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelActionTaskBar.Location = new System.Drawing.Point(10, 302);
            this.panelActionTaskBar.Margin = new System.Windows.Forms.Padding(0);
            this.panelActionTaskBar.Name = "panelActionTaskBar";
            this.panelActionTaskBar.Size = new System.Drawing.Size(509, 40);
            this.panelActionTaskBar.TabIndex = 11;
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 2;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel11.Controls.Add(this.labelTotalLikes, 1, 0);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(0, 22);
            this.tableLayoutPanel11.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 1;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(509, 24);
            this.tableLayoutPanel11.TabIndex = 1;
            // 
            // labelTotalLikes
            // 
            this.labelTotalLikes.AutoSize = true;
            this.labelTotalLikes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTotalLikes.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalLikes.ForeColor = System.Drawing.Color.White;
            this.labelTotalLikes.Location = new System.Drawing.Point(461, 0);
            this.labelTotalLikes.Margin = new System.Windows.Forms.Padding(0);
            this.labelTotalLikes.MinimumSize = new System.Drawing.Size(48, 0);
            this.labelTotalLikes.Name = "labelTotalLikes";
            this.labelTotalLikes.Size = new System.Drawing.Size(48, 24);
            this.labelTotalLikes.TabIndex = 1;
            this.labelTotalLikes.Text = "0";
            this.labelTotalLikes.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tableLayoutPanel12
            // 
            this.tableLayoutPanel12.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel12.ColumnCount = 5;
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel12.Controls.Add(this.labelLike, 4, 0);
            this.tableLayoutPanel12.Controls.Add(this.labelReply, 1, 0);
            this.tableLayoutPanel12.Controls.Add(this.labelTime, 0, 0);
            this.tableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel12.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel12.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            this.tableLayoutPanel12.RowCount = 1;
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel12.Size = new System.Drawing.Size(509, 22);
            this.tableLayoutPanel12.TabIndex = 0;
            // 
            // labelLike
            // 
            this.labelLike.AutoSize = true;
            this.labelLike.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelLike.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelLike.ForeColor = System.Drawing.Color.White;
            this.labelLike.Image = global::CustomControl.Properties.Resources.heart16;
            this.labelLike.Location = new System.Drawing.Point(461, 0);
            this.labelLike.Margin = new System.Windows.Forms.Padding(0);
            this.labelLike.MinimumSize = new System.Drawing.Size(48, 0);
            this.labelLike.Name = "labelLike";
            this.labelLike.Size = new System.Drawing.Size(48, 22);
            this.labelLike.TabIndex = 4;
            this.labelLike.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelReply
            // 
            this.labelReply.AutoSize = true;
            this.labelReply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelReply.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelReply.Font = new System.Drawing.Font("Montserrat SemiBold", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReply.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.labelReply.Location = new System.Drawing.Point(48, 0);
            this.labelReply.Margin = new System.Windows.Forms.Padding(0);
            this.labelReply.Name = "labelReply";
            this.labelReply.Size = new System.Drawing.Size(48, 22);
            this.labelReply.TabIndex = 1;
            this.labelReply.Text = "Reply";
            this.labelReply.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTime.ForeColor = System.Drawing.Color.White;
            this.labelTime.Location = new System.Drawing.Point(0, 0);
            this.labelTime.Margin = new System.Windows.Forms.Padding(0);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(48, 22);
            this.labelTime.TabIndex = 0;
            this.labelTime.Text = "•1w";
            this.labelTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelFullName
            // 
            this.labelFullName.AutoEllipsis = true;
            this.labelFullName.AutoSize = true;
            this.labelFullName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelFullName.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFullName.ForeColor = System.Drawing.Color.White;
            this.labelFullName.Location = new System.Drawing.Point(10, 0);
            this.labelFullName.Margin = new System.Windows.Forms.Padding(0);
            this.labelFullName.Name = "labelFullName";
            this.labelFullName.Size = new System.Drawing.Size(74, 22);
            this.labelFullName.TabIndex = 0;
            this.labelFullName.Text = "Full name";
            this.labelFullName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ReplyComment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanelComment);
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.MinimumSize = new System.Drawing.Size(0, 20);
            this.Name = "ReplyComment";
            this.Size = new System.Drawing.Size(569, 369);
            this.tableLayoutPanelComment.ResumeLayout(false);
            this.tableLayoutPanelComment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userAvatar)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.flowLayoutPanelImages.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            this.panelActionTaskBar.ResumeLayout(false);
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel11.PerformLayout();
            this.tableLayoutPanel12.ResumeLayout(false);
            this.tableLayoutPanel12.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private VoicePlayerCommon voicePlayer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelComment;
        private AvatarCommon userAvatar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelImages;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Panel panelActionTaskBar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private System.Windows.Forms.Label labelTotalLikes;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel12;
        private System.Windows.Forms.Label labelLike;
        private System.Windows.Forms.Label labelReply;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelFullName;
    }
}
