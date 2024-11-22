using BLL.DataProviders;
using CustomControl.Commons;
using CustomControl.Modals;
using GUI.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI.Forms
{
    public partial class ExploreForm : Form
    {
        private Label currentTaskBar;
        private Panel currentPanelResults;
        private AppDataProvider appDataProvider = AppDataProvider.Instance;
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
            searchDataProvider.TrendingNoQueryDataLoaded += LoadTrendingNoQueryPosts;
            searchDataProvider.NewsNoQueryDataLoaded += LoadNewsNoQueryPosts;
            searchDataProvider.PeopleNoQueryDataLoaded += LoadPeopleNoQueryPosts;
            searchDataProvider.PostsNoQueryDataLoaded += LoadPostsNoQuery;

            searchDataProvider.ForYouDataLoaded += LoadForYouWithQueryPosts;
            searchDataProvider.TrendingDataLoaded += LoadTrendingWithQueryPosts;
            searchDataProvider.NewsDataLoaded += LoadNewsWithQueryPosts;
            searchDataProvider.PeopleDataLoaded += LoadPeopleWithQueryPosts;
            searchDataProvider.PostsDataLoaded += LoadPostsWithQuery;

            SetUpNavigations();

            this.searchBarCommon.OnEnter += (sender, args) =>
            {
                OnSearchEnter(sender, args);
            };
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

            this.panelTrendingNoQueryPosts.Visible = false;
            this.panelTrendingPostsWithQuery.Visible = false;

            this.panelNewsNoQueryPosts.Visible = false;
            this.panelNewsPostsWithQuery.Visible = false;

            this.panelPeopleNoQuery.Visible = false;
            this.panelPeopleWithQuery.Visible = false;

            this.panelPostsNoQuery.Visible = false;
            this.panelPostsWithQuery.Visible = false;
        }
        private void OnSearchEnter(object sender, EventArgs e)
        {
            string query = this.searchBarCommon.Query;
            if (query != null)
            {
                ShowLoading();
                searchDataProvider.Search(query, 1, 10);                
                //ResetPanelResults();
            }
        }

        private void ShowLoading()
        {
            this.NotFoundContainer.Visible = false;
            this.currentPanelResults.Visible = false;
            this.LoadingContainer.Visible = true;
        }

        private void HideLoading()
        {
            this.currentPanelResults.Visible = true;
            this.LoadingContainer.Visible = false;
        }

        private void ResetPanelResults()
        {
            if (currentTaskBar == labelTrending)
            {
                LabelTrending_Click(this.labelTrending, EventArgs.Empty);
            }
            else if (currentTaskBar == labelNews)
            {
                LabelNews_Click(this.labelNews, EventArgs.Empty);
            }
            else if (currentTaskBar == labelPeople)
            {
                LabelPeople_Click(this.labelPeople, EventArgs.Empty);
            }
            else if (currentTaskBar == labelPosts)
            {
                LabelPosts_Click(this.labelPosts, EventArgs.Empty);
            }
            else 
            {
                LabelForYou_Click(this.labelForYou, EventArgs.Empty);
            }
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
                LoadPanel(sender, this.panelNewsPostsWithQuery, hasNewsWithQueryData);
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
                LoadPanel(sender, this.panelTrendingPostsWithQuery, hasTrendingWithQueryData);
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
            this.LoadingContainer.Visible = false;
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
            if (searchDataProvider.ForYouNoQueryPosts != null)
            {
                hasForYouNoQueryData = false;
                foreach (var item in searchDataProvider.ForYouNoQueryPosts)
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

            if (currentTaskBar == labelForYou)
            {
                HideLoading();
                LabelForYou_Click(this.labelForYou, EventArgs.Empty);
            }
        }

        private void LoadTrendingNoQueryPosts()
        {
            if (panelTrendingNoQueryPosts.InvokeRequired)
            {
                panelTrendingNoQueryPosts.Invoke(new Action(LoadTrendingNoQueryPosts));
                return;
            }

            if (searchDataProvider.TrendingsNoQuery != null)
            {
                hasTrendingNoQueryData = false;
                foreach (var item in searchDataProvider.TrendingsNoQuery)
                {
                    PostCommon postCommon = new PostCommon
                    {
                        CurrentPost = item,
                        Dock = DockStyle.Top,
                        Margin = new Padding(0, 0, 0, 0),
                    };

                    if (panelTrendingNoQueryPosts.InvokeRequired)
                    {
                        panelTrendingNoQueryPosts.Invoke(new Action(() =>
                        {
                            panelTrendingNoQueryPosts.Controls.Add(postCommon);
                        }));
                    }
                    else
                    {
                        panelTrendingNoQueryPosts.Controls.Add(postCommon);
                    }
                    if (!hasTrendingNoQueryData)
                    {
                        hasTrendingNoQueryData = true;
                    }
                }
            }
            else
            {
                hasTrendingNoQueryData = false;
            }

            if (currentTaskBar == labelTrending)
            {
                HideLoading();
                LabelTrending_Click(this.labelTrending, EventArgs.Empty);
            }
        }

        private void LoadNewsNoQueryPosts()
        {
            if (panelNewsNoQueryPosts.InvokeRequired)
            {
                panelNewsNoQueryPosts.Invoke(new Action(LoadNewsNoQueryPosts));
                return;
            }

            if (searchDataProvider.NewsNoQuery != null)
            {
                hasNewsNoQueryData = false;
                foreach (var item in searchDataProvider.NewsNoQuery)
                {
                    PostCommon postCommon = new PostCommon
                    {
                        CurrentPost = item,
                        Dock = DockStyle.Top,
                        Margin = new Padding(0, 0, 0, 0),
                    };

                    if (panelNewsNoQueryPosts.InvokeRequired)
                    {
                        panelNewsNoQueryPosts.Invoke(new Action(() =>
                        {
                            panelNewsNoQueryPosts.Controls.Add(postCommon);
                        }));
                    }
                    else
                    {
                        panelNewsNoQueryPosts.Controls.Add(postCommon);
                    }
                    if (!hasNewsNoQueryData)
                    {
                        hasNewsNoQueryData = true;
                    }
                }
            }
            else
            {
                hasNewsNoQueryData = false;
            }

            if (currentTaskBar == labelNews)
            {
                HideLoading();
                LabelNews_Click(this.labelNews, EventArgs.Empty);
            }
        }

        private void LoadPeopleNoQueryPosts()
        {
            if (panelPeopleNoQuery.InvokeRequired)
            {
                panelPeopleNoQuery.Invoke(new Action(LoadPeopleNoQueryPosts));
                return;
            }

            if (searchDataProvider.PeopleNoQuery != null)
            {
                hasPeopleNoQueryData = false;
                foreach (var item in searchDataProvider.PeopleNoQuery)
                {
                    UserSummaryCommon userSummary = new UserSummaryCommon
                    {
                        CurrentUserSummary = item,
                        IsFollowing = false,
                        Dock = DockStyle.Top,
                        Margin = new Padding(0, 0, 0, 0),
                        Padding = new Padding(10, 4, 10, 4),
                    };

                    if (panelPeopleNoQuery.InvokeRequired)
                    {
                        panelPeopleNoQuery.Invoke(new Action(() =>
                        {
                            panelPeopleNoQuery.Controls.Add(userSummary);
                        }));
                    }
                    else
                    {
                        panelPeopleNoQuery.Controls.Add(userSummary);
                    }
                    if (!hasPeopleNoQueryData)
                    {
                        hasPeopleNoQueryData = true;
                    }
                }
            }
            else
            {
                hasPeopleNoQueryData = false;
            }

            if (currentTaskBar == labelPeople)
            {
                HideLoading();
                LabelPeople_Click(this.labelPeople, EventArgs.Empty);
            }
        }

        private void LoadPostsNoQuery()
        {
            if (panelPostsNoQuery.InvokeRequired)
            {
                panelPostsNoQuery.Invoke(new Action(LoadPostsNoQuery));
                return;
            }

            if (searchDataProvider.PostsNoQuery != null)
            {
                hasPostsNoQueryData = false;
                foreach (var item in searchDataProvider.PostsNoQuery)
                {
                    PostCommon postCommon = new PostCommon
                    {
                        CurrentPost = item,
                        Dock = DockStyle.Top,
                        Margin = new Padding(0, 0, 0, 0),
                    };

                    if (panelPostsNoQuery.InvokeRequired)
                    {
                        panelPostsNoQuery.Invoke(new Action(() =>
                        {
                            panelPostsNoQuery.Controls.Add(postCommon);
                        }));
                    }
                    else
                    {
                        panelPostsNoQuery.Controls.Add(postCommon);
                    }
                    if (!hasPostsNoQueryData)
                    {
                        hasPostsNoQueryData = true;
                    }
                }
            }
            else
            {
                hasPostsNoQueryData = false;
            }

            if (currentTaskBar == labelPosts)
            {
                HideLoading();
                LabelPosts_Click(this.labelPosts, EventArgs.Empty);
            }
        }

        //With Query
        private void LoadForYouWithQueryPosts()
        {
            if (panelForYouPosts.InvokeRequired)
            {
                panelForYouPosts.Invoke(new Action(LoadForYouWithQueryPosts));
                return;
            }

            panelForYouPosts.Controls.Clear();
            if (searchDataProvider.ForYouPosts != null)
            {
                hasForYouWithQueryData = false;
                foreach (var item in searchDataProvider.ForYouPosts)
                {
                    PostCommon postCommon = new PostCommon
                    {
                        CurrentPost = item,
                        Dock = DockStyle.Top,
                        Margin = new Padding(0, 0, 0, 0),
                    };

                    if (panelForYouPosts.InvokeRequired)
                    {
                        panelForYouPosts.Invoke(new Action(() =>
                        {
                            panelForYouPosts.Controls.Add(postCommon);
                        }));
                    }
                    else
                    {
                        panelForYouPosts.Controls.Add(postCommon);
                    }
                    if (!hasForYouWithQueryData)
                    {
                        hasForYouWithQueryData = true;
                    }
                }
            }
            else
            {
                hasForYouWithQueryData = false;
            }

            if (currentTaskBar == labelForYou)
            {
                HideLoading();
                LabelForYou_Click(this.labelForYou, EventArgs.Empty);
            }
        }

        private void LoadTrendingWithQueryPosts()
        {
            if (panelTrendingPostsWithQuery.InvokeRequired)
            {
                panelTrendingPostsWithQuery.Invoke(new Action(LoadTrendingWithQueryPosts));
                return;
            }

            panelTrendingPostsWithQuery.Controls.Clear();
            if (searchDataProvider.Trendings != null)
            {
                hasTrendingWithQueryData = false;
                foreach (var item in searchDataProvider.Trendings)
                {
                    PostCommon postCommon = new PostCommon
                    {
                        CurrentPost = item,
                        Dock = DockStyle.Top,
                        Margin = new Padding(0, 0, 0, 0),
                    };

                    if (panelTrendingPostsWithQuery.InvokeRequired)
                    {
                        panelTrendingPostsWithQuery.Invoke(new Action(() =>
                        {
                            panelTrendingPostsWithQuery.Controls.Add(postCommon);
                        }));
                    }
                    else
                    {
                        panelTrendingPostsWithQuery.Controls.Add(postCommon);
                    }
                    if (!hasTrendingWithQueryData)
                    {
                        hasTrendingWithQueryData = true;
                    }
                }
            }
            else
            {
                hasTrendingWithQueryData = false;
            }

            if (currentTaskBar == labelTrending)
            {
                HideLoading();
                LabelTrending_Click(this.labelTrending, EventArgs.Empty);
            }
        }

        private void LoadNewsWithQueryPosts()
        {
            if (panelNewsPostsWithQuery.InvokeRequired)
            {
                panelNewsPostsWithQuery.Invoke(new Action(LoadNewsWithQueryPosts));
                return;
            }

            panelNewsPostsWithQuery.Controls.Clear();
            if (searchDataProvider.News != null)
            {
                hasNewsWithQueryData = false;
                foreach (var item in searchDataProvider.News)
                {
                    PostCommon postCommon = new PostCommon
                    {
                        CurrentPost = item,
                        Dock = DockStyle.Top,
                        Margin = new Padding(0, 0, 0, 0),
                    };

                    if (panelNewsPostsWithQuery.InvokeRequired)
                    {
                        panelNewsPostsWithQuery.Invoke(new Action(() =>
                        {
                            panelNewsPostsWithQuery.Controls.Add(postCommon);
                        }));
                    }
                    else
                    {
                        panelNewsPostsWithQuery.Controls.Add(postCommon);
                    }
                    if (!hasNewsWithQueryData)
                    {
                        hasNewsWithQueryData = true;
                    }
                }
            }
            else
            {
                hasNewsWithQueryData = false;
            }

            if (currentTaskBar == labelNews)
            {
                HideLoading();
                LabelNews_Click(this.labelNews, EventArgs.Empty);
            }
        }

        private void LoadPeopleWithQueryPosts()
        {
            if (panelPeopleWithQuery.InvokeRequired)
            {
                panelPeopleWithQuery.Invoke(new Action(LoadPeopleWithQueryPosts));
                return;
            }

            panelPeopleWithQuery.Controls.Clear();
            if (searchDataProvider.People != null)
            {
                hasPeopleWithQueryData = false;
                foreach (var item in searchDataProvider.People)
                {
                    bool isFollowing = false;
                    if (relationshipDataProvider.Followings != null && relationshipDataProvider.Followings.Exists(user => user.Username == appDataProvider.User.Username))
                    {
                        isFollowing = true;
                    }

                    UserSummaryCommon userSummary = new UserSummaryCommon
                    {
                        CurrentUserSummary = item,
                        IsFollowing = isFollowing,
                        Dock = DockStyle.Top,
                        Margin = new Padding(0, 0, 0, 0),
                        Padding = new Padding(10, 4, 10, 4),
                    };

                    if (panelPeopleWithQuery.InvokeRequired)
                    {
                        panelPeopleWithQuery.Invoke(new Action(() =>
                        {
                            panelPeopleWithQuery.Controls.Add(userSummary);
                        }));
                    }
                    else
                    {
                        panelPeopleWithQuery.Controls.Add(userSummary);
                    }
                    if (!hasPeopleWithQueryData)
                    {
                        hasPeopleWithQueryData = true;
                    }
                }
            }
            else
            {
                hasPeopleWithQueryData = false;
            }

            if (currentTaskBar == labelPeople)
            {
                HideLoading();
                LabelPeople_Click(this.labelPeople, EventArgs.Empty);
            }
        }

        private void LoadPostsWithQuery()
        {
            if (panelPostsWithQuery.InvokeRequired)
            {
                panelPostsWithQuery.Invoke(new Action(LoadPostsWithQuery));
                return;
            }

            panelPostsWithQuery.Controls.Clear();
            if (searchDataProvider.Posts!= null)
            {
                hasPostsWithQueryData = false;
                foreach (var item in searchDataProvider.Posts)
                {
                    PostCommon postCommon = new PostCommon
                    {
                        CurrentPost = item,
                        Dock = DockStyle.Top,
                        Margin = new Padding(0, 0, 0, 0),
                    };

                    if (panelPostsWithQuery.InvokeRequired)
                    {
                        panelPostsWithQuery.Invoke(new Action(() =>
                        {
                            panelPostsWithQuery.Controls.Add(postCommon);
                        }));
                    }
                    else
                    {
                        panelPostsWithQuery.Controls.Add(postCommon);
                    }
                    if (!hasPostsWithQueryData)
                    {
                        hasPostsWithQueryData = true;
                    }
                }
            }
            else
            {
                hasPostsWithQueryData = false;
            }

            if (currentTaskBar == labelPosts)
            {
                HideLoading();
                LabelPosts_Click(this.labelPosts, EventArgs.Empty);
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
