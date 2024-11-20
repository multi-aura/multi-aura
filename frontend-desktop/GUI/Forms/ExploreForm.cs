using BLL.DataProviders;
using CustomControl.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Forms
{
    public partial class ExploreForm : Form
    {
        private Label currentTaskBar;
        private Panel currentPanelResults;
        private RelationshipDataProvider relationshipDataProvider;
        private SearchDataProvider searchDataProvider;

        private bool hasForYouNoQueryData = false;
        private bool hasTrendingNoQueryData = false;
        private bool hasNewsNoQueryData = false;
        private bool hasPeopleNoQueryData = false;
        private bool hasPostsNoQueryData = false;

        private bool hasForYouWithQueryData = false;
        private bool hasTrendingWithQueryData = false;
        private bool hasNewsWithQueryData = false;
        private bool hasPeopleWithQueryData = false;
        private bool hasPostsWithQueryData = false;

        public SearchBarCommon SearchBar()
        {
            return this.searchBarCommon;
        }
        public ExploreForm()
        {
            InitializeComponent();
            relationshipDataProvider = RelationshipDataProvider.Instance;
            relationshipDataProvider.SuggestDataLoaded += LoadSuggestFriends;

            searchDataProvider = SearchDataProvider.Instance;
            searchDataProvider.ForYouNoQueryDataLoaded += LoadForYouNoQueryPosts;
            SetUpNavigations();
        }
        private void SetUpNavigations()
        {
            this.labelForYou.Click += LabelForYou_Click;
            this.labelTrending.Click += LabelTrending_Click;
            this.labelNews.Click += LabelNews_Click;
            this.labelPeople.Click += LabelPeople_Click;
            this.labelPosts.Click += LabelPosts_Click;
            this.Load += (sender, e) => LabelForYou_Click(this.labelForYou, e);

            this.panelForYouNoQueryPosts.Visible = true;
            this.currentPanelResults = this.panelForYouNoQueryPosts;

            this.panelForYouPosts.Visible = false;
            this.panelNewsNoQueryPosts.Visible = false;
            this.panelNewsPosts.Visible = false;
            this.panelPeopleNoQuery.Visible = false;
            this.panelPeopleWithQuery.Visible = false;
            this.panelPostsNoQuery.Visible = false;
            this.panelPostsWithQuery.Visible = false;
        }

        private void LabelPosts_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(searchBarCommon.Query))
            {
                //TODO: load data with searching
                LoadPanel(sender, this.panelPostsWithQuery, hasPostsWithQueryData);
            }
            else
            {
                LoadPanel(sender, this.panelPostsNoQuery, hasPostsNoQueryData);
            }
        }

        private void LabelPeople_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(searchBarCommon.Query))
            {
                //TODO: load data with searching
                LoadPanel(sender, this.panelPeopleWithQuery, hasPeopleWithQueryData);
            }
            else
            {
                LoadPanel(sender, this.panelPeopleNoQuery, hasPeopleNoQueryData);
            }
        }

        private void LabelNews_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(searchBarCommon.Query))
            {
                //TODO: load data with searching
                LoadPanel(sender, this.panelNewsPosts, hasNewsWithQueryData);
            }
            else
            {
                LoadPanel(sender, this.panelNewsNoQueryPosts, hasNewsNoQueryData);
            }
        }

        private void LabelTrending_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(searchBarCommon.Query))
            {
                //TODO: load data with searching
                LoadPanel(sender, this.panelTrendingPosts, hasTrendingWithQueryData);
            }
            else
            {
                LoadPanel(sender, this.panelTrendingNoQueryPosts, hasTrendingNoQueryData);
            }
        }

        private void LabelForYou_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(searchBarCommon.Query))
            {
                //TODO: load data with searching
                LoadPanel(sender, this.panelForYouPosts, hasForYouWithQueryData);
            }
            else
            {
                LoadPanel(sender, this.panelForYouNoQueryPosts, hasForYouNoQueryData);
            }
        }

        private void LoadPanel(object btnSender, object panelSender, bool hasData)
        {
            if (hasData)
            {
                this.NotFoundContainer.Visible = false;
            }
            else
            {
                this.NotFoundContainer.Visible = true;
            }
            ActivateButton(btnSender);
            ActivatePanel(panelSender);
        }

        private void LoadSuggestFriends()
        {
            if (relationshipDataProvider.SuggestedFriends == null)
            {
                return;
            }

            if (panelSuggests.InvokeRequired)
            {
                panelSuggests.Invoke(new Action(LoadSuggestFriends));
                return;
            }

            panelSuggests.Controls.Clear();

            SuggestForYouCommon suggestForYouCommon = new SuggestForYouCommon
            {
                UserSummaries = relationshipDataProvider.SuggestedFriends,
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 0, 0, 0),
            };

            panelSuggests.Controls.Add(suggestForYouCommon);
        }

        private void LoadForYouNoQueryPosts()
        {
            if (panelForYouNoQueryPosts.InvokeRequired)
            {
                panelForYouNoQueryPosts.Invoke(new Action(LoadForYouNoQueryPosts));
                return;
            }

            //panelForYouNoQueryPosts.Controls.Clear();
            if (searchDataProvider.ForYouPosts != null)
            {
                foreach (var item in searchDataProvider.ForYouPosts)
                {
                    PostCommon postCommon = new PostCommon
                    {
                        CurrentPost = item,
                        Dock = DockStyle.Top,
                        Margin = new Padding(0, 0, 0, 0),
                    };                    

                    if (panelForYouNoQueryPosts.InvokeRequired)
                    {
                        panelForYouNoQueryPosts.Invoke(new Action(() =>
                        {
                            panelForYouNoQueryPosts.Controls.Add(postCommon);
                        }));
                    }
                    else
                    {
                        panelForYouNoQueryPosts.Controls.Add(postCommon);
                    }
                    if (!hasForYouNoQueryData)
                    {
                        hasForYouNoQueryData = true;
                    }
                }
            }
            else
            {
                hasForYouNoQueryData = false;
            }
        }
        private void ActivatePanel(object sender)
        {
            if (sender != null)
            {
                if (currentPanelResults != (Panel)sender)
                {
                    currentPanelResults.Visible = false;
                    currentPanelResults = (Panel)sender;
                    currentPanelResults.Visible = true;
                }
            }
        }

        private void ActivateButton(object sender)
        {
            if (sender != null)
            {
                if (currentTaskBar != (Label)sender)
                {
                    DisableButton();
                    currentTaskBar = (Label)sender;
                    currentTaskBar.ForeColor = Color.White;
                    currentTaskBar.Font = new Font(currentTaskBar.Font, FontStyle.Bold);
                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previousTaskBar in tableLayoutPanelSearchTaskBar.Controls)
            {
                if (previousTaskBar.GetType() == typeof(Label))
                {
                    previousTaskBar.ForeColor = Color.FromArgb(222, 222, 222);
                    previousTaskBar.Font = new Font(previousTaskBar.Font, FontStyle.Regular);
                }
            }
        }
    }
}
