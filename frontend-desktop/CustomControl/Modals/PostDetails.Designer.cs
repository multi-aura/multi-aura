namespace CustomControl.Modals
{
    partial class PostDetails
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PostDetails));
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelImages = new System.Windows.Forms.Panel();
            this.currentPhotoBox = new System.Windows.Forms.PictureBox();
            this.panelDetails = new System.Windows.Forms.Panel();
            this.panelInteractions = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelDescription = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.actionButton = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelMessageSending = new System.Windows.Forms.Panel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.labelSending = new System.Windows.Forms.Label();
            this.panelWindownControlTaskBar = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.CloseWindowControlButton = new System.Windows.Forms.Button();
            this.panelComments = new System.Windows.Forms.Panel();
            this.nextImage = new CustomControl.Commons.AvatarCommon();
            this.preImage = new CustomControl.Commons.AvatarCommon();
            this.avatarCommon1 = new CustomControl.Commons.AvatarCommon();
            this.containerCommon1 = new CustomControl.Commons.ContainerCommon();
            this.inputComment = new CustomControl.Commons.AutoSizeTextBox();
            this.panelDesktop.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelImages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentPhotoBox)).BeginInit();
            this.panelDetails.SuspendLayout();
            this.panelInteractions.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panelMessageSending.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.panelWindownControlTaskBar.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nextImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.preImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.avatarCommon1)).BeginInit();
            this.containerCommon1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDesktop
            // 
            this.panelDesktop.BackColor = System.Drawing.Color.Transparent;
            this.panelDesktop.Controls.Add(this.tableLayoutPanel1);
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(0, 35);
            this.panelDesktop.Margin = new System.Windows.Forms.Padding(0);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(800, 438);
            this.panelDesktop.TabIndex = 8;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 600F));
            this.tableLayoutPanel1.Controls.Add(this.panelImages, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelDetails, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 438);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelImages
            // 
            this.panelImages.Controls.Add(this.nextImage);
            this.panelImages.Controls.Add(this.preImage);
            this.panelImages.Controls.Add(this.currentPhotoBox);
            this.panelImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelImages.Location = new System.Drawing.Point(0, 0);
            this.panelImages.Margin = new System.Windows.Forms.Padding(0);
            this.panelImages.Name = "panelImages";
            this.panelImages.Size = new System.Drawing.Size(200, 438);
            this.panelImages.TabIndex = 9;
            // 
            // currentPhotoBox
            // 
            this.currentPhotoBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.currentPhotoBox.Image = global::CustomControl.Properties.Resources.e689c6e22850ab91c9236b413cbaf32e;
            this.currentPhotoBox.Location = new System.Drawing.Point(0, 0);
            this.currentPhotoBox.Margin = new System.Windows.Forms.Padding(0);
            this.currentPhotoBox.Name = "currentPhotoBox";
            this.currentPhotoBox.Size = new System.Drawing.Size(200, 435);
            this.currentPhotoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.currentPhotoBox.TabIndex = 0;
            this.currentPhotoBox.TabStop = false;
            // 
            // panelDetails
            // 
            this.panelDetails.Controls.Add(this.panelInteractions);
            this.panelDetails.Controls.Add(this.panel3);
            this.panelDetails.Controls.Add(this.panel2);
            this.panelDetails.Controls.Add(this.panelMessageSending);
            this.panelDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDetails.Location = new System.Drawing.Point(200, 0);
            this.panelDetails.Margin = new System.Windows.Forms.Padding(0);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Size = new System.Drawing.Size(600, 438);
            this.panelDetails.TabIndex = 10;
            // 
            // panelInteractions
            // 
            this.panelInteractions.AutoScroll = true;
            this.panelInteractions.Controls.Add(this.panelComments);
            this.panelInteractions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInteractions.Location = new System.Drawing.Point(0, 149);
            this.panelInteractions.Margin = new System.Windows.Forms.Padding(0);
            this.panelInteractions.Name = "panelInteractions";
            this.panelInteractions.Size = new System.Drawing.Size(600, 239);
            this.panelInteractions.TabIndex = 32;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Silver;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 148);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(600, 1);
            this.panel3.TabIndex = 31;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.tableLayoutPanel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10, 4, 0, 4);
            this.panel2.Size = new System.Drawing.Size(600, 148);
            this.panel2.TabIndex = 30;
            // 
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.Controls.Add(this.labelDescription);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(10, 48);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(590, 96);
            this.panel4.TabIndex = 3;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.ForeColor = System.Drawing.Color.White;
            this.labelDescription.Location = new System.Drawing.Point(1, 0);
            this.labelDescription.Margin = new System.Windows.Forms.Padding(0);
            this.labelDescription.MaximumSize = new System.Drawing.Size(580, 0);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(579, 96);
            this.labelDescription.TabIndex = 0;
            this.labelDescription.Text = resources.GetString("labelDescription.Text");
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel3.Controls.Add(this.actionButton, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.avatarCommon1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel3.Location = new System.Drawing.Point(10, 4);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(590, 44);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // actionButton
            // 
            this.actionButton.AutoEllipsis = true;
            this.actionButton.AutoSize = true;
            this.actionButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.actionButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.actionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionButton.ForeColor = System.Drawing.Color.White;
            this.actionButton.Image = global::CustomControl.Properties.Resources.more;
            this.actionButton.Location = new System.Drawing.Point(540, 14);
            this.actionButton.Margin = new System.Windows.Forms.Padding(20, 14, 4, 14);
            this.actionButton.Name = "actionButton";
            this.actionButton.Size = new System.Drawing.Size(46, 16);
            this.actionButton.TabIndex = 3;
            this.actionButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(40, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(480, 44);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(10, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(470, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "•1w";
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(10, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(470, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nguyễn Minh Thư";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // panelMessageSending
            // 
            this.panelMessageSending.AutoSize = true;
            this.panelMessageSending.BackColor = System.Drawing.Color.Transparent;
            this.panelMessageSending.Controls.Add(this.tableLayoutPanel5);
            this.panelMessageSending.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelMessageSending.Location = new System.Drawing.Point(0, 388);
            this.panelMessageSending.Margin = new System.Windows.Forms.Padding(0);
            this.panelMessageSending.Name = "panelMessageSending";
            this.panelMessageSending.Padding = new System.Windows.Forms.Padding(10);
            this.panelMessageSending.Size = new System.Drawing.Size(600, 50);
            this.panelMessageSending.TabIndex = 28;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel5.Controls.Add(this.containerCommon1, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(10, 10);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.Size = new System.Drawing.Size(580, 30);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.labelSending, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(548, 6);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.MinimumSize = new System.Drawing.Size(24, 24);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(32, 24);
            this.tableLayoutPanel6.TabIndex = 5;
            // 
            // labelSending
            // 
            this.labelSending.AutoSize = true;
            this.labelSending.BackColor = System.Drawing.Color.Transparent;
            this.labelSending.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelSending.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSending.Image = global::CustomControl.Properties.Resources.sending;
            this.labelSending.Location = new System.Drawing.Point(4, 0);
            this.labelSending.Margin = new System.Windows.Forms.Padding(0);
            this.labelSending.MaximumSize = new System.Drawing.Size(24, 24);
            this.labelSending.MinimumSize = new System.Drawing.Size(24, 24);
            this.labelSending.Name = "labelSending";
            this.labelSending.Size = new System.Drawing.Size(24, 24);
            this.labelSending.TabIndex = 4;
            // 
            // panelWindownControlTaskBar
            // 
            this.panelWindownControlTaskBar.BackColor = System.Drawing.Color.Transparent;
            this.panelWindownControlTaskBar.Controls.Add(this.tableLayoutPanel2);
            this.panelWindownControlTaskBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelWindownControlTaskBar.Location = new System.Drawing.Point(0, 0);
            this.panelWindownControlTaskBar.Margin = new System.Windows.Forms.Padding(0);
            this.panelWindownControlTaskBar.Name = "panelWindownControlTaskBar";
            this.panelWindownControlTaskBar.Size = new System.Drawing.Size(800, 35);
            this.panelWindownControlTaskBar.TabIndex = 7;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.CloseWindowControlButton, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(700, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(100, 35);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // CloseWindowControlButton
            // 
            this.CloseWindowControlButton.BackColor = System.Drawing.Color.Transparent;
            this.CloseWindowControlButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CloseWindowControlButton.FlatAppearance.BorderSize = 0;
            this.CloseWindowControlButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.CloseWindowControlButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseWindowControlButton.Image = ((System.Drawing.Image)(resources.GetObject("CloseWindowControlButton.Image")));
            this.CloseWindowControlButton.Location = new System.Drawing.Point(66, 0);
            this.CloseWindowControlButton.Margin = new System.Windows.Forms.Padding(0);
            this.CloseWindowControlButton.Name = "CloseWindowControlButton";
            this.CloseWindowControlButton.Size = new System.Drawing.Size(34, 35);
            this.CloseWindowControlButton.TabIndex = 2;
            this.CloseWindowControlButton.UseVisualStyleBackColor = false;
            // 
            // panelComments
            // 
            this.panelComments.AutoSize = true;
            this.panelComments.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelComments.Location = new System.Drawing.Point(0, 0);
            this.panelComments.Margin = new System.Windows.Forms.Padding(0);
            this.panelComments.MinimumSize = new System.Drawing.Size(0, 40);
            this.panelComments.Name = "panelComments";
            this.panelComments.Padding = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.panelComments.Size = new System.Drawing.Size(600, 40);
            this.panelComments.TabIndex = 19;
            // 
            // nextImage
            // 
            this.nextImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nextImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.nextImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nextImage.Image = global::CustomControl.Properties.Resources.chevron_right;
            this.nextImage.Location = new System.Drawing.Point(173, 231);
            this.nextImage.Name = "nextImage";
            this.nextImage.Size = new System.Drawing.Size(24, 24);
            this.nextImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.nextImage.TabIndex = 2;
            this.nextImage.TabStop = false;
            // 
            // preImage
            // 
            this.preImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.preImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.preImage.Image = global::CustomControl.Properties.Resources.chevron_left;
            this.preImage.Location = new System.Drawing.Point(23, 231);
            this.preImage.Name = "preImage";
            this.preImage.Size = new System.Drawing.Size(24, 24);
            this.preImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.preImage.TabIndex = 1;
            this.preImage.TabStop = false;
            // 
            // avatarCommon1
            // 
            this.avatarCommon1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.avatarCommon1.Image = global::CustomControl.Properties.Resources._006833d62de3321b980cb2b6a46088a5;
            this.avatarCommon1.Location = new System.Drawing.Point(0, 0);
            this.avatarCommon1.Margin = new System.Windows.Forms.Padding(0);
            this.avatarCommon1.MaximumSize = new System.Drawing.Size(40, 40);
            this.avatarCommon1.MinimumSize = new System.Drawing.Size(40, 40);
            this.avatarCommon1.Name = "avatarCommon1";
            this.avatarCommon1.Size = new System.Drawing.Size(40, 40);
            this.avatarCommon1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.avatarCommon1.TabIndex = 1;
            this.avatarCommon1.TabStop = false;
            // 
            // containerCommon1
            // 
            this.containerCommon1.AutoSize = true;
            this.containerCommon1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.containerCommon1.Controls.Add(this.inputComment);
            this.containerCommon1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.containerCommon1.Location = new System.Drawing.Point(0, 0);
            this.containerCommon1.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.containerCommon1.Name = "containerCommon1";
            this.containerCommon1.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.containerCommon1.Radius = 6;
            this.containerCommon1.Size = new System.Drawing.Size(536, 30);
            this.containerCommon1.TabIndex = 4;
            // 
            // inputComment
            // 
            this.inputComment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.inputComment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inputComment.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.inputComment.Font = new System.Drawing.Font("Montserrat Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputComment.ForeColor = System.Drawing.Color.White;
            this.inputComment.Hint = "Aa, enter your text";
            this.inputComment.Location = new System.Drawing.Point(6, 4);
            this.inputComment.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.inputComment.MaxLine = 10;
            this.inputComment.Multiline = true;
            this.inputComment.Name = "inputComment";
            this.inputComment.Size = new System.Drawing.Size(524, 22);
            this.inputComment.TabIndex = 5;
            this.inputComment.Text = "Aa, enter your text";
            // 
            // PostDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.ClientSize = new System.Drawing.Size(800, 473);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelWindownControlTaskBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PostDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PostDetails";
            this.panelDesktop.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelImages.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.currentPhotoBox)).EndInit();
            this.panelDetails.ResumeLayout(false);
            this.panelDetails.PerformLayout();
            this.panelInteractions.ResumeLayout(false);
            this.panelInteractions.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.panelMessageSending.ResumeLayout(false);
            this.panelMessageSending.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.panelWindownControlTaskBar.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nextImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.preImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.avatarCommon1)).EndInit();
            this.containerCommon1.ResumeLayout(false);
            this.containerCommon1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDesktop;
        private System.Windows.Forms.Panel panelWindownControlTaskBar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button CloseWindowControlButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelImages;
        private Commons.AvatarCommon nextImage;
        private Commons.AvatarCommon preImage;
        private System.Windows.Forms.PictureBox currentPhotoBox;
        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.Panel panelMessageSending;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private Commons.ContainerCommon containerCommon1;
        private Commons.AutoSizeTextBox inputComment;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label labelSending;
        private System.Windows.Forms.Panel panelInteractions;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label actionButton;
        private Commons.AvatarCommon avatarCommon1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelComments;
    }
}