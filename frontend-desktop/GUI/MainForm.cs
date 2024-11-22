using GUI.Extensions;
using GUI.Forms;
using GUI.AuthenticationForms;
using System;
using System.Drawing;
using System.Windows.Forms;
using CustomControl.Commons;
using CustomControl.Modals;
using System.Net.Http;
using BLL.DataProviders;

namespace GUI
{
    public partial class MainForm : Form
    {
        private Button currentButton;
        private Form activeForm;
        private AppDataProvider appDataProvider = AppDataProvider.Instance;
        private RelationshipDataProvider relationshipDataProvider = RelationshipDataProvider.Instance;
        private bool isListeningForMouseDown = false;

        private Form homeForm;
        private Form exploreForm;
        private Form messagesForm;
        private Form notificationsForm;
        private Form profileForm;
        
        public MainForm()
        {
            InitializeComponent();
            appDataProvider.DataLoaded += SetUpUI;
            appDataProvider.Initialize();

            appDataProvider.MainForm = this;
            // Lấy kích thước màn hình của PC
            var screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            var screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

            // Thiết lập kích thước form là 80% chiều rộng và 80% chiều cao của màn hình
            this.Width = (int)(screenWidth * 0.8);
            this.Height = (int)(screenHeight * 0.8);

            appDataProvider.ScreenWidth = this.Width;
            appDataProvider.ScreenHeight = this.Height;

            this.SizeChanged += MainForm_SizeChanged;

            appDataProvider.ShowModalRequested += ShowModalRequest;

            homeForm = new HomeForm();
            exploreForm = new ExploreForm();
            messagesForm = new MessagesForm();
            notificationsForm = new NotificationsForm();
            profileForm = new ProfileForm();

            this.taskBarNotifications.Visible = false;
            this.KeyPreview = true;

            if (!appDataProvider.HasUser())
            {
                this.Hide();

                AuthenticationForm authenticationForm = new AuthenticationForm();
                authenticationForm.FormClosed += (s, args) =>
                {
                    if (appDataProvider.HasUser())
                    {
                        relationshipDataProvider.Initialize();

                        SetUpDefaultActions();
                        //appDataProvider.DataLoaded += SetUpUI;
                        //SetUpUI();
                        this.Show();
                    }
                    else
                    {
                        Application.Exit();
                    }
                };
                authenticationForm.ShowDialog();
            }
            else
            {
                relationshipDataProvider.Initialize();

                SetUpDefaultActions();
                //appDataProvider.DataLoaded += SetUpUI;
                //SetUpUI();
            }
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            appDataProvider.ScreenWidth = this.Width;
            appDataProvider.ScreenHeight = this.Height;
        }

        private void SetUpDefaultActions()
        {
            this.KeyPress += MainForm_KeyPress;
            this.EnableWindowResize();
            this.EnableWindowDrag(panelWindownControlTaskBar);
            this.EnableWindowControlButtons(
                minimizeButton: this.MinimizeWindowControlButton,
                maximizeButton: this.MaximizeWindowControlButton,
                closeButton: this.CloseWindowControlButton
                );
            SetUpNavigators();

            this.taskBarMore.Click += TaskBarMore_Click;
            this.userAvatar.Click += (sender, e) => OpenChildForm(profileForm, this.taskBarProfile);
        }

        private async void SetUpUI()
        {
            if (!string.IsNullOrEmpty(appDataProvider.User.Avatar))
            {
                try
                {
                    var imageUrl = appDataProvider.User.Avatar;
                    using (HttpClient httpClient = new HttpClient())
                    {
                        var imageBytes = await httpClient.GetByteArrayAsync(imageUrl);

                        using (var ms = new System.IO.MemoryStream(imageBytes))
                        {
                            userAvatar.Image = Image.FromStream(ms);
                        }
                    }
                }
                catch (Exception ex)
                {
                    userAvatar.Image = Properties.Resources.person;
                }
            }
            else
            {
                userAvatar.Image = Properties.Resources.person;
            }
        }

        private void TaskBarMore_Click(object sender, EventArgs e)
        {
            Form modal = new PostDetails
            {
                Width = this.Width - 400,
                Height = this.Height - 200,
                StartPosition = FormStartPosition.CenterScreen,
                ShowInTaskbar = false,
                TopMost = true
            };

            appDataProvider.ShowModal(this, modal);
        }

        public void ShowModalRequest(object sender, Form modal)
        {
            //ShowModal(modal = new PostDetails
            //{
            //    Width = this.Width - 400,
            //    Height = this.Height - 200,
            //    StartPosition = FormStartPosition.CenterScreen,
            //    ShowInTaskbar = false,
            //    TopMost = true
            //});
            this.modal = modal;
            ShowModal(modal);
        }

        private TransparentOverlayForm overlayForm;
        private Form modal;
        private void ShowModal(Form modal)
        {
            if (modal == null || modal.IsDisposed)
            {
                return;
            }

            ShowOverlayForm();

            //modal = new PostDetails
            //{
            //    Width = this.Width - 400,
            //    Height = this.Height - 200,
            //    StartPosition = FormStartPosition.CenterScreen,
            //    ShowInTaskbar = false,
            //    TopMost = true
            //};

            modal.FormClosed += (s, args) =>
            {
                this.Focus();
                this.TopMost = true;
                //overlayPanel.Visible = false;
                this.TopMost = false;

                HideOverlayForm();

                if (modal != null && !modal.IsDisposed)
                {
                    modal.Dispose();
                }

            };
            overlayForm.TopMost = false;
            modal.TopMost = false;
            modal.Show();
        }

        private void ShowOverlayForm()
        {
            if (overlayForm == null)
            {
                overlayForm = new TransparentOverlayForm();
                overlayForm.Size = this.ClientSize;
                overlayForm.Location = this.PointToScreen(Point.Empty);
                overlayForm.Click += OverlayForm_Click;
                overlayForm.Show();
            }
            else
            {
                overlayForm.Show();
            }
        }

        private void OverlayForm_Click(object sender, EventArgs e)
        {
            if (modal != null)
            {
                modal.Close();
                modal.Dispose();
            }
            HideOverlayForm();
        }

        private void HideOverlayForm()
        {
            if (overlayForm != null && !overlayForm.IsDisposed)
            {
                overlayForm.Close();
                overlayForm.Dispose();
                overlayForm = null;
            }
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            if (overlayForm != null && !overlayForm.IsDisposed)
            {
                overlayForm.TopMost = true;
                overlayForm.TopMost = false;
            }

            if (modal != null && !modal.IsDisposed)
            {
                modal.TopMost = true;
                modal.TopMost = false;
            }
        }

        private Panel overlayPanel;
        private void CreateOverlayPanel()
        {
            overlayPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(128, 0, 0, 0),
                Visible = false
            };
            this.Controls.Add(overlayPanel);
            overlayPanel.BringToFront();
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)  // Mã ASCII của phím ESC là 27
            {
                this.ActiveControl = null;  // Clear focus
                this.Focus();               // Đặt lại focus vào form (nếu cần)
            }
        }

        private void SetUpNavigators()
        {
            //this.taskBarHome.Click += (sender, e) => OpenChildForm(new HomeForm(), sender);
            //this.taskBarExplore.Click += (sender, e) => OpenChildForm(new ExploreForm(), sender);
            //this.taskBarMessages.Click += (sender, e) => OpenChildForm(new MessagesForm(), sender);
            //this.taskBarNotifications.Click += (sender, e) => OpenChildForm(new NotificationsForm(), sender);
            //this.taskBarProfile.Click += (sender, e) => OpenChildForm(new ProfileForm(), sender);
            //this.labelAppName.Click += (sender, e) => OpenChildForm(new HomeForm(), this.taskBarHome);
            //this.Load += (sender, e) => OpenChildForm(new HomeForm(), this.taskBarHome);

            this.taskBarHome.Click += (sender, e) => OpenChildForm(homeForm, sender);
            this.taskBarExplore.Click += (sender, e) => OpenChildForm(exploreForm, sender);
            this.taskBarMessages.Click += (sender, e) => OpenChildForm(messagesForm, sender);
            this.taskBarNotifications.Click += (sender, e) => OpenChildForm(notificationsForm, sender);
            this.taskBarProfile.Click += (sender, e) => OpenChildForm(profileForm, sender);
            this.labelAppName.Click += (sender, e) => OpenChildForm(homeForm, this.taskBarHome);
            this.Load += (sender, e) => OpenChildForm(homeForm, this.taskBarHome);
        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = Color.FromArgb(48, 48, 48);
                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in panelSideBarItems.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.Transparent;
                }
            }
        }
        private void OpenChildForm(Form childForm, object btnSender)
        {
            //if (activeForm != null)
            //{
            //    activeForm.Close();
            //}
            ActivateButton(btnSender);
            activeForm = childForm;

            if (childForm is ExploreForm)
            {
                ToggleMouseDownListener(true);
            }
            else
            {
                ToggleMouseDownListener(false);
            }

            //childForm.Tag = this.Tag;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        public void ToggleMouseDownListener(bool enable)
        {
            isListeningForMouseDown = enable;
            if (isListeningForMouseDown)
            {
                panelSideBar.MouseDown += MainForm_MouseDown;
                panelSideBarItems.MouseDown += MainForm_MouseDown;
                panelDesktop.MouseDown += MainForm_MouseDown;
                panelWindownControlTaskBar.MouseDown += MainForm_MouseDown;
            }
            else
            {
                panelSideBar.MouseDown -= MainForm_MouseDown;
                panelSideBarItems.MouseDown -= MainForm_MouseDown;
                panelDesktop.MouseDown -= MainForm_MouseDown;
                panelWindownControlTaskBar.MouseDown -= MainForm_MouseDown;
            }
        }

        // Phương thức xử lý sự kiện MouseDown để clear focus
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (activeForm is ExploreForm exploreForm)
            {
                if (!exploreForm.SearchBar().Bounds.Contains(e.Location))
                {
                    this.ActiveControl = null;
                    this.Focus();
                }
            }
        }
    }
}
