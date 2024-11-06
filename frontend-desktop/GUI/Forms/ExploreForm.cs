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
        //private UserControl activeDataFrame;

        public SearchBarCommon SearchBar()
        {
            return this.searchBarCommon;
        }
        public ExploreForm()
        {
            InitializeComponent();
            SetUpNavigations();
        }
        private void SetUpNavigations()
        {
            this.labelForYou.Click += (sender, e) => LoadData(/*new PostCommon(),*/ sender);
            this.labelTrending.Click += (sender, e) => LoadData(/*new PostCommon(),*/ sender);
            this.labelNews.Click += (sender, e) => LoadData(/*new PostCommon(),*/ sender);
            this.labelPeople.Click += (sender, e) => LoadData(/*new PostCommon(),*/ sender);
            this.labelPosts.Click += (sender, e) => LoadData(/*new PostCommon(),*/ sender);
            this.Load += (sender, e) => LoadData(/*new PostCommon(),*/ this.labelForYou);
        }

        private void LoadData(/*UserControl control,*/ object sender)
        {
            //if (activeDataFrame != null)
            //{
            //    activeDataFrame.Close();
            //}
            ActivateButton(sender);
            /*activeDataFrame = control;

            //childForm.Tag = this.Tag;
            control.TopLevel = false;
            control.FormBorderStyle = FormBorderStyle.None;
            control.Dock = DockStyle.Fill;
            this.panelResults.Controls.Add(control);
            this.panelResults.Tag = control;
            control.BringToFront();
            control.Show();*/
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
