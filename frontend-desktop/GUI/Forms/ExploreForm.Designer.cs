namespace GUI.Forms
{
    partial class ExploreForm
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.suggestForYouCommon1 = new CustomControl.Commons.SuggestForYouCommon();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelResults = new System.Windows.Forms.Panel();
            this.postCommon4 = new CustomControl.Commons.PostCommon();
            this.postCommon3 = new CustomControl.Commons.PostCommon();
            this.tableLayoutPanelSearchTaskBar = new System.Windows.Forms.TableLayoutPanel();
            this.labelPosts = new System.Windows.Forms.Label();
            this.labelPeople = new System.Windows.Forms.Label();
            this.labelNews = new System.Windows.Forms.Label();
            this.labelTrending = new System.Windows.Forms.Label();
            this.labelForYou = new System.Windows.Forms.Label();
            this.searchBarContainer = new System.Windows.Forms.Panel();
            this.searchBarCommon = new CustomControl.Commons.SearchBarCommon();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelResults.SuspendLayout();
            this.tableLayoutPanelSearchTaskBar.SuspendLayout();
            this.searchBarContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.suggestForYouCommon1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(601, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 80, 0, 0);
            this.panel2.Size = new System.Drawing.Size(320, 580);
            this.panel2.TabIndex = 4;
            // 
            // suggestForYouCommon1
            // 
            this.suggestForYouCommon1.BackColor = System.Drawing.Color.Transparent;
            this.suggestForYouCommon1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.suggestForYouCommon1.Location = new System.Drawing.Point(0, 80);
            this.suggestForYouCommon1.Margin = new System.Windows.Forms.Padding(0);
            this.suggestForYouCommon1.Name = "suggestForYouCommon1";
            this.suggestForYouCommon1.Size = new System.Drawing.Size(320, 500);
            this.suggestForYouCommon1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.panelResults);
            this.panel1.Controls.Add(this.tableLayoutPanelSearchTaskBar);
            this.panel1.Controls.Add(this.searchBarContainer);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 0, 40, 0);
            this.panel1.Size = new System.Drawing.Size(601, 580);
            this.panel1.TabIndex = 7;
            // 
            // panelResults
            // 
            this.panelResults.AutoScroll = true;
            this.panelResults.Controls.Add(this.postCommon4);
            this.panelResults.Controls.Add(this.postCommon3);
            this.panelResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelResults.Location = new System.Drawing.Point(0, 76);
            this.panelResults.Margin = new System.Windows.Forms.Padding(0);
            this.panelResults.Name = "panelResults";
            this.panelResults.Padding = new System.Windows.Forms.Padding(20, 20, 40, 20);
            this.panelResults.Size = new System.Drawing.Size(561, 504);
            this.panelResults.TabIndex = 25;
            // 
            // postCommon4
            // 
            this.postCommon4.AutoSize = true;
            this.postCommon4.BackColor = System.Drawing.Color.Transparent;
            this.postCommon4.Dock = System.Windows.Forms.DockStyle.Top;
            this.postCommon4.Location = new System.Drawing.Point(20, 1215);
            this.postCommon4.Margin = new System.Windows.Forms.Padding(0);
            this.postCommon4.MinimumSize = new System.Drawing.Size(520, 720);
            this.postCommon4.Name = "postCommon4";
            this.postCommon4.Size = new System.Drawing.Size(520, 1195);
            this.postCommon4.TabIndex = 1;
            // 
            // postCommon3
            // 
            this.postCommon3.AutoSize = true;
            this.postCommon3.BackColor = System.Drawing.Color.Transparent;
            this.postCommon3.Dock = System.Windows.Forms.DockStyle.Top;
            this.postCommon3.Location = new System.Drawing.Point(20, 20);
            this.postCommon3.Margin = new System.Windows.Forms.Padding(0);
            this.postCommon3.MinimumSize = new System.Drawing.Size(520, 720);
            this.postCommon3.Name = "postCommon3";
            this.postCommon3.Size = new System.Drawing.Size(520, 1195);
            this.postCommon3.TabIndex = 0;
            // 
            // tableLayoutPanelSearchTaskBar
            // 
            this.tableLayoutPanelSearchTaskBar.ColumnCount = 5;
            this.tableLayoutPanelSearchTaskBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelSearchTaskBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelSearchTaskBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelSearchTaskBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelSearchTaskBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelSearchTaskBar.Controls.Add(this.labelPosts, 4, 0);
            this.tableLayoutPanelSearchTaskBar.Controls.Add(this.labelPeople, 3, 0);
            this.tableLayoutPanelSearchTaskBar.Controls.Add(this.labelNews, 2, 0);
            this.tableLayoutPanelSearchTaskBar.Controls.Add(this.labelTrending, 1, 0);
            this.tableLayoutPanelSearchTaskBar.Controls.Add(this.labelForYou, 0, 0);
            this.tableLayoutPanelSearchTaskBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelSearchTaskBar.Location = new System.Drawing.Point(0, 39);
            this.tableLayoutPanelSearchTaskBar.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelSearchTaskBar.Name = "tableLayoutPanelSearchTaskBar";
            this.tableLayoutPanelSearchTaskBar.RowCount = 1;
            this.tableLayoutPanelSearchTaskBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelSearchTaskBar.Size = new System.Drawing.Size(561, 37);
            this.tableLayoutPanelSearchTaskBar.TabIndex = 24;
            // 
            // labelPosts
            // 
            this.labelPosts.AutoSize = true;
            this.labelPosts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPosts.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPosts.Location = new System.Drawing.Point(448, 0);
            this.labelPosts.Margin = new System.Windows.Forms.Padding(0);
            this.labelPosts.Name = "labelPosts";
            this.labelPosts.Size = new System.Drawing.Size(113, 37);
            this.labelPosts.TabIndex = 4;
            this.labelPosts.Text = "Posts";
            this.labelPosts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPeople
            // 
            this.labelPeople.AutoSize = true;
            this.labelPeople.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPeople.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPeople.Location = new System.Drawing.Point(336, 0);
            this.labelPeople.Margin = new System.Windows.Forms.Padding(0);
            this.labelPeople.Name = "labelPeople";
            this.labelPeople.Size = new System.Drawing.Size(112, 37);
            this.labelPeople.TabIndex = 3;
            this.labelPeople.Text = "People";
            this.labelPeople.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelNews
            // 
            this.labelNews.AutoSize = true;
            this.labelNews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelNews.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNews.Location = new System.Drawing.Point(224, 0);
            this.labelNews.Margin = new System.Windows.Forms.Padding(0);
            this.labelNews.Name = "labelNews";
            this.labelNews.Size = new System.Drawing.Size(112, 37);
            this.labelNews.TabIndex = 2;
            this.labelNews.Text = "News";
            this.labelNews.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTrending
            // 
            this.labelTrending.AutoSize = true;
            this.labelTrending.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTrending.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTrending.Location = new System.Drawing.Point(112, 0);
            this.labelTrending.Margin = new System.Windows.Forms.Padding(0);
            this.labelTrending.Name = "labelTrending";
            this.labelTrending.Size = new System.Drawing.Size(112, 37);
            this.labelTrending.TabIndex = 1;
            this.labelTrending.Text = "Trending";
            this.labelTrending.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelForYou
            // 
            this.labelForYou.AutoSize = true;
            this.labelForYou.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelForYou.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelForYou.Location = new System.Drawing.Point(0, 0);
            this.labelForYou.Margin = new System.Windows.Forms.Padding(0);
            this.labelForYou.Name = "labelForYou";
            this.labelForYou.Size = new System.Drawing.Size(112, 37);
            this.labelForYou.TabIndex = 0;
            this.labelForYou.Text = "For you";
            this.labelForYou.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // searchBarContainer
            // 
            this.searchBarContainer.Controls.Add(this.searchBarCommon);
            this.searchBarContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchBarContainer.Location = new System.Drawing.Point(0, 0);
            this.searchBarContainer.Margin = new System.Windows.Forms.Padding(0);
            this.searchBarContainer.Name = "searchBarContainer";
            this.searchBarContainer.Size = new System.Drawing.Size(561, 39);
            this.searchBarContainer.TabIndex = 23;
            // 
            // searchBarCommon
            // 
            this.searchBarCommon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.searchBarCommon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchBarCommon.Location = new System.Drawing.Point(0, 0);
            this.searchBarCommon.Margin = new System.Windows.Forms.Padding(0);
            this.searchBarCommon.MinimumSize = new System.Drawing.Size(320, 32);
            this.searchBarCommon.Name = "searchBarCommon";
            this.searchBarCommon.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.searchBarCommon.Size = new System.Drawing.Size(561, 39);
            this.searchBarCommon.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 100);
            this.panel3.TabIndex = 22;
            // 
            // ExploreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.ClientSize = new System.Drawing.Size(921, 580);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ExploreForm";
            this.Text = "ExploreForm";
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelResults.ResumeLayout(false);
            this.panelResults.PerformLayout();
            this.tableLayoutPanelSearchTaskBar.ResumeLayout(false);
            this.tableLayoutPanelSearchTaskBar.PerformLayout();
            this.searchBarContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private CustomControl.Commons.SuggestForYouCommon suggestForYouCommon1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelResults;
        private CustomControl.Commons.PostCommon postCommon4;
        private CustomControl.Commons.PostCommon postCommon3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSearchTaskBar;
        private System.Windows.Forms.Label labelPosts;
        private System.Windows.Forms.Label labelPeople;
        private System.Windows.Forms.Label labelNews;
        private System.Windows.Forms.Label labelTrending;
        private System.Windows.Forms.Label labelForYou;
        private System.Windows.Forms.Panel searchBarContainer;
        private CustomControl.Commons.SearchBarCommon searchBarCommon;
    }
}