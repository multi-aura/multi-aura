namespace GUI.Forms
{
    partial class ProfileForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonSettings = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelUsername = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.labelFullName = new System.Windows.Forms.Label();
            this.containerCommonEditProfile = new CustomControl.Commons.ContainerCommon();
            this.buttonEditProfile = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.labelFriendCounter = new System.Windows.Forms.Label();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.labelFollowingCounter = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.labelFollowerCounter = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.labelPostCounter = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanelProfileTaskBar = new System.Windows.Forms.TableLayoutPanel();
            this.labelMore = new System.Windows.Forms.Label();
            this.labelFriends = new System.Windows.Forms.Label();
            this.labelIntroduce = new System.Windows.Forms.Label();
            this.labelPosts = new System.Windows.Forms.Label();
            this.searchBarContainer = new System.Windows.Forms.Panel();
            this.panelResults = new System.Windows.Forms.FlowLayoutPanel();
            this.userAvatar = new CustomControl.Commons.AvatarCommon();
            this.containerCommonEditProfile = new CustomControl.Commons.ContainerCommon();
            this.buttonEditProfile = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatarUser)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.containerCommonEditProfile.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanelProfileTaskBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userAvatar)).BeginInit();
            this.containerCommonEditProfile.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 191F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Controls.Add(this.buttonSettings, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.userAvatar, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(68, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(0, 188);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(22, 25, 22, 25);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1019, 238);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonSettings
            // 
            this.buttonSettings.AutoSize = true;
            this.buttonSettings.BackColor = System.Drawing.Color.Transparent;
            this.buttonSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonSettings.Font = new System.Drawing.Font("Montserrat Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSettings.ForeColor = System.Drawing.Color.White;
            this.buttonSettings.Image = global::GUI.Properties.Resources.setting;
            this.buttonSettings.Location = new System.Drawing.Point(827, 20);
            this.buttonSettings.Margin = new System.Windows.Forms.Padding(0);
            this.buttonSettings.MaximumSize = new System.Drawing.Size(38, 38);
            this.buttonSettings.MinimumSize = new System.Drawing.Size(38, 38);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(38, 38);
            this.buttonSettings.TabIndex = 3;
            this.buttonSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // avatarUser
            // 
            this.avatarUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.avatarUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.avatarUser.Image = global::GUI.Properties.Resources._2773d8b41134ee880c2f2ba46fe02303;
            this.avatarUser.Location = new System.Drawing.Point(22, 25);
            this.avatarUser.Margin = new System.Windows.Forms.Padding(0);
            this.avatarUser.MaximumSize = new System.Drawing.Size(169, 188);
            this.avatarUser.MinimumSize = new System.Drawing.Size(169, 188);
            this.avatarUser.Name = "avatarUser";
            this.avatarUser.Size = new System.Drawing.Size(169, 188);
            this.avatarUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.avatarUser.TabIndex = 0;
            this.avatarUser.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.labelUsername, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(213, 25);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(68, 0, 0, 0);
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(716, 188);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.BackColor = System.Drawing.Color.Transparent;
            this.labelUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelUsername.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsername.ForeColor = System.Drawing.Color.White;
            this.labelUsername.Location = new System.Drawing.Point(60, 40);
            this.labelUsername.Margin = new System.Windows.Forms.Padding(0);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(577, 40);
            this.labelUsername.TabIndex = 3;
            this.labelUsername.Text = "Unknown";
            this.labelUsername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.06338F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.93662F));
            this.tableLayoutPanel3.Controls.Add(this.labelFullName, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.containerCommonEditProfile, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(68, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(648, 50);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // labelFullName
            // 
            this.labelFullName.AutoSize = true;
            this.labelFullName.BackColor = System.Drawing.Color.Transparent;
            this.labelFullName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFullName.ForeColor = System.Drawing.Color.White;
            this.labelFullName.Location = new System.Drawing.Point(0, 0);
            this.labelFullName.Margin = new System.Windows.Forms.Padding(0);
            this.labelFullName.Name = "labelFullName";
            this.labelFullName.Size = new System.Drawing.Size(473, 50);
            this.labelFullName.TabIndex = 2;
            this.labelFullName.Text = "Unknown";
            this.labelFullName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // containerCommonEditProfile
            // 
            this.containerCommonEditProfile.Controls.Add(this.buttonEditProfile);
            this.containerCommonEditProfile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.containerCommonEditProfile.Location = new System.Drawing.Point(473, 0);
            this.containerCommonEditProfile.Margin = new System.Windows.Forms.Padding(0);
            this.containerCommonEditProfile.Name = "containerCommonEditProfile";
            this.containerCommonEditProfile.Padding = new System.Windows.Forms.Padding(11, 2, 11, 2);
            this.containerCommonEditProfile.Radius = 6;
            this.containerCommonEditProfile.Size = new System.Drawing.Size(175, 50);
            this.containerCommonEditProfile.TabIndex = 3;
            // 
            // buttonEditProfile
            // 
            this.buttonEditProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.buttonEditProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEditProfile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonEditProfile.FlatAppearance.BorderSize = 0;
            this.buttonEditProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditProfile.ForeColor = System.Drawing.Color.White;
            this.buttonEditProfile.Location = new System.Drawing.Point(11, 2);
            this.buttonEditProfile.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEditProfile.Name = "buttonEditProfile";
            this.buttonEditProfile.Size = new System.Drawing.Size(153, 46);
            this.buttonEditProfile.TabIndex = 4;
            this.buttonEditProfile.Text = "Edit profile";
            this.buttonEditProfile.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel7);
            this.panel1.Controls.Add(this.tableLayoutPanel6);
            this.panel1.Controls.Add(this.tableLayoutPanel5);
            this.panel1.Controls.Add(this.tableLayoutPanel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(68, 100);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(648, 50);
            this.panel1.TabIndex = 4;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.AutoSize = true;
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.Controls.Add(this.labelFriendCounter, 0, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(340, 0);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.Padding = new System.Windows.Forms.Padding(0, 0, 22, 0);
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(102, 40);
            this.tableLayoutPanel7.TabIndex = 8;
            // 
            // labelFriendCounter
            // 
            this.labelFriendCounter.AutoSize = true;
            this.labelFriendCounter.BackColor = System.Drawing.Color.Transparent;
            this.labelFriendCounter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelFriendCounter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFriendCounter.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFriendCounter.ForeColor = System.Drawing.Color.White;
            this.labelFriendCounter.Location = new System.Drawing.Point(0, 0);
            this.labelFriendCounter.Margin = new System.Windows.Forms.Padding(0);
            this.labelFriendCounter.Name = "labelFriendCounter";
            this.labelFriendCounter.Size = new System.Drawing.Size(82, 40);
            this.labelFriendCounter.TabIndex = 4;
            this.labelFriendCounter.Text = "0 Friends";
            this.labelFriendCounter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.AutoSize = true;
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.Controls.Add(this.labelFollowingCounter, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(209, 0);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.Padding = new System.Windows.Forms.Padding(0, 0, 22, 0);
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(131, 40);
            this.tableLayoutPanel6.TabIndex = 7;
            // 
            // labelFollowingCounter
            // 
            this.labelFollowingCounter.AutoSize = true;
            this.labelFollowingCounter.BackColor = System.Drawing.Color.Transparent;
            this.labelFollowingCounter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelFollowingCounter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFollowingCounter.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFollowingCounter.ForeColor = System.Drawing.Color.White;
            this.labelFollowingCounter.Location = new System.Drawing.Point(0, 0);
            this.labelFollowingCounter.Margin = new System.Windows.Forms.Padding(0);
            this.labelFollowingCounter.Name = "labelFollowingCounter";
            this.labelFollowingCounter.Size = new System.Drawing.Size(111, 40);
            this.labelFollowingCounter.TabIndex = 4;
            this.labelFollowingCounter.Text = "0 Followings";
            this.labelFollowingCounter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.Controls.Add(this.labelFollowerCounter, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(88, 0);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.Padding = new System.Windows.Forms.Padding(0, 0, 22, 0);
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(121, 40);
            this.tableLayoutPanel5.TabIndex = 6;
            // 
            // labelFollowerCounter
            // 
            this.labelFollowerCounter.AutoSize = true;
            this.labelFollowerCounter.BackColor = System.Drawing.Color.Transparent;
            this.labelFollowerCounter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelFollowerCounter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFollowerCounter.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFollowerCounter.ForeColor = System.Drawing.Color.White;
            this.labelFollowerCounter.Location = new System.Drawing.Point(0, 0);
            this.labelFollowerCounter.Margin = new System.Windows.Forms.Padding(0);
            this.labelFollowerCounter.Name = "labelFollowerCounter";
            this.labelFollowerCounter.Size = new System.Drawing.Size(101, 40);
            this.labelFollowerCounter.TabIndex = 4;
            this.labelFollowerCounter.Text = "0 Followers";
            this.labelFollowerCounter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.labelPostCounter, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.Padding = new System.Windows.Forms.Padding(0, 0, 22, 0);
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(88, 40);
            this.tableLayoutPanel4.TabIndex = 5;
            // 
            // labelPostCounter
            // 
            this.labelPostCounter.AutoSize = true;
            this.labelPostCounter.BackColor = System.Drawing.Color.Transparent;
            this.labelPostCounter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelPostCounter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPostCounter.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPostCounter.ForeColor = System.Drawing.Color.White;
            this.labelPostCounter.Location = new System.Drawing.Point(0, 0);
            this.labelPostCounter.Margin = new System.Windows.Forms.Padding(0);
            this.labelPostCounter.Name = "labelPostCounter";
            this.labelPostCounter.Size = new System.Drawing.Size(68, 40);
            this.labelPostCounter.TabIndex = 4;
            this.labelPostCounter.Text = "0 Posts";
            this.labelPostCounter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.tableLayoutPanelProfileTaskBar);
            this.panel2.Controls.Add(this.searchBarContainer);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(68, 238);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 0, 45, 0);
            this.panel2.Size = new System.Drawing.Size(1019, 95);
            this.panel2.TabIndex = 8;
            // 
            // tableLayoutPanelProfileTaskBar
            // 
            this.tableLayoutPanelProfileTaskBar.ColumnCount = 4;
            this.tableLayoutPanelProfileTaskBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelProfileTaskBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelProfileTaskBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelProfileTaskBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelProfileTaskBar.Controls.Add(this.labelMore, 3, 0);
            this.tableLayoutPanelProfileTaskBar.Controls.Add(this.labelFriends, 2, 0);
            this.tableLayoutPanelProfileTaskBar.Controls.Add(this.labelIntroduce, 1, 0);
            this.tableLayoutPanelProfileTaskBar.Controls.Add(this.labelPosts, 0, 0);
            this.tableLayoutPanelProfileTaskBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelProfileTaskBar.Location = new System.Drawing.Point(0, 49);
            this.tableLayoutPanelProfileTaskBar.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelProfileTaskBar.Name = "tableLayoutPanelProfileTaskBar";
            this.tableLayoutPanelProfileTaskBar.RowCount = 1;
            this.tableLayoutPanelProfileTaskBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelProfileTaskBar.Size = new System.Drawing.Size(974, 46);
            this.tableLayoutPanelProfileTaskBar.TabIndex = 24;
            // 
            // labelMore
            // 
            this.labelMore.AutoSize = true;
            this.labelMore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelMore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMore.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMore.ForeColor = System.Drawing.Color.White;
            this.labelMore.Image = global::GUI.Properties.Resources.vertical_more24;
            this.labelMore.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelMore.Location = new System.Drawing.Point(729, 0);
            this.labelMore.Margin = new System.Windows.Forms.Padding(0);
            this.labelMore.Name = "labelMore";
            this.labelMore.Size = new System.Drawing.Size(245, 46);
            this.labelMore.TabIndex = 5;
            this.labelMore.Text = "More";
            this.labelMore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelFriends
            // 
            this.labelFriends.AutoSize = true;
            this.labelFriends.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelFriends.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFriends.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFriends.ForeColor = System.Drawing.Color.White;
            this.labelFriends.Location = new System.Drawing.Point(486, 0);
            this.labelFriends.Margin = new System.Windows.Forms.Padding(0);
            this.labelFriends.Name = "labelFriends";
            this.labelFriends.Size = new System.Drawing.Size(243, 46);
            this.labelFriends.TabIndex = 2;
            this.labelFriends.Text = "Friends";
            this.labelFriends.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelIntroduce
            // 
            this.labelIntroduce.AutoSize = true;
            this.labelIntroduce.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelIntroduce.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelIntroduce.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIntroduce.ForeColor = System.Drawing.Color.White;
            this.labelIntroduce.Location = new System.Drawing.Point(243, 0);
            this.labelIntroduce.Margin = new System.Windows.Forms.Padding(0);
            this.labelIntroduce.Name = "labelIntroduce";
            this.labelIntroduce.Size = new System.Drawing.Size(243, 46);
            this.labelIntroduce.TabIndex = 1;
            this.labelIntroduce.Text = "Introduce";
            this.labelIntroduce.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPosts
            // 
            this.labelPosts.AutoSize = true;
            this.labelPosts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelPosts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPosts.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPosts.ForeColor = System.Drawing.Color.White;
            this.labelPosts.Location = new System.Drawing.Point(0, 0);
            this.labelPosts.Margin = new System.Windows.Forms.Padding(0);
            this.labelPosts.Name = "labelPosts";
            this.labelPosts.Size = new System.Drawing.Size(243, 46);
            this.labelPosts.TabIndex = 0;
            this.labelPosts.Text = "Posts";
            this.labelPosts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // searchBarContainer
            // 
            this.searchBarContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchBarContainer.Location = new System.Drawing.Point(0, 0);
            this.searchBarContainer.Margin = new System.Windows.Forms.Padding(0);
            this.searchBarContainer.Name = "searchBarContainer";
            this.searchBarContainer.Size = new System.Drawing.Size(974, 49);
            this.searchBarContainer.TabIndex = 23;
            // 
            // panelResults
            // 
            this.panelResults.AutoSize = true;
            this.panelResults.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelResults.Location = new System.Drawing.Point(60, 266);
            this.panelResults.Margin = new System.Windows.Forms.Padding(0);
            this.panelResults.MinimumSize = new System.Drawing.Size(0, 200);
            this.panelResults.Name = "panelResults";
            this.panelResults.Padding = new System.Windows.Forms.Padding(0, 20, 0, 20);
            this.panelResults.Size = new System.Drawing.Size(907, 200);
            this.panelResults.TabIndex = 28;
            // 
            // userAvatar
            // 
            this.userAvatar.CurrentUser = null;
            this.userAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.userAvatar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userAvatar.Image = global::GUI.Properties.Resources.profile;
            this.userAvatar.Location = new System.Drawing.Point(20, 20);
            this.userAvatar.Margin = new System.Windows.Forms.Padding(0);
            this.userAvatar.MaximumSize = new System.Drawing.Size(150, 150);
            this.userAvatar.MinimumSize = new System.Drawing.Size(150, 150);
            this.userAvatar.Name = "userAvatar";
            this.userAvatar.Size = new System.Drawing.Size(150, 150);
            this.userAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userAvatar.TabIndex = 0;
            this.userAvatar.TabStop = false;
            // 
            // containerCommonEditProfile
            // 
            this.containerCommonEditProfile.Controls.Add(this.buttonEditProfile);
            this.containerCommonEditProfile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.containerCommonEditProfile.Location = new System.Drawing.Point(421, 0);
            this.containerCommonEditProfile.Margin = new System.Windows.Forms.Padding(0);
            this.containerCommonEditProfile.Name = "containerCommonEditProfile";
            this.containerCommonEditProfile.Padding = new System.Windows.Forms.Padding(10, 2, 10, 2);
            this.containerCommonEditProfile.Radius = 6;
            this.containerCommonEditProfile.Size = new System.Drawing.Size(156, 40);
            this.containerCommonEditProfile.TabIndex = 3;
            // 
            // buttonEditProfile
            // 
            this.buttonEditProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.buttonEditProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEditProfile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonEditProfile.FlatAppearance.BorderSize = 0;
            this.buttonEditProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditProfile.ForeColor = System.Drawing.Color.White;
            this.buttonEditProfile.Location = new System.Drawing.Point(10, 2);
            this.buttonEditProfile.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEditProfile.Name = "buttonEditProfile";
            this.buttonEditProfile.Size = new System.Drawing.Size(136, 36);
            this.buttonEditProfile.TabIndex = 4;
            this.buttonEditProfile.Text = "Edit profile";
            this.buttonEditProfile.UseVisualStyleBackColor = false;
            // 
            // ProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.ClientSize = new System.Drawing.Size(1155, 698);
            this.Controls.Add(this.panelResults);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ProfileForm";
            this.Padding = new System.Windows.Forms.Padding(68, 0, 68, 0);
            this.Text = "ProfileForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatarUser)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.containerCommonEditProfile.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanelProfileTaskBar.ResumeLayout(false);
            this.tableLayoutPanelProfileTaskBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userAvatar)).EndInit();
            this.containerCommonEditProfile.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private CustomControl.Commons.AvatarCommon userAvatar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label labelFullName;
        private System.Windows.Forms.Label buttonSettings;
        private CustomControl.Commons.ContainerCommon containerCommonEditProfile;
        private System.Windows.Forms.Button buttonEditProfile;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Label labelFriendCounter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label labelFollowingCounter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label labelFollowerCounter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label labelPostCounter;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelProfileTaskBar;
        private System.Windows.Forms.Label labelFriends;
        private System.Windows.Forms.Label labelIntroduce;
        private System.Windows.Forms.Label labelPosts;
        private System.Windows.Forms.Panel searchBarContainer;
        private System.Windows.Forms.Label labelMore;
        private System.Windows.Forms.FlowLayoutPanel panelResults;
    }
}