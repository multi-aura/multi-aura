using BLL;
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

namespace GUI.AuthenticationForms
{
    public partial class AuthenticationForm : Form
    {
        private Button currentButton;
        private Form activeForm;
        private AppDataProvider appDataProvider = AppDataProvider.Instance;
        public AuthenticationForm()
        {
            InitializeComponent();
            this.EnableWindowDrag(panelWindownControlTaskBar);
            this.EnableWindowResize();
            this.EnableWindowControlButtons(
                this.MinimizeWindowControlButton,
                this.MaximizeWindowControlButton,
                this.CloseWindowControlButton
                );
            appDataProvider.HasUser = false;
            this.FormClosed += AuthenticationForm_FormClosed;
            SetUpNavigators();
        }

        private void AuthenticationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!appDataProvider.HasUser)
            {
                this.Hide();
                WelcomeForm welcomeForm = new WelcomeForm();
                welcomeForm.ShowDialog();
            }
        }
        private void SetUpNavigators()
        {
            this.Load += (sender, e) => OpenChildForm(new LoginForm(OnGoToRegister));
        }
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
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

        private void OnGoToRegister(object sender, EventArgs e)
        {
            OpenChildForm(new RegisterForm(OnBackToLogin));
        }

        private void OnBackToLogin(object sender, EventArgs e)
        {
            OpenChildForm(new LoginForm(OnGoToRegister));
        }
    }
}
