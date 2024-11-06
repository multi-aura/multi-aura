using GUI.Extensions;
using GUI.Forms;
using GUI.AuthenticationForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace GUI
{
    public partial class MainForm : Form
    {
        private Button currentButton;
        private Form activeForm;
        private AppDataProvider appDataProvider = AppDataProvider.Instance;
        private bool isListeningForMouseDown = false;

        public MainForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            if (!appDataProvider.HasUser())
            {
                this.Hide();

                AuthenticationForm authenticationForm = new AuthenticationForm();
                authenticationForm.FormClosed += (s, args) =>
                {
                    if (appDataProvider.HasUser())
                    {
                        SetUpDefaultActions();

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
                SetUpDefaultActions();
            }
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
            this.taskBarHome.Click += (sender, e) => OpenChildForm(new HomeForm(), sender);
            this.taskBarExplore.Click += (sender, e) => OpenChildForm(new ExploreForm(), sender);
            this.taskBarMessages.Click += (sender, e) => OpenChildForm(new MessagesForm(), sender);
            this.taskBarNotifications.Click += (sender, e) => OpenChildForm(new NotificationsForm(), sender);
            this.taskBarProfile.Click += (sender, e) => OpenChildForm(new ProfileForm(), sender);
            this.labelAppName.Click += (sender, e) => OpenChildForm(new HomeForm(), this.taskBarHome);
            this.Load += (sender, e) => OpenChildForm(new HomeForm(), this.taskBarHome);
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
            if (activeForm != null)
            {
                activeForm.Close();
            }
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
