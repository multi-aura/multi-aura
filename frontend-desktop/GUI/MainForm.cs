using GUI.Extensions;
using GUI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class MainForm : Form
    {
        private Button currentButton;
        private Form activeForm;
        public MainForm()
        {
            InitializeComponent();
            this.EnableWindowDrag(panelWindownControlTaskBar);
            this.EnableWindowResize();
            this.EnableWindowControlButtons(
                this.MinimizeWindowControlButton,
                this.MaximizeWindowControlButton,
                this.CloseWindowControlButton
                );
            SetUPNavigators();
        }
        private void SetUPNavigators()
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
                    previousBtn.BackColor = Color.FromArgb(12, 12, 12);
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
            //childForm.Tag = this.Tag;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
    }
}
